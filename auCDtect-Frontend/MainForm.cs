using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;

namespace auCDtect_Frontend
{
    public partial class MainForm : Form 
    {
        private const string auCDtect = "auCDtect.exe";
        private const string programName = "auCDtect-Frontend";
        private const string programVersion = "1.0";
        private const string auCDtectPath = "tools/" + auCDtect; 

        public MainForm()
        {
            InitializeComponent();
            this.Text = programName;
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            bool isFileExist = File.Exists(auCDtectPath);
            if (!isFileExist)
            {
                string title = $"{auCDtect} not found";
                string message = $"{auCDtect} is not found, {programName} can't be used without it. Please place auCDtect.exe in tools directory";
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
            if (extension == ".wav")
            {               
                lbxFiles.Items.Add(fullFileName);
            }
        }

        private void btnAboutClick(object sender, EventArgs e)
        {
            string title = $"{programName} version info";
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
                EnableControls(false);
                backgroundWorker.RunWorkerAsync();
            }
            else // btnStart.Text == "Stop"
            {
                backgroundWorker.CancelAsync();
            }
        }

        private void EnableControls(bool enable)
        {
            btnAddFiles.Enabled = enable;
            btnRemoveFile.Enabled = enable;
            btnClearList.Enabled = enable;
            btnHelp.Enabled = enable;
            btnAbout.Enabled = enable;
            btnExit.Enabled = enable;
            nudDetectMode.Enabled = enable;

            btnStart.Text = enable ? "Start" : "Stop"; ;
        }

        private void ApendResultToOutput(string fileName, AnalyzeResult result)
        {
            if (result.Error)
            {
                AppendColorTextToOutput(fileName + " => Error: " + result.ErrorMessage + Environment.NewLine, Color.Red);
            }
            else // result.Error == false
            {
                Color color = SelectColorForAudioFormat(result.AudioFormat);
                string outputText = string.Empty;
              
                switch (result.AudioFormat)
                {
                    case "CDDA":
                    case "MPEG":
                        outputText = fileName + " => " + result.AudioFormat + " [" + result.PercentOfConfidence + "]" + Environment.NewLine;
                        break;
                    case "UNKN":
                        outputText = fileName + " => Unknown source" + Environment.NewLine;
                        break;
                    default:
                        outputText = fileName + " => " + result.AudioFormat + Environment.NewLine;
                        break;
                }
                AppendColorTextToOutput(outputText, color);
            }
        }

        private static Color SelectColorForAudioFormat(string audioFormat)
        {
            Color color;

            switch (audioFormat)
            {                          
                case "CDDA":
                    color = Color.Green;
                    break;
                case "MPEG":
                    color = Color.Red;
                    break;
                case "UNKN":
                    color = Color.Blue;
                    break;
                default:
                    color = Color.Black;
                    break;
            }

            return color;
        }

        private void AppendColorTextToOutput(string text, Color color)
        {
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
                    result = ParseProcessOutput(processOutput);      
                }
                else // process.ExitCode != 0  => Process ends with error
                {
                    result = ParseProcessErrorOutput(processOutput);
                }

                process.Close();
            }

            return result;
        }

        private static AnalyzeResult ParseProcessErrorOutput(string processOutput)
        {
            const string keyword = "error:";
            int startIndex;
            AnalyzeResult result = new AnalyzeResult();

            if (processOutput.Contains(keyword))
            {
                startIndex = processOutput.IndexOf(keyword) + keyword.Length + 1;
                result.ErrorMessage = processOutput.Substring(startIndex).TrimEnd();
            }
            else
            {
                result.ErrorMessage = $"Parsing {auCDtect} output error";
            }               
            return result;
        }

        private static AnalyzeResult ParseProcessOutput(string processOutput)
        {   
            const string unknSourceString = "Could not qualify the source of this track";
            Regex regExprOutput = new Regex(@"This track looks like CDDA|MPEG with probability \d{1,3}%");

            AnalyzeResult result = new AnalyzeResult();

            if (regExprOutput.IsMatch(processOutput))
            {
                result.AudioFormat = GetAudioFormatFromOutput(processOutput);
                result.PercentOfConfidence = GetPercentOfConfidenceFromOutput(processOutput);
            }
            else if (processOutput.Contains(unknSourceString))
            {
                result.AudioFormat = "UNKN";
            }
            else
            {
                result.ErrorMessage = $"Parsing {auCDtect} output error";
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
            string fullFileName, fileName;
            int count = lbxFiles.Items.Count;
            int detectMode = (int)nudDetectMode.Value;
            AnalyzeResult result;
            string userState = null;
                                    
            for (int i = 0; i < count; i++)
            {
                userState = $"{i+1}/{count}";

                // Raises backgroundWorkerProgressChanged Event
                backgroundWorker.ReportProgress((i*100)/count, userState);

                fullFileName = (string)lbxFiles.Items[i];
                result = AnalyzeFile(detectMode, fullFileName);
                fileName = Path.GetFileName(fullFileName);

                ApendResultToOutput(fileName, result);         
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

            EnableControls(true);
            this.Text = programName + " - " + status;
        }
    }
}

