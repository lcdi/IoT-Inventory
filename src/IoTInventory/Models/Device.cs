using System;

namespace IoTInventory.Models;

/// <summary>
/// Represents an IoT device in the inventory system
/// </summary>
public class Device
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public string ModelNumber { get; set; } = string.Empty;
    public bool IsCheckedOut { get; set; }
    public DateTime? LastDataGenDate { get; set; }

    // TODO: Add any additional properties needed for device tracking
    // Consider: SerialNumber, Notes, PurchaseDate, Status, etc.
}
