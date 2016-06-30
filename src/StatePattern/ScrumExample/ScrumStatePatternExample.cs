using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatePattern.ScrumExample
{
    public class ScrumStatePatternExample
    {
        public static void Run()
        {
            UserStory userStory = new UserStory();
            userStory.RemoveFromBacklog();
            userStory.MoveToBacklog();
            userStory.StartImplementation();
            userStory.AcceptanceTestsFail();
            userStory.StartImplementation();
            userStory.AcceptanceTestsPassed();

            userStory.StartImplementation();
        }
    }

    public interface IScrumState
    {
        void RemoveFromBacklog();

        void MoveToBacklog();

        void StartImplementation();

        void AcceptanceTestsFail();

        void AcceptanceTestsPassed();

        void CodeFinishedAnUnitTestsPassed();
    }

    public class UserStory
    {
        public IScrumState New { get; private set; }
        public IScrumState Active { get; private set; }
        public IScrumState Resolved { get; private set; }
        public IScrumState Closed { get; private set; }
        public IScrumState Removed { get; private set; }

        public UserStory()
        {
            New = new ScrumStateNew(this);
            Active = new ScrumStateActive(this);
            Resolved = new ScrumStateResolved(this);
            Closed = new ScrumStateClosed(this);
            Removed = new ScrumStateRemoved(this);

            State = New;
        }
        public IScrumState State { get; set; }
        public int Name { get; internal set; }

        public void AcceptanceTestsFail()
        {
            State.AcceptanceTestsFail();
        }

        public void AcceptanceTestsPassed()
        {
            State.AcceptanceTestsPassed();
        }
        public void MoveToBacklog()
        {
            State.MoveToBacklog();
        }

        public void RemoveFromBacklog()
        {
            State.RemoveFromBacklog();
        }

        public void StartImplementation()
        {
            State.StartImplementation();
        }

        public void CodeFinishedAnUnitTestsPassed()
        {
            State.CodeFinishedAnUnitTestsPassed();
        }
    }

    internal class ScrumStateNew : IScrumState
    {
        private UserStory userStory;

        public ScrumStateNew(UserStory userStory)
        {
            this.userStory = userStory;
        }

        public void AcceptanceTestsFail()
        {
            Console.WriteLine("Implementation did not start yet, probably that's why the tests are failing");
        }

        public void AcceptanceTestsPassed()
        {
            Console.WriteLine("Development didn't even started, you should check your tests");
        }

        public void CodeFinishedAnUnitTestsPassed()
        {
            Console.WriteLine("Before you can finish the code, you should have started implementation"); 
        }

        public void MoveToBacklog()
        {
            Console.WriteLine("Already in backlog"); 
        }

        public void RemoveFromBacklog()
        {
            Console.WriteLine("User story removed");
        }

        public void StartImplementation()
        {
            Console.WriteLine("Started work on User story: {0}", userStory.Name);
            userStory.State = userStory.Active;
        }
    }

    internal class ScrumStateActive : IScrumState
    {
        private UserStory userStory;

        public ScrumStateActive(UserStory userStory)
        {
            this.userStory = userStory;
        }

        public void AcceptanceTestsFail()
        {
            Console.WriteLine("Implementation is not done yet, probably that's why tests are failing");
        }

        public void AcceptanceTestsPassed()
        {
            Console.WriteLine("Development is not yet done");
        }

        public void CodeFinishedAnUnitTestsPassed()
        {
            Console.WriteLine("I'll notify the testers!");
            userStory.State = userStory.Resolved;
        }

        public void MoveToBacklog()
        {
            Console.WriteLine("Moved userstory to backlog");
        }

        public void RemoveFromBacklog()
        {
            Console.WriteLine("You must first move the item to backlog");
        }

        public void StartImplementation()
        {

            Console.WriteLine("You can start work only on user stories that are new, current user story state is: {0}", userStory.State);
        }
    }

    internal class ScrumStateResolved : IScrumState
    {
        private UserStory userStory;

        public ScrumStateResolved(UserStory userStory)
        {
            this.userStory = userStory;
        }

        public void AcceptanceTestsFail()
        {
            Console.WriteLine("We'll notify the devs, that they did a bad job");
            userStory.State = userStory.Active;
        }

        public void AcceptanceTestsPassed()
        {
            Console.WriteLine("Cool, we'll close the us");
            userStory.State = userStory.Closed;
        }

        public void CodeFinishedAnUnitTestsPassed()
        {
            Console.WriteLine("The item was already resolved");
        }

        public void MoveToBacklog()
        {
            Console.WriteLine("Item was already resolved, it can be moved to backlog, only if the acceptance tests failed");
        }

        public void RemoveFromBacklog()
        {
            Console.WriteLine(@"The item was already resolved, it can be deleted only if the acceptance tests failed and moved to backlog");
        }

        public void StartImplementation()
        {
            Console.WriteLine("You can start work only on user stories that are new, current user story state is: {0}", userStory.State);
        }
    }

    internal class ScrumStateClosed : IScrumState
    {
        private UserStory userStory;

        public ScrumStateClosed(UserStory userStory)
        {
            this.userStory = userStory;
        }

        public void AcceptanceTestsFail()
        {
            Console.WriteLine("User story is already closed");
        }

        public void AcceptanceTestsPassed()
        {
            Console.WriteLine("User story is already closed");
        }

        public void CodeFinishedAnUnitTestsPassed()
        {
            Console.WriteLine("Item was already closed");
        }

        public void MoveToBacklog()
        {
            Console.WriteLine("Item was already closed, cannot move to new state");
        }

        public void RemoveFromBacklog()
        {
            Console.WriteLine("Once a User Story is Closed, it cannot be removed");
        }

        public void StartImplementation()
        {
            Console.WriteLine("You can start work only on user stories that are new, current user story state is: {0}", userStory.State);
        }
    }

    internal class ScrumStateRemoved : IScrumState
    {
        private UserStory userStory;

        public ScrumStateRemoved(UserStory userStory)
        {
            this.userStory = userStory;
        }

        public void AcceptanceTestsFail()
        {
            Console.WriteLine("Item was removed, you can only move it to backlog again");
        }

        public void AcceptanceTestsPassed()
        {
            Console.WriteLine("Item was removed, you can only move it to backlog again");
        }

        public void CodeFinishedAnUnitTestsPassed()
        {
         
        }

        public void MoveToBacklog()
        {
            Console.WriteLine("Moved userstory to backlog");
            userStory.State = userStory.New;
        }

        public void RemoveFromBacklog()
        {
            Console.WriteLine("Once a User Story is Closed, it cannot be removed");
        }

        public void StartImplementation()
        {
            Console.WriteLine("You can start work only on user stories that are new, current user story state is: {0}", userStory.State);
        }
    }
}
