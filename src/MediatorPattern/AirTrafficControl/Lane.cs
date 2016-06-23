namespace MediatorPattern.AirTrafficControl
{
    public class Lane
    {
        public Lane(int id, bool isAvailable = true)
        {
            ID = id;
            IsAvailable = isAvailable;
        }
        public int ID { get; private set; }

        public bool IsAvailable { get; set; }
    }
}