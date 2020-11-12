using DITypeFilterSample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace Pachkoriya_HW09.Infrastructure
{
    public class ExceptionLogingAttribute : ExceptionFilterAttribute
    {
        private readonly Logger logger;

        public ExceptionLogingAttribute(Logger logger)
        {
            this.logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            logger.WriteLog("Message: " + context.Exception.Message);
            logger.WriteLog("Stack Trace: " + context.Exception.StackTrace);
            
            // возврат другого представления в случае ошибки
            context.Result = new ViewResult() { ViewName = "Error" };
        }
    }
}