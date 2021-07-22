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
    public class OrderService
    {
        private readonly Guid _userId;
        public OrderService(Guid UserId)
        {
            _userId = UserId;
        }
        public bool AddOrder(CreateOrder model)
        {
            StockServices service = new StockServices();
            Stock stock = service.GetStock(model.TickerSymbol);
            var entity = new Order() { OrderedStock = stock, OrderType = model.OrderType, NumberOfUnits = model.NumberOfUnits };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Orders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<OrderListItem> GetOrders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Orders.Where(q => q.UserId == _userId).Select(q => new OrderListItem() { TypeOfOrder = q.OrderType, NumberOfUnits = q.NumberOfUnits, OrderedStock = q.OrderedStock });
                return query.ToArray();
            }
        }
        public OrderDetail GetOrder(int orderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Orders.Where(q => q.UserId == _userId).Single(q => q.OrderId == orderId);
                return new OrderDetail() { TypeOfOrder = entity.OrderType, OrderedStock = entity.OrderedStock, NumberOfUnits = entity.NumberOfUnits, IsFilled = entity.IsFilled };
            }
        }
        public bool DeleteOrder(int orderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Orders.Single(e => e.UserId == _userId && e.OrderId == orderId);
                ctx.Orders.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
