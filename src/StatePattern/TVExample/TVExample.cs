using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.TVExample
{
    public class TVExampleRunner
    {
        public static void Run()
        {
            TVContext context = new TVContext();

            context.OnPowerButtonPresed();

            context.OnPowerButtonPresed();

            context.OnPowerButtonPresed();

            context.OnPowerButtonPresed();
        }
    }
}
