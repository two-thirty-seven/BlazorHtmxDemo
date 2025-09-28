using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlazorHtmxDemo.Features.Todo;

public class TodoController(IHttpContextAccessor contextAccessor) : ControllerBase
{
    [HttpGet("/todolist")]
    public IResult Index()
    {
        var tasks = contextAccessor.HttpContext?.Session.GetObjectFromJson<List<TodoTask>>("Tasks") ?? [];
        return new RazorComponentResult<TodoList>(new
        {
            Tasks = tasks
        });
    }

    [HttpPatch("/todolist/add")]
    public IResult Add([FromForm] List<TodoTask>? tasks)
    {
        tasks?.Add(new TodoTask(tasks.Count, "", false));
            
        return new RazorComponentResult<TodoList>(new
        {
            tasks
        });
    }
    
    [HttpPatch("/todolist/delete/{index:int}")]
    public IResult Add(int index, [FromForm] List<TodoTask>? tasks)
    {
        tasks?.RemoveAt(index);
            
        return new RazorComponentResult<TodoList>(new
        {
            tasks
        });
    }

    [HttpPost("/todolist")]
    public IResult Save([FromForm] List<TodoTask>? tasks)
    {
        contextAccessor.HttpContext?.Session.SetObjectAsJson<List<TodoTask>>("Tasks", tasks!);
        return new RazorComponentResult<TodoList>(new
        {
            tasks
        });
    }
}