using BlazorHtmxDemo.Features.Photos;

public record PhotosState(int Page, int Size, IEnumerable<Photo> Photos)
{
    public PhotosState() : this(1, 16, Enumerable.Empty<Photo>()){}
}