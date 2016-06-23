using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatorPattern.FlightAirTrafficControl
{
    public class FlightAirTrafficControlExample
    {
        public void Run()
        {
            var controlTower = new AirTrafficControlTower();

            var fligh1 = new Plane("p1", 1000, controlTower);
            var fligh2 = new Plane("p2", 2000, controlTower);
            var fligh3 = new Plane("p3", 2000, controlTower);
            var fligh4 = new Plane("p4", 500, controlTower);

            controlTower.PrintPlanesAltitude();

        }
    }
}
