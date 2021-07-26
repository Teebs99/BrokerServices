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
    public class PortfolioController : ApiController
    {
        private PortfolioService CreateService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new PortfolioService(userId);

        }


        [HttpPost]
        public IHttpActionResult CreatePortfolio(CreatePortfolio model)
        {
            var service =  CreateService();
            if (!ModelState.IsValid)
                return BadRequest();
            if (!service.AddPortfolio(model))
                return InternalServerError();
            return Ok();

        }
        [HttpGet]
        public IHttpActionResult GetPorfolio(int id)
        {
            var service = CreateService();
            var entity = service.GetPortfolio(id);
            if (entity == null)
                return NotFound();
            return Ok(entity);
            
        }
        [HttpDelete]
        public IHttpActionResult DeletePortfolio(int id)
        {
            var service = CreateService();
            if (!service.DeletePortfolio(id))
                return NotFound();
            return Ok();
        }
    }
}
