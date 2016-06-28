using System;

namespace ObserverPattern.StockUpdateEvents
{
    /// <summary>
    /// Subject
    /// </summary>
    public class StockSubject
    {

        public void UpdateStockValue(Stock s)
        {
            StockUpdated?.Invoke(this, new StockUpdateEventArgs(s));
        }

        public event EventHandler<StockUpdateEventArgs> StockUpdated;
    }
}