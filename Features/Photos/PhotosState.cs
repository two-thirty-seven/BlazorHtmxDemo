namespace BlazorHtmxDemo.Features.Photos;

public record PhotosState(int Page, int Size)
{
    public PhotosState() : this(1, 24){}
}