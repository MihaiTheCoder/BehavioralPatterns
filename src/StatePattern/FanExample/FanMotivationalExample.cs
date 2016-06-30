using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatePattern.FanExample
{
    public class FanMotivationalExample
    {   
        public static void Run()
        {
            FanMotivationalContext fanContext = new FanMotivationalContext();

            fanContext.PullChain();

            fanContext.PullChain();

            fanContext.PullChain();

            fanContext.PullChain();

            fanContext.PullChain();

            fanContext.PullChain();

            fanContext.PullChain();

        }
    }

    public class FanMotivationalContext
    {
        private const int OFF = 0;

        private const int S1 = 1;

        private const int S2 = 2;

        private const int S3 = 3;

        private const int S4 = 4;

        int state = OFF;

        public void PullChain()
        {
            if(state == OFF)
            {
                Console.WriteLine("Turning TV to speed 1");
                state = S1;
            }
            else if(state == S1)
            {
                Console.WriteLine("Turning TV to speed 2");
                state = S2;
            }
            else if (state == S2)
            {
                Console.WriteLine("Turning TV to speed 3");
                state = S3;
            }
            else if (state == S3)
            {
                Console.WriteLine("Turning TV to speed 4");
                state = S4;
            }
            else if (state == S4)
            {
                Console.WriteLine("Turning TV OFF");
                state = OFF;
            }
        }

    }
}
