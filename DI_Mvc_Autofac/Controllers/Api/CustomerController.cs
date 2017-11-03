using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DI_Mvc_Autofac.Infrastructure.Interfaces;

namespace DI_Mvc_Autofac.Controllers.Api
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private readonly ILogger _logger;

        public CustomerController(ILogger logger)
        {
            _logger = logger;
        }

        public IHttpActionResult Get()
        {
            var customer = new
            {
                Id = 1,
                Name = "Cheranga Hatangala"
            };

            return Ok(customer);
        }
    }
}