namespace TheRestaurantMvc.HttpClients;

public class RegisteredClients(IHttpClientFactory clientFactory)
{
    public HttpClient TheRestaurantApiClient() =>
        clientFactory.CreateClient("TheRestaurantApi");
}