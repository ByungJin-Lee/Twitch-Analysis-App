using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows.Data;
using System.Windows.Input;
using Twitch_Analysis_App.Models;
using Twitch_Analysis_App.Structure;
using Twitch_Analysis_App.ViewModels.Command;

namespace Twitch_Analysis_App.ViewModels
{
    class TwitchViewModel : INotifyPropertyChanged
    {
        #region Command
        public ICommand connectCommand { get; }
        public ICommand enterCommand { get; }
        #endregion

        #region Variables
        private readonly object _lock = new object();
        private IRCClient client = null;
        private Thread irc_worker = null;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Status
        public bool isConnect = false;
        public bool IsConnect { 
            set
            {
                if (isConnect != value)
                {
                    isConnect = value;
                    OnStatusChange("IsConnect");
                }
            }
            get
            {
                return isConnect;
            }
        }
        public bool isJoin = false;
        public bool IsJoin
        {
            set
            {
                if(isJoin != value)
                {
                    isJoin = value;
                    OnStatusChange("IsJoin");
                }
            }
            get
            {
                return isJoin;
            }
        }
        public string channel = "";
        public string Channel
        {
            set
            {
                if(channel != value)
                {
                    channel = value;
                    OnStatusChange("Channel");
                }
            }
            get
            {
                return channel;
            }
        }
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
            //Event
            client.logger += write_log;
            client.onChat += ChattingViewModel.onChat;
            client.OnExit += onExit;
            client.OnJoin += onJoin;
            client.OnDisconnet += onDisconnect;
            client.OnConnect += onConnect;

            BindingOperations.EnableCollectionSynchronization(logs, _lock);            

            connectCommand = new ConnectCommand(connectExecute, canConnectExecute);
            enterCommand = new EnterCommand(enterExecute, canEnterExecute);            
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
            if(!isConnect)
            {
                client.setServer(Configuration.IRC_IP);
                client.setNick(Configuration.NICK);
                client.setPassword(Configuration.Auth_irc_token);
                client.setPort(6667);
                irc_worker = new Thread(client.start);
                irc_worker.Start();
            }
            else
            {
                client.disconnect();
            }
        }
        public bool canEnterExecute(object parameter)
        {            
            return true;
        }
        public void enterExecute(object parameter)
        {
            if (!isJoin)
            {
                Channel = (string)parameter;
                client.joinChannel(channel);
            }
            else
            {                
                client.outChannel();                
            }
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

        #region Event
        public void onConnect()
        {
            IsConnect = true;
        }
        public void onDisconnect()
        {
            IsConnect = false;
        }
        public void onJoin()
        {
            IsJoin = true;
        }
        public void onExit()
        {
            IsJoin = false;
            Channel = "";
        }
        public void OnStatusChange(string property_name)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property_name));
            }
        }
        #endregion
    }
}
