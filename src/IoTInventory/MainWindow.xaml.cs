using System.Windows;
using IoTInventory.Services;

namespace IoTInventory;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly InventoryDataService _dataService;

    public MainWindow()
    {
        InitializeComponent();
        _dataService = new InventoryDataService();

        // TODO: Initialize data binding and load initial data
        // TODO: Set up event handlers for buttons
    }

    // TODO: Add event handlers for button clicks
    // Example methods to implement:
    // - OnAddDeviceClick
    // - OnAddPhoneClick
    // - OnCheckOutClick
    // - OnRefreshClick
}
