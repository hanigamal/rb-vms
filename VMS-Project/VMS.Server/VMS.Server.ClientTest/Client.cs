using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using XYNetSocketLib;

namespace Client
{
    public class Client:System.Windows.Forms.Form
    {
        private Label label1;
        private TextBox txtServerIP;
        private Label label2;
        private TextBox txtMessage;
        private Button btnStatus;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lbStatus;
        private Label label3;
        private TextBox txtNumClient;
        private Label label4;
        private TextBox txtTimeOut;
        private Label label5;
        private TextBox txtPort;
    
        public Client()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnStatus = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumClient = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTimeOut = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP:";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(16, 30);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(213, 20);
            this.txtServerIP.TabIndex = 1;
            this.txtServerIP.Text = "192.168.244.1";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(235, 30);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(56, 20);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "8080";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Port :";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(16, 126);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(345, 90);
            this.txtMessage.TabIndex = 2;
            // 
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(286, 222);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(75, 23);
            this.btnStatus.TabIndex = 3;
            this.btnStatus.Text = "Send";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 253);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(373, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 4;
            // 
            // lbStatus
            // 
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(38, 17);
            this.lbStatus.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "NumberClient";
            // 
            // txtNumClient
            // 
            this.txtNumClient.Location = new System.Drawing.Point(16, 84);
            this.txtNumClient.Name = "txtNumClient";
            this.txtNumClient.Size = new System.Drawing.Size(56, 20);
            this.txtNumClient.TabIndex = 1;
            this.txtNumClient.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(146, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "TimeOut";
            // 
            // txtTimeOut
            // 
            this.txtTimeOut.Location = new System.Drawing.Point(149, 84);
            this.txtTimeOut.Name = "txtTimeOut";
            this.txtTimeOut.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTimeOut.Size = new System.Drawing.Size(56, 20);
            this.txtTimeOut.TabIndex = 1;
            this.txtTimeOut.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "s";
            // 
            // Client
            // 
            this.ClientSize = new System.Drawing.Size(373, 275);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtTimeOut);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNumClient);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtServerIP);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Client";
            this.Text = "Client";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            /*
            XYNetClient ClientSender = new XYNetClient(txtServerIP.Text, int.Parse(txtPort.Text));
            if (ClientSender.Connect() == true)
            {
                lbStatus.Text = "Connected";
                if (ClientSender.SendStringData(txtMessage.Text) == true)
                {
                    lbStatus.Text = "Send Message successful";
                    
                }
                else
                {
                    lbStatus.Text = "Cannot Send";
                }
            }
            else
                lbStatus.Text = "Cannot Connect to Server";
             */
            int nSize = int.Parse(txtNumClient.Text);
            int nPause = int.Parse(txtTimeOut.Text);
            XYNetClient[] pClients = new XYNetClient[nSize];
            for (int i = 0; i < nSize; i++)
            {
                pClients[i] = new XYNetClient(txtServerIP.Text, int.Parse(txtPort.Text));
                if (pClients[i].Connect() == false)
                    throw pClients[i].GetLastException();
                Thread.Sleep(nPause);
            }

            for (int i = 0; i < nSize; i++)
            {
                if (pClients[i].SendStringData(txtMessage.Text) == false)
                    throw pClients[i].GetLastException();
                Thread.Sleep(nPause);
            }
            // receive reply message from the server
           lbStatus.Text = "Complete";
        }

    }
}
