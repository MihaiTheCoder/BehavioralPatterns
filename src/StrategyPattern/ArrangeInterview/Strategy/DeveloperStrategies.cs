using System;

namespace StrategyPattern.ArrangeInterview.Strategy
{
    public class JuniorDeveloperStrategy : IInterviewStrategy
    {
        public void Arrange(InterviewedPerson person)
        {
            Console.WriteLine("Prepare junior developer interview questions");
            Console.WriteLine("Reserve a meeting with any medium/senior developer");
        }
    }

    public class MediumDeveloperStrategy : IInterviewStrategy
    {
        public void Arrange(InterviewedPerson person)
        {
            Console.WriteLine("Prepare medium developer interview questions");
            Console.WriteLine("Give him a small program to develop before he comes here");
            Console.WriteLine("Reserve a meeting with any senior developer");
        }
    }

    public class SeniorDeveloperStrategy : IInterviewStrategy
    {
        public void Arrange(InterviewedPerson person)
        {
            Console.WriteLine("Give him a complex program to develop before he comes here");
            Console.WriteLine("Prepare senior tester interview questions");
            Console.WriteLine("Reserve a meeting with any 2 senior developers");
            Console.WriteLine("Reserver a meeting with one of the managers");
        }
    }

    public class RockstarDeveloperStrategy : IInterviewStrategy
    {
        public void Arrange(InterviewedPerson person)
        {
            Console.WriteLine("We don't hire rockstar developers, because they are too cocky, this title was a trap");
        }
    }
}
