namespace TheRestaurantMvc.Models.ViewModels;

public class MenuItemUpdateViewModel
{
    public string Name { get; set; } = string.Empty;

    // Use string for form binding
    public string Price { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public bool IsPopular { get; set; }
}
