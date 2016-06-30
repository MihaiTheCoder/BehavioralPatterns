using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatePattern.FanExample
{
    public class FanWithStatePatternExample
    {
        public static void Run()
        {
            FanMotivationalContext fanContext = new FanMotivationalContext();

            fanContext.PullChain();

            fanContext.PullChain();

            fanContext.PullChain();

            fanContext.PullChain();

            fanContext.PullChain();

            fanContext.PullChain();

            fanContext.PullChain();
        }
    }

    /// <summary>
    /// Context
    /// </summary>
    public class FanContext
    {
        public IFanState OFF { get; private set; }

        public IFanState S1 { get; private set; }

        public IFanState S2 { get; private set; }

        public IFanState S3 { get; private set; }

        public IFanState S4 { get; private set; }

        public IFanState State { get; set; }

        public FanContext()
        {
            OFF = new FanOffState(this);

            S1 = new FanS1State(this);

            S2 = new FanS2State(this);

            S3 = new FanS3State(this);

            S4 = new FanS4State(this);

            State = OFF;
        }   

        public void PullChain()
        {
            State.PullChain();
        }
    }      

    /// <summary>
    /// State interface
    /// </summary>
    public interface IFanState
    {
        void PullChain();
    }

    public class FanOffState : IFanState
    {
        FanContext context;
        public FanOffState(FanContext context)
        {
            this.context = context;
        }
        public void PullChain()
        {
            Console.WriteLine("Turning TV to speed 1");
            context.State = context.S1;
        }
    }

    /// <summary>
    /// State concrete implementation
    /// </summary>
    public class FanS1State : IFanState
    {
        private FanContext fanContext;

        public FanS1State(FanContext fanContext)
        {
            this.fanContext = fanContext;
        }

        public void PullChain()
        {
            Console.WriteLine("Turning TV to speed 2");
            fanContext.State = fanContext.S2;
        }
    }

    /// <summary>
    /// State concrete implementation
    /// </summary>
    public class FanS2State : IFanState
    {
        private FanContext fanContext;

        public FanS2State(FanContext fanContext)
        {
            this.fanContext = fanContext;
        }

        public void PullChain()
        {
            Console.WriteLine("Turning TV to speed 3");
            fanContext.State = fanContext.S3;
        }
    }

    /// <summary>
    /// State concrete implementation
    /// </summary>
    public class FanS3State : IFanState
    {
        private FanContext fanContext;

        public FanS3State(FanContext fanContext)
        {
            this.fanContext = fanContext;
        }

        public void PullChain()
        {
            Console.WriteLine("Turning TV to speed 4");
            fanContext.State = fanContext.S4;
        }
    }

    /// <summary>
    /// State concrete implementation
    /// </summary>
    public class FanS4State : IFanState
    {
        private FanContext fanContext;

        public FanS4State(FanContext fanContext)
        {
            this.fanContext = fanContext;
        }

        public void PullChain()
        {
            Console.WriteLine("Turning TV OFF");
            fanContext.State = fanContext.OFF;
        }
    }
}
