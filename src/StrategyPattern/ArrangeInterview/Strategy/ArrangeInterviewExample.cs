using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyPattern.ArrangeInterview.Strategy
{
    public class ArrangeInterviewExample
    {
        public static void Run(InterviewedPerson[] persons)
        {
            InterviewManager interviewManager = new InterviewManager();
            Console.WriteLine("Arranging interview for {0} perons", persons.Length);
            foreach (var person in persons)
            {
                Console.WriteLine();
                Console.WriteLine("Arranging interview for {0}-{1}-{2}-{3}", person.Name, person.Role, person.Experience, person.HiringType);

                IInterviewStrategy strategy = interviewManager.GetInterviewStrategy(person);

                strategy.Arrange(person);
            }
        }
    }

    public class InterviewManager
    {
        public IInterviewStrategy GetInterviewStrategy(InterviewedPerson person)
        {
            Console.WriteLine("Reserve a meeting with one from HR");
            switch (person.Role)
            {
                case Role.Devloper:
                    return GetDeveloperStrategy(person);                    
                case Role.Designer:
                    return GetStrategyFOrDesigner(person);                    
                case Role.Tester:
                    return GetStrategyForTester(person);                    
                case Role.Manager:
                    return GetStrategyForManager(person);
                case Role.DevOp:
                    return GetStrategyForDevOp(person);
                default:
                    throw new NotImplementedException("not implemented how to arrange interview for:" + person.Role);
            }
        }

        private IInterviewStrategy GetStrategyForDevOp(InterviewedPerson person)
        {
            //It could get more complex, if we decide we want different process for different positions(part time/full time)
            switch (person.Experience)
            {
                case Experience.Junior:
                    return new JuniorDevOpStrategy();
                case Experience.Medium:
                    return new MediumDevOpStrategy();
                case Experience.Senior:
                    return new SeniorDevOpStrategy();
                case Experience.RockStar:
                    return new RockstarDevOpStrategy();
                default:
                    throw new NotImplementedException("hiring for " + person.Experience + " is not implemented");
            }
        }

        private IInterviewStrategy GetStrategyForManager(InterviewedPerson person)
        {
            switch (person.Experience)
            {
                case Experience.Junior:
                    return new JuniorManagerStrategy();
                case Experience.Medium:
                    if (person.HiringType == HiringType.FullTime)
                        return new MediumFullTimeManagerStrategy();
                    else
                        return new MediumNonFullTimeManagerStrategy();
                case Experience.Senior:
                case Experience.RockStar:
                    return new SeniorAndRockstarManagerStrategy();
                default:
                    throw new NotImplementedException("What kind of experience is this?");
            }
        }

        private IInterviewStrategy GetStrategyForTester(InterviewedPerson person)
        {
            //It could get more complex, if we decide we want different process for different positions(part time/full time)
            switch (person.Experience)
            {
                case Experience.Junior:
                    return new JuniorTesterStrategy();
                case Experience.Medium:
                    return new MediumTesterStrategy();
                case Experience.Senior:
                    return new SeniorTestingStrategy();
                case Experience.RockStar:
                    return new RockstarTestingStrategy();
                default:
                    throw new NotImplementedException("hiring for " + person.Experience + " is not implemented");
            }
        }

        private IInterviewStrategy GetStrategyFOrDesigner(InterviewedPerson person)
        {
            //It could get more complex, if we decide we want different process for different positions(part time/full time)
            switch (person.Experience)
            {
                case Experience.Junior:
                    return new JuniorDesignerStrategy();
                case Experience.Medium:
                    return new MediumDesignerStrategy();
                case Experience.Senior:
                    return new SeniorDesignerStrategy();
                case Experience.RockStar:
                    return new RockstarDesignerStrategy();
                default:
                    throw new NotImplementedException("hiring for " + person.Experience + " is not implemented");
            }
        }

        private IInterviewStrategy GetDeveloperStrategy(InterviewedPerson person)
        {
            //It could get more complex, if we decide we want different process for different positions(part time/full time)
            switch (person.Experience)
            {
                case Experience.Junior:
                    return new JuniorDeveloperStrategy();
                case Experience.Medium:
                    return new MediumDeveloperStrategy();
                case Experience.Senior:
                    return new SeniorDeveloperStrategy();
                case Experience.RockStar:
                    return new RockstarDeveloperStrategy();
                default:
                    throw new NotImplementedException("hiring for " + person.Experience + " is not implemented");
            }
        }
    }
}
