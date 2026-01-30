using System;

namespace IoTInventory.Models;

/// <summary>
/// Represents a checkout record linking phones and devices
/// </summary>
public class CheckOut
{
    public int Id { get; set; }
    public int PhoneId { get; set; }
    public int DeviceId { get; set; }
    public string CheckedOutBy { get; set; } = string.Empty;
    public DateTime CheckOutDate { get; set; }
    public DateTime? CheckInDate { get; set; }
    public string Purpose { get; set; } = string.Empty; // e.g., "Data Generation", "Development"

    // TODO: Add navigation properties when implementing proper database
    // public Phone? Phone { get; set; }
    // public Device? Device { get; set; }

    // TODO: Consider adding additional tracking information
    // Notes, Status, etc.
}
