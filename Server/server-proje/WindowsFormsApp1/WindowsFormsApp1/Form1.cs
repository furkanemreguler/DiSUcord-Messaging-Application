using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;


using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer listUpdateTimer;
        private System.Windows.Forms.Timer listUpdateTimer2;
        private System.Windows.Forms.Timer listUpdateTimer3;
        public Form1()
        {
            InitializeComponent();
          

            // Initialize and configure the timer
            listUpdateTimer = new System.Windows.Forms.Timer();
            listUpdateTimer.Interval = 100; // Update interval in milliseconds, e.g., 1000 for 1 second
            listUpdateTimer.Tick += new EventHandler(UpdateClientListDisplay);
            listUpdateTimer.Start();



            listUpdateTimer2 = new System.Windows.Forms.Timer();
            listUpdateTimer2.Interval = 100; // Update interval in milliseconds, e.g., 1000 for 1 second
            listUpdateTimer2.Tick += new EventHandler(UpdateIFClientsDisplay);
            listUpdateTimer2.Start();



            listUpdateTimer3 = new System.Windows.Forms.Timer();
            listUpdateTimer3.Interval = 100; // Update interval in milliseconds, e.g., 1000 for 1 second
            listUpdateTimer3.Tick += new EventHandler(UpdateSpsClientsDisplay);
            listUpdateTimer3.Start();









        }

        private void UpdateClientListDisplay(object sender, EventArgs e)
        {
            // Build a string with all client names, separated by new lines
            string clientListText = string.Join(Environment.NewLine, allClientsDict.Keys);

            // Update the RichTextBox text
            allClients.Text = clientListText;
        }

        private void UpdateIFClientsDisplay(object sender, EventArgs e)
        {
            string ifClientListText = string.Join(Environment.NewLine, ifClientsDict.Keys);
            IFclients.Text = ifClientListText;
        }


        private void UpdateSpsClientsDisplay(object sender, EventArgs e)
        {
            string spsClientListText = string.Join(Environment.NewLine, spsClientsDict.Keys);
            SPSclients.Text = spsClientListText;
        }














        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>();

        bool terminating = false;
        bool listening = false;
        Dictionary<string, Socket> allClientsDict = new Dictionary<string, Socket>();
        Dictionary<string, Socket> spsClientsDict = new Dictionary<string, Socket>();
        Dictionary<string, Socket> ifClientsDict = new Dictionary<string, Socket>();



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listenButton_Click(object sender, EventArgs e)
        {
            int serverPort;

            if (Int32.TryParse(portNum.Text, out serverPort))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);

                listening = true;
                listenButton.Enabled = false;


                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

             

                monitorScreen.Invoke((MethodInvoker)delegate
                {
                    monitorScreen.AppendText("Started listening on port: " + serverPort + "\n");
                });

            }
            else
            {


                monitorScreen.Invoke((MethodInvoker)delegate
                {
                    monitorScreen.AppendText("Please check port number \n");
                });
            }
        }
        private void Accept()
        {
            while (listening)
            {
                try
                {
                    Socket newClient = serverSocket.Accept();
                    clientSockets.Add(newClient);
                



                    Thread receiveThread = new Thread(() => Receive(newClient)); // updated
                    receiveThread.Start();

                }
                catch
                {
                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {


                        monitorScreen.Invoke((MethodInvoker)delegate
                        {
                            monitorScreen.AppendText("The socket stopped working.\n");
                        });
                    }

                }
            }
        }
        private void NotifyClientsServerClosing()
        {

            string closingMessage = "Server is closed";
            byte[] buffer = Encoding.Default.GetBytes(closingMessage);

            foreach (var client in ifClientsDict.Values)
            {
                try
                {
                    client.Send(buffer);
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occur during sending
                    monitorScreen.Invoke((MethodInvoker)delegate
                    {
                        monitorScreen.AppendText("Error sending announcement to a client: " + "\n");
                    });
                }
            }

            // Clear dictionaries after notifying all clients
            allClientsDict.Clear();
            spsClientsDict.Clear();
            ifClientsDict.Clear();
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
             // Indicate that the server is shutting down
            if (listening)
            {
                NotifyClientsServerClosing();
                
                
           monitorScreen.Invoke((MethodInvoker)delegate
                {
                    monitorScreen.AppendText("Server shut down.\n");
                });
                listening = false;
                serverSocket.Close();
            }
            terminating = true;
        }


        private void Receive(Socket thisClient) // updated
        {
            bool connected = true;
            string clientUsername = null;  // To store the username of this client

            while (connected && !terminating)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    thisClient.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));

                    if (incomingMessage.StartsWith("myusername: "))
                    {
                        string username = incomingMessage.Substring(12);
                        if (allClientsDict.ContainsKey(username))
                        {

                            monitorScreen.Invoke((MethodInvoker)delegate
                            {
                                monitorScreen.AppendText((username ?? "unknown") + " could not connect to the server due to usage of existing username.\n");
                            });

                            string message = "Username already taken. Could not connect to server. \n";
                            buffer = Encoding.Default.GetBytes(message);
                            thisClient.Send(buffer);

                            // Disconnect this client only
                            thisClient.Close();
                            connected = false;
                        }
                        else
                        {
                            string message = "Connection is established \n";
                            buffer = Encoding.Default.GetBytes(message);
                            thisClient.Send(buffer);

                            allClientsDict[username] = thisClient;
                            clientUsername = username;  // Store this client's username
                            monitorScreen.Invoke((MethodInvoker)delegate
                            {
                                monitorScreen.AppendText("Client " + username + " connected.\n");
                            });

                        }
                    }
                    else if(incomingMessage.StartsWith("Disconnected"))
                    {

                        string myuser = incomingMessage.Substring(18);
                        monitorScreen.Invoke((MethodInvoker)delegate
                        {
                            monitorScreen.AppendText(myuser + " is disconnected from server \n");
                        });
                        thisClient.Close();
                        connected = false;
                        if((allClientsDict.ContainsKey(myuser))) {
                            allClientsDict.Remove(myuser);
                        }
                        if (ifClientsDict.ContainsKey(myuser))
                        {
                            ifClientsDict.Remove(myuser);
                        }
                        if (spsClientsDict.ContainsKey(myuser))
                        {
                            spsClientsDict.Remove(myuser);
                        }
                    }

                    else if (incomingMessage.StartsWith("subscribe if-"))
                    {

                        string myuser = incomingMessage.Substring(13);
                        monitorScreen.Invoke((MethodInvoker)delegate
                        {
                            monitorScreen.AppendText(myuser + " is subscribed to IF100 Channel \n");
                        });
                        ifClientsDict[myuser] = thisClient;
                    }


                    else if (incomingMessage.StartsWith("unsubscribe if-"))
                    {

                        string myuser = incomingMessage.Substring(15);
                        monitorScreen.Invoke((MethodInvoker)delegate
                        {
                            monitorScreen.AppendText(myuser + " is unsubscribed to IF100 Channel \n");
                        });
                        ifClientsDict.Remove(myuser);
                    }
                    else if (incomingMessage.StartsWith("subscribe sps-"))
                    {

                        string myuser = incomingMessage.Substring(14);
                        monitorScreen.Invoke((MethodInvoker)delegate
                        {
                            monitorScreen.AppendText(myuser + " is subscribed to SPS101 Channel \n");
                        });
                        spsClientsDict[myuser] = thisClient;
                    }
                    else if (incomingMessage.StartsWith("unsubscribe sps-"))
                    {

                        string myuser = incomingMessage.Substring(16);
                        monitorScreen.Invoke((MethodInvoker)delegate
                        {
                            monitorScreen.AppendText(myuser + " is unsubscribed to SPS101 Channel \n");
                        });
                        spsClientsDict.Remove(myuser);
                    }
                    else if (incomingMessage.StartsWith("unsubscribe sps-"))
                    {

                        string myuser = incomingMessage.Substring(16);
                        monitorScreen.Invoke((MethodInvoker)delegate
                        {
                            monitorScreen.AppendText(myuser + " is unsubscribed to SPS101 Channel \n");
                        });
                        spsClientsDict.Remove(myuser);
                    }
                    else if (incomingMessage.StartsWith("announcment if- "))
                    {

                        string message = incomingMessage.Substring(16);
                        monitorScreen.Invoke((MethodInvoker)delegate
                        {
                            monitorScreen.AppendText("There is announcment on IF100 channel: " + message + "\n");
                        });

                        foreach (var client in ifClientsDict.Values)
                        {
                            try
                            {
                                buffer = Encoding.Default.GetBytes("IF From: " + message);
                                client.Send(buffer);
                            }
                            catch (Exception ex)
                            {
                                // Handle any exceptions that occur during sending
                                monitorScreen.Invoke((MethodInvoker)delegate
                                {
                                    monitorScreen.AppendText("Error sending announcement to a client: " + ex.Message + "\n");
                                });
                            }
                        }



                    }
                    else if (incomingMessage.StartsWith("announcment sps- "))
                    {

                        string message = incomingMessage.Substring(17);
                        monitorScreen.Invoke((MethodInvoker)delegate
                        {
                            monitorScreen.AppendText("There is announcment on SPS101 channel: " + message + "\n");
                        });

                        foreach (var client in spsClientsDict.Values)
                        {
                            try
                            {
                                buffer = Encoding.Default.GetBytes("SPS From: " + message );
                                client.Send(buffer);
                            }
                            catch (Exception ex)
                            {
                                // Handle any exceptions that occur during sending
                                monitorScreen.Invoke((MethodInvoker)delegate
                                {
                                    monitorScreen.AppendText("Error sending announcement to a client: " + ex.Message + "\n");
                                });
                            }
                        }
                    }
                }
                catch
                {

                    thisClient.Close();
                    clientSockets.Remove(thisClient);
                    if (clientUsername != null)
                    {
                        allClientsDict.Remove(clientUsername);  // Remove this client's username from the list
                    }
                    connected = false;
                }
            }
        }


    }
}
