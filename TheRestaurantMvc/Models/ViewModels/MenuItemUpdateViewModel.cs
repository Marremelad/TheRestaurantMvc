using System.ComponentModel.DataAnnotations;

namespace TheRestaurantMvc.Models.ViewModels;

public record MenuItemUpdateViewModel(
    [Required(ErrorMessage = "Name is required.")] string Name,
    [Required(ErrorMessage = "Price is required.")][Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")] decimal Price,
    [Required(ErrorMessage = "Description is required.")] string Description,
    [Required(ErrorMessage = "Image URL is required.")] string Image,
    bool IsPopular = false
    );
