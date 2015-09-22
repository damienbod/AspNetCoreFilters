using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;

namespace AspNet5.Filters.ExceptionFilters
{
    public class CustomTwoLoggingExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;

        public CustomTwoLoggingExceptionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("CustomTwoLoggingExceptionFilter");
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogInformation("OnActionExecuting");
        }
    }
}
