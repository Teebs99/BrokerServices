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
    public class PortfolioService
    {
        private Guid _userId;

        public PortfolioService(Guid userId)
        {
            _userId = userId;
        }

        public bool AddPortfolio(CreatePortfolio model)
        {
            var entity = new Portfolio() { Name = model.Name, Cash = 0, };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Portfolios.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public PortfolioDetail GetPortfolio(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Portfolios.Single(e => e.UserId == _userId && e.Id == id);
                return new PortfolioDetail()
                {
                    Name = entity.Name,
                    Positions = entity.Positions,
                    Cash = entity.Cash,
                    Value = entity.Value
                };
            }
        }
        //Not implementing PUT, want to find a way to stream realtime data to update

        public bool DeletePortfolio(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Portfolios.Single(e => e.UserId == _userId && e.Id == id);
                ctx.Portfolios.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }

    }
}
