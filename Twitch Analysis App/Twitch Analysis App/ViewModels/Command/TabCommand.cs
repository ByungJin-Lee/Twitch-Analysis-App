using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Twitch_Analysis_App.ViewModels.Command
{
    public class TabCommand : ICommand
    {        
        Action<object> execute = null;
        Func<object, bool> can_execute = null;

        public TabCommand(Action<object> e, Func<object, bool> ce)
        {
            this.execute = e;
            this.can_execute = ce;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }    

        public bool CanExecute(object parameter)
        {
            if(can_execute != null)
            {
                return can_execute(parameter);
            }
            else
            {
                return true;
            }            
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
