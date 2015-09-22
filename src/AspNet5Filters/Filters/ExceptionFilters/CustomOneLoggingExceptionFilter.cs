using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;

namespace AspNet5.Filters.ExceptionFilters
{
    public class CustomOneLoggingExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;

        public CustomOneLoggingExceptionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("CustomOneLoggingExceptionFilter");
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogInformation("OnActionExecuting");
        }
    }
}
