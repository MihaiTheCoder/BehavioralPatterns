using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatorPattern.StockExchange
{
    public class StockRequest
    {
        public string Symbol { get; set; }

        public int Count { get; set; }

        public double Price { get; set; }

        public string Requester { get; set; }
    }
}
