using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Twitch_Analysis_App.ViewModels.Command;

namespace Twitch_Analysis_App.ViewModels
{
    class TwitchViewModel
    {
        public ICommand command { get; }

        #region Constructor

        public TwitchViewModel()
        {
            command = new ConnectCommand(execute, canExecute);
        }
        #endregion

        #region Execute&Can
        public bool canExecute(object parmeter)
        {
            //TODO Scan Configuration
            return true;
        }
        public void execute(object parmeter)
        {
            //TODO connect Twicth IRC Server
            MessageBox.Show("Click");
        }
        #endregion
    }
}
