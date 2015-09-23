using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;

namespace AspNet5.Filters.ResourceFilters
{
    public class CustomOneResourceFilter : IResourceFilter
    {

        private readonly ILogger _logger;

        public CustomOneResourceFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("CustomOneResourceFilter");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            _logger.LogInformation("OnActionExecuted");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            _logger.LogInformation("OnActionExecuting");
        }
    }
}
