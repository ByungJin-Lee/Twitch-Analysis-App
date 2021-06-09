using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Twitch_Analysis_App.Models;
using Twitch_Analysis_App.Structure;

namespace Twitch_Analysis_App.ViewModels
{
    class ChattingViewModel
    {
        #region Variables

        static private ObservableCollection<Message> messages = new ObservableCollection<Message>();       
        static private IRCClient client = new IRCClient();

        static public ObservableCollection<Message> MessageCollection { get
            {                
                return messages;
            } }

        #endregion

        #region Constructor

        public ChattingViewModel()
        {
            client.onChat += onChat;
            client.logger += alert;
        }
        #endregion

        #region Methods
        static public void connect()
        {                        
            //Configuration File    
            client.setServer(Configuration.IRC_IP);
            client.setNick(Configuration.NICK);
            client.setPassword(Configuration.Auth_irc_token);
            client.setPort(6667);
            Thread chatThread = new Thread(client.start);
            chatThread.Start();                       
        }
        static public void join(string channel)
        {
            client.joinChannel(channel);
        }

        static public void alert(string tag, string content, bool warning)
        {            
            TwitchViewModel.addLog(new Log()
            {
                Time = DateTime.Now,
                Content = content,
                Source = tag,
                Warning = warning
            });
        }
        #endregion

        #region Event

        public void onChat(string sender, string content)
        {
            //Add Message to Messages
            messages.Add(new Message()
            {
                Time = DateTime.Now,
                Chat = content,
                Name = sender,
                IsMine = false,
            });
        }

        #endregion
    }
}
