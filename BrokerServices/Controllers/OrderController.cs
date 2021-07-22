using Microsoft.AspNet.Identity;
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
    public class OrderController : ApiController
    {
        private OrderService CreateService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new OrderService(userId);
        }

        [HttpPost]
        public IHttpActionResult CreateOrder(CreateOrder model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var service = CreateService();
            if (!service.AddOrder(model))
                return InternalServerError();
            return Ok("Order Created Successfully");
        }
        [HttpGet]
        public IHttpActionResult GetOrders()
        {
            var service = CreateService();
            var orders = service.GetOrders();
            if (orders == null)
                return InternalServerError();
            return Ok(orders);
        }
        [HttpGet]
        public IHttpActionResult GetOrderById(int id)
        {
            var service = CreateService();
            var order = service.GetOrder(id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }
        [HttpDelete]
        public IHttpActionResult DeleteOrder(int id)
        {
            var service = CreateService();
            if (!service.DeleteOrder(id))
                return InternalServerError();
            return Ok();
        }

    }
}
