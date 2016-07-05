using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyPattern.ArrangeInterview.Strategy
{
    public class JuniorDesignerStrategy : IInterviewStrategy
    {
        public void Arrange(InterviewedPerson person)
        {
            Console.WriteLine("Reserve a meeting with any medium/senior designer");
        }
    }

    public class MediumDesignerStrategy : IInterviewStrategy
    {
        public void Arrange(InterviewedPerson person)
        {
            Console.WriteLine("Give him medium designer test");
            Console.WriteLine("Reserve a meeting with any senior designer");
        }
    }

    public class SeniorDesignerStrategy : IInterviewStrategy
    {
        public void Arrange(InterviewedPerson person)
        {
            Console.WriteLine("Give him a website to design");
            Console.WriteLine("Reserve a meeting with any 2 senior desginers");
            Console.WriteLine("Reserver a meeting with one of the managers");
        }
    }

    public class RockstarDesignerStrategy : IInterviewStrategy
    {
        public void Arrange(InterviewedPerson person)
        {
            Console.WriteLine("Give him a website to design");
            Console.WriteLine("Reserve a meeting with best senior designers");
            Console.WriteLine("Reserver a meeting with one of the managers");
        }
    }
}
