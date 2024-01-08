using BlazorHtmxDemo.Features.Photos;

public record PhotosState(int Page, int Size, IEnumerable<Photo> Photos)
{
    public PhotosState() : this(1, 24, Enumerable.Empty<Photo>()){}
}