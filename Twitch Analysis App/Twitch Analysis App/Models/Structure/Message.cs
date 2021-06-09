using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch_Analysis_App.Structure
{
    class Message
    {
        public Boolean IsMine { get; set; }
        public String Name { get; set; }
        public DateTime Time { get; set; }
        public String Chat { get; set; }
    }
}
