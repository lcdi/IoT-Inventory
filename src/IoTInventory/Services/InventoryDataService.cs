using System;
using System.Collections.Generic;
using IoTInventory.Models;

namespace IoTInventory.Services;

/// <summary>
/// Mock data service providing in-memory storage for the inventory
/// TODO: Replace this with a proper database implementation (e.g., Entity Framework Core with SQLite)
/// </summary>
public class InventoryDataService
{
    private List<Device> _devices;
    private List<Phone> _phones;
    private List<CheckOut> _checkOuts;

    public InventoryDataService()
    {
        _devices = new List<Device>();
        _phones = new List<Phone>();
        _checkOuts = new List<CheckOut>();

        // Initialize with some sample data
        InitializeSampleData();
    }

    private void InitializeSampleData()
    {
        // TODO: Interns should modify or remove this sample data
        _devices.Add(
            new Device
            {
                Id = 1,
                Name = "Smart Thermostat",
                Type = "Environmental Sensor",
                Manufacturer = "Nest",
                ModelNumber = "T3007ES",
                IsCheckedOut = false,
            }
        );

        _phones.Add(
            new Phone
            {
                Id = 1,
                Name = "Development Phone 1",
                Model = "Pixel 7",
                OperatingSystem = "Android",
                IsCheckedOut = false,
            }
        );
    }

    // Device Methods
    public List<Device> GetAllDevices()
    {
        // TODO: Implement proper data retrieval
        return _devices;
    }

    public Device? GetDeviceById(int id)
    {
        // TODO: Implement device lookup by ID
        throw new NotImplementedException();
    }

    public void AddDevice(Device device)
    {
        // TODO: Implement device creation with proper ID generation
        throw new NotImplementedException();
    }

    // Phone Methods
    public List<Phone> GetAllPhones()
    {
        // TODO: Implement proper data retrieval
        return _phones;
    }

    public Phone? GetPhoneById(int id)
    {
        // TODO: Implement phone lookup by ID
        throw new NotImplementedException();
    }

    public void AddPhone(Phone phone)
    {
        // TODO: Implement phone creation with proper ID generation
        throw new NotImplementedException();
    }

    // CheckOut Methods
    public List<CheckOut> GetAllCheckOuts()
    {
        // TODO: Implement proper data retrieval
        return _checkOuts;
    }

    public void CheckOutDevice(int phoneId, int deviceId, string userName, string purpose)
    {
        // TODO: Implement checkout logic
        // 1. Verify phone and device exist
        // 2. Check if they're already checked out
        // 3. Create checkout record
        // 4. Update device and phone status
        throw new NotImplementedException();
    }

    public void CheckInDevice(int checkOutId)
    {
        // TODO: Implement check-in logic
        // 1. Find the checkout record
        // 2. Set check-in date
        // 3. Update device and phone status
        throw new NotImplementedException();
    }
}
