using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5.Filters
{
    using Microsoft.AspNet.Mvc;
    using Microsoft.Framework.Logging;

    public class ConsoleLogActionOneFilter : ActionFilterAttribute
    {
        private readonly ILogger _logger;

        public ConsoleLogActionOneFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("ConsoleLogActionOneFilter");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("OnActionExecuting");
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("OnActionExecuted");
            base.OnActionExecuted(context);
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation("OnResultExecuting");
            base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation("OnResultExecuted");
            base.OnResultExecuted(context);
        }
    }
}
