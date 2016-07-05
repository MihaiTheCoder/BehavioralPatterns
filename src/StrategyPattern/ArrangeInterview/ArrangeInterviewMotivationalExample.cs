using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyPattern.ArrangeInterview
{
    public class ArrangeInterviewMotivationalExample
    {
        public static void Run(InterviewedPerson[] persons)
        {
            MInterviewManager interviewManager = new MInterviewManager();
            Console.WriteLine("Arranging interview for {0} perons", persons.Length);
            foreach (var person in persons)
            {
                Console.WriteLine();
                Console.WriteLine("Arranging interview for {0}-{1}-{2}-{3}", person.Name, person.Role, person.Experience, person.HiringType);
                
                interviewManager.ArrangeInterview(person);
            }
        }
    }

    public class MInterviewManager
    {
        public void ArrangeInterview(InterviewedPerson person)
        {
            Console.WriteLine("Reserve a meeting with one from HR");
            switch (person.Role)
            {
                case Role.Devloper:
                    ArrangeInterviewForDeveloper(person);
                    break;
                case Role.Designer:
                    ArrangeInterviewForDesigner(person);
                    break;
                case Role.Tester:
                    ArrangeInterviewForTester(person);
                    break;
                case Role.Manager:
                    ArrangeInterviewForManager(person);
                    break;
                case Role.DevOp:
                    ArrangeInterviewForDevOp(person);
                    break;
                default:
                    throw new NotImplementedException("not implemented how to arrange interview for:" + person.Role);
            }
        }

        private void ArrangeInterviewForDevOp(InterviewedPerson person)
        {
            //It could get more complex, if we decide we want different process for different positions(part time/full time)
            switch (person.Experience)
            {
                case Experience.Junior:
                    Console.WriteLine("Reserve a meeting with any medium/senior DevOp");
                    break;
                case Experience.Medium:
                    Console.WriteLine("Reserve a meeting with any senior DevOps");
                    break;
                case Experience.Senior:
                    Console.WriteLine("Reserve a meeting with any 2 senior DevOps");
                    Console.WriteLine("Reserver a meeting with one of the managers");
                    break;
                case Experience.RockStar:
                    Console.WriteLine("Reserve a meeting with best senior DevOps");
                    Console.WriteLine("Reserver a meeting with one of the managers");
                    break;
                default:
                    throw new NotImplementedException("hiring for " + person.Experience + " is not implemented");
            }
        }

        private void ArrangeInterviewForManager(InterviewedPerson person)
        {
            switch (person.Experience)
            {
                case Experience.Junior:
                    Console.WriteLine("We don't hire junior managers");
                    break;
                case Experience.Medium:
                    if (person.HiringType == HiringType.FullTime)
                        Console.WriteLine("Reserve a meeting with one of the managers");
                    else
                        Console.WriteLine("We dont hire Medium managers only full time");
                    break;
                case Experience.Senior:
                case Experience.RockStar:
                    Console.WriteLine("Reserver a meeting with all the managers");
                    break;
                default:
                    throw new NotImplementedException("What kind of experience is this?");
            }
        }

        private void ArrangeInterviewForTester(InterviewedPerson person)
        {
            //It could get more complex, if we decide we want different process for different positions(part time/full time)
            switch (person.Experience)
            {
                case Experience.Junior:
                    Console.WriteLine("Prepare junior tester interview questions");
                    Console.WriteLine("Reserve a meeting with any medium/senior tester");
                    break;
                case Experience.Medium:
                    Console.WriteLine("Prepare medium tester interview questions");
                    Console.WriteLine("Reserve a meeting with any senior tester");
                    break;
                case Experience.Senior:
                    Console.WriteLine("Prepare senior tester interview questions");
                    Console.WriteLine("Reserve a meeting with any 2 senior testers");
                    Console.WriteLine("Reserver a meeting with one of the managers");
                    break;
                case Experience.RockStar:
                    Console.WriteLine("get third party rockstar testers to test him out");
                    Console.WriteLine("Reserver a meeting with one of the managers");
                    break;
                default:
                    throw new NotImplementedException("hiring for " + person.Experience + " is not implemented");
            }
        }

        private void ArrangeInterviewForDesigner(InterviewedPerson person)
        {
            //It could get more complex, if we decide we want different process for different positions(part time/full time)
            switch (person.Experience)
            {
                case Experience.Junior:
                    Console.WriteLine("Reserve a meeting with any medium/senior designer");
                    break;
                case Experience.Medium:
                    Console.WriteLine("Give him medium designer test");
                    Console.WriteLine("Reserve a meeting with any senior designer");
                    break;
                case Experience.Senior:
                    Console.WriteLine("Give him a website to design");
                    Console.WriteLine("Reserve a meeting with any 2 senior desginers");
                    Console.WriteLine("Reserver a meeting with one of the managers");
                    break;
                case Experience.RockStar:
                    Console.WriteLine("Give him a website to design");
                    Console.WriteLine("Reserve a meeting with best senior designers");
                    Console.WriteLine("Reserver a meeting with one of the managers");
                    break;
                default:
                    throw new NotImplementedException("hiring for " + person.Experience + " is not implemented");
            }
        }

        private void ArrangeInterviewForDeveloper(InterviewedPerson person)
        {
            //It could get more complex, if we decide we want different process for different positions(part time/full time)
            switch (person.Experience)
            {
                case Experience.Junior:
                    Console.WriteLine("Prepare junior developer interview questions");                    
                    Console.WriteLine("Reserve a meeting with any medium/senior developer");
                    break;
                case Experience.Medium:
                    Console.WriteLine("Prepare medium developer interview questions");
                    Console.WriteLine("Give him a small program to develop before he comes here");
                    Console.WriteLine("Reserve a meeting with any senior developer");
                    break;
                case Experience.Senior:
                    Console.WriteLine("Give him a complex program to develop before he comes here");
                    Console.WriteLine("Prepare senior tester interview questions");
                    Console.WriteLine("Reserve a meeting with any 2 senior developers");
                    Console.WriteLine("Reserver a meeting with one of the managers");
                    break;
                case Experience.RockStar:
                    Console.WriteLine("We don't hire rockstar developers, because they are too cocky, this title was a trap");
                    break;
                default:
                    throw new NotImplementedException("hiring for " + person.Experience + " is not implemented");
            }
        }
    }    
}
