namespace TheRestaurantMvc.Clients;

public class RestaurantApiClient : IRestaurantApiClient
{
    private readonly HttpClient _httpClient;
    
    public RestaurantApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public HttpClient TheRestaurantApiClient() => _httpClient; // Always returns same instance
}