namespace ObserverPattern.StockUpdateEvents
{
    public class StockUpdateEventArgs
    {
        public Stock Stock { get; set; }

        public StockUpdateEventArgs(Stock stock)
        {
            Stock = stock;
        }
    }
}