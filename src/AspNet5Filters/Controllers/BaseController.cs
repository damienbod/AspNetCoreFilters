using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using AspNet5.Filters.ActionFilters;

using Microsoft.Extensions.Logging;

namespace AspNet5.Controllers
{
    [ServiceFilter(typeof(ClassConsoleLogActionBaseFilter))]
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        private readonly ILogger _logger;

        public BaseController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("BaseController");
        }

        // GET: api/test
        [HttpGet]
        [HttpGet("getallbase")]
        [ServiceFilter(typeof(ConsoleLogActionOneFilter))]
        [ServiceFilter(typeof(ConsoleLogActionTwoFilter))]
        public IEnumerable<string> Get()
        {
            _logger.LogInformation("Executing Http Get all");
            return new string[] { "test data one", "test data two" };
        }
    }
}
