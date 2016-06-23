using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MememntoPattern.EmployeeSerialized
{
    public class EmployeeSerializedExample
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

            Console.WriteLine("Last saved address: {0}", e.Address);

            caretaker.Save(e);

            e.Address = "Home of the brave"; // No save, no home, no address

            Console.WriteLine("Address before revert: {0}", e.Address);

            caretaker.Revert(e);

            Console.WriteLine("First reverted Address: {0}", e.Address);

            caretaker.Revert(e);

            Console.WriteLine("Second reverted Address: {0}", e.Address);

        }
       
    }
}
