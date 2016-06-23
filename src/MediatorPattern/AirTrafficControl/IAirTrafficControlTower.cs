using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatorPattern.AirTrafficControl
{
    /// <summary>
    /// Mediator
    /// </summary>
    public interface IAirTrafficControlTower
    {

        Optional<Lane> RequestPermissionToLand(Plane plane);

        bool RequestLaneForMaintainance(MaintainerTeam team, Lane lane);        

    }
}
