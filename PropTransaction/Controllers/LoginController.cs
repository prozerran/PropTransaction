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

namespace PropTransaction.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : BaseController
    {
        public LoginController(ILogger<LoginController> logger) : base(logger)
        { }

        // Adds items to table
        [HttpPost]
        public IActionResult Post([FromBody] Login login)
        {
            using (var conn = new SQLiteConnection(connstr))
            {
                var sql = string.Format($"SELECT * FROM User WHERE Email = '{login.Email}' LIMIT 1");

                var result = conn.Query<Registry>(sql, new DynamicParameters());
                var record = result.FirstOrDefault(x => x.Email == login.Email);

                if (record != null)
                {
                    var hashedPass = CommonUtil.GetHashedString(login.Password);

                    if (record.Password.Equals(hashedPass))
                    {
                        // password check ok, return a new session of user
                        var guid = Guid.NewGuid();
                        return Ok(new Session { SessionId = guid.ToString() });
                    }
                }
            }
            return Forbid();
        }
    }
}
