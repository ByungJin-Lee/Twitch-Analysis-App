using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch_Analysis_App.Structure
{
    class Log
    {
        public DateTime Time { get; set; }
        public String Source { get; set; }
        public String Content { get; set; }
        public Boolean Warning { get; set; }
    }
}
