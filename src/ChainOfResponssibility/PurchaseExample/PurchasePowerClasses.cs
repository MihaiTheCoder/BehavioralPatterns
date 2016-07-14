namespace ChainOfResponssibility.PurchaseExample
{
    public class ManagerPPower : PurchasePower
    {
        protected override double MaximumToSpend { get { return BaseUnit * 10; } }

        protected override string Role { get { return "Manager"; } }
    }

    public class DirectorPPower : PurchasePower
    {
        protected override double MaximumToSpend { get { return BaseUnit * 20; } }

        protected override string Role { get { return "Director"; } }
    }

    public class VicePresidentPPower : PurchasePower
    {
        protected override double MaximumToSpend { get { return BaseUnit * 40; } }

        protected override string Role { get { return "VicePresident"; } }
    }

    public class PresidentPPower : PurchasePower
    {
        protected override double MaximumToSpend { get { return BaseUnit * 60; } }

        protected override string Role { get { return "President"; } }
    }
}
