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
            USBFound = new Label();
            searchHidButton = new Button();
            sendOutputReportButton = new Button();
            button1 = new Button();
            inputReportTextBox = new TextBox();
            SuspendLayout();
            // 
            // USBFound
            // 
            USBFound.AutoSize = true;
            USBFound.Location = new Point(33, 29);
            USBFound.Name = "USBFound";
            USBFound.Size = new Size(139, 20);
            USBFound.TabIndex = 0;
            USBFound.Text = "Click on Search HID";
            // 
            // searchHidButton
            // 
            searchHidButton.Location = new Point(35, 72);
            searchHidButton.Name = "searchHidButton";
            searchHidButton.Size = new Size(94, 29);
            searchHidButton.TabIndex = 1;
            searchHidButton.Text = "Search HID";
            searchHidButton.UseVisualStyleBackColor = true;
            searchHidButton.Click += searchHidButton_Click;
            // 
            // sendOutputReportButton
            // 
            sendOutputReportButton.Location = new Point(33, 124);
            sendOutputReportButton.Name = "sendOutputReportButton";
            sendOutputReportButton.Size = new Size(181, 29);
            sendOutputReportButton.TabIndex = 2;
            sendOutputReportButton.Text = "Send Output Report";
            sendOutputReportButton.UseVisualStyleBackColor = true;
            sendOutputReportButton.Click += sendOutputReportButton_Click;
            // 
            // button1
            // 
            button1.Location = new Point(35, 176);
            button1.Name = "button1";
            button1.Size = new Size(181, 29);
            button1.TabIndex = 2;
            button1.Text = "Get Input Report";
            button1.UseVisualStyleBackColor = true;
            button1.Click += getInputReportButton_Click;
            // 
            // inputReportTextBox
            // 
            inputReportTextBox.Location = new Point(35, 228);
            inputReportTextBox.Name = "inputReportTextBox";
            inputReportTextBox.ReadOnly = true;
            inputReportTextBox.Size = new Size(125, 27);
            inputReportTextBox.TabIndex = 3;
            // 
            // Form1
            // 
            ClientSize = new Size(347, 307);
            Controls.Add(inputReportTextBox);
            Controls.Add(button1);
            Controls.Add(sendOutputReportButton);
            Controls.Add(searchHidButton);
            Controls.Add(USBFound);
            Name = "Form1";
            Text = "HID - Windows Forms";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label USBFound;
        private Button searchHidButton;
        private Button sendOutputReportButton;
        private Button button1;
        private TextBox inputReportTextBox;
    }
}