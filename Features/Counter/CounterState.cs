namespace BlazorHtmxDemo.Features.Counter;

public record CounterState(int CurrentCount)
{
    public CounterState() : this(0){}
}