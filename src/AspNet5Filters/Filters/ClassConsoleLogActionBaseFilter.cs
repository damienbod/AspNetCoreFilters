namespace AspNet5.Filters
{
    using Microsoft.AspNet.Mvc;
    using Microsoft.Framework.Logging;

    public class ClassConsoleLogActionBaseFilter : ActionFilterAttribute
    {
        private readonly ILogger _logger;

        public ClassConsoleLogActionBaseFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("TestController");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogWarning("ClassConsoleLogActionBaseFilter OnActionExecuting");
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogWarning("ClassConsoleLogActionBaseFilter OnActionExecuted");
            base.OnActionExecuted(context);
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogDebug("ClassConsoleLogActionBaseFilter OnResultExecuting");
            base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogDebug("ClassConsoleLogActionBaseFilter OnResultExecuted");
            base.OnResultExecuted(context);
        }
    }
}
