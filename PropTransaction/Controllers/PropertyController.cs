using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PropTransaction.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace PropTransaction.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyController : Controller
    {
        //private readonly string connstr = @"DataSource=..\..\..\Resources\Properties.db;Version=3;";
        private readonly string connstr = @"DataSource=C:\github\PropTransaction\PropTransaction\Resources\Properties.db;Version=3;";
        //private readonly string file = @"C:\github\PropTransaction\PropTransaction\Resources\Properties.db";

        private readonly ILogger<PropertyController> _logger;

        public PropertyController(ILogger<PropertyController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Property> Get()
        {
            //if (!System.IO.File.Exists(file))
            //    return null;

            using (var conn = new SQLiteConnection(connstr))
            {
                var resultset = conn.Query<Property>("SELECT * FROM Property", new DynamicParameters());
                return resultset.ToList();
            }

            //return Enumerable.Range(1, 5).Select(index => new Property
            //{
            //    PropertyId = 1,
            //    PropertyName = "First",
            //    IsAvaliable = true,
            //    SalePrice = 4500000M,
            //    LeasePrice = 23000M
            //})
            //.ToArray();
        }
    }
}
