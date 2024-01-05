namespace BlazorHtmxDemo.Features.Photos;

public class PhotosService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public PhotosService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<Photo>> FetchPhotos(int currentPage, int pageSize)
    {
        var baseUrl = _configuration.GetValue<string>($"Urls:Photos");
        var album = $"{baseUrl}/v2/list?page={currentPage}&limit={pageSize}";

        HttpClient _httpClient = _httpClientFactory.CreateClient();
        var photos = await _httpClient.GetFromJsonAsync<PhotoDto[]>(album);
        var payload = photos.Select((p) => new Photo(p.Id, $"{baseUrl}/id/{p.Id}/235", p.Download_Url, p.Author));

        return payload ?? Array.Empty<Photo>();
    }
}
