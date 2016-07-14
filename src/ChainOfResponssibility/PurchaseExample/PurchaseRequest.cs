namespace ChainOfResponssibility.PurchaseExample
{
    public class PurchaseRequest
    {
        public PurchaseRequest(double ammount, string reason)
        {
            Ammount = ammount;

            Reason = reason;
        }

        public double Ammount { get; private set; }

        public string Reason { get; private set; }
    }
}