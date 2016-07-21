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

            //This is the first example where a state may not execute all transitions
            //There is an active debate if this violates liskov substitution principle or not -> https://en.wikipedia.org/wiki/Liskov_substitution_principle            
            //but leaving that asside, assuming we will have to add another transition availalable that can be executed only from one state
            //we will have to modify all the existing states, just to throw the exception.
            
            //To view what are the allowed transitions, is very hard when using state pattern with roles
        }
    }

    /// <summary>
    /// State interface
    /// </summary>
    public interface IScrumState
    {
        void RemoveFromBacklog();

        void MoveToBacklog();

        void StartImplementation();

        void AcceptanceTestsFail();

        void AcceptanceTestsPassed();

        void CodeFinishedAndUnitTestsPassed();
    }

    /// <summary>
    /// Context
    /// User story states: New, Active, Resolved, Closed, Removed
    /// Actions on user stories: 
    /// Create - creates a new user story in state New
    /// RemoveFromBacklog - moves a user story from state New to State removed
    /// StartImplementation - moves user story from state New to state Active
    /// MoveToBacklog - moves user story from state Active/Removed to state New
    /// CodeFinishedAndUnitTestsPassed - move user story from state Active to state Resolved 
    /// AcceptanceTestsFail - move user story from state Resolved to state Active
    /// AcceptanceTestsPassed - moves user story from state Resolved to state Closed
    /// </summary>
    public class UserStory
    {
        public IScrumState State { get; set; }

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

        public void CodeFinishedAndUnitTestsPassed()
        {
            State.CodeFinishedAndUnitTestsPassed();
        }
    }

    /// <summary>
    /// Concrete State
    /// </summary>
    internal class ScrumStateNew : IScrumState
    {
        private UserStory userStory;

        public ScrumStateNew(UserStory userStory)
        {
            this.userStory = userStory;
        }

        public void AcceptanceTestsFail()
        {
            //throw the exception
            Console.WriteLine("Implementation did not start yet, probably that's why the tests are failing");
        }

        public void AcceptanceTestsPassed()
        {
            //throw the exception
            Console.WriteLine("Development didn't even started, you should check your tests");
        }

        public void CodeFinishedAndUnitTestsPassed()
        {
            //throw the exception
            Console.WriteLine("Before you can finish the code, you should have started implementation"); 
        }

        public void MoveToBacklog()
        {
            //throw the exception
            Console.WriteLine("Already in backlog"); 
        }

        public void RemoveFromBacklog()
        {
            Console.WriteLine("User story removed");
            userStory.State = userStory.Removed;
        }

        public void StartImplementation()
        {
            Console.WriteLine("Started work on User story: {0}", userStory.Name);
            userStory.State = userStory.Active;
        }
    }

    /// <summary>
    /// Concrete State
    /// </summary>
    internal class ScrumStateActive : IScrumState
    {
        private UserStory userStory;

        public ScrumStateActive(UserStory userStory)
        {
            this.userStory = userStory;
        }

        public void AcceptanceTestsFail()
        {
            //throw the exception
            Console.WriteLine("Implementation is not done yet, probably that's why tests are failing");
        }

        public void AcceptanceTestsPassed()
        {
            //throw the exception
            Console.WriteLine("Development is not yet done");
        }

        public void CodeFinishedAndUnitTestsPassed()
        {
            Console.WriteLine("I'll notify the testers!");
            userStory.State = userStory.Resolved;
        }

        public void MoveToBacklog()
        {
            Console.WriteLine("Moved userstory to backlog");
            userStory.State = userStory.New;
        }

        public void RemoveFromBacklog()
        {
            //throw the exception
            Console.WriteLine("You must first move the item to backlog");
        }

        public void StartImplementation()
        {
            //throw the exception
            Console.WriteLine("You can start work only on user stories that are new, current user story state is: {0}", userStory.State);
        }
    }

    /// <summary>
    /// Concrete State
    /// </summary>
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

        public void CodeFinishedAndUnitTestsPassed()
        {
            //throw the exception
            Console.WriteLine("The item was already resolved");
        }

        public void MoveToBacklog()
        {
            //throw the exception
            Console.WriteLine("Item was already resolved, it can be moved to backlog, only if the acceptance tests failed");
        }

        public void RemoveFromBacklog()
        {
            //throw the exception
            Console.WriteLine(@"The item was already resolved, it can be deleted only if the acceptance tests failed and moved to backlog");
        }

        public void StartImplementation()
        {
            //throw the exception
            Console.WriteLine("You can start work only on user stories that are new, current user story state is: {0}", userStory.State);
        }
    }

    /// <summary>
    /// Concrete State
    /// </summary>
    internal class ScrumStateClosed : IScrumState
    {
        private UserStory userStory;

        public ScrumStateClosed(UserStory userStory)
        {
            this.userStory = userStory;
        }

        public void AcceptanceTestsFail()
        {
            //throw the exception
            Console.WriteLine("User story is already closed");
        }

        public void AcceptanceTestsPassed()
        {
            //throw the exception
            Console.WriteLine("User story is already closed");
        }

        public void CodeFinishedAndUnitTestsPassed()
        {
            //throw the exception
            Console.WriteLine("Item was already closed");
        }

        public void MoveToBacklog()
        {
            //throw the exception
            Console.WriteLine("Item was already closed, cannot move to new state");
        }

        public void RemoveFromBacklog()
        {
            //throw the exception
            Console.WriteLine("Once a User Story is Closed, it cannot be removed");
        }

        public void StartImplementation()
        {
            //throw the exception
            Console.WriteLine("You can start work only on user stories that are new, current user story state is: {0}", userStory.State);
        }
    }

    /// <summary>
    /// Concrete State
    /// </summary>
    internal class ScrumStateRemoved : IScrumState
    {
        private UserStory userStory;

        public ScrumStateRemoved(UserStory userStory)
        {
            this.userStory = userStory;
        }

        public void AcceptanceTestsFail()
        {
            //throw the exception
            Console.WriteLine("Item was removed, you can only move it to backlog again");
        }

        public void AcceptanceTestsPassed()
        {
            //throw the exception
            Console.WriteLine("Item was removed, you can only move it to backlog again");
        }

        public void CodeFinishedAndUnitTestsPassed()
        {
            //throw the exception         
        }

        public void MoveToBacklog()
        {
            Console.WriteLine("Moved userstory to backlog");
            userStory.State = userStory.New;
        }

        public void RemoveFromBacklog()
        {
            //throw the exception
            Console.WriteLine("Once a User Story is Closed, it cannot be removed");
        }

        public void StartImplementation()
        {
            //throw the exception
            Console.WriteLine("You can start work only on user stories that are new, current user story state is: {0}", userStory.State);
        }
    }
}
