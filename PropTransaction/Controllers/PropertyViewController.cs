using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PropTransaction.Filters;
using PropTransaction.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PropTransaction.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyViewController : BaseController
    {
        public PropertyViewController(ILogger<PropertyViewController> logger) : base(logger)
        { }

        [HttpGet]
        [HttpAuthroizationFilter]
        public IEnumerable<Property> Get()
        {
            using (var conn = new SQLiteConnection(connstr))
            {
                var resultset = conn.Query<Property>("SELECT * FROM Property", new DynamicParameters());
                return resultset.ToList();
            }
        }
    }
}
