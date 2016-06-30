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
            ITVState tvOnState = new TVOnState();
            ITVState tvOffState = new TVOffState();

            TVContext context = new TVContext(tvOffState);

            context.OnPowerButtonPresed();

            context.State = tvOnState;

            context.OnPowerButtonPresed();
        }
    }
}
