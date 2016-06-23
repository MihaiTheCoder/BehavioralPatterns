using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPattern.StocksExample
{
    /// <summary>
    /// Invoker. The invoker will invoke the command
    /// </summary>
    public class Agent
    {
        Stack<Order> ordersNotExecuted;
        FixedSizedQueue<Order> ordersPlaced;
        IStockSchedule stockSchedule;

        public Agent(IStockSchedule stockSchedule)
        {
            ordersNotExecuted = new Stack<Order>();
            ordersPlaced = new FixedSizedQueue<Order>(10);
            this.stockSchedule = stockSchedule;
            stockSchedule.StockExchangedOpened += StockSchedule_StockExchangedOpened;
        }

        private void StockSchedule_StockExchangedOpened(object sender, EventArgs e)
        {
            while (ordersNotExecuted.Any())
            {
                PlaceOrder(ordersNotExecuted.Pop());
            }
        }

        public void PlaceOrder(Order order)
        {
            if(stockSchedule.IsStockOpen())
            {
                order.Execute();
                ordersPlaced.Enqueue(order);
            }
            else
            {
                Console.WriteLine("Market is not opened, so the order was saved for later");
                ordersNotExecuted.Push(order);
            }
        }        
    }
}
