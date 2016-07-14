using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponssibility.PurchaseExample
{
    public abstract class PurchasePower
    {
        protected const double BaseUnit = 500;        

        public PurchasePower Successor { get; set; }

        protected abstract double MaximumToSpend { get; }

        protected abstract string Role { get; }

        public void ProcessRequest(PurchaseRequest request)
        {
            if (request.Ammount <= MaximumToSpend)
            {
                Console.WriteLine("{0} will approve ${1}", Role, request.Ammount);
            }
            else
            {
                if (Successor != null)
                    Successor.ProcessRequest(request);
                else
                    Console.WriteLine("No one has that much money");
            }
        }

        public void PrintHowMuchICanSpend()
        {
            Console.WriteLine("As a {0} I can spend at most {1}", Role, MaximumToSpend);
        }
    }    
}
