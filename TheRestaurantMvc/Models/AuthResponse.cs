namespace TheRestaurantMvc.Models;

public record AuthResponse(
    string AccessToken,
    string RefreshToken
    );