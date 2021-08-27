using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PropTransaction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropTransaction.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyController : Controller
    {
        private readonly ILogger<PropertyController> _logger;

        public PropertyController(ILogger<PropertyController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Property> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Property
            {
                PropertyId = 1,
                PropertyName = "First",
                IsAvaliable = true,
                SalePrice = 4500000M,
                LeasePrice = 23000M
            })
            .ToArray();
        }
    }
}
