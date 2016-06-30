using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.TVExample
{
    public class TVOffState : ITVState
    {
        TVContext context;
        public TVOffState(TVContext context)
        {
            this.context = context;
        }

        public void OnPowerButtonPresed()
        {
            Console.WriteLine("Turning TV on");
            context.State = context.TvOnState;
        }
    }
}
