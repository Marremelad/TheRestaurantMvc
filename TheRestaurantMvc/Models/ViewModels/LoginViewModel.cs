using System.ComponentModel.DataAnnotations;

namespace TheRestaurantMvc.Models.ViewModels;

public record LoginViewModel(
    [Required(ErrorMessage = "The username field is required.")] string UserName,
    [Required(ErrorMessage = "The password field is required.")] string Password
    );