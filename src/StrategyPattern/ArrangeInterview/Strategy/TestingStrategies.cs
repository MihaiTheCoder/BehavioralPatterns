using System;

namespace StrategyPattern.ArrangeInterview.Strategy
{
    public class JuniorTesterStrategy : IInterviewStrategy
    {
        public void Arrange(InterviewedPerson person)
        {
            Console.WriteLine("Prepare junior tester interview questions");
            Console.WriteLine("Reserve a meeting with any medium/senior tester"); ;
        }
    }

    public class MediumTesterStrategy : IInterviewStrategy
    {
        public void Arrange(InterviewedPerson person)
        {
            Console.WriteLine("Prepare medium tester interview questions");
            Console.WriteLine("Reserve a meeting with any senior tester");
        }
    }

    public class SeniorTestingStrategy : IInterviewStrategy
    {
        public void Arrange(InterviewedPerson person)
        {
            Console.WriteLine("Prepare senior tester interview questions");
            Console.WriteLine("Reserve a meeting with any 2 senior testers");
            Console.WriteLine("Reserver a meeting with one of the managers");
        }
    }

    public class RockstarTestingStrategy : IInterviewStrategy
    {
        public void Arrange(InterviewedPerson person)
        {
            Console.WriteLine("get third party rockstar testers to test him out");
            Console.WriteLine("Reserver a meeting with one of the managers");
        }
    }
}
