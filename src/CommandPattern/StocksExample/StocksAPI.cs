using System;

namespace CommandPattern.StocksExample
{
    /// <summary>
    /// Receiver of the command. Concrete command is executing code from this class
    /// </summary>
    public class StocksAPI
    {
        public void Buy(Stock stock)
        {
            Console.WriteLine("Stock [ Name: {0}, Quantity: {1} bought", stock.Name, stock.Quantity);
        }

        public void Sell(Stock stock)
        {
            Console.WriteLine("Stock [ Name: {0}, Quantity: {1} sold", stock.Name, stock.Quantity);
        }
    }
}
