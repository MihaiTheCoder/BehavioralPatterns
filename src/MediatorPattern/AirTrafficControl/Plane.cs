using System;

namespace MediatorPattern.AirTrafficControl
{
    public class Plane
    {
        public string ID { get; private set; }
        IAirTrafficControlTower controlTower;
        public Plane(string id, IAirTrafficControlTower controlTower)
        {
            this.controlTower = controlTower;
            ID = id;
        }

        public void RequestPermissionToLand()
        {
            var lane = controlTower.RequestPermissionToLand(this);

            if (lane.IsPresent)
                Console.WriteLine("Landing");
            else
                Console.WriteLine("I will ask again in 5 minutes");
        }
    }
}