using System;

namespace ChainOfResponssibility.PurchaseExample
{
    public class CheckAuthority
    {
        ManagerPPower manager;
        DirectorPPower director;
        VicePresidentPPower vp;
        PresidentPPower president;

        public CheckAuthority()
        {
            manager = new ManagerPPower();
            director = new DirectorPPower();
            vp = new VicePresidentPPower();
            president = new PresidentPPower();

            manager.Successor = director;
            director.Successor = vp;
            vp.Successor = president;
        }

        public void PrintHowMuchEachCanSpend()
        {
            manager.PrintHowMuchICanSpend();
            director.PrintHowMuchICanSpend();
            vp.PrintHowMuchICanSpend();
            president.PrintHowMuchICanSpend();
        }

        public void SpendMoney()
        {
            string input = "";
            do
            {
                Console.WriteLine("Enter the amount to check who should approve your expenditure.");
                Console.Write(">");
                input = Console.ReadLine();

                if (IsDoulbe(input))
                {
                    double d = double.Parse(input);
                    manager.ProcessRequest(new PurchaseRequest(d, "I am beautifull"));
                }

            } while (!IsExitCode(input));
        }






















        private static bool IsExitCode(string input)
        {
            return "exit".Equals(input, StringComparison.OrdinalIgnoreCase);
        }

        private bool IsDoulbe(string input)
        {
            double x = 0;
            return double.TryParse(input, out x);
        }
        

        public string GetDescriptionOfExample()
        {
            return @"Description of example:
CheckAuthority allows an employee to spend money
 if(manager can approve it) manager will process the request
 if (director can approve it) director will process the request
 if (vice president can approve it) vice president will process the request
 if (president can approve it) president will process the request"; 
        }
    }
}
