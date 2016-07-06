using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePattern.WorkersExample
{
    /// <summary>
    /// Framework class
    /// </summary>
    public abstract class Worker
    {
        public void StartWorking()
        {
            WakeUpAndDrinkCoffee();
            TakeAShower();
            GetDressed();
            GoToWork();
            Work();
        }

        protected virtual void WakeUpAndDrinkCoffee()
        {
            Console.WriteLine("Wake up and drink coffee normally");
        }

        protected virtual void TakeAShower()
        {
            Console.WriteLine("Take a shower");
        }

        protected virtual void GetDressed()
        {
            Console.WriteLine("Get dressed");
        }

        protected virtual void GoToWork()
        {
            Console.WriteLine("Go to work");
        }

        protected abstract void Work();
    }
}
