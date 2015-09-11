using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using AspNet5.Filters;
using Microsoft.Framework.Logging;

namespace AspNet5.Controllers
{
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

        // GET api/test/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            _logger.LogInformation("Executing Http Get with id");
            return "test data 1";
        }

        // POST api/test
        [HttpPost]
        public void Post([FromBody]string value)
        {
            _logger.LogInformation("Executing Http Post string value");
        }
    }
}
