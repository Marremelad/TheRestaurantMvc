namespace TheRestaurantMvc.Models.ViewModels;

public class MenuItemUpdateViewModel
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; } // Change from string to decimal
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public bool IsPopular { get; set; }
}
