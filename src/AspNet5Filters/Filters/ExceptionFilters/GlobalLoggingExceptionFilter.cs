using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;

namespace AspNet5.Filters.ExceptionFilters
{
    public class GlobalLoggingExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;

        public GlobalLoggingExceptionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("GlobalLoggingExceptionFilter.");
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogInformation("OnActionExecuting");
        }
    }
}
