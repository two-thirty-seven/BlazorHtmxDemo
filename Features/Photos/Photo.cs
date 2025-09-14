namespace BlazorHtmxDemo.Features.Photos;

public record Photo(string Id, string ThumbnailUrl, string DownloadUrl, string Author) { }

public record PhotoDto(string Id, string Author, int Width, int Height, string Url, string Download_Url) { }