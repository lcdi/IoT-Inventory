namespace IoTInventory.Models;

/// <summary>
/// Represents a phone used for IoT device data generation
/// </summary>
public class Phone
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string OperatingSystem { get; set; } = string.Empty;
    public bool IsCheckedOut { get; set; }
    public string? CheckedOutBy { get; set; }

    // TODO: Add any additional properties needed for phone tracking
    // Consider: OSVersion, IMEI, Notes, etc.
}
