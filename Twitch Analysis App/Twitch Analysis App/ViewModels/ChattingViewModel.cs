using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitch_Analysis_App.Models;
using Twitch_Analysis_App.Structure;

namespace Twitch_Analysis_App.ViewModels
{
    class ChattingViewModel
    {
        #region Variables

        private ObservableCollection<Message> messages = new ObservableCollection<Message>();       
        static private IRCClient client = new IRCClient();

        #endregion

        #region Constructor

        public ChattingViewModel()
        {
            client.onChat += onChat;
        }

        #endregion

        #region Methods

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
