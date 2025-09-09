namespace TheRestaurantMvc.Clients;

public class RestaurantApiClient(HttpClient httpClient) : IRestaurantApiClient
{
    public HttpClient TheRestaurantApiClient() => httpClient; // Always returns same instance
}