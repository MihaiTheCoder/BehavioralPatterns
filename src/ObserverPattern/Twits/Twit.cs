using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObserverPattern.Twits
{
    public class Twit
    {
        public TwitUser Emiter { get; set; }

        public string Message { get; set; }
    }
}
