using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MememntoPattern.IterativeEmployee
{
    public class EmployeeIterativeExample
    {
        public void Run()
        {
            Caretaker caretaker = new Caretaker();
            Employee e = new Employee();
            e.Name = "Ghiuri";
            e.Address = "Stairway to heaven";

            Console.WriteLine("First saved address: {0}", e.Address);
            caretaker.Save(e);

            e.Address = "Highway to hell";

            Console.WriteLine("Second saved address: {0}", e.Address);

            caretaker.Save(e);

            e.Address = "Home of the brave";

            Console.WriteLine("Third saved address: {0}", e.Address);

            caretaker.Save(e);

            e.Address = "Somesing";

            Console.WriteLine("Address before revert: {0}", e.Address);

            caretaker.Revert(e);

            Console.WriteLine("First reverted Address: {0}", e.Address);

            caretaker.Revert(e);

            Console.WriteLine("Second reverted Address: {0}", e.Address);

            caretaker.Revert(e);

            Console.WriteLine("Third reverted Address: {0}", e.Address);

            caretaker.Revert(e);

            Console.WriteLine("Forth reverted Address: {0}", e.Address);

        }
       
    }
}
