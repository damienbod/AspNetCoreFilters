using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5.Filters
{
    using Microsoft.AspNet.Mvc;
    using Microsoft.Framework.Logging;

    public class ConsoleLogActionTwoFilter : ActionFilterAttribute
    {
        private readonly ILogger _logger;

        public ConsoleLogActionTwoFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("TestController");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("ConsoleLogActionTwoFilter OnActionExecuting");
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("ConsoleLogActionTwoFilter OnActionExecuted");
            base.OnActionExecuted(context);
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation("ConsoleLogActionTwoFilter OnResultExecuting");
            base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation("ConsoleLogActionTwoFilter OnResultExecuted");
            base.OnResultExecuted(context);
        }
    }
}
