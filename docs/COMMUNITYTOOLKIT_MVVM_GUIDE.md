# Using CommunityToolkit.Mvvm - Team Standard Guide

This project uses **CommunityToolkit.Mvvm** - the same toolkit your production team uses. This guide will help you understand and use it effectively.

## What is CommunityToolkit.Mvvm?

CommunityToolkit.Mvvm is a modern, fast, and modular MVVM toolkit. It uses **source generators** to automatically create boilerplate code for you, making MVVM development much simpler and less error-prone.

### Key Benefits
- ✅ Less boilerplate code to write
- ✅ Type-safe code generation
- ✅ Better performance than reflection-based approaches
- ✅ Industry standard (used by Microsoft and many teams)
- ✅ Same as your production team uses!

## Core Components

### 1. ObservableObject Base Class

**What it does**: Provides INotifyPropertyChanged implementation automatically.

**Usage**: Make your ViewModels inherit from it.

```csharp
using CommunityToolkit.Mvvm.ComponentModel;

public partial class DeviceViewModel : ObservableObject
{
    // Your ViewModel code here
}
```

⚠️ **Important**: Notice the `partial` keyword - required for source generators!

---

### 2. [ObservableProperty] Attribute

**What it does**: Automatically generates a full property with change notification from a private field.

**Old Way (Manual)**:
```csharp
private string _deviceName = "";

public string DeviceName
{
    get => _deviceName;
    set
    {
        if (_deviceName != value)
        {
            _deviceName = value;
            OnPropertyChanged();
        }
    }
}
```

**New Way (CommunityToolkit.Mvvm)**:
```csharp
[ObservableProperty]
private string _deviceName = "";

// That's it! The toolkit generates the public property for you.
```

The generated property is named without the underscore and with proper casing:
- `_deviceName` → generates → `DeviceName` property
- `_isCheckedOut` → generates → `IsCheckedOut` property
- `_selectedDevice` → generates → `SelectedDevice` property

**In XAML**, bind to the generated property:
```xml
<TextBox Text="{Binding DeviceName}" />
<CheckBox IsChecked="{Binding IsCheckedOut}" />
```

---

### 3. Property Change Notifications

You can hook into property changes with partial methods:

```csharp
[ObservableProperty]
private string _searchText = "";

// Called AFTER the property changes
partial void OnSearchTextChanged(string value)
{
    // Perform search/filter based on new value
    FilterDevices(value);
}

// Called BEFORE the property changes (less common)
partial void OnSearchTextChanging(string oldValue, string newValue)
{
    // Validate or prevent change if needed
}
```

---

### 4. [RelayCommand] Attribute

**What it does**: Automatically generates ICommand implementations from methods.

**Old Way (Manual)**:
```csharp
private ICommand? _addDeviceCommand;

public ICommand AddDeviceCommand
{
    get
    {
        if (_addDeviceCommand == null)
        {
            _addDeviceCommand = new RelayCommand(AddDevice, CanAddDevice);
        }
        return _addDeviceCommand;
    }
}

private void AddDevice()
{
    // Implementation
}

private bool CanAddDevice()
{
    return true;
}
```

**New Way (CommunityToolkit.Mvvm)**:
```csharp
[RelayCommand]
private void AddDevice()
{
    // Implementation
}

// Command is automatically generated as "AddDeviceCommand"
```

**In XAML**, bind to the generated command:
```xml
<Button Content="Add Device" Command="{Binding AddDeviceCommand}" />
```

---

### 5. Async Commands

Commands can be async!

```csharp
[RelayCommand]
private async Task SaveDevice()
{
    await _dataService.SaveDeviceAsync(CurrentDevice);
    // The toolkit handles all the async/await complexity
}
```

