using System.Net;

namespace TheRestaurantMvc.Models;

public record ApiResponse<T>(
    bool IsSuccess,
    HttpStatusCode StatusCode,
    T? Value,
    string Message
    );