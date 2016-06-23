using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatorPattern.StockExchange
{
    public class StockExchangeExample
    {
        public void Run()
        {
            IStockExchange stockExchange = new StockExchange();
            Buyer aaplBuyer = new Buyer("El Ciupi AAPL", "AAPL", 100, 15.0, stockExchange);
            var buyResult = aaplBuyer.BuyFromStockExchange();

            Seller aaplSeller = new Seller("capo di APPL", "AAPL", 100, 16.0, stockExchange);
            var sellResult = aaplSeller.SellFromStockExchange();

            aaplSeller = new Seller("capo di APPL", "AAPL", 100, 14.0, stockExchange);
            sellResult = aaplSeller.SellFromStockExchange();

        }
    }
}
