
namespace auCDtect_Frontend
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.addFiles = new System.Windows.Forms.Button();
            this.removeFile = new System.Windows.Forms.Button();
            this.clearList = new System.Windows.Forms.Button();
            this.fileList = new System.Windows.Forms.ListBox();
            this.detectModeLabel = new System.Windows.Forms.Label();
            this.detectMode = new System.Windows.Forms.NumericUpDown();
            this.start = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.RichTextBox();
            this.help = new System.Windows.Forms.Button();
            this.about = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.detectMode)).BeginInit();
            this.SuspendLayout();
            // 
            // addFiles
            // 
            this.addFiles.Location = new System.Drawing.Point(9, 6);
            this.addFiles.Name = "addFiles";
            this.addFiles.Size = new System.Drawing.Size(75, 23);
            this.addFiles.TabIndex = 0;
            this.addFiles.Text = "Add files";
            this.toolTip.SetToolTip(this.addFiles, "Add files for analysis");
            this.addFiles.UseVisualStyleBackColor = true;
            this.addFiles.Click += new System.EventHandler(this.AddFilesClick);
            // 
            // removeFile
            // 
            this.removeFile.Location = new System.Drawing.Point(90, 6);
            this.removeFile.Name = "removeFile";
            this.removeFile.Size = new System.Drawing.Size(75, 23);
            this.removeFile.TabIndex = 1;
            this.removeFile.Text = "Remove file";
            this.toolTip.SetToolTip(this.removeFile, "Remove selected files from the list");
            this.removeFile.UseVisualStyleBackColor = true;
            this.removeFile.Click += new System.EventHandler(this.RemoveFileClick);
            // 
            // clearList
            // 
            this.clearList.Location = new System.Drawing.Point(171, 6);
            this.clearList.Name = "clearList";
            this.clearList.Size = new System.Drawing.Size(75, 23);
            this.clearList.TabIndex = 2;
            this.clearList.Text = "Clear filelist";
            this.toolTip.SetToolTip(this.clearList, "Clear the list of files");
            this.clearList.UseVisualStyleBackColor = true;
            this.clearList.Click += new System.EventHandler(this.ClearListClick);
            // 
            // FileList
            // 
            this.fileList.FormattingEnabled = true;
            this.fileList.HorizontalScrollbar = true;
            this.fileList.Location = new System.Drawing.Point(9, 35);
            this.fileList.Name = "fileList";
            this.fileList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.fileList.Size = new System.Drawing.Size(462, 186);
            this.fileList.TabIndex = 3;
            this.toolTip.SetToolTip(this.fileList, "Files for analysis");
            // 
            // detectModeLabel
            // 
            this.detectModeLabel.AutoSize = true;
            this.detectModeLabel.Location = new System.Drawing.Point(6, 231);
            this.detectModeLabel.Name = "DetectModeLabel";
            this.detectModeLabel.Size = new System.Drawing.Size(71, 13);
            this.detectModeLabel.TabIndex = 4;
            this.detectModeLabel.Text = "Detect mode:";
            this.detectModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DetectMode
            // 
            this.detectMode.Location = new System.Drawing.Point(79, 229);
            this.detectMode.Maximum = new decimal(new int[] { 40, 0, 0, 0 });
            this.detectMode.Name = "DetectMode";
            this.detectMode.Size = new System.Drawing.Size(55, 20);
            this.detectMode.TabIndex = 5;
            this.toolTip.SetToolTip(this.detectMode, "0 - slow and most accurate\n40 - fast, but less accurate");
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(140, 228);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 6;
            this.start.Text = "Start";
            this.toolTip.SetToolTip(this.start, "Starts/Stops the file analysis process");
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.StartClick);
            // 
            // output
            // 
            this.output.CausesValidation = false;
            this.output.Location = new System.Drawing.Point(9, 255);
            this.output.Name = "Output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(465, 128);
            this.output.TabIndex = 7;
            this.output.Text = "";
            this.toolTip.SetToolTip(this.output, "The results of the analysis");
            this.output.WordWrap = false;
            // 
            // help
            // 
            this.help.Location = new System.Drawing.Point(9, 389);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(75, 23);
            this.help.TabIndex = 8;
            this.help.Text = "Help";
            this.toolTip.SetToolTip(this.help, "Display help information");
            this.help.UseVisualStyleBackColor = true;
            this.help.Click += new System.EventHandler(this.HelpClick);
            // 
            // about
            // 
            this.about.Location = new System.Drawing.Point(90, 389);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(75, 23);
            this.about.TabIndex = 9;
            this.about.Text = "About";
            this.toolTip.SetToolTip(this.about, "Display information about program");
            this.about.UseVisualStyleBackColor = true;
            this.about.Click += new System.EventHandler(this.AboutClick);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(399, 389);
            this.exit.Name = "Exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 10;
            this.exit.Text = "Exit";
            this.toolTip.SetToolTip(this.exit, "Exit program");
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.ExitClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "wav";
            this.openFileDialog.Filter = "Music files (*.wav)|*.wav";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.ReadOnlyChecked = true;
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.ShowReadOnly = true;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerDoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorkerProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerRunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 418);
            this.Controls.Add(this.addFiles);
            this.Controls.Add(this.removeFile);
            this.Controls.Add(this.clearList);
            this.Controls.Add(this.fileList);
            this.Controls.Add(this.detectModeLabel);
            this.Controls.Add(this.detectMode);
            this.Controls.Add(this.start);
            this.Controls.Add(this.output);
            this.Controls.Add(this.help);
            this.Controls.Add(this.about);
            this.Controls.Add(this.exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "auCDtect-Frontend";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FilesDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FilesDragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.detectMode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Button addFiles;
        private System.Windows.Forms.Button removeFile;
        private System.Windows.Forms.Button clearList;
        private System.Windows.Forms.ListBox fileList;
        private System.Windows.Forms.Label detectModeLabel;
        private System.Windows.Forms.NumericUpDown detectMode;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Button about;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolTip toolTip;
        private System.ComponentModel.BackgroundWorker backgroundWorker;

    }
}

