﻿using Dapper;
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

        [HttpPost]
        public IActionResult Post([FromBody] Property prop)
        {
            using (var conn = new SQLiteConnection(connstr))
            {
                conn.Execute("INSERT INTO Property (PropertyName, Bedroom, IsAvaliable, SalePrice, LeasePrice) " +
                     "VALUES (@PropertyName, @Bedroom, @IsAvaliable, @SalePrice, @LeasePrice)", prop);
            }
            return Ok();
        }

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