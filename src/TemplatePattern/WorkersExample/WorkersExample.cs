using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePattern.WorkersExample
{
    public class WorkersExample
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine("Manager:");
            Manager m = new Manager();
            m.StartWorking();

            Console.WriteLine();
            Console.WriteLine("Construction worker:");
            ConstructionWorker c = new ConstructionWorker();
            c.StartWorking();

            Console.WriteLine();
            Console.WriteLine("Student:");
            Student s = new Student();
            s.StartWorking();
        }
    }
}
