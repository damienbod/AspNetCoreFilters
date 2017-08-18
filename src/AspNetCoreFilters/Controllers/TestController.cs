using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreFilters.Filters.ActionFilters;
using Microsoft.Extensions.Logging;

namespace AspNetCoreFilters.Controllers
{
    [ServiceFilter(typeof(ClassConsoleLogActionOneFilter))]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly ILogger _logger;

        public TestController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("TestController");
        }

        // GET: api/test
        [HttpGet]
        [ServiceFilter(typeof(ConsoleLogActionOneFilter))]
        [ServiceFilter(typeof(ConsoleLogActionTwoFilter))]
        public IEnumerable<string> Get()
        {
            _logger.LogInformation("Executing Http Get all");
            return new string[] { "test data one", "test data two" };
        }

    }
}
