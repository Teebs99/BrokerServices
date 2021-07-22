using Data;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BrokerServices.Controllers
{
    public class StockController : ApiController
    {
        private StockServices CreateService()
        {
            return new StockServices();
        }


        [HttpPost]
        public IHttpActionResult CreateStock(CreateStock model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var service = CreateService();
            if (!service.AddStock(model))
                return InternalServerError();
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetStocks()
        {
            var service = CreateService();
            var stocks = service.GetStocks();
            if (stocks == null)
                return NotFound();
            return Ok(stocks);
        }
        [HttpGet]
        public IHttpActionResult GetStockBySymbol(string symbol)
        {
            var service = CreateService();
            var stock = service.GetStock(symbol);
            if (stock == null)
                return NotFound();
            return Ok(stock);
        }
        [HttpDelete]
        public IHttpActionResult DeleteStock(string symbol)
        {
            var service = CreateService();
            if (!service.DeleteStock(symbol))
                return NotFound();
            return Ok();
        }
    }
}
