﻿
using System.ComponentModel;

namespace CheckFormatFile
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

            l_logger_Fuction.Log($"End app!");
            l_logger_CRLF.Log($"End apps");
            l_logger_Not_CRLF.Log($"End apps");
            l_logger_UTF8.Log($"End apps");
            l_logger_Not_UTF8.Log($"End apps");

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.stactic_label_Browser = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_Result = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn_OpenLog = new System.Windows.Forms.Button();
            this.btn_CRLF_OpenFile = new System.Windows.Forms.Button();
            this.btn_checkCRLF = new System.Windows.Forms.Button();
            this.l_txtSelectFolder = new System.Windows.Forms.TextBox();
            this.treeView_Seletect = new System.Windows.Forms.TreeView();
            this.btn_FormatFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.combobox_Lang = new System.Windows.Forms.ComboBox();
            this.stactic_label_Lang = new System.Windows.Forms.Label();
            this.l_btn_CheckUpdate = new System.Windows.Forms.Button();
            this.l_label_version = new System.Windows.Forms.Label();
            this.stactic_label_Version = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_OpenFile = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // stactic_label_Browser
            // 
            this.stactic_label_Browser.AutoSize = true;
            this.stactic_label_Browser.Location = new System.Drawing.Point(16, 11);
            this.stactic_label_Browser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stactic_label_Browser.Name = "stactic_label_Browser";
            this.stactic_label_Browser.Size = new System.Drawing.Size(56, 16);
            this.stactic_label_Browser.TabIndex = 0;
            this.stactic_label_Browser.Text = "Browser";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_Result);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.btn_OpenLog);
            this.groupBox2.Controls.Add(this.btn_CRLF_OpenFile);
            this.groupBox2.Controls.Add(this.btn_checkCRLF);
            this.groupBox2.Location = new System.Drawing.Point(16, 335);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(559, 204);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Check CRLF";
            // 
            // txt_Result
            // 
            this.txt_Result.Location = new System.Drawing.Point(55, 73);
            this.txt_Result.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Result.Multiline = true;
            this.txt_Result.Name = "txt_Result";
            this.txt_Result.ReadOnly = true;
            this.txt_Result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Result.Size = new System.Drawing.Size(467, 88);
            this.txt_Result.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(55, 36);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(468, 28);
            this.progressBar1.TabIndex = 3;
            // 
            // btn_OpenLog
            // 
            this.btn_OpenLog.Location = new System.Drawing.Point(392, 169);
            this.btn_OpenLog.Margin = new System.Windows.Forms.Padding(4);
            this.btn_OpenLog.Name = "btn_OpenLog";
            this.btn_OpenLog.Size = new System.Drawing.Size(131, 28);
            this.btn_OpenLog.TabIndex = 2;
            this.btn_OpenLog.Text = "Open LogFile";
            this.btn_OpenLog.UseVisualStyleBackColor = true;
            this.btn_OpenLog.Click += new System.EventHandler(this.btn_OpenLog_Click);
            // 
            // btn_CRLF_OpenFile
            // 
            this.btn_CRLF_OpenFile.Location = new System.Drawing.Point(227, 169);
            this.btn_CRLF_OpenFile.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CRLF_OpenFile.Name = "btn_CRLF_OpenFile";
            this.btn_CRLF_OpenFile.Size = new System.Drawing.Size(131, 28);
            this.btn_CRLF_OpenFile.TabIndex = 1;
            this.btn_CRLF_OpenFile.Text = "Open File";
            this.btn_CRLF_OpenFile.UseVisualStyleBackColor = true;
            this.btn_CRLF_OpenFile.Click += new System.EventHandler(this.btn_CRLF_OpenFile_Click);
            // 
            // btn_checkCRLF
            // 
            this.btn_checkCRLF.Location = new System.Drawing.Point(55, 169);
            this.btn_checkCRLF.Margin = new System.Windows.Forms.Padding(4);
            this.btn_checkCRLF.Name = "btn_checkCRLF";
            this.btn_checkCRLF.Size = new System.Drawing.Size(131, 28);
            this.btn_checkCRLF.TabIndex = 0;
            this.btn_checkCRLF.Text = "Check CRLF";
            this.btn_checkCRLF.UseVisualStyleBackColor = true;
            this.btn_checkCRLF.Click += new System.EventHandler(this.btn_checkCRLF_Click);
            // 
            // l_txtSelectFolder
            // 
            this.l_txtSelectFolder.Location = new System.Drawing.Point(104, 11);
            this.l_txtSelectFolder.Margin = new System.Windows.Forms.Padding(4);
            this.l_txtSelectFolder.Name = "l_txtSelectFolder";
            this.l_txtSelectFolder.Size = new System.Drawing.Size(941, 22);
            this.l_txtSelectFolder.TabIndex = 3;
            this.l_txtSelectFolder.Text = "Choose file check format";
            this.l_txtSelectFolder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSelete_KeyDown);
            this.l_txtSelectFolder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSelete_KeyPress);
            // 
            // treeView_Seletect
            // 
            this.treeView_Seletect.BackColor = System.Drawing.Color.PaleGreen;
            this.treeView_Seletect.Location = new System.Drawing.Point(16, 43);
            this.treeView_Seletect.Margin = new System.Windows.Forms.Padding(4);
            this.treeView_Seletect.Name = "treeView_Seletect";
            this.treeView_Seletect.Size = new System.Drawing.Size(1029, 283);
            this.treeView_Seletect.TabIndex = 4;
            // 
            // btn_FormatFile
            // 
            this.btn_FormatFile.Location = new System.Drawing.Point(8, 169);
            this.btn_FormatFile.Margin = new System.Windows.Forms.Padding(4);
            this.btn_FormatFile.Name = "btn_FormatFile";
            this.btn_FormatFile.Size = new System.Drawing.Size(162, 28);
            this.btn_FormatFile.TabIndex = 1;
            this.btn_FormatFile.Text = "Start";
            this.btn_FormatFile.UseVisualStyleBackColor = true;
            this.btn_FormatFile.Click += new System.EventHandler(this.btn_FormatFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.combobox_Lang);
            this.groupBox1.Controls.Add(this.stactic_label_Lang);
            this.groupBox1.Controls.Add(this.l_btn_CheckUpdate);
            this.groupBox1.Controls.Add(this.l_label_version);
            this.groupBox1.Controls.Add(this.stactic_label_Version);
            this.groupBox1.Controls.Add(this.btn_Exit);
            this.groupBox1.Controls.Add(this.btn_OpenFile);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_FormatFile);
            this.groupBox1.Location = new System.Drawing.Point(583, 335);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(464, 204);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Check Endcoding";
            // 
            // combobox_Lang
            // 
            this.combobox_Lang.FormattingEnabled = true;
            this.combobox_Lang.Location = new System.Drawing.Point(250, 119);
            this.combobox_Lang.Margin = new System.Windows.Forms.Padding(4);
            this.combobox_Lang.Name = "combobox_Lang";
            this.combobox_Lang.Size = new System.Drawing.Size(205, 24);
            this.combobox_Lang.TabIndex = 12;
            this.combobox_Lang.SelectedIndexChanged += new System.EventHandler(this.combobox_Lang_SelectedIndexChanged);
            // 
            // stactic_label_Lang
            // 
            this.stactic_label_Lang.AutoSize = true;
            this.stactic_label_Lang.Location = new System.Drawing.Point(9, 122);
            this.stactic_label_Lang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stactic_label_Lang.Name = "stactic_label_Lang";
            this.stactic_label_Lang.Size = new System.Drawing.Size(68, 16);
            this.stactic_label_Lang.TabIndex = 11;
            this.stactic_label_Lang.Text = "Language";
            // 
            // l_btn_CheckUpdate
            // 
            this.l_btn_CheckUpdate.Location = new System.Drawing.Point(250, 70);
            this.l_btn_CheckUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.l_btn_CheckUpdate.Name = "l_btn_CheckUpdate";
            this.l_btn_CheckUpdate.Size = new System.Drawing.Size(205, 28);
            this.l_btn_CheckUpdate.TabIndex = 10;
            this.l_btn_CheckUpdate.Text = "Check Update";
            this.l_btn_CheckUpdate.UseVisualStyleBackColor = true;
            // 
            // l_label_version
            // 
            this.l_label_version.AutoSize = true;
            this.l_label_version.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_label_version.Location = new System.Drawing.Point(120, 76);
            this.l_label_version.Name = "l_label_version";
            this.l_label_version.Size = new System.Drawing.Size(50, 22);
            this.l_label_version.TabIndex = 9;
            this.l_label_version.Text = "1.0.0";
            // 
            // stactic_label_Version
            // 
            this.stactic_label_Version.AutoSize = true;
            this.stactic_label_Version.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stactic_label_Version.Location = new System.Drawing.Point(8, 73);
            this.stactic_label_Version.Name = "stactic_label_Version";
            this.stactic_label_Version.Size = new System.Drawing.Size(81, 22);
            this.stactic_label_Version.TabIndex = 8;
            this.stactic_label_Version.Text = "Version :";
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(325, 169);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(131, 28);
            this.btn_Exit.TabIndex = 7;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_OpenFile
            // 
            this.btn_OpenFile.Location = new System.Drawing.Point(186, 169);
            this.btn_OpenFile.Margin = new System.Windows.Forms.Padding(4);
            this.btn_OpenFile.Name = "btn_OpenFile";
            this.btn_OpenFile.Size = new System.Drawing.Size(131, 28);
            this.btn_OpenFile.TabIndex = 6;
            this.btn_OpenFile.Text = "Open File";
            this.btn_OpenFile.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Unicode",
            "UTF8withBOM",
            "UTF8withoutBOM",
            "UTF7"});
            this.comboBox1.Location = new System.Drawing.Point(124, 36);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(331, 24);
            this.comboBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Format extends";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeView_Seletect);
            this.Controls.Add(this.l_txtSelectFolder);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.stactic_label_Browser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "CheckCRLF";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label stactic_label_Browser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox l_txtSelectFolder;
        private System.Windows.Forms.TreeView treeView_Seletect;
        private System.Windows.Forms.Button btn_checkCRLF;
        private System.Windows.Forms.Button btn_FormatFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Result;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btn_OpenLog;
        private System.Windows.Forms.Button btn_CRLF_OpenFile;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_OpenFile;
        private Logger l_logger_Fuction;
        private Logger l_logger_CRLF;
        private Logger l_logger_Not_CRLF;
        private Logger l_logger_UTF8;
        private Logger l_logger_Not_UTF8;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label l_label_version;
        private System.Windows.Forms.Label stactic_label_Version;
        private System.Windows.Forms.Button l_btn_CheckUpdate;
        private System.Windows.Forms.Label stactic_label_Lang;
        private System.Windows.Forms.ComboBox combobox_Lang;
    }
}

