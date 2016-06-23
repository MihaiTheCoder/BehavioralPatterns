using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatorPattern.AirTrafficControl
{
    public class AirTrafficControlExample
    {
        public void Run()
        {
            Lane l1 = new Lane(1);
            Lane l2 = new Lane(2);
            Lane l3 = new Lane(3);
            Lane l4 = new Lane(4, isAvailable: false);

            IAirTrafficControlTower controlTower = new AirTrafficControl(new List<Lane> { l1, l2, l3, l4 });

            MaintainerTeam m1 = new MaintainerTeam(controlTower);
            m1.RequestLane(l1);

            Plane p1a = new Plane("1a", controlTower);
            Plane p1b = new Plane("1b", controlTower);
            Plane p1c = new Plane("1c", controlTower);
            Plane p1d = new Plane("1d", controlTower);

            
            p1a.RequestPermissionToLand();
            p1b.RequestPermissionToLand();
            p1c.RequestPermissionToLand();
            p1d.RequestPermissionToLand();
            
        }
    }
}
