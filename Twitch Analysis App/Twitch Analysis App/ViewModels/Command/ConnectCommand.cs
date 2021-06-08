using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Twitch_Analysis_App.ViewModels.Command
{
    class ConnectCommand : ICommand
    {

        public ConnectCommand(Action<object> w, Func<object, bool> j)
        {
            work = w;
            judge = j;
        }


        Action<object> work = null;
        Func<object, bool> judge = null;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if(judge != null)
            {
                return judge(parameter);
            }
            else
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            work(parameter);
        }
    }
}
