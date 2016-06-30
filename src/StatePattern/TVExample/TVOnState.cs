using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.TVExample
{
    public class TVOnState : ITVState
    {
        public void OnPowerButtonPresed()
        {
            Console.WriteLine("TV turning off");
        }
    }
}
