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
using System.Net.Http;
using System.Threading.Tasks;

namespace PropTransaction.Controllers
{
    [ApiController]
    [HttpAuthroizationFilter]
    [Route("[controller]")]
    public class PropertyViewController : BaseController
    {
        public PropertyViewController(ILogger<PropertyViewController> logger) : base(logger)
        { }

        [HttpGet]
        public IEnumerable<Property> Get()
        {
            var sessionId = Request.Headers["Authorization"];
            var sv = LoginController.GetSessionView(sessionId);
            var sql = "SELECT * FROM Property";

            if (!sv.IsAdmin)
            {
                sql = string.Format($"SELECT * FROM Property");
            }

            using (var conn = new SQLiteConnection(connstr))
            {
                var resultset = conn.Query<Property>(sql, new DynamicParameters());
                return resultset.ToList();
            }
        }
    }
}
