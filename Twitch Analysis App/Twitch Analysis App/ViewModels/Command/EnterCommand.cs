using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Twitch_Analysis_App.ViewModels.Command
{
    class EnterCommand : ICommand
    {
        #region Variables
        public event EventHandler CanExecuteChanged;
        private Action<object> work = null;
        private Func<object, bool> judge = null;
        #endregion

        #region Constructor
        public EnterCommand(Action<object> w, Func<object, bool> j)
        {
            work = w;
            judge = j;
        }
        #endregion


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
            if(work != null)
            {
                work(parameter);
            }
        }
    }
}
