using Microsoft.AspNet.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace AspNet5.Filters.ExceptionFilters
{
    public class CustomTwoLoggingExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public CustomTwoLoggingExceptionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("CustomTwoLoggingExceptionFilter");
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogInformation("OnException");
            handleCustomException(context);
            base.OnException(context);
        }

        //public override Task OnExceptionAsync(ExceptionContext context)
        //{
        //    _logger.LogInformation("OnActionExecuting async");
        //    return base.OnExceptionAsync(context);
        //}

        private void handleCustomException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(CustomException))
            {
                _logger.LogInformation("Handling the custom exception here, will not pass it on to further exception filters");
                context.Exception = null;
            }
        }
    }
}
