using BrokerServices.Models;
using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StockServices
    {
        public bool AddStock(CreateStock model)
        {
            var entity = new Stock() { TickerSymbol = model.TickerSymbol, Price = model.Price };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Stocks.Add(entity);
                return ctx.SaveChanges() == 1; 
            }
        }
        public IEnumerable<Stock> GetStocks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Stocks.ToArray();
            }
        }
        public Stock GetStock(string symbol)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Stocks.Find(symbol);

            }
        }
        public bool DeleteStock(string symbol)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Stocks.Find(symbol);
                ctx.Stocks.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
