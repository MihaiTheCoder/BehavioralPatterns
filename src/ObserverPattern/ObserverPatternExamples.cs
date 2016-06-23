using ObserverPattern.Twits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObserverPattern
{
    
    public class ObserverPatternExamples
    {
        public static void Run()
        {
            ObservableTwitsExample obsTwits = new ObservableTwitsExample();
            obsTwits.Run();
        }
    }
}
