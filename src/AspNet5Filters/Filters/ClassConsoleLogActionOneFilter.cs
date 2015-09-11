namespace AspNet5.Filters
{
    using Microsoft.AspNet.Mvc;
    using Microsoft.Framework.Logging;

    public class ClassConsoleLogActionOneFilter : ActionFilterAttribute
    {
        private readonly ILogger _logger;

        public ClassConsoleLogActionOneFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("TestController");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("ClassConsoleLogActionOneFilter OnActionExecuting");
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("ClassConsoleLogActionOneFilter OnActionExecuted");
            base.OnActionExecuted(context);
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation("ClassConsoleLogActionOneFilter OnResultExecuting");
            base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation("ClassConsoleLogActionOneFilter OnResultExecuted");
            base.OnResultExecuted(context);
        }
    }
}
