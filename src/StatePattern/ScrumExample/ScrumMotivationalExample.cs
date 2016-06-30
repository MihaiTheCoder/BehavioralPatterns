using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatePattern.ScrumExample
{
    public class ScrumMotivationalExample
    {
        public static void Run()
        {
            ScrumMotivationalContext context = new ScrumMotivationalContext();

            UserStoryMotivational userStory = new UserStoryMotivational();
            context.Create(userStory);
            context.RemoveFromBacklog(userStory);
            context.MoveToBacklog(userStory);
            context.StartImplementation(userStory);
            context.AcceptanceTestsFail(userStory);
            context.StartImplementation(userStory);
            context.AcceptanceTestsPassed(userStory);

            context.StartImplementation(userStory);
        }
    }

    /// <summary>
    /// User story states: New, Active, Resolved, Closed, Removed
    /// Actions on user stories: 
    /// Create - creates a new user story in state New
    /// RemoveFromBacklog - moves a user story from state New to State removed
    /// StartImplementation - moves user story from state New to state Active
    /// MoveToBacklog - moves user story from state Active/Removed to state New
    /// CodeFinishedAnUnitTestsPassed - move user story from state Active to state Resolved 
    /// AcceptanceTestsFail - move user story from state Resolved to state Active
    /// AcceptanceTestsPassed - moves user story from state Resolved to state Closed
    /// </summary>
    public class ScrumMotivationalContext
    {

        public void Create(UserStoryMotivational userStory)
        {
            userStory.State = UserStoryState.New;
        }

        public void RemoveFromBacklog(UserStoryMotivational userStory)
        {
            switch (userStory.State)
            {
                case UserStoryState.New:
                    Console.WriteLine("User story removed");
                    userStory.State = UserStoryState.Removed;
                    break;
                case UserStoryState.Removed:
                    Console.WriteLine("Already in removed state");
                    break;
                case UserStoryState.Closed:
                    Console.WriteLine("Once a User Story is Closed, it cannot be removed");
                    break;
                case UserStoryState.Resolved:
                    Console.WriteLine(@"The item was already resolved, it can be deleted only if the acceptance tests failed and moved to backlog");                    
                    break;
                case UserStoryState.Active:
                    Console.WriteLine("You must first move the item to backlog");
                    break;          
                default:
                    throw new Exception(string.Format("Cannot process user stories that are in {0} state", userStory.State));
            }            
        }

        public void StartImplementation(UserStoryMotivational userStory)
        {
            switch (userStory.State)
            {
                case UserStoryState.New:
                    Console.WriteLine("Started work on User story: {0}", userStory.Name);
                    userStory.State = UserStoryState.Active;
                    break;
                case UserStoryState.Removed:
                case UserStoryState.Active:
                case UserStoryState.Resolved:
                case UserStoryState.Closed:
                    Console.WriteLine("You can start work only on user stories that are new, current user story state is: {0}", userStory.State);
                    break;
                default:
                    throw new Exception(string.Format("Cannot process user stories that are in {0} state", userStory.State));                    
            }
        }

        public void MoveToBacklog(UserStoryMotivational userStory)
        {
            switch (userStory.State)
            {
                case UserStoryState.New:
                    Console.WriteLine("Already in backlog");
                    break;
                case UserStoryState.Removed:
                case UserStoryState.Active:
                    Console.WriteLine("Moved userstory to backlog");
                    userStory.State = UserStoryState.New;
                    break;
                case UserStoryState.Resolved:
                    Console.WriteLine("Item was already resolved, it can be moved to backlog, only if the acceptance tests failed");
                    break;
                case UserStoryState.Closed:
                    Console.WriteLine("Item was already closed, cannot move to new state");
                    break;
                default:
                    throw new Exception(string.Format("Cannot process user stories that are in {0} state", userStory.State));
            }
        }

        public void CodeFinishedAnUnitTestsPassed(UserStoryMotivational userStory)
        {
            switch (userStory.State)
            {
                case UserStoryState.New:
                    Console.WriteLine("Before you can finish the code, you should have started implementation");
                    break;
                case UserStoryState.Active:
                    Console.WriteLine("I'll notify the testers!");
                    userStory.State = UserStoryState.Resolved;
                    break;
                case UserStoryState.Resolved:
                    Console.WriteLine("The item was already resolved");
                    break;
                case UserStoryState.Closed:
                    Console.WriteLine("Item was already closed");
                    break;
                case UserStoryState.Removed:
                    Console.WriteLine("Item was removed, you can only move it to backlog again");
                    break;
                default:
                    throw new Exception(string.Format("Cannot process user stories that are in {0} state", userStory.State));                    
            }
        }

        public void AcceptanceTestsFail(UserStoryMotivational userStory)
        {
            switch (userStory.State)
            {
                case UserStoryState.New:
                    Console.WriteLine("Implementation did not start yet, probably that's why the tests are failing");
                    break;
                case UserStoryState.Active:
                    Console.WriteLine("Implementation is not done yet, probably that's why tests are failing");
                    break;
                case UserStoryState.Resolved:
                    Console.WriteLine("We'll notify the devs, that they did a bad job");
                    userStory.State = UserStoryState.Active;
                    break;
                case UserStoryState.Closed:
                    Console.WriteLine("User story is already closed");
                    break;
                case UserStoryState.Removed:
                    Console.WriteLine("Item was removed, you can only move it to backlog again");
                    break;
                default:
                    throw new Exception(string.Format("Cannot process user stories that are in {0} state", userStory.State));                    
            }
        }

        public void AcceptanceTestsPassed(UserStoryMotivational userStory)
        {
            switch (userStory.State)
            {
                case UserStoryState.New:
                    Console.WriteLine("Development didn't even started, you should check your tests");
                    break;
                case UserStoryState.Active:
                    Console.WriteLine("Development is not yet done");
                    break;
                case UserStoryState.Resolved:
                    Console.WriteLine("Cool, we'll close the us");
                    userStory.State = UserStoryState.Closed;
                    break;
                case UserStoryState.Closed:
                    Console.WriteLine("User story is already closed");
                    break;
                case UserStoryState.Removed:
                    Console.WriteLine("Item was removed, you can only move it to backlog again");
                    break;
                default:
                    throw new Exception(string.Format("Cannot process user stories that are in {0} state", userStory.State));
            }
        }
    }
}
