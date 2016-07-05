using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyPattern.LoopWithException
{
    public class LoopWithExceptionExample
    {
        public static void Run()
        {
            LoopUsingException loopUsingException = new LoopUsingException(40, (i) => Console.WriteLine(i));
            loopUsingException.ExecuteForAll();
        }
    }

    public class LoopUsingException
    {
        private Action<int> executeStrategy;
        private int repeatCount;

        public LoopUsingException(int repeatCount, Action<int> executeStrategy)
        {
            this.repeatCount = repeatCount;
            this.executeStrategy = executeStrategy;
        }

        public void ExecuteForAll(int index = 1)
        {
            //Stop condition
            try
            {
                var x = 1 / (repeatCount + 1 - index);
            }
            catch (DivideByZeroException)
            {
                return;                
            }
            

            executeStrategy(index);

            ExecuteForAll(++index);
        }
    }
}
