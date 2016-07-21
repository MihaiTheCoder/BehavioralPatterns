using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace StatePattern.ScrumWithRoleStates
{
    public class ScrumStateWithRoleInterfacesExample
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

            userStory.CodeFinishedAnUnitTestsPassed();

            userStory.AcceptanceTestsPassed();            

            Console.WriteLine("User story state: {0}", userStory.State.Name);

        }

        /// <summary>
        /// Context
        /// User story states: New, Active, Resolved, Closed, Removed
        /// Actions on user stories: 
        /// Create - creates a new user story in state New
        /// RemoveFromBacklog - moves a user story from state New to State Removed
        /// StartImplementation - moves user story from state New to state Active
        /// MoveToBacklog - moves user story from state Active/Removed to state New
        /// CodeFinishedAndUnitTestsPassed - move user story from state Active to state Resolved 
        /// AcceptanceTestsFail - move user story from state Resolved to state Active
        /// AcceptanceTestsPassed - moves user story from state Resolved to state Closed
        /// </summary>
        public class UserStory
        {            
            public IScrumState State { get; set; }

            public UserStoryStates States { get; private set; }

            public string Name { get; set; }

            public UserStory()
            {
                States = new UserStoryStates(this);                 

                State = States.New;
            }

            public void MoveToBacklog()
            {
                ICanMoveToBacklog state = GetState<ICanMoveToBacklog>();

                if(state == null)
                {
                    Console.WriteLine("Cannot move to backlog from state: {0}", State.Name);
                    return;
                }

                state.MoveToBacklog();
            }

            public void StartImplementation()
            {
                ICanStartImplementation state = GetState<ICanStartImplementation>();

                if (state == null)
                {
                    Console.WriteLine("Cannot start implementation from state: {0}", State.Name);
                    return;
                }

                state.StartImplementation();
            }

            public void CodeFinishedAnUnitTestsPassed()
            {
                ICanFinishCode state = GetState<ICanFinishCode>();

                if (state == null)
                {
                    Console.WriteLine("Cannot mark the code as done from state: {0}", State.Name);
                    return;
                }

                state.CodeFinishedAndUnitTestsPassed();
            }

            public void AcceptanceTestsFail()
            {
                ICanRunAcceptanceTests state = GetState<ICanRunAcceptanceTests>();

                if (state == null)
                {
                    Console.WriteLine("Cannot fail the acceptance tests from state: {0}", State.Name);
                    return;
                }

                state.AcceptanceTestsFail();
            }

            public void AcceptanceTestsPassed()
            {
                ICanRunAcceptanceTests state = GetState<ICanRunAcceptanceTests>();

                if (state == null)
                {
                    Console.WriteLine("Cannot mark the code as done from state: {0}", State.Name);
                    return;
                }

                state.AcceptanceTestsPassed();
            }

            public void RemoveFromBacklog()
            {
                ICanRemoveFromBacklog state = GetState<ICanRemoveFromBacklog>();

                if (state == null)
                {
                    Console.WriteLine("Cannot remove from backlog from state: {0}", State.Name);
                    return;
                }

                state.RemoveFromBacklog();
            }

            private TTransition GetState<TTransition>()
            {                
                if(State is TTransition)
                {
                    return (TTransition)State;
                }

                return default(TTransition);

                
            }
        }

        /// <summary>
        /// State interface
        /// </summary>
        public interface IScrumState
        {
            string Name { get; }
        }

        public class UserStoryStates
        {
            public UserStoryStates(UserStory userStory)
            {
                New = new ScrumStateNew(userStory);
                Active = new ScrumStateActive(userStory);
                Resolved = new ScrumStateResolved(userStory);
                Closed = new ScrumStateClosed(userStory);
                Removed = new ScrumStateRemoved(userStory);


                //Defined but not used, we could use this array to get from what state we can do an operation, by just checking which implements the required interface
                AllStates = new IScrumState[] { New, Active, Resolved, Closed, Removed };
            }
            public IScrumState[] AllStates { get; private set; }

            public IScrumState New { get; private set; }

            public IScrumState Active { get; private set; }

            public IScrumState Resolved { get; private set; }

            public IScrumState Closed { get; private set; }

            public IScrumState Removed { get; private set; }
        }


        #region role interfaces
        internal interface ICanMoveToBacklog 
        {
            void MoveToBacklog();
        }

       
        internal interface ICanStartImplementation
        {
            void StartImplementation();
        }

        internal interface ICanFinishCode
        {
            void CodeFinishedAndUnitTestsPassed();
        }

        internal interface ICanRunAcceptanceTests
        {
            void AcceptanceTestsFail();

            void AcceptanceTestsPassed();
        }

        internal interface ICanRemoveFromBacklog
        {
            void RemoveFromBacklog();
        }

        #endregion

        #region concrete state implementations
        public class ScrumStateNew : IScrumState, ICanRemoveFromBacklog, ICanStartImplementation
        {
            private UserStory userStory;

            public ScrumStateNew(UserStory userStory)
            {
                this.userStory = userStory;
            }

            public string Name { get { return "New"; } }

            public void RemoveFromBacklog()
            {
                Console.WriteLine("User story removed");
                userStory.State = userStory.States.Removed;
            }

            public void StartImplementation()
            {
                Console.WriteLine("Started work on User story: {0}", userStory.Name);
                userStory.State = userStory.States.Active;
            }
        }

        public class ScrumStateRemoved : IScrumState, ICanMoveToBacklog
        {
            private UserStory userStory;

            public ScrumStateRemoved(UserStory userStory)
            {
                this.userStory = userStory;
            }

            public string Name { get { return "Removed"; } }

            public void MoveToBacklog()
            {
                Console.WriteLine("Moved userstory to backlog");
                userStory.State = userStory.States.New;
            }
        }

        public class ScrumStateActive : IScrumState, ICanMoveToBacklog, ICanFinishCode
        {
            private UserStory userStory;

            public ScrumStateActive(UserStory userStory)
            {
                this.userStory = userStory;
            }

            public string Name { get { return "Active"; } }

            public void CodeFinishedAndUnitTestsPassed()
            {
                Console.WriteLine("I'll notify the testers!");
                userStory.State = userStory.States.Resolved;
            }

            public void MoveToBacklog()
            {
                Console.WriteLine("Moved userstory to backlog");
                userStory.State = userStory.States.New;
            }
        }

        public class ScrumStateResolved : IScrumState, ICanRunAcceptanceTests
        {
            private UserStory userStory;

            public ScrumStateResolved(UserStory userStory)
            {
                this.userStory = userStory;
            }

            public string Name { get { return "Resolved"; } }

            public void AcceptanceTestsFail()
            {
                Console.WriteLine("We'll notify the devs, that they did a bad job");
                userStory.State = userStory.States.Active;
            }

            public void AcceptanceTestsPassed()
            {
                Console.WriteLine("Cool, we'll close the us");
                userStory.State = userStory.States.Closed;
            }
        }

        public class ScrumStateClosed : IScrumState
        {
            private UserStory userStory;

            public ScrumStateClosed(UserStory userStory)
            {
                this.userStory = userStory;
            }

            public string Name { get { return "Closed"; } }
        }
        #endregion
    }

    
}
