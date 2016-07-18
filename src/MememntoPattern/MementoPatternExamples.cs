using MememntoPattern.CompressedEmployee;
using MememntoPattern.Employee;
using MememntoPattern.EmployeeSerialized;
using MememntoPattern.IterativeEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MememntoPattern
{    
    public class MementoPatternExamples
    {

        public static void Run()
        {
            Console.WriteLine(GetWhenToUse());
            Console.WriteLine(GetActors());
            Console.WriteLine(GetAlternatives());

            GoToNextStep();

            //Basic example
            EmployeeExample empExample = new EmployeeExample();
            empExample.Run();

            GoToNextStep();

            //Limited stack with serialization
            EmployeeSerializedExample empSerExample = new EmployeeSerializedExample();
            empSerExample.Run();

            GoToNextStep();
            
            //Iterative memento
            EmployeeIterativeExample empIterEx = new EmployeeIterativeExample();
            empIterEx.Run();
            GoToNextStep();

            //Basic memento with compression
            EmployeeCompressedExample empComp = new EmployeeCompressedExample();
            empComp.Run();
            //We used gzip encoding in here, but usually, one would use:
            //https://en.wikipedia.org/wiki/Delta_encoding
            //Git goes the middle way, it first stores the objects as they are.
            //and from time to time, it compresses them, by creating pack files
            //http://alblue.bandlem.com/2011/09/git-tip-of-week-objects-and-packfiles.html

            Console.WriteLine(GetPitfalls());
        }

        static string GetWhenToUse()
        {
            return @"When to use:
When you need to be able to track the state of an object,or/and restore previous states as needed
When you cannot use simple operation undo/redo, by saving the commands (when there are side effects to the operations) - example translation
Database transactions.
";
        }



        static string GetAlternatives()
        {
            return @"Alternatives:
Command undo - when operations maybe undone
Iterative Memento - Save the changes, instead of storing the entire state again like GIT";
        }

        static string GetActors()
        {
            return @"Actors:
Originator: object that we want to save. It will create the actual memento.
Caretaker: keeps the mementos
Memento: (Magic cookie) internal state of the object";
        }

        static string GetPitfalls()
        {
            return @"
Can be expensive
Needs to consider deleting history, or how much history it should keep
Exposing information only to memento so that we don't brake encapsulation";
        }

        private static void GoToNextStep()
        {
            Console.ReadKey();
            Console.Clear();
        }
    }
}
