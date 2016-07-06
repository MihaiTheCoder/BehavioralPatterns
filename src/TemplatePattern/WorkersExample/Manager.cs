using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePattern.WorkersExample
{
    public class Manager : Worker
    {
        protected override void GoToWork()
        {
            Console.WriteLine("Get an expensive car, and go to work");
        }
        protected override void Work()
        {
            Console.WriteLine("Convince other people to work");
        }
    }
}
