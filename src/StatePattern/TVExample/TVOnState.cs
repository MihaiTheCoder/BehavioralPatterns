using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.TVExample
{
    /// <summary>
    /// Concrete state
    /// </summary>
    public class TVOnState : ITVState
    {
        TVContext context;
        public TVOnState(TVContext context)
        {
            this.context = context;
        }

        public void OnPowerButtonPresed()
        {
            Console.WriteLine("TV turning off");
            context.State = context.TvOffState;
        }
    }
}
