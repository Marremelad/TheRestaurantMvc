namespace TheRestaurantMvc.Utilities;

public class RegisteredClients(IHttpClientFactory clientFactory)
{
    public HttpClient TheRestaurantApiClient() =>
        clientFactory.CreateClient("TheRestaurantApi");
}