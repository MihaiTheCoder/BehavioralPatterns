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
            var indiaPrice = shippingCostCaluclator.GetPrice(new Order(), new IndiaPost());
            var postaPrice = shippingCostCaluclator.GetPrice(new Order(), new Posta());
            var tcePrice = shippingCostCaluclator.GetPrice(new Order(), new TCE());

            Console.WriteLine("The shipping cost for india is:{0}, for posta is {1} for tce is {2}", indiaPrice, postaPrice, tcePrice);
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
            return 0.25;
        }
    }

    public class Posta : ShippingService
    {
        public override double GetPrice(Order o)
        {
            return 2;
        }
    }

    public class TCE : ShippingService
    {
        public override double GetPrice(Order o)
        {
            return 1;
        }
    }

    public class Order
    {
    }
}
