using System.Collections.Generic;
using IoTInventory.Models;
using IoTInventory.Services;
using Xunit;

namespace IoTInventory.Tests;

/// <summary>
/// Example unit tests for the InventoryDataService
/// TODO: Interns should add more comprehensive tests here
/// </summary>
public class InventoryDataServiceTests
{
    [Fact]
    public void GetAllDevices_ReturnsListOfDevices()
    {
        // Arrange - Set up the test
        var service = new InventoryDataService();

        // Act - Perform the action we're testing
        var devices = service.GetAllDevices();

        // Assert - Verify the result
        Assert.NotNull(devices);
        Assert.IsType<List<Device>>(devices);
    }

    [Fact]
    public void GetAllPhones_ReturnsListOfPhones()
    {
        // Arrange
        var service = new InventoryDataService();

        // Act
        var phones = service.GetAllPhones();

        // Assert
        Assert.NotNull(phones);
        Assert.IsType<List<Phone>>(phones);
    }

    // TODO: Add more tests!
    // Ideas for tests to implement:
    // - Test that AddDevice properly adds a device
    // - Test that checkout prevents double-booking
    // - Test that GetDeviceById returns null for invalid ID
    // - Test that CheckInDevice properly updates status
    // - Test error handling for edge cases

    // Example of testing for exceptions:
    // [Fact]
    // public void AddDevice_NullDevice_ThrowsArgumentNullException()
    // {
    //     var service = new InventoryDataService();
    //     Assert.Throws<ArgumentNullException>(() => service.AddDevice(null));
    // }
}
