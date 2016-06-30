using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    /// <summary>
    /// State interface
    /// </summary>
    public interface ITVState
    {
        void OnPowerButtonPresed();
    }
}
