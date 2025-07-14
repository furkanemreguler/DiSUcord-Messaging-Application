namespace WindowsFormsApp1
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.portNum = new System.Windows.Forms.TextBox();
            this.monitorScreen = new System.Windows.Forms.RichTextBox();
            this.allClients = new System.Windows.Forms.RichTextBox();
            this.IFclients = new System.Windows.Forms.RichTextBox();
            this.SPSclients = new System.Windows.Forms.RichTextBox();
            this.listenButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // portNum
            // 
            this.portNum.Location = new System.Drawing.Point(86, 30);
            this.portNum.Name = "portNum";
            this.portNum.Size = new System.Drawing.Size(100, 20);
            this.portNum.TabIndex = 1;
            // 
            // monitorScreen
            // 
            this.monitorScreen.Location = new System.Drawing.Point(29, 124);
            this.monitorScreen.Name = "monitorScreen";
            this.monitorScreen.Size = new System.Drawing.Size(263, 347);
            this.monitorScreen.TabIndex = 2;
            this.monitorScreen.Text = "";
            // 
            // allClients
            // 
            this.allClients.Location = new System.Drawing.Point(325, 125);
            this.allClients.Name = "allClients";
            this.allClients.Size = new System.Drawing.Size(260, 346);
            this.allClients.TabIndex = 3;
            this.allClients.Text = "";
            // 
            // IFclients
            // 
            this.IFclients.Location = new System.Drawing.Point(621, 123);
            this.IFclients.Name = "IFclients";
            this.IFclients.Size = new System.Drawing.Size(278, 144);
            this.IFclients.TabIndex = 4;
            this.IFclients.Text = "";
            // 
            // SPSclients
            // 
            this.SPSclients.Location = new System.Drawing.Point(621, 327);
            this.SPSclients.Name = "SPSclients";
            this.SPSclients.Size = new System.Drawing.Size(278, 144);
            this.SPSclients.TabIndex = 5;
            this.SPSclients.Text = "";
            // 
            // listenButton
            // 
            this.listenButton.Location = new System.Drawing.Point(86, 67);
            this.listenButton.Name = "listenButton";
            this.listenButton.Size = new System.Drawing.Size(100, 24);
            this.listenButton.TabIndex = 6;
            this.listenButton.Text = "Listen";
            this.listenButton.UseVisualStyleBackColor = true;
            this.listenButton.Click += new System.EventHandler(this.listenButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 543);
            this.Controls.Add(this.listenButton);
            this.Controls.Add(this.SPSclients);
            this.Controls.Add(this.IFclients);
            this.Controls.Add(this.allClients);
            this.Controls.Add(this.monitorScreen);
            this.Controls.Add(this.portNum);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox portNum;
        private System.Windows.Forms.RichTextBox monitorScreen;
        private System.Windows.Forms.RichTextBox allClients;
        private System.Windows.Forms.RichTextBox IFclients;
        private System.Windows.Forms.RichTextBox SPSclients;
        private System.Windows.Forms.Button listenButton;
    }
}

