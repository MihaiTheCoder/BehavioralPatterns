using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorPattern.CalculateMoney;
using VisitorPattern.CalculateMoney.DynamicVisitor;
using VisitorPattern.CalculateMoney.WithoutVisitor;
using VisitorPattern.CalculateMoney.WithVisitor;

namespace VisitorPattern
{
    public class VisitorPatternExamples
    {
        public VisitorPatternExamples()
        {
        }

        public static void Run()
        {
            CalculateMoneyMotivationalExample.Run();

            CalculateMoneyWithVisitorExample.Run();

            CalculateMoneyWithDynamicVisitorExample.Run();
        }

        public static string GetDescription()
        {
            return @"Visitor pattern allows for one or more operation to be applied to a set of objects at runtime, decoupling the operations from the object structure. ";
        }
    }
}
