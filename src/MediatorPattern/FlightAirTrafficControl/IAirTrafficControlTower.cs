namespace MediatorPattern.FlightAirTrafficControl
{
    public interface IAirTrafficControlTower
    {
        void StartMonitor(Plane plane);
        void UpdateLocation(Plane plane);
    }
}