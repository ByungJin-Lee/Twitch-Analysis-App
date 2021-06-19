﻿using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Data;
using System.Windows.Input;
using Twitch_Analysis_App.Models;
using Twitch_Analysis_App.Structure;
using Twitch_Analysis_App.ViewModels.Command;

namespace Twitch_Analysis_App.ViewModels
{
    class TwitchViewModel
    {
        #region Command
        public ICommand connectCommand { get; }
        public ICommand enterCommand { get; }
        #endregion

        #region Variables
        private readonly object _lock = new object();
        private IRCClient client = null;
        private Thread irc_worker = null;
        #endregion

        #region Collection        
        static public ObservableCollection<Log> logs = new ObservableCollection<Log>();
        public ObservableCollection<Log> LogCollection {
            get{
                return logs;
            } }
        #endregion

        #region Constructor & Destructor
        public TwitchViewModel()
        {
            client = new IRCClient();
            client.logger += write_log;            

            BindingOperations.EnableCollectionSynchronization(logs, _lock);            

            connectCommand = new ConnectCommand(connectExecute, canConnectExecute);
            enterCommand = new EnterCommand(enterExecute, canEnterExecute);            
        }    
        ~TwitchViewModel()
        {
            if(client != null)
            {
                client.stop();
            }
        }
        #endregion

        #region Execute&Can
        public bool canConnectExecute(object parmeter)
        {
            //TODO Scan Configuration
            if (client != null && logs != null)
            {
                return true;
            }
            return false;
        }
        public void connectExecute(object parmeter)
        {
            //TODO connect Twicth IRC Server
            client.setServer(Configuration.IRC_IP);
            client.setNick(Configuration.NICK);
            client.setPassword(Configuration.Auth_irc_token);
            client.setPort(6667);
            irc_worker = new Thread(client.start);
            irc_worker.Start();            
        }
        public bool canEnterExecute(object parameter)
        {            
            return true;
        }
        public void enterExecute(object parameter)
        {            
            client.onChat += ChattingViewModel.onChat;
            client.joinChannel((string)parameter);
        }
        #endregion

        #region IRC_Logger
        public void write_log(string tag, string content, bool warning)
        {            
            logs.Add(new Log()
            {
                Time = DateTime.Now,
                Content = content,
                Source = tag,
                Warning = warning
            });            
        }
        #endregion
    }
}
