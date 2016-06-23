using MememntoPattern.Employee;
using MememntoPattern.EmployeeSerialized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MememntoPattern
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class MementoPatternExamples
    {
        public MementoPatternExamples()
        {
                       
        }

        public void Run()
        {
            Console.WriteLine(GetWhenToUse());
            Console.WriteLine(GetActors());
            Console.WriteLine(GetAlternatives());

            GoToNextStep();

            EmployeeExample empExample = new EmployeeExample();
            empExample.Run();

            GoToNextStep();

            EmployeeSerializedExample empSerExample = new EmployeeSerializedExample();
            empSerExample.Run();

            GoToNextStep();

            Console.WriteLine(GetPitfalls());
        }

        string GetWhenToUse()
        {
            return @"When to use:
When you need to be able to track the state of an object,or/and restore previous states as needed
When you cannot use simple operation undo/redo, by saving the commands (when there are side effects to the operations) - example translation
Database transactions.
";
        }

        

        string GetAlternatives()
        {
            return @"Alternatives:
Command undo - when operations maybe undone
Iterative Memento - Save the changes, instead of storing the entire state again like GIT";
        }

        string GetActors()
        {
            return @"Actors:
Originator: object that we want to save. It will create the actual memento.
Caretaker: keeps the mementos
Memento: (Magic cookie) internal state of the object";
        }

        string GetPitfalls()
        {
            return @"
Can be expensive
Deltes/history
Exposing information only to memento so that we don't brake encapsulation";
        }

        private static void GoToNextStep()
        {
            Console.ReadKey();
            Console.Clear();
        }
    }
}
