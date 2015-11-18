using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using AspNet5.Filters.ActionFilters;
using Microsoft.Extensions.Logging;

namespace AspNet5.Controllers
{
    [ServiceFilter(typeof(ClassConsoleLogActionOneFilter), Order=3)]
    [Route("api/[controller]")]
    public class TestWithOrderedFiltersController : Controller
    {
        private readonly ILogger _logger;

        public TestWithOrderedFiltersController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("TestWithOrderedFiltersController");
        }

        // GET: api/test
        [HttpGet]
        [ServiceFilter(typeof(ConsoleLogActionOneFilter), Order = 5)]
        [ServiceFilter(typeof(ConsoleLogActionTwoFilter), Order = 2)]
        public IEnumerable<string> Get()
        {
            _logger.LogInformation("Http Get all");
            return new string[] { "test data one", "test data two" };
        }
    }
}
