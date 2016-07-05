using System;

namespace StrategyPattern.ArrangeInterview.Strategy
{
    public class JuniorDevOpStrategy : IInterviewStrategy
    {
        public void Arrange(InterviewedPerson person)
        {
            Console.WriteLine("Reserve a meeting with any medium/senior DevOp");
        }
    }

    public class MediumDevOpStrategy : IInterviewStrategy
    {
        public void Arrange(InterviewedPerson person)
        {
            Console.WriteLine("Reserve a meeting with any senior DevOps");
        }
    }

    public class SeniorDevOpStrategy : IInterviewStrategy
    {
        public void Arrange(InterviewedPerson person)
        {
            Console.WriteLine("Reserve a meeting with any 2 senior DevOps");
            Console.WriteLine("Reserver a meeting with one of the managers");
        }
    }

    public class RockstarDevOpStrategy : IInterviewStrategy
    {
        public void Arrange(InterviewedPerson person)
        {
            Console.WriteLine("Reserve a meeting with best senior DevOps");
            Console.WriteLine("Reserver a meeting with one of the managers");
        }
    }
}
