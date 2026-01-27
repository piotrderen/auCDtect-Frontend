
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
            this.AddFiles = new System.Windows.Forms.Button();
            this.RemoveFile = new System.Windows.Forms.Button();
            this.ClearList = new System.Windows.Forms.Button();
            this.FileList = new System.Windows.Forms.ListBox();
            this.DetectModeLabel = new System.Windows.Forms.Label();
            this.DetectMode = new System.Windows.Forms.NumericUpDown();
            this.Start = new System.Windows.Forms.Button();
            this.Output = new System.Windows.Forms.RichTextBox();
            this.Help = new System.Windows.Forms.Button();
            this.About = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.DetectMode)).BeginInit();
            this.SuspendLayout();
            // 
            // AddFiles
            // 
            this.AddFiles.Location = new System.Drawing.Point(9, 6);
            this.AddFiles.Name = "AddFiles";
            this.AddFiles.Size = new System.Drawing.Size(75, 23);
            this.AddFiles.TabIndex = 0;
            this.AddFiles.Text = "Add files";
            this.toolTip.SetToolTip(this.AddFiles, "Add files for analysis");
            this.AddFiles.UseVisualStyleBackColor = true;
            this.AddFiles.Click += new System.EventHandler(this.AddFilesClick);
            // 
            // RemoveFile
            // 
            this.RemoveFile.Location = new System.Drawing.Point(90, 6);
            this.RemoveFile.Name = "RemoveFile";
            this.RemoveFile.Size = new System.Drawing.Size(75, 23);
            this.RemoveFile.TabIndex = 1;
            this.RemoveFile.Text = "Remove file";
            this.toolTip.SetToolTip(this.RemoveFile, "Remove selected files from the list");
            this.RemoveFile.UseVisualStyleBackColor = true;
            this.RemoveFile.Click += new System.EventHandler(this.RemoveFileClick);
            // 
            // ClearList
            // 
            this.ClearList.Location = new System.Drawing.Point(171, 6);
            this.ClearList.Name = "ClearList";
            this.ClearList.Size = new System.Drawing.Size(75, 23);
            this.ClearList.TabIndex = 2;
            this.ClearList.Text = "Clear filelist";
            this.toolTip.SetToolTip(this.ClearList, "Clear the list of files");
            this.ClearList.UseVisualStyleBackColor = true;
            this.ClearList.Click += new System.EventHandler(this.ClearListClick);
            // 
            // FileList
            // 
            this.FileList.FormattingEnabled = true;
            this.FileList.HorizontalScrollbar = true;
            this.FileList.Location = new System.Drawing.Point(9, 35);
            this.FileList.Name = "FileList";
            this.FileList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.FileList.Size = new System.Drawing.Size(462, 186);
            this.FileList.TabIndex = 3;
            this.toolTip.SetToolTip(this.FileList, "Files for analysis");
            // 
            // DetectModeLabel
            // 
            this.DetectModeLabel.AutoSize = true;
            this.DetectModeLabel.Location = new System.Drawing.Point(6, 231);
            this.DetectModeLabel.Name = "DetectModeLabel";
            this.DetectModeLabel.Size = new System.Drawing.Size(71, 13);
            this.DetectModeLabel.TabIndex = 4;
            this.DetectModeLabel.Text = "Detect mode:";
            this.DetectModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DetectMode
            // 
            this.DetectMode.Location = new System.Drawing.Point(79, 229);
            this.DetectMode.Maximum = new decimal(new int[] { 40, 0, 0, 0 });
            this.DetectMode.Name = "DetectMode";
            this.DetectMode.Size = new System.Drawing.Size(55, 20);
            this.DetectMode.TabIndex = 5;
            this.toolTip.SetToolTip(this.DetectMode, "0 - slow and most accurate\n40 - fast, but less accurate");
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(140, 228);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 6;
            this.Start.Text = "Start";
            this.toolTip.SetToolTip(this.Start, "Starts/Stops the file analysis process");
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.StartClick);
            // 
            // Output
            // 
            this.Output.CausesValidation = false;
            this.Output.Location = new System.Drawing.Point(9, 255);
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.Size = new System.Drawing.Size(465, 128);
            this.Output.TabIndex = 7;
            this.Output.Text = "";
            this.toolTip.SetToolTip(this.Output, "The results of the analysis");
            this.Output.WordWrap = false;
            // 
            // Help
            // 
            this.Help.Location = new System.Drawing.Point(9, 389);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(75, 23);
            this.Help.TabIndex = 8;
            this.Help.Text = "Help";
            this.toolTip.SetToolTip(this.Help, "Display help information");
            this.Help.UseVisualStyleBackColor = true;
            this.Help.Click += new System.EventHandler(this.HelpClick);
            // 
            // About
            // 
            this.About.Location = new System.Drawing.Point(90, 389);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(75, 23);
            this.About.TabIndex = 9;
            this.About.Text = "About";
            this.toolTip.SetToolTip(this.About, "Display information about program");
            this.About.UseVisualStyleBackColor = true;
            this.About.Click += new System.EventHandler(this.AboutClick);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(399, 389);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 10;
            this.Exit.Text = "Exit";
            this.toolTip.SetToolTip(this.Exit, "Exit program");
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.ExitClick);
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
            this.Controls.Add(this.AddFiles);
            this.Controls.Add(this.RemoveFile);
            this.Controls.Add(this.ClearList);
            this.Controls.Add(this.FileList);
            this.Controls.Add(this.DetectModeLabel);
            this.Controls.Add(this.DetectMode);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.About);
            this.Controls.Add(this.Exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "auCDtect-Frontend";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FilesDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FilesDragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.DetectMode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Button AddFiles;
        private System.Windows.Forms.Button RemoveFile;
        private System.Windows.Forms.Button ClearList;
        private System.Windows.Forms.ListBox FileList;
        private System.Windows.Forms.Label DetectModeLabel;
        private System.Windows.Forms.NumericUpDown DetectMode;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.RichTextBox Output;
        private System.Windows.Forms.Button Help;
        private System.Windows.Forms.Button About;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolTip toolTip;
        private System.ComponentModel.BackgroundWorker backgroundWorker;

    }
}

