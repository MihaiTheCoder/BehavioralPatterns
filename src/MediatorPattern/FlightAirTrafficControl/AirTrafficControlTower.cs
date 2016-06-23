using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatorPattern.FlightAirTrafficControl
{
    public class AirTrafficControlTower : IAirTrafficControlTower
    {
        int MINIMUM_DIFFERENCE_BETWEEN_PLANES = 2000;
        List<Plane> planesMonitored;
        public AirTrafficControlTower()
        {
            planesMonitored = new List<Plane>();
        }
        public void StartMonitor(Plane plane)
        {
            if(!planesMonitored.Contains(plane))
            {
                planesMonitored.Add(plane);
            }

            UpdateLocation(plane);
        }

        public void PrintPlanesAltitude()
        {
            Console.WriteLine("Planes monitored:");

            foreach (var plane in planesMonitored)
            {
                Console.WriteLine("Plane {0} at altitude {1}", plane.ID, plane.Altitude);
            }
        }

        public void UpdateLocation(Plane plane)
        {
            var otherPlanesMonitored = planesMonitored.Where(p => p.ID != plane.ID);

            var planesNearby = otherPlanesMonitored.Where(p => GetDifferenceInAltitude(p, plane) < MINIMUM_DIFFERENCE_BETWEEN_PLANES).OrderBy(p => p.Altitude);

            if(!planesNearby.Any())
            {
                Console.WriteLine("Thanks for update {0}, no planes nearby, please continue", plane.ID);
            }
            else
            {
                var planeAbove = planesNearby.FirstOrDefault(p => p.Altitude > plane.Altitude);

                if (planeAbove != null)
                {
                    planeAbove.ChangeAltitude(MINIMUM_DIFFERENCE_BETWEEN_PLANES);
                }

                var planeBellow = planesNearby.FirstOrDefault(p => p.Altitude <= plane.Altitude);

                if(planeBellow != null)
                {
                    plane.ChangeAltitude(MINIMUM_DIFFERENCE_BETWEEN_PLANES);
                }
            }

        }

        private int GetDifferenceInAltitude(Plane p1, Plane p2)
        {
            return Math.Abs(p1.Altitude - p2.Altitude);
        }
    }
}
