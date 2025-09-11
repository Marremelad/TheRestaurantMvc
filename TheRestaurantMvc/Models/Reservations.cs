namespace TheRestaurantMvc.Models;

public record Reservation(
    int Id,
    DateOnly Date,
    int TimeSlot,
    string DisplayableTimeSlot, 
    int TableNumber,
    string FirstName,
    string LastName,
    string Email 
    );