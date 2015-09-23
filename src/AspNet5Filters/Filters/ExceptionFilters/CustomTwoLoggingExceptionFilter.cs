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
            handleCustomException(context);
        }

        private void handleCustomException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(CustomException))
            {
                _logger.LogInformation("Handling the custom exception here, will not pass  it on to further exception filters");
                context.Exception = null;
            }
        }
    }
}
