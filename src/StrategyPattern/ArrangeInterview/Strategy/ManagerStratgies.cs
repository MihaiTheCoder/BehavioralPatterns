using System;

namespace StrategyPattern.ArrangeInterview.Strategy
{
    public class JuniorManagerStrategy : IInterviewStrategy
    {
        public void Arrange(InterviewedPerson person)
        {
            Console.WriteLine("We don't hire junior managers");
        }
    }

    public class MediumFullTimeManagerStrategy : IInterviewStrategy
    {
        public void Arrange(InterviewedPerson person)
        {
            Console.WriteLine("Reserve a meeting with one of the managers");
        }
    }

    public class MediumNonFullTimeManagerStrategy : IInterviewStrategy
    {
        public void Arrange(InterviewedPerson person)
        {
            Console.WriteLine("We dont hire Medium managers only full time");
        }
    }

    public class SeniorAndRockstarManagerStrategy : IInterviewStrategy
    {
        public void Arrange(InterviewedPerson person)
        {
            Console.WriteLine("Reserver a meeting with all the managers");
        }
    }
}
