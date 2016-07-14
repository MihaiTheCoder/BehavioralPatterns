using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyPattern.LoopWithoutLoop
{
    public class MagnificLoopExample
    {
        public static void Run()
        {
            LoopLikeABoss loopLikeABoss = new LoopLikeABoss();
            loopLikeABoss.PrintNumbersOf1ToN(10);
        }
    }

    public class LoopLikeABoss
    {
        public void PrintNumbersOf1ToN(int n)
        {
            LoopStep l = new LoopStep((i) => Console.WriteLine(i));
            l.Loops = new LoopStep[] { l, new StopLoopStep() };
            l.Loop(1, n);
        }
    }

    public class LoopStep
    {
        Action<int> printNumberStrategy;
        public LoopStep(Action<int> printNumberStrategy)
        {
            this.printNumberStrategy = printNumberStrategy;
        }
        public LoopStep[] Loops { get; set; }        

        public virtual void Loop(int currentIndex, int n)
        {
            var loopStep = GetNextStep(currentIndex, n);
            loopStep.printNumberStrategy(currentIndex);
            loopStep.Loop(++currentIndex, n);
        }

        public LoopStep GetNextStep(int i, int n)
        {
            return Loops[i / (n + 1)];
        }
    }

    public class StopLoopStep : LoopStep
    {
        public StopLoopStep() : base((i) => { })
        {
        }

        public override void Loop(int currentIndex, int n)
        {
            return;
        }
    }    
}
