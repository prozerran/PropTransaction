using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class PropertyModController : Controller
    {
        private readonly string connstr = @"DataSource=.\Resources\Properties.db;Version=3;";

        private readonly ILogger<PropertyModController> _logger;

        public PropertyModController(ILogger<PropertyModController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
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
