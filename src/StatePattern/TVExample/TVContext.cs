using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.TVExample
{
    public class TVContext : ITVState
    {
        public ITVState TvOnState { get; private set; }
        public ITVState TvOffState { get; private set; }
        public ITVState State { get; set; }
        public TVContext()
        {
            TvOnState = new TVOnState(this);
            TvOffState = new TVOffState(this);
            State = TvOffState;
        }
        
        public void OnPowerButtonPresed()
        {
            State.OnPowerButtonPresed();
        }
    }
}