The generated command will be `SaveDeviceCommand` (still synchronous from XAML's perspective).

---

### 6. Commands with Parameters

```csharp
[RelayCommand]
private void DeleteDevice(Device device)
{
    _dataService.DeleteDevice(device.Id);
    Devices.Remove(device);
}
```

**In XAML**:
```xml
<Button Command="{Binding DeleteDeviceCommand}" 
        CommandParameter="{Binding}" 
        Content="Delete" />
```

---

### 7. Command CanExecute

Control when a command is enabled:

**Method 1: Using CanExecute parameter**
```csharp
[RelayCommand(CanExecute = nameof(CanSave))]
private void Save()
{
    // Save logic
}

private bool CanSave()
{
    return !string.IsNullOrEmpty(DeviceName);
}
```

**Method 2: Notify when CanExecute changes**
```csharp
[ObservableProperty]
[NotifyCanExecuteChangedFor(nameof(SaveCommand))]
private string _deviceName = "";

[RelayCommand(CanExecute = nameof(CanSave))]
private void Save()
{
    // Save logic
}

private bool CanSave()
{
    return !string.IsNullOrEmpty(DeviceName);
}
```

When `DeviceName` changes, the `SaveCommand`'s CanExecute is automatically re-evaluated!

---

## Complete Example ViewModel

Here's a complete example showing all the patterns:

```csharp
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace IoTInventory.ViewModels
{
    public partial class DeviceListViewModel : ObservableObject
    {
        private readonly InventoryDataService _dataService;

        public DeviceListViewModel(InventoryDataService dataService)
        {
            _dataService = dataService;
            Devices = new ObservableCollection<Device>(dataService.GetAllDevices());
        }

        // Property - automatically observable
        [ObservableProperty]
        private string _searchText = "";

        // Property with change notification
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(DeleteDeviceCommand))]
        private Device? _selectedDevice;

        // Collection
        public ObservableCollection<Device> Devices { get; set; }

        // Simple command
        [RelayCommand]
        private void AddDevice()
        {
            var newDevice = new Device { Name = "New Device" };
            _dataService.AddDevice(newDevice);
            Devices.Add(newDevice);
        }

        // Command with CanExecute
        [RelayCommand(CanExecute = nameof(CanDeleteDevice))]
        private void DeleteDevice()
        {
            if (SelectedDevice != null)
            {
                _dataService.DeleteDevice(SelectedDevice.Id);
                Devices.Remove(SelectedDevice);
            }
        }

        private bool CanDeleteDevice()
        {
            return SelectedDevice != null;
        }

        // Async command
        [RelayCommand]
        private async Task RefreshDevices()
        {
            var devices = await _dataService.GetAllDevicesAsync();
            Devices.Clear();
            foreach (var device in devices)
            {
                Devices.Add(device);
            }
        }

        // Property change handler
        partial void OnSearchTextChanged(string value)
        {
            // Filter devices based on search text
            FilterDevices(value);
        }

        private void FilterDevices(string searchText)
        {
            // Implementation
        }
    }
}
```

---

## XAML Binding Examples

### Binding to Properties
```xml
<!-- Simple property binding -->
<TextBox Text="{Binding DeviceName, UpdateSourceTrigger=PropertyChanged}" />

<!-- Two-way binding -->
<CheckBox IsChecked="{Binding IsAvailable}" />

<!-- Selected item -->
<ComboBox ItemsSource="{Binding Devices}" 
          SelectedItem="{Binding SelectedDevice}" />
```

### Binding to Commands
```xml
<!-- Simple command -->
<Button Content="Add" Command="{Binding AddDeviceCommand}" />

<!-- Command with parameter -->
<Button Content="Delete" 
        Command="{Binding DeleteDeviceCommand}" 
        CommandParameter="{Binding SelectedDevice}" />

<!-- Command in DataGrid -->
<DataGrid ItemsSource="{Binding Devices}">
    <DataGrid.Columns>
        <DataGridTemplateColumn Header="Actions">
            <DataGridTemplateColumn.CellTemplate>
                <DataTemplate>
                    <Button Content="Edit" 
                            Command="{Binding DataContext.EditDeviceCommand, 
                                      RelativeSource={RelativeSource AncestorType=DataGrid}}"
                            CommandParameter="{Binding}" />
                </DataTemplate>
            </DataGridTemplateColumn.CellTemplate>
        </DataGridTemplateColumn>
    </DataGrid.Columns>
</DataGrid>
```

---

## Common Patterns

### Pattern 1: Master-Detail View
```csharp
[ObservableProperty]
[NotifyPropertyChangedFor(nameof(HasSelection))]
[NotifyCanExecuteChangedFor(nameof(EditCommand), nameof(DeleteCommand))]
private Device? _selectedDevice;

public bool HasSelection => SelectedDevice != null;

[RelayCommand(CanExecute = nameof(HasSelection))]
private void Edit()
{
    // Edit selected device
}
```

### Pattern 2: Validation
```csharp
[ObservableProperty]
[NotifyCanExecuteChangedFor(nameof(SaveCommand))]
private string _deviceName = "";

[ObservableProperty]
[NotifyCanExecuteChangedFor(nameof(SaveCommand))]
private string _deviceType = "";

[RelayCommand(CanExecute = nameof(CanSave))]
private void Save()
{
    // Save device
}

private bool CanSave()
{
    return !string.IsNullOrWhiteSpace(DeviceName) && 
           !string.IsNullOrWhiteSpace(DeviceType);
}
```

### Pattern 3: Loading State
```csharp
[ObservableProperty]
[NotifyCanExecuteChangedFor(nameof(RefreshCommand))]
private bool _isLoading;

[RelayCommand(CanExecute = nameof(CanRefresh))]
private async Task Refresh()
{
    IsLoading = true;
    try
    {
        var devices = await _dataService.GetAllDevicesAsync();
        Devices.Clear();
        foreach (var device in devices)
        {
            Devices.Add(device);
        }
    }
    finally
    {
        IsLoading = false;
    }
}

private bool CanRefresh() => !IsLoading;
```

---

## Best Practices

### ✅ DO:
- Use `partial` class for ViewModels
- Use `[ObservableProperty]` for all properties the UI needs to observe
- Use `[RelayCommand]` for all UI actions
- Keep ViewModels focused on presentation logic
- Put business logic in Services
- Use `ObservableCollection<T>` for lists that change
- Use descriptive command names (AddDeviceCommand, not AddCommand)

### ❌ DON'T:
- Don't reference UI elements (TextBox, Button, etc.) in ViewModels
- Don't put database code in ViewModels
- Don't forget the `partial` keyword
- Don't manually implement INotifyPropertyChanged when using the toolkit
- Don't create properties without `[ObservableProperty]` that need change notification

---

## Troubleshooting

### Issue: "The name 'DeviceNameProperty' does not exist"
**Solution**: You forgot the `partial` keyword on your class. Source generators need it.

### Issue: Generated property not found
**Solution**: 
1. Check that your field starts with underscore (_deviceName)
2. Make sure class is `partial`
3. Rebuild the project (Ctrl+Shift+B)
4. Sometimes Visual Studio needs a restart

### Issue: Command not working in XAML
**Solution**: 
1. Check the binding: `Command="{Binding YourMethodNameCommand}"`
2. Note: Method `DoSomething()` generates `DoSomethingCommand`
3. Make sure DataContext is set properly

### Issue: Property changes but UI doesn't update
**Solution**: 
1. Did you use `[ObservableProperty]`?
2. Is the class inheriting from `ObservableObject`?
3. Is the class marked as `partial`?

---

## Migration from Manual MVVM

If you see old manual code, here's how to convert it:

**Old**:
```csharp
private string _name;
public string Name
{
    get => _name;
    set => SetProperty(ref _name, value);
}
```

**New**:
```csharp
[ObservableProperty]
private string _name = "";
```

**Old**:
```csharp
public ICommand SaveCommand { get; }

public MyViewModel()
{
    SaveCommand = new RelayCommand(Save);
}

private void Save() { }
```

**New**:
```csharp
[RelayCommand]
private void Save() { }
```

---

## Learning Resources

- [Official Documentation](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/)
- [ObservableProperty Guide](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/generators/observableproperty)
- [RelayCommand Guide](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/generators/relaycommand)
- [Sample Apps](https://github.com/CommunityToolkit/dotnet)

---

## Quick Reference Card

```csharp
// ViewModel class
public partial class MyViewModel : ObservableObject

// Observable property
[ObservableProperty]
private string _myProperty = "";

// Property change notification
partial void OnMyPropertyChanged(string value) { }

// Simple command
[RelayCommand]
private void DoSomething() { }

// Async command
[RelayCommand]
private async Task DoSomethingAsync() { }

// Command with CanExecute
[RelayCommand(CanExecute = nameof(CanDo))]
private void DoSomething() { }
private bool CanDo() => true;

// Notify command when property changes
[ObservableProperty]
[NotifyCanExecuteChangedFor(nameof(SaveCommand))]
private string _name = "";
```

---

Remember: This is the same toolkit your production team uses, so learning it well here will prepare you for real team projects!
