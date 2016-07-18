using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MememntoPattern.CompressedEmployee
{
    public class EmployeeCompressedExample
    {
        public void Run()
        {
            CaretakerObjectCompressed caretaker = new CaretakerObjectCompressed();
            CaretakerListCompressed caretaker2 = new CaretakerListCompressed();
            Employee e = new Employee();
            e.Name = "Ghiuri";
            e.Address = "Stairway to heaven";

            Console.WriteLine("First saved address: {0}", e.Address);
            caretaker.Save(e);
            caretaker2.Save(e);

            e.Address = "Highway to hell";

            Console.WriteLine("Second saved address: {0}", e.Address);

            caretaker.Save(e);
            caretaker2.Save(e);

            e.Address = "Home of the brave";

            Console.WriteLine("Third saved address: {0}", e.Address);

            caretaker.Save(e);
            caretaker2.Save(e);

            e.Address = "Somesing";

            Console.WriteLine("Address before revert: {0}", e.Address);

            caretaker.Revert(e);
            caretaker2.Revert(e);

            Console.WriteLine("First reverted Address: {0}", e.Address);

            caretaker.Revert(e);
            caretaker2.Revert(e);

            Console.WriteLine("Second reverted Address: {0}", e.Address);

            caretaker.Revert(e);
            caretaker2.Revert(e);

            Console.WriteLine("Third reverted Address: {0}", e.Address);

            caretaker.Revert(e);
            caretaker2.Revert(e);

            Console.WriteLine("Forth reverted Address: {0}", e.Address);

            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 500; i++)
            {
                e.Address = e.Address + " Le ciupi";
                
                caretaker2.Save(e);
            }
            sw.Stop();
            Console.WriteLine("It took {0} to save 500 versions of the employee object", sw.Elapsed.ToString());

            caretaker2.PrintSizeOfFile();
            caretaker2.PrintSizeOfDecompressedHistory();

            sw = Stopwatch.StartNew();
            for (int i = 0; i < 500; i++)
            {                
                caretaker2.Revert(e);                
            }
            sw.Stop();

            Console.WriteLine("It took {0} to revert 500 versions of the employee object", sw.Elapsed.ToString());
        }        

    }
}
