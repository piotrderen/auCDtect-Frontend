
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
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.btnRemoveFile = new System.Windows.Forms.Button();
            this.btnClearList = new System.Windows.Forms.Button();
            this.lbxFiles = new System.Windows.Forms.ListBox();
            this.lblDetectMode = new System.Windows.Forms.Label();
            this.nudDetectMode = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.nudDetectMode)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Location = new System.Drawing.Point(9, 6);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(75, 23);
            this.btnAddFiles.TabIndex = 0;
            this.btnAddFiles.Text = "Add files";
            this.toolTip.SetToolTip(this.btnAddFiles, "Add files for analysis");
            this.btnAddFiles.UseVisualStyleBackColor = true;
            this.btnAddFiles.Click += new System.EventHandler(this.btnAddFilesClick);
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.Location = new System.Drawing.Point(90, 6);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveFile.TabIndex = 1;
            this.btnRemoveFile.Text = "Remove file";
            this.toolTip.SetToolTip(this.btnRemoveFile, "Remove selected files from the list");
            this.btnRemoveFile.UseVisualStyleBackColor = true;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFileClick);
            // 
            // btnClearList
            // 
            this.btnClearList.Location = new System.Drawing.Point(171, 6);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(75, 23);
            this.btnClearList.TabIndex = 2;
            this.btnClearList.Text = "Clear filelist";
            this.toolTip.SetToolTip(this.btnClearList, "Clear the list of files");
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearListClick);
            // 
            // lbxFiles
            // 
            this.lbxFiles.FormattingEnabled = true;
            this.lbxFiles.HorizontalScrollbar = true;
            this.lbxFiles.Location = new System.Drawing.Point(9, 35);
            this.lbxFiles.Name = "lbxFiles";
            this.lbxFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxFiles.Size = new System.Drawing.Size(462, 186);
            this.lbxFiles.TabIndex = 3;
            this.toolTip.SetToolTip(this.lbxFiles, "Files for analysis");
            // 
            // lblDetectMode
            // 
            this.lblDetectMode.AutoSize = true;
            this.lblDetectMode.Location = new System.Drawing.Point(6, 231);
            this.lblDetectMode.Name = "lblDetectMode";
            this.lblDetectMode.Size = new System.Drawing.Size(71, 13);
            this.lblDetectMode.TabIndex = 4;
            this.lblDetectMode.Text = "Detect mode:";
            this.lblDetectMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudDetectMode
            // 
            this.nudDetectMode.Location = new System.Drawing.Point(79, 229);
            this.nudDetectMode.Maximum = new decimal(new int[] { 40, 0, 0, 0 });
            this.nudDetectMode.Name = "nudDetectMode";
            this.nudDetectMode.Size = new System.Drawing.Size(55, 20);
            this.nudDetectMode.TabIndex = 5;
            this.toolTip.SetToolTip(this.nudDetectMode, "0 - slow and most accurate\n40 - fast, but less accurate");
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(140, 228);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.toolTip.SetToolTip(this.btnStart, "Starts/Stops the file analysis process");
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStartClick);
            // 
            // rtbOutput
            // 
            this.rtbOutput.CausesValidation = false;
            this.rtbOutput.Location = new System.Drawing.Point(9, 255);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.ReadOnly = true;
            this.rtbOutput.Size = new System.Drawing.Size(465, 128);
            this.rtbOutput.TabIndex = 7;
            this.rtbOutput.Text = "";
            this.toolTip.SetToolTip(this.rtbOutput, "The results of the analysis");
            this.rtbOutput.WordWrap = false;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(9, 389);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.Text = "Help";
            this.toolTip.SetToolTip(this.btnHelp, "Display help information");
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelpClick);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(90, 389);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 9;
            this.btnAbout.Text = "About";
            this.toolTip.SetToolTip(this.btnAbout, "Display information about program");
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAboutClick);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(399, 389);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.toolTip.SetToolTip(this.btnExit, "Exit program");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExitClick);
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
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerRunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 418);
            this.Controls.Add(this.btnAddFiles);
            this.Controls.Add(this.btnRemoveFile);
            this.Controls.Add(this.btnClearList);
            this.Controls.Add(this.lbxFiles);
            this.Controls.Add(this.lblDetectMode);
            this.Controls.Add(this.nudDetectMode);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "auCDtect-Fronted";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbxFilesDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbxFilesDragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.nudDetectMode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.Button btnRemoveFile;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.ListBox lbxFiles;
        private System.Windows.Forms.Label lblDetectMode;
        private System.Windows.Forms.NumericUpDown nudDetectMode;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolTip toolTip;
        private System.ComponentModel.BackgroundWorker backgroundWorker;

    }
}

