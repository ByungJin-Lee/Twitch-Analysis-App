using System;
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
        private string currentChannel = null;

        private int port = -1;                        

        private bool isConnect = false;
        private bool isJoin = false;        

        private TcpClient client = null;
        private StreamWriter writer = null;
        private StreamReader reader = null;
        private Thread receiveMessageThread = null;        

        public delegate void CommentHandler(string sender, string content, bool warning);
        public CommentHandler logger = null;

        public delegate void ChatEventHandler(string sender, string content);
        public ChatEventHandler onChat;

        public delegate void ControllHandler();
        public ControllHandler OnConnect;
        public ControllHandler OnJoin;
        public ControllHandler OnExit;
        public ControllHandler OnDisconnet;
        #endregion

        #region Methods

        public void start()
        {
            if (!isCheck() || isConnect) return;

            try
            {                
                if (connect())
                {
                    //Init
                    Stream stream = client.GetStream();
                    writer = new StreamWriter(stream);
                    reader = new StreamReader(stream);
                    receiveMessageThread = new Thread(receiveThreadRun);                                        
                    receiveMessageThread.Start();
                    sendAuthInformation();                    
                    //LOOP
                    while (client.Connected) {}
                }                        
            }
            catch (Exception x)
            {
                comment("Connect", $"Message - {x.Message}\nST - {x.StackTrace}", true);
            }
            finally
            {
                disconnect();
            }
        }
        public bool connect()
        {
            client = new TcpClient();            
            var result = client.BeginConnect(server, port, null, null);

            if (result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1)))
            {
                client.EndConnect(result);
                isConnect = true;
                if (OnConnect != null) OnConnect();
                comment("Connect", "Success", false);                
                return true;
            }
            else
            {
                comment("Connect", "Fail...", true);
                return false;
            }            
        }
        public void disconnect()
        {
            if (!isConnect) return;

            receiveMessageThread.Abort();
            writer.Close();
            reader.Close();            
            client.Close();
            isConnect = false;
            if (OnDisconnet != null) OnDisconnet();
        }
        #endregion

        #region IRC Methods

        public void command(string cmd)
        {
            if (cmd.StartsWith("!"))
            {
                chatToChannel(cmd.Substring(1));
            }
            else
            {
                sendRawAndFlush(cmd);
            }
        }
        public void joinChannel(string channel)
        {
            currentChannel = channel;
            if (!String.IsNullOrEmpty(currentChannel) && !isJoin)
            {
                if(sendRawAndFlush("JOIN #" + currentChannel))
                {                    
                    isJoin = true;
                    comment("Channel", "Join Channel", false);
                    if (OnJoin != null) OnJoin();
                }                
            }
            else
            {
                comment("Channel", "Not right condition(already join or channel is null)", true);
            }
        }

        public void outChannel()
        {
            if (isJoin && !String.IsNullOrEmpty(currentChannel))
            {
                sendRawAndFlush("PART #" + currentChannel);
                currentChannel = null;
                isJoin = false;
                comment("Channel", "Out from Channel", false);
                if (OnExit != null) OnExit();
            }
            else
            {
                comment("Channel", "Not right condition(already out or channel is null)", true);
            }
        }

        public void chatToChannel(string message)
        {
            if (!String.IsNullOrEmpty(currentChannel) && isJoin && !String.IsNullOrWhiteSpace(message))
            {
                sendRawAndFlush($"PRIVMSG #{currentChannel} :{message}");
            }
            else
            {
                comment("Channel", "Not right condition(channel is null or message is empty or not join channel", true);
            }
        }

        #endregion

        #region ReceiveThread Methods
        private void receiveThreadRun()
        {
            if (reader != null)
            {
                string data = null;
                string[] splitedMessage = null;
                while (client.Connected && isConnect)
                {
                    data = reader.ReadLine();
                    if (!String.IsNullOrEmpty(data))
                    {                        
                        splitedMessage = data.Split(' ');
                        if (splitedMessage[0] == "PING")
                            sendRawAndFlush("PONG");
                        //Chat Event
                        if (splitedMessage[1] == "PRIVMSG" && onChat != null)
                        {
                            onChat(data.Substring(1, data.IndexOf('!') - 1), data.Substring(data.LastIndexOf(":") + 1));
                        }                            
                        else
                        {
                            comment("Reader", data, false);
                        }                         
                    }
                }
            }
        }

        #endregion

        #region Writer Methods

        public void sendRaw(string message)
        {
            writer.WriteLine(message);
            comment("Writer", message, false);
        }

        public bool sendRawAndFlush(string message)
        {
            if (writer != null)
            {
                sendRaw(message);
                writer.Flush();
                return true;
            }
            else
            {
                comment("Writer", "undefined writer stream..", true);
                return false;
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
                comment("Writer", "undefined writer stream..", true);
            }
        }

        #endregion

        #region Setter Getter

        public void setNick(string nick)
        {
            if (!String.IsNullOrWhiteSpace(nick))
                this.nick = nick;
            else
                comment("Error", "parmeter 'nick' is null or empty.", true);
        }
        public void setPassword(string password)
        {
            if (!String.IsNullOrWhiteSpace(password))
                this.password = password;
            else
                comment("Error", "parmeter 'password' is null or empty.", true);
        }
        public void setServer(string server)
        {
            if (!String.IsNullOrWhiteSpace(server))
                this.server = server;
            else
                comment("Error", "parmeter 'server' is null or empty.", true);
        }        
        public void setPort(int port)
        {
            if (port < 0)
                comment("Error", "port is less than 0", true);
            else
                this.port = port;
        }
        public int getPort()
        {
            return port;
        }

        #endregion

        #region Check Alerter

        private void comment(string tag, string content, bool warning)
        {
            if(logger != null)
                logger(tag, content, warning);
        }        
        private bool isCheck()
        {
            if (server == null)
            {
                comment("Error", "server is null", true);
                return false;
            }
            if (nick == null)
            {
                comment("Error", "nick is null", true);
                return false;
            }
            if (password == null)
            {
                comment("Error", "password is null", true);
                return false;
            }
            if (port < 0)
            {
                comment("Error", "port is not good value", false);
                return false;
            }
            return true;
        }        
        #endregion
    }
}
