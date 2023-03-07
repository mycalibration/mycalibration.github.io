namespace WinFormsApp
{
    partial class Form1
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonCallApiForHeaders = new System.Windows.Forms.Button();
            this.buttonCallApiForJsonData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelLog = new System.Windows.Forms.Label();
            this.testApiButton = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBox1.Location = new System.Drawing.Point(0, 693);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1778, 388);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "1) Enter Permament Access Token";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(27, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1579, 31);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonCallApiForHeaders
            // 
            this.buttonCallApiForHeaders.Enabled = false;
            this.buttonCallApiForHeaders.Location = new System.Drawing.Point(27, 163);
            this.buttonCallApiForHeaders.Name = "buttonCallApiForHeaders";
            this.buttonCallApiForHeaders.Size = new System.Drawing.Size(238, 34);
            this.buttonCallApiForHeaders.TabIndex = 3;
            this.buttonCallApiForHeaders.Text = "Call API and get metadata";
            this.buttonCallApiForHeaders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCallApiForHeaders.UseVisualStyleBackColor = true;
            this.buttonCallApiForHeaders.Click += new System.EventHandler(this.buttonCallApiForHeaders_Click);
            // 
            // buttonCallApiForJsonData
            // 
            this.buttonCallApiForJsonData.Enabled = false;
            this.buttonCallApiForJsonData.Location = new System.Drawing.Point(475, 163);
            this.buttonCallApiForJsonData.Name = "buttonCallApiForJsonData";
            this.buttonCallApiForJsonData.Size = new System.Drawing.Size(257, 34);
            this.buttonCallApiForJsonData.TabIndex = 4;
            this.buttonCallApiForJsonData.Text = "Call API and get chosen data";
            this.buttonCallApiForJsonData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCallApiForJsonData.UseVisualStyleBackColor = true;
            this.buttonCallApiForJsonData.Click += new System.EventHandler(this.buttonCallApiForJsonData_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(407, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "2) Get the header info and choose a serial number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(475, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(641, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "3) Download the JSON of the sensor with the chosen serial number and convert";
            // 
            // labelLog
            // 
            this.labelLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelLog.AutoSize = true;
            this.labelLog.Location = new System.Drawing.Point(12, 665);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(42, 25);
            this.labelLog.TabIndex = 7;
            this.labelLog.Text = "Log";
            // 
            // testApiButton
            // 
            this.testApiButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.testApiButton.Enabled = false;
            this.testApiButton.Location = new System.Drawing.Point(1612, 53);
            this.testApiButton.Name = "testApiButton";
            this.testApiButton.Size = new System.Drawing.Size(136, 34);
            this.testApiButton.TabIndex = 8;
            this.testApiButton.Text = "Test API Call";
            this.testApiButton.UseVisualStyleBackColor = true;
            this.testApiButton.Click += new System.EventHandler(this.testApiButton_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(27, 203);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(400, 440);
            this.treeView1.TabIndex = 9;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(478, 202);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(400, 440);
            this.richTextBox2.TabIndex = 10;
            this.richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(924, 203);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(400, 440);
            this.richTextBox3.TabIndex = 11;
            this.richTextBox3.Text = "";
            // 
            // richTextBox4
            // 
            this.richTextBox4.Location = new System.Drawing.Point(1358, 203);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(400, 440);
            this.richTextBox4.TabIndex = 12;
            this.richTextBox4.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(315, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 13;
            this.button1.Text = "Download";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1778, 1081);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox4);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.testApiButton);
            this.Controls.Add(this.labelLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCallApiForJsonData);
            this.Controls.Add(this.buttonCallApiForHeaders);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Sample Windows Forms App for myCalibration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox richTextBox1;
        private Label label1;
        private TextBox textBox1;
        private Button buttonCallApiForHeaders;
        private Button buttonCallApiForJsonData;
        private Label label2;
        private Label label3;
        private Label labelLog;
        private Button testApiButton;
        private TreeView treeView1;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox3;
        private RichTextBox richTextBox4;
        private Button button1;
    }
}