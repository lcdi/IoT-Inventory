using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IoTInventory.Models;
using IoTInventory.Services;

namespace IoTInventory.ViewModels;

/// <summary>
/// Example ViewModel demonstrating CommunityToolkit.Mvvm patterns
/// This shows the modern approach your team uses for MVVM development
/// TODO: Interns should study this and create similar ViewModels for the main window
/// </summary>
public partial class ExampleViewModel : ObservableObject
{
    private readonly InventoryDataService _dataService;

    public ExampleViewModel()
    {
        _dataService = new InventoryDataService();
        Devices = new ObservableCollection<Device>(_dataService.GetAllDevices());
    }

    // ObservableCollection automatically notifies the UI when items are added/removed
    public ObservableCollection<Device> Devices { get; set; }

    /// <summary>
    /// The [ObservableProperty] attribute automatically generates:
    /// - A private backing field (_searchText)
    /// - A public property with INotifyPropertyChanged implementation
    /// - OnSearchTextChanged() and OnSearchTextChanging() partial methods you can implement
    ///
    /// This replaces the manual property implementation with full change notification
    /// </summary>
    [ObservableProperty]
    private string _searchText = string.Empty;

    /// <summary>
    /// Optional: This method is called after SearchText changes
    /// Uncomment and implement to add search functionality
    /// </summary>
    // partial void OnSearchTextChanged(string value)
    // {
    //     // TODO: Filter Devices collection based on search text
    //     FilterDevices(value);
    // }

    /// <summary>
    /// Another observable property example
    /// This demonstrates how easy it is to add properties with CommunityToolkit.Mvvm
    /// </summary>
    [ObservableProperty]
    private Device? _selectedDevice;

    /// <summary>
    /// The [RelayCommand] attribute automatically generates:
    /// - An ICommand property named "AddDeviceCommand"
    /// - Proper command implementation with INotifyPropertyChanged
    ///
    /// In XAML, bind to this like: Command="{Binding AddDeviceCommand}"
    /// </summary>
    [RelayCommand]
    private void AddDevice()
    {
        // TODO: Implement adding a device
        // This could open a dialog, or add directly if you have the data

        // Example of what you might do:
        // var newDevice = new Device { Name = "New Device", Type = "Sensor" };
        // _dataService.AddDevice(newDevice);
        // Devices.Add(newDevice);
    }

    /// <summary>
    /// Commands can also be async!
    /// The [RelayCommand] attribute generates "RefreshDevicesCommand"
    /// </summary>
    [RelayCommand]
    private async Task RefreshDevices()
    {
        // TODO: Implement refresh logic
        // For now, just reload from service
        await Task.Run(() =>
        {
            var devices = _dataService.GetAllDevices();
            // Update UI on UI thread
            App.Current.Dispatcher.Invoke(() =>
            {
                Devices.Clear();
                foreach (var device in devices)
                {
                    Devices.Add(device);
                }
            });
        });
    }

    /// <summary>
    /// Commands can also take parameters!
    /// The parameter type is inferred from the method signature
    /// In XAML: Command="{Binding DeleteDeviceCommand}" CommandParameter="{Binding}"
    /// </summary>
    [RelayCommand]
    private void DeleteDevice(Device device)
    {
        // TODO: Implement device deletion
        // _dataService.DeleteDevice(device.Id);
        // Devices.Remove(device);
    }

    /// <summary>
    /// You can control when a command can execute
    /// The method name should be "Can" + CommandMethodName
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanDeleteDevice))]
    private void DeleteSelectedDevice()
    {
        if (SelectedDevice != null)
        {
            // TODO: Implement deletion
            // Devices.Remove(SelectedDevice);
        }
    }

    private bool CanDeleteDevice()
    {
        // Command only enabled when a device is selected
        return SelectedDevice != null;
    }

    // TODO: Add more commands for your application needs:
    // - EditDeviceCommand
    // - CheckOutDeviceCommand
    // - CheckInDeviceCommand
    // - SearchDevicesCommand
    // etc.

    // TIPS FOR INTERNS:
    // 1. Use [ObservableProperty] for all properties that the UI needs to observe
    // 2. Use [RelayCommand] for all button/action commands
    // 3. Keep ViewModels focused on presentation logic, not business logic
    // 4. Business logic goes in Services
    // 5. ViewModels should never reference UI elements directly
}
