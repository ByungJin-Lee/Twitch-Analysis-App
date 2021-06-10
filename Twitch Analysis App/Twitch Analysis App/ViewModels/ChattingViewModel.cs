using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;
using Twitch_Analysis_App.Models;
using Twitch_Analysis_App.Structure;

namespace Twitch_Analysis_App.ViewModels
{
    class ChattingViewModel
    {
        #region Variables

        static private readonly object _lock = new object();
        static private ObservableCollection<Message> messages = null;

        static public ObservableCollection<Message> MessageCollection { get
            {                
                return messages;
            } }

        #endregion

        #region Constructor

        public ChattingViewModel()
        {
                      
        }
        #endregion

        #region Methods
        
        static public void init()
        {
            messages = new ObservableCollection<Message>();
            BindingOperations.EnableCollectionSynchronization(messages, _lock);            
        }

        #endregion

        #region Event

        static public void onChat(string sender, string content)
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
