namespace BlazorHtmxDemo.Extensions;

public static class HXRequestOnlyEndpointExtensions
{
    public static RouteHandlerBuilder RequireHXRequest(this RouteHandlerBuilder builder)
    {
        return builder.AddEndpointFilter(async (context, next) =>
        {
            var httpContext = context.HttpContext;
            if (!httpContext.Request.Headers.ContainsKey("HX-Request"))
            {
                return Results.StatusCode(403);
            }
            return await next(context);
        });
    }
}
