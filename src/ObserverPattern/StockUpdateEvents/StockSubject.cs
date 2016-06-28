using System;
using System.Reactive.Subjects;

namespace ObserverPattern.StockUpdateEvents
{
    /// <summary>
    /// Subject to be observed
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