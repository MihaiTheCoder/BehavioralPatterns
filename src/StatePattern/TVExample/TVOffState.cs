using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.TVExample
{
    public class TVOffState : ITVState
    {
        public void OnPowerButtonPresed()
        {
            Console.WriteLine("Turning TV on");
        }
    }
}
