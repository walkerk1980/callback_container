namespace Egscape_gui
{
    partial class EgscapeMainForm
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
            this.hostTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.protocolComboBox = new System.Windows.Forms.ComboBox();
            this.hostLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.scanButton = new System.Windows.Forms.Button();
            this.portTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // hostTextBox
            // 
            this.hostTextBox.Location = new System.Drawing.Point(35, 119);
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(121, 20);
            this.hostTextBox.TabIndex = 1;
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(35, 183);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(121, 20);
            this.portTextBox.TabIndex = 2;
            // 
            // protocolComboBox
            // 
            this.protocolComboBox.FormattingEnabled = true;
            this.protocolComboBox.Items.AddRange(new object[] {
            "TCP",
            "UDP",
            "Proxy"});
            this.protocolComboBox.Location = new System.Drawing.Point(35, 57);
            this.protocolComboBox.Name = "protocolComboBox";
            this.protocolComboBox.Size = new System.Drawing.Size(121, 21);
            this.protocolComboBox.TabIndex = 0;
            this.protocolComboBox.Text = "Protocol";
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(32, 103);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(54, 13);
            this.hostLabel.TabIndex = 5;
            this.hostLabel.Text = "Host or IP";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(32, 167);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(95, 13);
            this.portLabel.TabIndex = 6;
            this.portLabel.Text = "Port, Port List or Port Range";
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(35, 231);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(121, 23);
            this.scanButton.TabIndex = 4;
            this.scanButton.Text = "Scan";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // portTypeComboBox
            // 
            this.portTypeComboBox.FormattingEnabled = true;
            this.portTypeComboBox.Items.AddRange(new object[] {
            "Dash Seperated Range",
            "Comma Seperated Ports"});
            this.portTypeComboBox.Location = new System.Drawing.Point(162, 182);
            this.portTypeComboBox.Name = "portTypeComboBox";
            this.portTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.portTypeComboBox.TabIndex = 3;
            this.portTypeComboBox.Text = "Port Input Type";
            // 
            // EgscapeMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 357);
            this.Controls.Add(this.portTypeComboBox);
            this.Controls.Add(this.scanButton);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.hostLabel);
            this.Controls.Add(this.protocolComboBox);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.hostTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EgscapeMainForm";
            this.Text = "Egscape";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox hostTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.ComboBox protocolComboBox;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.ComboBox portTypeComboBox;
    }
}

