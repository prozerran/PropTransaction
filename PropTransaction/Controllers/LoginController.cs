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
    public class LoginController : BaseController
    {
        public LoginController(ILogger<LoginController> logger) : base(logger)
        { }

        // Login
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
                        // logout previous login, kickout previous session
                        Delete(record.Id);

                        // password check ok, return a new session of user
                        var session = new Session {
                            UserId = record.Id,
                            SessionId = Guid.NewGuid().ToString()
                        };

                        // Add the new Session
                        InsertSession(session);
                        return Ok(session);
                    }
                }
            }
            return Forbid();
        }

        // Logout
        [HttpDelete]
        [Route("{userId}")]
        public IActionResult Delete(int userId)
        {
            using (var conn = new SQLiteConnection(connstr))
            {
                conn.Execute($"DELETE FROM Session WHERE UserId = {userId}");
            }
            return Ok();
        }

        // IsAdmin
        [HttpGet]
        [Route("{userId}")]
        public IActionResult Get(int userId)
        {
            using (var conn = new SQLiteConnection(connstr))
            {
                var sql = string.Format($"SELECT * FROM User WHERE Id = {userId}");

                var result = conn.Query<Registry>(sql, new DynamicParameters());
                var record = result.FirstOrDefault(x => x.Id == userId);

                if (record != null) {
                    return Ok(record.IsAdmin);
                }
            }
            return BadRequest("No User Found");
        }

        #region Private Methods
        private void InsertSession(Session session)
        {
            using (var conn = new SQLiteConnection(connstr))
            {
                conn.Execute("INSERT INTO Session (UserId, SessionId) VALUES (@UserId, @SessionId)", session);
            }
        }

        public static bool IsSessionValid(string sessionId)
        {
            var connstr = CommonUtil.DBPath;

            using (var conn = new SQLiteConnection(connstr))
            {
                var sql = string.Format($"SELECT * FROM Session_View WHERE SessionId = '{sessionId}'");

                var result = conn.Query<SessionView>(sql, new DynamicParameters());
                var record = result.FirstOrDefault(x => x.SessionId == sessionId);

                if (record != null)
                    return true;
            }
            return false;
        }

        public static SessionView GetSessionView(string sessionId)
        {
            var connstr = CommonUtil.DBPath;

            using (var conn = new SQLiteConnection(connstr))
            {
                var sql = string.Format($"SELECT * FROM Session_View WHERE SessionId = '{sessionId}'");

                var result = conn.Query<SessionView>(sql, new DynamicParameters());
                return result.FirstOrDefault(x => x.SessionId == sessionId);
            }
        }
        #endregion
    }
}
