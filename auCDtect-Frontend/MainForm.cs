using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;
using System.Linq;

namespace auCDtect_Frontend
{
    public partial class MainForm : Form 
    {
        private const string auCDtect = "auCDtect.exe";
        private const string programName = "auCDtect-Frontend";
        private const string programVersion = "1.0";
        private const string auCDtectPath = "tools/" + auCDtect;
        private static readonly string[] supportedExtensionFiles = { ".wav" };
        
        public MainForm()
        {
            InitializeComponent();
            this.Text = programName;
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            bool fileExist = File.Exists(auCDtectPath);
            if (!fileExist)
            {
                string title = $"{auCDtect} not found";
                string message = $"{auCDtect} is not found, {programName} can't be used without it. Please place {auCDtect} in tools directory";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void btnAddFilesClick(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in openFileDialog.FileNames)
                {
                    AddFileToList(file);
                }
            }
        }

        private void btnExitClick(object sender, EventArgs e)
        {
            Close();
        }

        private void lbxFilesDragDrop(object sender, DragEventArgs e)
        {
            string[] fileDropList = (string[]) e.Data.GetData(DataFormats.FileDrop);
          
            foreach (string fileDropItem in fileDropList)
            {
                // Check whether dropped item is directory
                if (Directory.Exists(fileDropItem))
                {
                     //find all files in that directory
                     foreach(string fileDropDirItem in Directory.GetFiles(fileDropItem, "*.*", SearchOption.AllDirectories))
                     {
                        AddFileToList(fileDropDirItem);   
                     }
                }
                else 
                {
                    AddFileToList(fileDropItem);                   
                }
            }
        }
        
        private void lbxFilesDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
		

        private void AddFileToList(string fullFileName)
        {
            string extension = Path.GetExtension(fullFileName);
            bool extentionSupported = supportedExtensionFiles.Contains(extension);

            if (extentionSupported)
            {               
                lbxFiles.Items.Add(fullFileName);
            }
        }

