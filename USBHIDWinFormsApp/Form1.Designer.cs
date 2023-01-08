namespace USBHIDWinFormsApp
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
            this.USBFound = new System.Windows.Forms.Label();
            this.searchHidButton = new System.Windows.Forms.Button();
            this.sendOutputReportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // USBFound
            // 
            this.USBFound.AutoSize = true;
            this.USBFound.Location = new System.Drawing.Point(39, 46);
            this.USBFound.Name = "USBFound";
            this.USBFound.Size = new System.Drawing.Size(139, 20);
            this.USBFound.TabIndex = 0;
            this.USBFound.Text = "Click on Search HID";
            // 
            // searchHidButton
            // 
            this.searchHidButton.Location = new System.Drawing.Point(41, 88);
            this.searchHidButton.Name = "searchHidButton";
            this.searchHidButton.Size = new System.Drawing.Size(94, 29);
            this.searchHidButton.TabIndex = 1;
            this.searchHidButton.Text = "Search HID";
            this.searchHidButton.UseVisualStyleBackColor = true;
            this.searchHidButton.Click += new System.EventHandler(this.searchHidButton_Click);
            // 
            // sendOutputReportButton
            // 
            this.sendOutputReportButton.Location = new System.Drawing.Point(39, 139);
            this.sendOutputReportButton.Name = "sendOutputReportButton";
            this.sendOutputReportButton.Size = new System.Drawing.Size(181, 29);
            this.sendOutputReportButton.TabIndex = 2;
            this.sendOutputReportButton.Text = "Send Output Report";
            this.sendOutputReportButton.UseVisualStyleBackColor = true;
            this.sendOutputReportButton.Click += new System.EventHandler(this.sendOutputReportButton_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.sendOutputReportButton);
            this.Controls.Add(this.searchHidButton);
            this.Controls.Add(this.USBFound);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label USBFound;
        private Button searchHidButton;
        private Button sendOutputReportButton;
    }
}