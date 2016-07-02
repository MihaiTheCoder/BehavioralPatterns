using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyPattern.ShippingCalculator
{
    public class ShippingMotivatingExample
    {
        public static void Run()
        {
            MShippingCalculator shippingCostCaluclator = new MShippingCalculator();
            var indiaPrice = shippingCostCaluclator.GetPrice(new MOrder(), MShippingService.IndiaPost);
            var postaPrice = shippingCostCaluclator.GetPrice(new MOrder(), MShippingService.Posta);
            var tcePrice = shippingCostCaluclator.GetPrice(new MOrder(), MShippingService.TCE);

            Console.WriteLine("The shipping cost for india is:{0}, for posta is {1} for tce is {2}", indiaPrice, postaPrice, tcePrice);
        }
    }

    public class MShippingCalculator
    {
        public double GetPrice(MOrder order, MShippingService shippingService)
        {
            switch (shippingService)
            {
                case MShippingService.Posta:
                    return ComputeForPosta(order, shippingService);
                case MShippingService.TCE:
                    return ComputeForTCE(order, shippingService);
                case MShippingService.IndiaPost:
                    return ComputeForIndiaPost(order, shippingService);
                default:
                    throw new Exception("Me not know the shipping service, boom boom");
            }
        }

        private double ComputeForIndiaPost(MOrder order, MShippingService shippingService)
        {
            return 50;
        }

        private double ComputeForTCE(MOrder order, MShippingService shippingService)
        {
            return 150;
        }

        private double ComputeForPosta(MOrder order, MShippingService shippingService)
        {
            return 200;
        }
    }

    public class MOrder
    {

    }

    public enum MShippingService
    {
        Posta,
        TCE,
        IndiaPost
    }
}
