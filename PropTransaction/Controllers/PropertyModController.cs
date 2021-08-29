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
    [HttpActionFilter]
    [HttpExceptionFilter]
    [HttpAuthroizationFilter]
    [Route("[controller]")]
    public class PropertyModController : BaseController
    {
        public PropertyModController(ILogger<PropertyModController> logger) : base(logger)
        { }

        [HttpGet]
        public IEnumerable<Property> Get()
        {
            using (var conn = new SQLiteConnection(connstr))
            {
                var resultset = conn.Query<Property>("SELECT * FROM Property", new DynamicParameters());
                return resultset.ToList();
            }
        }

        // Adds items to table
        [HttpPost]
        public IActionResult Post([FromBody] Property prop)
        {
            var sessionId = Request.Headers["Authorization"];
            var sv = LoginController.GetSessionView(sessionId);
            prop.UserId = sv.UserId;

            using (var conn = new SQLiteConnection(connstr))
            {
                conn.Execute("INSERT INTO Property (PropertyName, UserId, Bedroom, IsAvaliable, SalePrice, LeasePrice) " +
                     "VALUES (@PropertyName, @UserId, @Bedroom, @IsAvaliable, @SalePrice, @LeasePrice)", prop);
            }
            return Ok();
        }

        // Deletes items from table
        [HttpDelete]
        [Route("{propId}")]
        public IActionResult Delete(int propId)
        {
            using (var conn = new SQLiteConnection(connstr))
            {
                conn.Execute($"DELETE FROM Property WHERE PropertyId = {propId}");
            }
            return Ok();
        }

        // Updates items in table
        [HttpPut]
        public IActionResult Put([FromBody] Property prop)
        {
            using (var conn = new SQLiteConnection(connstr))
            {
                conn.Execute("UPDATE Property SET " +
                    "PropertyName = @PropertyName, " +
                    "Bedroom = @Bedroom, " +
                    "IsAvaliable = @IsAvaliable, " +
                    "SalePrice = @SalePrice, " +
                    "LeasePrice = @LeasePrice " +
                    "WHERE PropertyId = @PropertyId", prop);
            }
            return Ok();
        }
    }
}
