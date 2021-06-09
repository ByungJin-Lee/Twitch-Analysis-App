using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
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

        #region Collection
        delegate void Add();
        static private ObservableCollection<Log> logs = new ObservableCollection<Log>();
        public ObservableCollection<Log> LogCollection {
            get{
                return logs;
            } }
        #endregion

        #region Constructor

        public TwitchViewModel()
        {
            connectCommand = new ConnectCommand(connectExecute, canConnectExecute);
            enterCommand = new EnterCommand(enterExecute, canEnterExecute);
        }
        #endregion

        #region Execute&Can
        public bool canConnectExecute(object parmeter)
        {
            //TODO Scan Configuration
            return true;
        }
        public void connectExecute(object parmeter)
        {
            //TODO connect Twicth IRC Server
            ChattingViewModel.connect();
        }
        public bool canEnterExecute(object parameter)
        {
            return true;
        }
        public void enterExecute(object parameter)
        {            
            ChattingViewModel.join((string)parameter);
        }
        #endregion

        #region Log Methods
        static public void addLog(Log log)
        {
            Dispatcher.CurrentDispatcher.Invoke(() =>
            {
                logs.Add(log);
            });            
        }
        #endregion
    }
}
