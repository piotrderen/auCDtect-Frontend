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
            openFileDialog.Filter = BuildOpenFileDialogFilter();
        }

        private static string BuildOpenFileDialogFilter()
        {
            string retVal = string.Empty;
            retVal = "Music files (";
            string extensionString = SuportedExtensionsString();
            retVal += extensionString;
            retVal += ")|";
            retVal += extensionString;
            retVal += "|";
            retVal += "All files(*.*)|*.*";

            return retVal;
        }
        private static string SuportedExtensionsString()
        {
            int length = supportedExtensionFiles.Length;
            string retVal = string.Empty;

            for (int i = 0; i < length; ++i)
            {
                retVal += $"*{supportedExtensionFiles[i]}";

                if (i < length - 1)
                {
                    retVal += ";";
                }
            }
            return retVal;
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

        private void AddFilesClick(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in openFileDialog.FileNames)
                {
                    AddFileToList(file);
                }
            }
        }

        private void ExitClick(object sender, EventArgs e)
        {
            Close();
        }

        private void FilesDragDrop(object sender, DragEventArgs e)
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
        
        private void FilesDragEnter(object sender, DragEventArgs e)
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
                FileList.Items.Add(fullFileName);
            }
        }

        private void AboutClick(object sender, EventArgs e)
        {
            string title = $"{programName} version information";
            string message = $"{programName} ver {programVersion}, using {auCDtect} 0.8.2";
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void HelpClick(object sender, EventArgs e)
        {
            string title = $"{programName} Help";
            string message = "Place your mouse pointer over a control to get more information";
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RemoveFileClick(object sender, EventArgs e)
        {
            /*
            for (int i = lstbxFiles.SelectedItems.Count - 1; i > -1; i--)
            {
                lstbxFiles.Items.Remove(lstbxFiles.SelectedItems[i]);
            }
            */
            while (FileList.SelectedItems.Count > 0)
            {
                FileList.Items.Remove(FileList.SelectedItems[0]);
            }
        }

        private void ClearListClick(object sender, EventArgs e)
        {
            FileList.Items.Clear();
        }

        private void StartClick(object sender, EventArgs e)
        {
            if (Start.Text == "Start")
            {
                Output.Clear();
                SetEnabledControls(false);
                Start.Text = "Stop";
                backgroundWorker.RunWorkerAsync();
            }
            else // Start.Text == "Stop"
            {
                backgroundWorker.CancelAsync();
            }
        }

        private void SetEnabledControls(bool enabled)
        {
            AddFiles.Enabled = enabled;
            RemoveFile.Enabled = enabled;
            ClearList.Enabled = enabled;
            Help.Enabled = enabled;
            About.Enabled = enabled;
            Exit.Enabled = enabled;
            DetectMode.Enabled = enabled;
            Output.Enabled = enabled;
        }

        private void ApendResultToOutput(AnalyzeResult result)
        {
            string text = result.FormatResult();
            Color color = result.TextColor;

            Output.SuspendLayout();
            Action action = () => {
                Output.SelectionColor = color;
                Output.AppendText(text);
                Output.ScrollToCaret();
            };
            this.BeginInvoke(action);  
            Output.ResumeLayout();   
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
                    result = ParseProcessOkOutput(fileName, processOutput);      
                }
                else // process.ExitCode != 0  => Process ends with error
                {
                    result = ParseProcessErrorOutput(fileName, processOutput);
                }

                process.Close();
            }

            return result;
        }

     
        private static AnalyzeResult ParseProcessOkOutput(string fileName, string processOutput)
        {   
            const string unknownSourceString = "Could not qualify the source of this track";
            Regex regExprOutput = new Regex(@"This track looks like CDDA|MPEG with probability [0-9]{1,3}%");

            AnalyzeResult result;
            string file = Path.GetFileName(fileName);

            if (regExprOutput.IsMatch(processOutput))
            {
                string confidence = GetPercentOfConfidence(processOutput);
                string audioFormat = GetAudioFormat(processOutput);

                if (audioFormat == "CDDA")
                {
                    result = new ResultCDDA(file, confidence);
                }
                else // audioFormat == "MPEG"
                {
                    result = new ResultMPEG(file, confidence);
                } 
            }
            else if (processOutput.Contains(unknownSourceString))
            {
                result = new ResultUnknown(file);
            }
            else
            {
                result = new ResultError(file, $"Parsing {auCDtect} output error");
            }

            return result;
        }

        private static AnalyzeResult ParseProcessErrorOutput(string fileName, string processOutput)
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


        private static string GetAudioFormat(string processOutput)
        {
            int startIndex, length;
            const string keywordStart = "This track looks like";
            const string keywordEnd = "with";
            
            startIndex = processOutput.IndexOf(keywordStart) + keywordStart.Length + 1;
            length = processOutput.IndexOf(keywordEnd, startIndex) - startIndex - 1;

            return processOutput.Substring(startIndex, length);
        }

        private static string GetPercentOfConfidence(string processOutput)
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
            int count = FileList.Items.Count;
            int detectMode = (int)DetectMode.Value;
            AnalyzeResult result;
            string userState;
                                    
            for (int i = 0; i < count; i++)
            {
                userState = $"{i+1}/{count}";

                // Raises backgroundWorkerProgressChanged Event
                backgroundWorker.ReportProgress((i*100)/count, userState);

                fullFileName = (string)FileList.Items[i];
                result = AnalyzeFile(detectMode, fullFileName);

                ApendResultToOutput(result);         
            }
        }

        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
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

        private void BackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string title = $"{programName} - Analyzing {e.UserState} : [{e.ProgressPercentage}%]";
            this.Text = title;
        }

        private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            SetEnabledControls(true);
            Start.Text = "Start";

            this.Text = programName + " - " + status;
        }
    }
}

