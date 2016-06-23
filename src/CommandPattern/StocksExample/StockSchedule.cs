using System;
using System.Threading;

namespace CommandPattern.StocksExample
{
    public class FakeStockSchedule : IStockSchedule
    {
        TimeSpan timeWhenMarketOpens;
        bool isStockOpen;
        public FakeStockSchedule(bool isStockOpen, TimeSpan dueTime)
        {
            this.isStockOpen = isStockOpen;
            if (!isStockOpen)
            {
                var timer = new Timer((obj) =>
                {
                    this.isStockOpen = true;
                    StockExchangedOpened?.Invoke(this, null);
                }, null, Timeout.Infinite, Timeout.Infinite);

                timer.Change((int)dueTime.TotalMilliseconds, Timeout.Infinite);
            }
        }
        public event EventHandler StockExchangedOpened;

        public bool IsStockOpen()
        {
            return isStockOpen;
        }
    }
    public class StockSchedule : IStockSchedule
    {
        TimeSpan openingTime;
        TimeSpan closingTime;
        public StockSchedule()
        {
            CheckForOpeningOfStockExchange();
            openingTime = new TimeSpan(9, 0, 0);
            closingTime = new TimeSpan(17, 0, 0);
        }        

        public event EventHandler StockExchangedOpened;
        
        public bool IsStockOpen()
        {
            var timeOfDay = DateTime.Now.TimeOfDay;
            if(timeOfDay.CompareTo(openingTime) > 0 && timeOfDay.CompareTo(closingTime) < 0)
            {
                return true;
            }
            return false;
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