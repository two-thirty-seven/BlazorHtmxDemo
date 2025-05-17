namespace BlazorHtmxDemo.Features.Photos;

public class PhotosService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
{
    public async Task<IEnumerable<Photo>> FetchPhotos(int currentPage, int pageSize)
    {
        var baseUrl = configuration.GetValue<string>($"Urls:Photos");
        var album = $"{baseUrl}/v2/list?page={currentPage}&limit={pageSize}";

        var httpClient = httpClientFactory.CreateClient();
        var photos = await httpClient.GetFromJsonAsync<PhotoDto[]>(album);
        var payload = photos!.Select((p) => new Photo(p.Id, $"{baseUrl}/id/{p.Id}/235", p.Download_Url, p.Author));

        return payload ?? [];
    }
}
