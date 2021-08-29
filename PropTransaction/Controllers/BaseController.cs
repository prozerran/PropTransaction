using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PropTransaction.Common;
using PropTransaction.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PropTransaction.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly string connstr = CommonUtil.DBPath;

        protected readonly ILogger<BaseController> _logger;

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }
    }
}
