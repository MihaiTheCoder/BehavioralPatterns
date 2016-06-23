using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatorPattern.FlightAirTrafficControl
{
    public class Plane
    {
        public string ID { get; private set; }

        IAirTrafficControlTower controlTower;
        public Plane(string id, int altitude, IAirTrafficControlTower controlTower)
        {
            this.controlTower = controlTower;
            ID = id;
            Altitude = altitude;
            controlTower.StartMonitor(this);
        }

        public int Altitude { get; private set; }

        public void ChangeAltitude(int altitudeDifference)
        {
            int newExpectedAltitude = Altitude + altitudeDifference;
            Console.WriteLine("Plane {0} is changing altitude from {1} to {2}", ID, Altitude, newExpectedAltitude);
            Altitude = newExpectedAltitude;
            controlTower.UpdateLocation(this);
        }        

    }
}
