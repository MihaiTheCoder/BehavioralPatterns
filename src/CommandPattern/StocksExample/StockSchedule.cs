using System;
using System.Threading;

namespace CommandPattern.StocksExample
{
    public class StockSchedule
    {
        TimeSpan openingTime;
        public StockSchedule()
        {
            CheckForOpeningOfStockExchange();
            openingTime = new TimeSpan(9, 0, 0);
        }        

        public event EventHandler StockExchangedOpened;
        
        public bool IsStockOpen()
        {
            return new Random().NextDouble() > 0.5;
        }

        private void OnStockExchangedOpened(object state)
        {
            StockExchangedOpened?.Invoke(this, null);
            Thread.Sleep(1);
            CheckForOpeningOfStockExchange();

        }

        private void CheckForOpeningOfStockExchange()
        {
            var t = new Timer(new TimerCallback(OnStockExchangedOpened), null, Timeout.Infinite, Timeout.Infinite);

            // Figure how much time until opening market
            DateTime now = DateTime.Now;
            DateTime openingTime = DateTime.Today.Add(this.openingTime);

            // If it's already past opening time, wait until opening time tomorrow    
            if (now > openingTime)
            {
                openingTime = openingTime.AddDays(1.0);
            }

            int msUntilOpeningHour = (int)((openingTime - now).TotalMilliseconds);

            // Set the timer to elapse only once, at opening time.
            t.Change(msUntilOpeningHour, Timeout.Infinite);
        }
    }
}