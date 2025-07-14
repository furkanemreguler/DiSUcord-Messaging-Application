namespace client_proje
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ip = new System.Windows.Forms.TextBox();
            this.port = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.connect = new System.Windows.Forms.Button();
            this.disconnect = new System.Windows.Forms.Button();
            this.richText = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SubscribeIF = new System.Windows.Forms.Button();
            this.UnsubscribeIF = new System.Windows.Forms.Button();
            this.SubsribeSPS = new System.Windows.Forms.Button();
            this.UnsubsribeSPS = new System.Windows.Forms.Button();
            this.spsChannel = new System.Windows.Forms.RichTextBox();
            this.ifChannel = new System.Windows.Forms.RichTextBox();
            this.ifmessage = new System.Windows.Forms.TextBox();
            this.spsmessage = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.sendif = new System.Windows.Forms.Button();
            this.sendsps = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Username :";
            // 
            // ip
            // 
            this.ip.Location = new System.Drawing.Point(105, 27);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(117, 20);
            this.ip.TabIndex = 3;
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(105, 64);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(117, 20);
            this.port.TabIndex = 4;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(105, 105);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(117, 20);
            this.username.TabIndex = 5;
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(32, 180);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(75, 21);
            this.connect.TabIndex = 6;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // disconnect
            // 
            this.disconnect.Enabled = false;
            this.disconnect.Location = new System.Drawing.Point(126, 180);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(75, 21);
            this.disconnect.TabIndex = 7;
            this.disconnect.Text = "Disconnect";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.disconnect_Click);
            // 
            // richText
            // 
            this.richText.Location = new System.Drawing.Point(63, 262);
            this.richText.Name = "richText";
            this.richText.Size = new System.Drawing.Size(230, 291);
            this.richText.TabIndex = 8;
            this.richText.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(479, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "IF 100 Channel : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(827, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "SPS 101 Channel :";
            // 
            // SubscribeIF
            // 
            this.SubscribeIF.Enabled = false;
            this.SubscribeIF.Location = new System.Drawing.Point(590, 22);
            this.SubscribeIF.Name = "SubscribeIF";
            this.SubscribeIF.Size = new System.Drawing.Size(75, 23);
            this.SubscribeIF.TabIndex = 11;
            this.SubscribeIF.Text = "Subscribe";
            this.SubscribeIF.UseVisualStyleBackColor = true;
            this.SubscribeIF.Click += new System.EventHandler(this.SubscribeIF_Click);
            // 
            // UnsubscribeIF
            // 
            this.UnsubscribeIF.Enabled = false;
            this.UnsubscribeIF.Location = new System.Drawing.Point(694, 22);
            this.UnsubscribeIF.Name = "UnsubscribeIF";
            this.UnsubscribeIF.Size = new System.Drawing.Size(75, 23);
            this.UnsubscribeIF.TabIndex = 12;
            this.UnsubscribeIF.Text = "Unsubscribe";
            this.UnsubscribeIF.UseVisualStyleBackColor = true;
            this.UnsubscribeIF.Click += new System.EventHandler(this.UnsubscribeIF_Click);
            // 
            // SubsribeSPS
            // 
            this.SubsribeSPS.Enabled = false;
            this.SubsribeSPS.Location = new System.Drawing.Point(930, 24);
            this.SubsribeSPS.Name = "SubsribeSPS";
            this.SubsribeSPS.Size = new System.Drawing.Size(75, 23);
            this.SubsribeSPS.TabIndex = 15;
            this.SubsribeSPS.Text = "Subscribe";
            this.SubsribeSPS.UseVisualStyleBackColor = true;
            this.SubsribeSPS.Click += new System.EventHandler(this.SubsribeSPS_Click);
            // 
            // UnsubsribeSPS
            // 
            this.UnsubsribeSPS.Enabled = false;
            this.UnsubsribeSPS.Location = new System.Drawing.Point(1042, 25);
            this.UnsubsribeSPS.Name = "UnsubsribeSPS";
            this.UnsubsribeSPS.Size = new System.Drawing.Size(75, 23);
            this.UnsubsribeSPS.TabIndex = 16;
            this.UnsubsribeSPS.Text = "Unsubscribe";
            this.UnsubsribeSPS.UseVisualStyleBackColor = true;
            this.UnsubsribeSPS.Click += new System.EventHandler(this.UnsubsribeSPS_Click);
            // 
            // spsChannel
            // 
            this.spsChannel.Location = new System.Drawing.Point(830, 61);
            this.spsChannel.Name = "spsChannel";
            this.spsChannel.Size = new System.Drawing.Size(287, 398);
            this.spsChannel.TabIndex = 17;
            this.spsChannel.Text = "";
            // 
            // ifChannel
            // 
            this.ifChannel.Location = new System.Drawing.Point(482, 61);
            this.ifChannel.Name = "ifChannel";
            this.ifChannel.Size = new System.Drawing.Size(287, 398);
            this.ifChannel.TabIndex = 18;
            this.ifChannel.Text = "";
            // 
            // ifmessage
            // 
            this.ifmessage.Location = new System.Drawing.Point(554, 479);
            this.ifmessage.Name = "ifmessage";
            this.ifmessage.Size = new System.Drawing.Size(215, 20);
            this.ifmessage.TabIndex = 19;
            // 
            // spsmessage
            // 
            this.spsmessage.Location = new System.Drawing.Point(902, 479);
            this.spsmessage.Name = "spsmessage";
            this.spsmessage.Size = new System.Drawing.Size(215, 20);
            this.spsmessage.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(479, 486);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Message:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(827, 486);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Message:";
            // 
            // sendif
            // 
            this.sendif.Enabled = false;
            this.sendif.Location = new System.Drawing.Point(590, 530);
            this.sendif.Name = "sendif";
            this.sendif.Size = new System.Drawing.Size(75, 23);
            this.sendif.TabIndex = 23;
            this.sendif.Text = "Send";
            this.sendif.UseVisualStyleBackColor = true;
            this.sendif.Click += new System.EventHandler(this.sendif_Click);
            // 
            // sendsps
            // 
            this.sendsps.Enabled = false;
            this.sendsps.Location = new System.Drawing.Point(930, 530);
            this.sendsps.Name = "sendsps";
            this.sendsps.Size = new System.Drawing.Size(75, 23);
            this.sendsps.TabIndex = 24;
            this.sendsps.Text = "Send";
            this.sendsps.UseVisualStyleBackColor = true;
            this.sendsps.Click += new System.EventHandler(this.sendsps_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 608);
            this.Controls.Add(this.sendsps);
            this.Controls.Add(this.sendif);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.spsmessage);
            this.Controls.Add(this.ifmessage);
            this.Controls.Add(this.ifChannel);
            this.Controls.Add(this.spsChannel);
            this.Controls.Add(this.UnsubsribeSPS);
            this.Controls.Add(this.SubsribeSPS);
            this.Controls.Add(this.UnsubscribeIF);
            this.Controls.Add(this.SubscribeIF);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richText);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.username);
            this.Controls.Add(this.port);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Send";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.RichTextBox richText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button SubscribeIF;
        private System.Windows.Forms.Button UnsubscribeIF;
        private System.Windows.Forms.Button SubsribeSPS;
        private System.Windows.Forms.Button UnsubsribeSPS;
        private System.Windows.Forms.RichTextBox spsChannel;
        private System.Windows.Forms.RichTextBox ifChannel;
        private System.Windows.Forms.TextBox ifmessage;
        private System.Windows.Forms.TextBox spsmessage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button sendif;
        private System.Windows.Forms.Button sendsps;
    }
}

