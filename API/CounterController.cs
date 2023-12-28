using BlazorHtmxDemo.Components.Partials;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CounterController : ControllerBase
{
    [HttpGet]
    public IResult GetCounter()
    {
        return new RazorComponentResult<CurrentCount>();
    }

    [HttpPost]
    public IResult IncrementCounter()
    {
        int? currentCount = HttpContext.Session.GetInt32("CurrentCount");
        if (currentCount.HasValue)
        {
            currentCount++;
        }
        else {
            currentCount = 0; 
        }
        HttpContext.Session.SetInt32("CurrentCount", currentCount.Value);
        HttpContext.Response.Headers.Append("HX-Trigger", "counter-updated");

        return new RazorComponentResult<CurrentCount>();
    }
}