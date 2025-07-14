using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client_proje
{
    public partial class Form1 : Form
    {
        bool terminating = false;
        bool connected = false;
        Socket clientSocket;
        string globalUsername;
        public Form1()
        {
            InitializeComponent();
        }

        private void connect_Click(object sender, EventArgs e)
        {


            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = ip.Text;
            globalUsername = username.Text;
            int portNum;
            if (Int32.TryParse(port.Text, out portNum))
            {
                try
                {
                    clientSocket.Connect(IP, portNum);
                    connect.Enabled = false;
                    disconnect.Enabled = true;

                    connected = true;


                    richText.Invoke((MethodInvoker)delegate
                    {
                        richText.AppendText("Trying to connect the server!\n");
                    });

                    // Start a new thread to send the username
                    Thread sendUsernameThread = new Thread(() => SendUsername(globalUsername)); // Replace with actual username
                    sendUsernameThread.Start();

                    Thread receiveThread = new Thread(Receive);
                    receiveThread.Start();
                }
                catch
                {
                    

                    richText.Invoke((MethodInvoker)delegate
                    {
                        richText.AppendText("Could not connect to the server!\n");
                    });
                }
            }
            else
            {
                


                richText.Invoke((MethodInvoker)delegate
                {
                    richText.AppendText("Check the port\n");
                });
            }
        }

        private void Receive()
        {
            while (connected)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    clientSocket.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));

                    if (incomingMessage == "Username already taken. Could not connect to server. \n")
                    {
                        serverDisconnect();
                        richText.Invoke((MethodInvoker)delegate
                        {
                            richText.AppendText("Server: " + incomingMessage + "\n");
                        });

                    }

                    else if(incomingMessage.StartsWith("IF-"))
                    {

                        ifChannel.Invoke((MethodInvoker)delegate
                        {
                            ifChannel.AppendText(incomingMessage.Substring(3) + "\n");
                        });
                    }
                    else if (incomingMessage.StartsWith("SPS-"))
                    {
                        spsChannel.Invoke((MethodInvoker)delegate
                        {
                            spsChannel.AppendText(incomingMessage.Substring(4) + "\n");
                        });
                    }
                    else if(incomingMessage.StartsWith("Connectio"))
                    {

                        this.Invoke((MethodInvoker)delegate
                        {
                            SubscribeIF.Enabled = true;
                            SubsribeSPS.Enabled = true;
                        });
                    
                     }
                    else if(incomingMessage.StartsWith("IF From: "))
                    {
                        ifChannel.Invoke((MethodInvoker)delegate
                        {
                            ifChannel.AppendText(incomingMessage.Substring(9) + "\n");
                        });

                    }
                    else if (incomingMessage.StartsWith("SPS From: "))
                    {
                        spsChannel.Invoke((MethodInvoker)delegate
                        {
                            spsChannel.AppendText(incomingMessage.Substring(10) + "\n");
                        });

                    }

                    else
                    {
                    Disconnect();
                    }

                }
                catch
                {
                    if (!terminating)
                    {
                        

                        richText.Invoke((MethodInvoker)delegate
                        {
                            richText.AppendText("The server has disconnected\n");
                        });
  

                    }

                    clientSocket.Close();
                    connected = false;
                }

            }
        }
        private void Disconnect()
        {
            disconnect.Enabled = false;
            connect.Enabled = true;
            sendif.Enabled = false;
            sendsps.Enabled = false;
            SubscribeIF.Enabled = false;
            SubsribeSPS.Enabled = false;
            UnsubscribeIF.Enabled = false;
            UnsubsribeSPS.Enabled = false;
            if (connected)
            {

                string message = "Disconnected with " + globalUsername;
                SendMessage( message);
                terminating = true;
                connected = false;
                clientSocket.Close();
                richText.Invoke((MethodInvoker)delegate
                {
                    richText.AppendText("You have been disconnected.\n");
                });

                connect.Invoke((MethodInvoker)delegate
                {
                    connect.Enabled = true;
                });

                disconnect.Invoke((MethodInvoker)delegate
                {
                    disconnect.Enabled = false;
                });
            }
        }

        private void serverDisconnect()
        {
            if (connected)
            {
                terminating = true;
                connected = false;
                clientSocket.Close();



                connect.Invoke((MethodInvoker)delegate
                {
                    connect.Enabled = true;
                });

                disconnect.Invoke((MethodInvoker)delegate
                {
                    disconnect.Enabled = false;
                });
            }
        }
        private void SendUsername(string username)
        {
            try
            {
                byte[] buffer = Encoding.Default.GetBytes("myusername: " + username);
                clientSocket.Send(buffer);
            }
            catch (Exception ex)
            {
                // Handle any exceptions, for example, display in the richText
                richText.Invoke((MethodInvoker)delegate
                {
                    richText.AppendText("Error sending username: " + ex.Message + "\n");
                });
            }
        }

        private void SendMessage(string message)
        {
            try
            {
                byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
            }
            catch (Exception ex)
            {
                // Handle any exceptions, for example, display in the richText
                richText.Invoke((MethodInvoker)delegate
                {
                    richText.AppendText("Error sending username: " + ex.Message + "\n");
                });
            }
        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
            disconnect.Enabled = false;
            connect.Enabled = true;
            sendif.Enabled = false;
            sendsps.Enabled = false;
            SubscribeIF.Enabled = false;
            SubsribeSPS.Enabled = false;
            UnsubscribeIF.Enabled = false;
            UnsubsribeSPS.Enabled = false;


        }

        private void UnsubsribeSPS_Click(object sender, EventArgs e)
        {
            richText.Invoke((MethodInvoker)delegate
            {
                richText.AppendText("Unsubscribed to SPS101 chanell"+ "\n");
            });
            SendMessage("unsubscribe sps-" + globalUsername);

            UnsubsribeSPS.Enabled = false;
            SubsribeSPS.Enabled = true;
            sendsps.Enabled = false;
        }

        private void SubscribeIF_Click(object sender, EventArgs e)
        {

            richText.Invoke((MethodInvoker)delegate
            {
                richText.AppendText("Subscribed to IF100 chanell" + "\n");
            });
            SendMessage("subscribe if-" + globalUsername);
            UnsubscribeIF.Enabled = true;
            SubscribeIF.Enabled = false;
            sendif.Enabled = true;


        }

        private void UnsubscribeIF_Click(object sender, EventArgs e)
        {
            richText.Invoke((MethodInvoker)delegate
            {
                richText.AppendText("Unsubscribed to IF100 chanell" + "\n");
            });
            SendMessage("unsubscribe if-" + globalUsername);

            UnsubscribeIF.Enabled = false;
            SubscribeIF.Enabled = true;
            sendif.Enabled = false;
        }

        private void SubsribeSPS_Click(object sender, EventArgs e)
        {
            richText.Invoke((MethodInvoker)delegate
            {
                richText.AppendText("Subscribed to SPS101 chanell" + "\n");
            });
            SendMessage("subscribe sps-" + globalUsername);
            UnsubsribeSPS.Enabled = true;
            SubsribeSPS.Enabled = false;
            sendsps.Enabled = true;
        }

        private void sendif_Click(object sender, EventArgs e)
        {
            string message = ifmessage.Text;

            richText.Invoke((MethodInvoker)delegate
            {
                richText.AppendText("Your Message to IF100: " + message + "\n" );
            });

            SendMessage("announcment if- " + globalUsername + ": " + message);

        }

        private void sendsps_Click(object sender, EventArgs e)
        {
            string message = spsmessage.Text;

            richText.Invoke((MethodInvoker)delegate
            {
                richText.AppendText("Your Message to SPS101: " + message + "\n");
            });

            SendMessage("announcment sps- " + globalUsername + ": " + message);
        }
    }
}
