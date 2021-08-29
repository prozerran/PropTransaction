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
using PropTransaction.Common;
using PropTransaction.Filters;

namespace PropTransaction.Controllers
{
    [ApiController]
    [HttpExceptionFilter]
    [Route("[controller]")]
    public class RegistrationController : BaseController
    {
        public RegistrationController(ILogger<RegistrationController> logger) : base(logger)
        { }

        // Adds items to table
        [HttpPost]
        public IActionResult Post([FromBody] Registry reg)
        {
            using (var conn = new SQLiteConnection(connstr))
            {
                conn.Execute("INSERT INTO User (Email, Password, IsAdmin) " +
                     "VALUES (@Email, @Password, @IsAdmin)", new { 
                         Email = reg.Email, 
                         Password = CommonUtil.GetHashedString(reg.Password),
                         IsAdmin = reg.IsAdmin });
            }
            return Ok();
        }

        // Deletes items from table
        [HttpDelete]
        [Route("{userId}")]
        public IActionResult Delete(int userId)
        {
            using (var conn = new SQLiteConnection(connstr))
            {
                conn.Execute($"DELETE FROM User WHERE Id = {userId}");
            }
            return Ok();
        }
    }
}
