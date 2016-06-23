namespace MediatorPattern.AirTrafficControl
{
    public class MaintainerTeam
    {
        IAirTrafficControlTower airControlTower;
        public MaintainerTeam(IAirTrafficControlTower airControlTower)
        {
            this.airControlTower = airControlTower;
        }

        public void RequestLane(Lane lane)
        {
            airControlTower.RequestLaneForMaintainance(this, lane);
        }
    }
}