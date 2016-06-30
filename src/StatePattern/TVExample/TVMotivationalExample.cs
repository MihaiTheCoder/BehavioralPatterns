using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatePattern.TVExample
{
    public class TVMotivationalExample
    {        
        public static void Run()
        {
            var tvMotivationalContext = new TVMotivationalContext();

            tvMotivationalContext.OnPowerButtonPresed();

            tvMotivationalContext.OnPowerButtonPresed();

            tvMotivationalContext.OnPowerButtonPresed();

            tvMotivationalContext.OnPowerButtonPresed();
        }
    }

    public class TVMotivationalContext
    {
        bool isTvOn = false;

        public void OnPowerButtonPresed()
        {
            if(isTvOn)
            {
                Console.WriteLine("TV turning off");
                isTvOn = false;
            }
            else
            {
                Console.WriteLine("Turning TV on");
                isTvOn = true;
            }
        }
    }
}
