using Microsoft.AspNet.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace AspNet5.Filters.ExceptionFilters
{
    public class CustomOneLoggingExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public CustomOneLoggingExceptionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("CustomOneLoggingExceptionFilter");
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogInformation("OnException");
            base.OnException(context);
        }

        //public override Task OnExceptionAsync(ExceptionContext context)
        //{
        //    _logger.LogInformation("OnActionExecuting async");
        //    return base.OnExceptionAsync(context);
        //}
    }
}
