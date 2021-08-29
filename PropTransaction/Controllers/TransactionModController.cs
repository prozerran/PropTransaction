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
    public class TransactionModController : BaseController
    {
        public TransactionModController(ILogger<TransactionModController> logger) : base(logger)
        { }

        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            using (var conn = new SQLiteConnection(connstr))
            {
                var resultset = conn.Query<Transaction>("SELECT * FROM 'Transaction'", new DynamicParameters());
                return resultset.ToList();
            }
        }

        // Adds items to table
        [HttpPost]
        public IActionResult Post([FromBody] Transaction tran)
        {
            var sessionId = Request.Headers["Authorization"];
            var sv = LoginController.GetSessionView(sessionId);
            tran.UserId = sv.UserId;

            using (var conn = new SQLiteConnection(connstr))
            {
                conn.Execute("INSERT INTO 'Transaction' (PropertyId, UserId, TransactionDate) " +
                     "VALUES (@PropertyId, @UserId, @TransactionDate)", tran);
            }
            return Ok();
        }

        // Deletes items from table
        [HttpDelete]
        [Route("{propId}")]
        public IActionResult Delete(int transId)
        {
            using (var conn = new SQLiteConnection(connstr))
            {
                conn.Execute($"DELETE FROM 'Transaction' WHERE PropertyId = {transId}");
            }
            return Ok();
        }

        // Updates items in table
        [HttpPut]
        public IActionResult Put([FromBody] Transaction tran)
        {
            using (var conn = new SQLiteConnection(connstr))
            {
                conn.Execute("UPDATE 'Transaction' SET " +
                    "PropertyId = @PropertyId, " +
                    "UserId = @UserId, " +
                    "TransactionDate = @TransactionDate " +
                    "WHERE TransactionId = @TransactionId", tran);
            }
            return Ok();
        }
    }
}
