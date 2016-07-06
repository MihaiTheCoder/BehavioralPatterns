using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePattern.WorkersExample
{
    public class ConstructionWorker : Worker
    {
        protected override void GoToWork()
        {
            Console.WriteLine("Buy some beers");
            base.GoToWork();
        }
        protected override void Work()
        {
            Console.WriteLine("If nobody is around, just look around, if boss is around work a little bit");
        }
    }
}
