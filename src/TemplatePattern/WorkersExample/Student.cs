using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePattern.WorkersExample
{
    /// <summary>
    /// Concrete class
    /// </summary>
    public class Student : Worker
    {
        protected override void WakeUpAndDrinkCoffee()
        {
            Console.WriteLine("Not yet..");
            Console.WriteLine("Not yet...");
            Console.WriteLine("Not yet...");
            base.WakeUpAndDrinkCoffee();
        }
        
        protected override void Work()
        {
            Console.WriteLine("If session, start learning, visit 9Gag, learn again");
        }
    }
}
