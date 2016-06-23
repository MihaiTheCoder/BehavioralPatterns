using System;

namespace CommandPattern.StocksExample
{
    public interface IStockSchedule
    {
        event EventHandler StockExchangedOpened;

        bool IsStockOpen();
    }
}