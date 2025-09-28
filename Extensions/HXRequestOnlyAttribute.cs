using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlazorHtmxDemo.Extensions;

public class HXRequestOnlyAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.HttpContext.Request.Headers.ContainsKey("HX-Request"))
        {
            context.Result = new ForbidResult();
        }
        base.OnActionExecuting(context);
    }
}
