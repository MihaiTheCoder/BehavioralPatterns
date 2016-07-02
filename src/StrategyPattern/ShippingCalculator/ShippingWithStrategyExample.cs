using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyPattern.ShippingCalculator
{
    public class ShippingWithStrategyExample
    {
        public static void Run()
        {
            ShippingCalculator shippingCostCaluclator = new ShippingCalculator();
            var order = new Order();
            var indiaPrice = shippingCostCaluclator.GetPrice(order, new IndiaPost());
            var postaPrice = shippingCostCaluclator.GetPrice(order, new Posta());
            var tcePrice = shippingCostCaluclator.GetPrice(order, new TCE());

            var priceOfTrainConductor = shippingCostCaluclator.GetPrice(order, new SimpleService(o => 10));

            const int priceOfBeer = 5;
            var prifeOfIon = shippingCostCaluclator.GetPrice(order, new SimpleService(o => priceOfBeer));

            Console.WriteLine(@"The shipping cost for india is:{0}, for posta is {1} for tce is {2}, 
if you talk to train conductor:{3}, if you go to Ion {4}", indiaPrice, postaPrice,
                tcePrice, priceOfTrainConductor, prifeOfIon);
        }
    }

    public class ShippingCalculator
    {
        public double GetPrice(Order order, ShippingService shippingService)
        {
            return shippingService.GetPrice(order);
        }
    }

    public abstract class ShippingService
    {
        public abstract double GetPrice(Order o);
    }

    public class IndiaPost : ShippingService
    {
        public override double GetPrice(Order o)
        {
            return 50;
        }
    }

    public class Posta : ShippingService
    {
        public override double GetPrice(Order o)
        {
            return 200;
        }
    }

    public class TCE : ShippingService
    {
        public override double GetPrice(Order o)
        {
            return 150;
        }
    }

    public class SimpleService : ShippingService
    {
        Func<Order, double> simpleCalculator;
        public SimpleService(Func<Order, double> simpleCalculator)
        {
            this.simpleCalculator = simpleCalculator;
        }
        public override double GetPrice(Order o)
        {
            return simpleCalculator(o);
        }
    }

    public class Order
    {
    }
}
