﻿using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace Twitch_Analysis_App.Models
{
    public class IRCClient
    {
        #region Variables

        private string server = null;
        private string nick = null;
        private string password = null;
        private int port = -1;
        private bool isRunning = false;

        private TcpClient client = null;
        private StreamWriter writer = null;
        private StreamReader reader = null;
        private Thread receiveMessageThread = null;

        #endregion

        #region Methods

        public void start()
        {
            if (!this.isCheck()) return;

            try
            {
                client = new TcpClient();
                client.Connect(server, port);

                if (client.Connected)
                {
                    //Init
                    Stream stream = client.GetStream();
                    writer = new StreamWriter(stream);
                    reader = new StreamReader(stream);
                    receiveMessageThread = new Thread(receiveThreadRun);
                    //Start
                    isRunning = true;
                    receiveMessageThread.Start();
                    sendAuthInformation();
                }
                string message = null;
                //I have to send PING to Server every five minute                
                while (client.Connected)
                {
                    if ((message = Console.ReadLine()) == "EXIT")
                        break;
                    sendRawAndFlush(message);
                }
            }
            catch (Exception x)
            {
                comment("Error", x.Message);
            }
            finally
            {
                //End Program
                receiveMessageThread.Interrupt();
                client.Close();
            }
        }

        #endregion

        #region Thread Methods

        private void receiveThreadRun()
        {
            if (reader != null)
            {
                string data = null;
                string[] splitedMessage = null;
                while (client.Connected)
                {
                    data = reader.ReadLine();
                    if (!String.IsNullOrEmpty(data))
                    {
                        comment("Reader", data);
                        splitedMessage = data.Split(' ');
                        if (splitedMessage[0] == "PING")
                            sendRawAndFlush("PONG");
                    }
                }
            }
        }

        #endregion

        #region Writer Methods

        public void sendRaw(string message)
        {
            writer.WriteLine(message);
            comment("Writer", message);
        }

        public void sendRawAndFlush(string message)
        {
            if (writer != null)
            {
                sendRaw(message);
                writer.Flush();
            }
            else
            {
                comment("Writer", "undefined writer stream..");
            }
        }

        private void sendAuthInformation()
        {
            if (writer != null)
            {
                sendRaw($"PASS {password}");
                sendRaw($"NICK {nick}");
                writer.Flush();
            }
            else
            {
                comment("Writer", "undefined writer stream..");
            }
        }

        #endregion

        #region Setter Getter

        public void setNick(string nick)
        {
            if (!String.IsNullOrWhiteSpace(nick))
                this.nick = nick;
            else
                comment("Error", "parmeter 'nick' is null or empty.");
        }
        public void setPassword(string password)
        {
            if (!String.IsNullOrWhiteSpace(password))
                this.password = password;
            else
                comment("Error", "parmeter 'password' is null or empty.");
        }
        public void setServer(string server)
        {
            if (!String.IsNullOrWhiteSpace(server))
                this.server = server;
            else
                comment("Error", "parmeter 'server' is null or empty.");
        }
        public bool IsRunning()
        {
            return this.isRunning;
        }
        public void setPort(int port)
        {
            if (port < 0)
                comment("Error", "port is less than 0");
            else
                this.port = port;
        }
        public int getPort()
        {
            return port;
        }

        #endregion

        #region Check Alerter

        private void comment(string tag, string content)
        {
            Console.WriteLine($"[{tag}] {content}");
        }
        private bool isCheck()
        {
            if (server == null)
            {
                comment("Error", "server is null");
                return false;
            }
            if (nick == null)
            {
                comment("Error", "nick is null");
                return false;
            }
            if (password == null)
            {
                comment("Error", "password is null");
                return false;
            }
            if (port < 0)
            {
                comment("Error", "port is not good value");
                return false;
            }
            return true;
        }

        #endregion
    }
}