        private void btnAboutClick(object sender, EventArgs e)
        {
            string title = $"{programName} version information";
            string message = $"{programName} v{programVersion}, using {auCDtect} 0.8.2";
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHelpClick(object sender, EventArgs e)
        {
            string title = $"{programName} Help";
            string message = "Place your mouse pointer over a control to get more information";
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRemoveFileClick(object sender, EventArgs e)
        {
            /*
            for (int i = lstbxFiles.SelectedItems.Count - 1; i > -1; i--)
            {
                lstbxFiles.Items.Remove(lstbxFiles.SelectedItems[i]);
            }
            */
            while (lbxFiles.SelectedItems.Count > 0)
            {
                lbxFiles.Items.Remove(lbxFiles.SelectedItems[0]);
            }
        }

        private void btnClearListClick(object sender, EventArgs e)
        {
            lbxFiles.Items.Clear();
        }

        private void btnStartClick(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start")
            {
                rtbOutput.Clear();
                DisableControls();
                backgroundWorker.RunWorkerAsync();
            }
            else // btnStart.Text == "Stop"
            {
                backgroundWorker.CancelAsync();
            }
        }

        private void EnableControls()
        {
            btnAddFiles.Enabled = true;
            btnRemoveFile.Enabled = true;
            btnClearList.Enabled = true;
            btnHelp.Enabled = true;
            btnAbout.Enabled = true;
            btnExit.Enabled = true;
            nudDetectMode.Enabled = true;
            btnStart.Text = "Start";
        }

        private void DisableControls()
        {
            btnAddFiles.Enabled = false;
            btnRemoveFile.Enabled = false;
            btnClearList.Enabled = false;
            btnHelp.Enabled = false;
            btnAbout.Enabled = false;
            btnExit.Enabled = false;
            nudDetectMode.Enabled = false;
            btnStart.Text = "Stop";
        }

        private void ApendResultToOutput(AnalyzeResult result)
        {
            string text = result.FormatResult();
            Color color = result.TextColor;
            /* 
             Must be like below because: 
             System.InvalidOperationException: 'Invalid cross-thread operation: The control 
             is being accessed from a thread other than the thread on which it was created.'
             Call BeginInvoke method here below is required
            */
            rtbOutput.SuspendLayout();
            Action action = () => {
                rtbOutput.SelectionColor = color;
                rtbOutput.AppendText(text);
                rtbOutput.ScrollToCaret();
            };
            this.BeginInvoke(action);  
            rtbOutput.ResumeLayout();   
        }

        private static AnalyzeResult AnalyzeFile(int detectMode, string fileName)
        {
            AnalyzeResult result = null;

            using (Process process = new Process())
            {
                process.StartInfo.FileName = auCDtectPath;
                process.StartInfo.Arguments = $"-m{detectMode} \"{fileName}\"";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                process.WaitForExit();
                
                string processOutput = process.StandardOutput.ReadToEnd();
             
                // Process ends OK
                if (process.ExitCode == 0)
                {
                    result = ParseProcessOkOutput(processOutput, fileName);      
                }
                else // process.ExitCode != 0  => Process ends with error
                {
                    result = ParseProcessErrorOutput(processOutput, fileName);
                }

                process.Close();
            }

            return result;
        }

        private static AnalyzeResult ParseProcessErrorOutput(string processOutput, string fileName)
        {
            const string keyword = "error:";
            int startIndex;
            AnalyzeResult result;
            string file = Path.GetFileName(fileName);
            string errorMessage;

            if (processOutput.Contains(keyword))
            {
                startIndex = processOutput.IndexOf(keyword) + keyword.Length + 1;
                errorMessage = processOutput.Substring(startIndex).TrimEnd();
            }
            else
            {
                errorMessage = $"Parsing {auCDtect} output error"; 
            }
            result = new ResultError(file, errorMessage); 

            return result;
        }

        private static AnalyzeResult ParseProcessOkOutput(string processOutput, string fileName)
        {   
            const string unknSourceString = "Could not qualify the source of this track";
            Regex regExprOutput = new Regex(@"This track looks like CDDA|MPEG with probability [0-9]{1,3}%");

            AnalyzeResult result;
            string file = Path.GetFileName(fileName);

            if (regExprOutput.IsMatch(processOutput))
            {
                string confidence = GetPercentOfConfidenceFromOutput(processOutput);
                string audioFormat = GetAudioFormatFromOutput(processOutput);

                if (audioFormat == "CDDA")
                {
                    result = new ResultCDDA(file, confidence);
                }
                else // audioFormat == "MPEG"
                {
                    result = new ResultMPEG(file, confidence);
                } 
            }
            else if (processOutput.Contains(unknSourceString))
            {
                result = new ResultUnknown(file);
            }
            else
            {
                result = new ResultError(file, $"Parsing {auCDtect} output error");
            }

            return result;
        }

        private static string GetAudioFormatFromOutput(string processOutput)
        {
            int startIndex, length;
            const string keywordStart = "This track looks like";
            const string keywordEnd = "with";
            
            startIndex = processOutput.IndexOf(keywordStart) + keywordStart.Length + 1;
            length = processOutput.IndexOf(keywordEnd, startIndex) - startIndex - 1;

            return processOutput.Substring(startIndex, length);
        }

        private static string GetPercentOfConfidenceFromOutput(string processOutput)
        {
            int startIndex, length;
            const string keywordStart = "probability";
            const string keywordEnd = "%";

            startIndex = processOutput.IndexOf(keywordStart) + keywordStart.Length + 1;
            length = processOutput.IndexOf(keywordEnd, startIndex) - startIndex + 1;

            return processOutput.Substring(startIndex, length);
        }

        private void BackgroundOperation()
        {
            string fullFileName;
            int count = lbxFiles.Items.Count;
            int detectMode = (int)nudDetectMode.Value;
            AnalyzeResult result;
            string userState;
                                    
            for (int i = 0; i < count; i++)
            {
                userState = $"{i+1}/{count}";

                // Raises backgroundWorkerProgressChanged Event
                backgroundWorker.ReportProgress((i*100)/count, userState);

                fullFileName = (string)lbxFiles.Items[i];
                result = AnalyzeFile(detectMode, fullFileName);

                ApendResultToOutput(result);         
            }
        }

        private void backgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            Thread childThread = new Thread(new ThreadStart(BackgroundOperation));
            childThread.Start();

            while (childThread.IsAlive)
            {
                if (backgroundWorker.CancellationPending)
                {
                    childThread.Abort();
                    e.Cancel = true;
                    break;
                }
                Thread.SpinWait(1);
            }

        }

        private void backgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string title = $"{programName} - Analyzing {e.UserState} : [{e.ProgressPercentage}%]";
            this.Text = title;
        }

        private void backgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string status;
            
            if (e.Cancelled)
            {
                status = "Cancelled";
            }
            else if (e.Error != null)
            {
                status = "Error";
            }
            else
            {
                status = "Done";
            }

            EnableControls();
            this.Text = programName + " - " + status;
        }
    }
}

