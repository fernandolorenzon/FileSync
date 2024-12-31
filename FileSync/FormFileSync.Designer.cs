namespace FileSync
{
    partial class FormFileSync
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            buttonSource = new Button();
            textBoxSource = new TextBox();
            textBoxTarget = new TextBox();
            buttonTarget = new Button();
            label2 = new Label();
            listBoxAdd = new ListBox();
            buttonScan = new Button();
            listBoxUpdate = new ListBox();
            listBoxDelete = new ListBox();
            progressBar1 = new ProgressBar();
            buttonSync = new Button();
            labelStatus = new Label();
            labelAdd = new Label();
            labelModify = new Label();
            labelDelete = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 32);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Source";
            // 
            // buttonSource
            // 
            buttonSource.Location = new Point(306, 70);
            buttonSource.Name = "buttonSource";
            buttonSource.Size = new Size(38, 23);
            buttonSource.TabIndex = 1;
            buttonSource.Text = "...";
            buttonSource.UseVisualStyleBackColor = true;
            buttonSource.Click += buttonSource_Click;
            // 
            // textBoxSource
            // 
            textBoxSource.Location = new Point(10, 70);
            textBoxSource.Name = "textBoxSource";
            textBoxSource.Size = new Size(290, 23);
            textBoxSource.TabIndex = 2;
            // 
            // textBoxTarget
            // 
            textBoxTarget.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxTarget.Location = new Point(450, 70);
            textBoxTarget.Name = "textBoxTarget";
            textBoxTarget.Size = new Size(290, 23);
            textBoxTarget.TabIndex = 5;
            // 
            // buttonTarget
            // 
            buttonTarget.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonTarget.Location = new Point(746, 69);
            buttonTarget.Name = "buttonTarget";
            buttonTarget.Size = new Size(38, 23);
            buttonTarget.TabIndex = 4;
            buttonTarget.Text = "...";
            buttonTarget.UseVisualStyleBackColor = true;
            buttonTarget.Click += buttonTarget_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(452, 32);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 3;
            label2.Text = "Target";
            // 
            // listBoxAdd
            // 
            listBoxAdd.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxAdd.Font = new Font("Segoe UI", 7F);
            listBoxAdd.FormattingEnabled = true;
            listBoxAdd.HorizontalScrollbar = true;
            listBoxAdd.ItemHeight = 12;
            listBoxAdd.Location = new Point(12, 129);
            listBoxAdd.Name = "listBoxAdd";
            listBoxAdd.ScrollAlwaysVisible = true;
            listBoxAdd.Size = new Size(230, 352);
            listBoxAdd.TabIndex = 6;
            // 
            // buttonScan
            // 
            buttonScan.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonScan.Location = new Point(12, 519);
            buttonScan.Name = "buttonScan";
            buttonScan.Size = new Size(75, 32);
            buttonScan.TabIndex = 7;
            buttonScan.Text = "Scan";
            buttonScan.UseVisualStyleBackColor = true;
            buttonScan.Click += buttonScan_Click;
            // 
            // listBoxUpdate
            // 
            listBoxUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxUpdate.Font = new Font("Segoe UI", 7F);
            listBoxUpdate.FormattingEnabled = true;
            listBoxUpdate.HorizontalScrollbar = true;
            listBoxUpdate.ItemHeight = 12;
            listBoxUpdate.Location = new Point(263, 129);
            listBoxUpdate.Name = "listBoxUpdate";
            listBoxUpdate.ScrollAlwaysVisible = true;
            listBoxUpdate.Size = new Size(230, 352);
            listBoxUpdate.TabIndex = 8;
            // 
            // listBoxDelete
            // 
            listBoxDelete.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxDelete.Font = new Font("Segoe UI", 7F);
            listBoxDelete.FormattingEnabled = true;
            listBoxDelete.HorizontalScrollbar = true;
            listBoxDelete.ItemHeight = 12;
            listBoxDelete.Location = new Point(520, 129);
            listBoxDelete.Name = "listBoxDelete";
            listBoxDelete.ScrollAlwaysVisible = true;
            listBoxDelete.Size = new Size(230, 352);
            listBoxDelete.TabIndex = 9;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(12, 557);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(772, 23);
            progressBar1.TabIndex = 10;
            // 
            // buttonSync
            // 
            buttonSync.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonSync.Location = new Point(93, 519);
            buttonSync.Name = "buttonSync";
            buttonSync.Size = new Size(75, 32);
            buttonSync.TabIndex = 11;
            buttonSync.Text = "Sync";
            buttonSync.UseVisualStyleBackColor = true;
            buttonSync.Click += buttonSync_Click;
            // 
            // labelStatus
            // 
            labelStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(185, 528);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(12, 15);
            labelStatus.TabIndex = 12;
            labelStatus.Text = "-";
            // 
            // labelAdd
            // 
            labelAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelAdd.AutoSize = true;
            labelAdd.Location = new Point(12, 488);
            labelAdd.Name = "labelAdd";
            labelAdd.Size = new Size(12, 15);
            labelAdd.TabIndex = 13;
            labelAdd.Text = "-";
            // 
            // labelModify
            // 
            labelModify.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelModify.AutoSize = true;
            labelModify.Location = new Point(263, 488);
            labelModify.Name = "labelModify";
            labelModify.Size = new Size(12, 15);
            labelModify.TabIndex = 14;
            labelModify.Text = "-";
            // 
            // labelDelete
            // 
            labelDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelDelete.AutoSize = true;
            labelDelete.Location = new Point(520, 488);
            labelDelete.Name = "labelDelete";
            labelDelete.Size = new Size(12, 15);
            labelDelete.TabIndex = 15;
            labelDelete.Text = "-";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 111);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 16;
            label3.Text = "ADD";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(263, 111);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 17;
            label4.Text = "UPDATE";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(520, 111);
            label5.Name = "label5";
            label5.Size = new Size(45, 15);
            label5.TabIndex = 18;
            label5.Text = "DELETE";
            // 
            // FormFileSync
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 592);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(labelDelete);
            Controls.Add(labelModify);
            Controls.Add(labelAdd);
            Controls.Add(labelStatus);
            Controls.Add(buttonSync);
            Controls.Add(progressBar1);
            Controls.Add(listBoxDelete);
            Controls.Add(listBoxUpdate);
            Controls.Add(buttonScan);
            Controls.Add(listBoxAdd);
            Controls.Add(textBoxTarget);
            Controls.Add(buttonTarget);
            Controls.Add(label2);
            Controls.Add(textBoxSource);
            Controls.Add(buttonSource);
            Controls.Add(label1);
            Name = "FormFileSync";
            Text = "FileSync";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button buttonSource;
        private TextBox textBoxSource;
        private TextBox textBoxTarget;
        private Button buttonTarget;
        private Label label2;
        private ListBox listBoxAdd;
        private Button buttonScan;
        private ListBox listBoxUpdate;
        private ListBox listBoxDelete;
        private ProgressBar progressBar1;
        private Button buttonSync;
        private Label labelStatus;
        private Label labelAdd;
        private Label labelModify;
        private Label labelDelete;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}
