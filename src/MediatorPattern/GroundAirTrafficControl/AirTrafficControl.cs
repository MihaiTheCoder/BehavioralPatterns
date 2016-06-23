using System;
using System.Collections.Generic;
using System.Linq;

namespace MediatorPattern.GroundAirTrafficControl
{
    public class AirTrafficControl : IAirTrafficControlTower
    {
        List<Lane> lanes;
        object lockLanes = new object();
        public AirTrafficControl(List<Lane> lanes)
        {
            this.lanes = lanes;
        }
        public bool RequestLaneForMaintainance(MaintainerTeam team, Lane lane)
        {
            var requestedLane = lanes.FirstOrDefault(l => l.ID == lane.ID);

            if (requestedLane == null)
                return false;
            lock (lockLanes)
            {
                if (requestedLane.IsAvailable)
                {
                    requestedLane.IsAvailable = false;
                    Console.WriteLine("Lane {0} is now used by maintainers", lane.ID);
                    return true;
                }
                else
                {
                    Console.WriteLine("Lane {0} cannot be used by maintainers because it's already in use", lane.ID);
                    return false;
                }
            }
        }

        public Optional<Lane> RequestPermissionToLand(Plane plane)
        {
            lock (lockLanes)
            {
                var availableLane = lanes.FirstOrDefault(l => l.IsAvailable);

                if (availableLane != null)
                {
                    availableLane.IsAvailable = false;
                    Console.WriteLine("Approved landing for plane {0} on lane {1}", plane.ID, availableLane.ID);                    
                    return Optional<Lane>.Of(availableLane);
                }
                else
                {
                    Console.WriteLine("Landing not approved for plane {0}", plane.ID);
                    return Optional<Lane>.Empty;
                }
            }
        }
    }
}
