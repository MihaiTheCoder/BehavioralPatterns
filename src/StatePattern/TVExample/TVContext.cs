using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.TVExample
{
    public class TVContext : ITVState
    {
        ITVState initialState;
        public TVContext(ITVState initialState)
        {
            State = initialState;
        }
        public ITVState State { get; set; }
        public void OnPowerButtonPresed()
        {
            State.OnPowerButtonPresed();
        }
    }
}
