# Contributing to IoT Device Inventory

Thank you for contributing to this project! This guide will help you get started.

## Getting Started

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd IoT-Inventory
   ```

2. **Create a branch for your work**
   ```bash
   git checkout -b feature/your-feature-name
   ```
   Examples:
   - `feature/add-device-grid`
   - `feature/checkout-dialog`
   - `fix/null-reference-error`

3. **Make your changes**
   - Write clear, understandable code
   - Add comments where logic is complex
   - Follow C# naming conventions

4. **Test your changes**
   ```bash
   dotnet build
   dotnet run
   ```

5. **Commit your changes**
   ```bash
   git add .
   git commit -m "Add device display grid to devices tab"
   ```

## Code Style Guidelines

### Naming Conventions
- **Classes**: `PascalCase` - `DeviceService`, `CheckOutDialog`
- **Methods**: `PascalCase` - `GetAllDevices()`, `CheckOutDevice()`
- **Variables**: `camelCase` - `deviceList`, `userName`
- **Private fields**: `_camelCase` - `_dataService`, `_devices`
- **Constants**: `PascalCase` - `MaxDevices`, `DefaultTimeout`

### Comments
```csharp
// Good: Explains why, not what
// Using ObservableCollection to automatically update UI when list changes
public ObservableCollection<Device> Devices { get; set; }

// Bad: States the obvious
// This is a list of devices
public List<Device> Devices { get; set; }
```

### Method Structure
```csharp
/// <summary>
/// Checks out a device to a user with a specific phone
/// </summary>
/// <param name="deviceId">The ID of the device to check out</param>
/// <param name="phoneId">The ID of the phone being used</param>
/// <param name="userName">The name of the person checking out</param>
/// <returns>True if successful, false otherwise</returns>
public bool CheckOutDevice(int deviceId, int phoneId, string userName)
{
    // Validation
    if (string.IsNullOrWhiteSpace(userName))
    {
        throw new ArgumentException("User name cannot be empty");
    }

    // Implementation
    // ...
    
    return true;
}
```

## Pull Request Process

1. **Before creating a PR**
   - Make sure your code builds without errors
   - Test your changes thoroughly
   - Update documentation if needed

2. **Create a Pull Request**
   - Use a clear title: "Add device display grid" not "Updated stuff"
   - Describe what you changed and why
   - Reference any related issues

3. **PR Description Template**
   ```markdown
   ## What does this PR do?
   Adds a DataGrid to the Devices tab that displays all devices from the service.

   ## What component does this touch?
   - [ ] Frontend (UI/XAML)
   - [x] Backend (Models/Services)
   - [ ] Testing
   - [ ] Documentation

   ## How to test?
   1. Build and run the application
   2. Navigate to the Devices tab
   3. Verify that devices appear in the grid

   ## Screenshots (if applicable)
   [Add screenshot here]
   ```

4. **Code Review**
   - Address reviewer comments
   - Make requested changes
   - Be open to feedback - we're all learning!

## Testing Guidelines

When you add new functionality, add tests:

```csharp
[Fact]
public void AddDevice_ValidDevice_AddsToList()
{
    // Arrange
    var service = new InventoryDataService();
    var device = new Device { Name = "Test Device" };
    
    // Act
    service.AddDevice(device);
    
    // Assert
    Assert.Contains(device, service.GetAllDevices());
}
```

## Common Tasks

### Adding a New Model Property
1. Add property to the model class
2. Update the UI to display/edit it
3. Update sample data in the service
4. Update any tests

### Adding a New Button
1. Add button to XAML
2. Create Click event handler in code-behind
3. Implement functionality
4. Test the button

### Creating a New Window/Dialog
1. Add new XAML file in Views folder
2. Create corresponding .xaml.cs file
3. Show dialog from main window:
   ```csharp
   var dialog = new AddDeviceDialog();
   if (dialog.ShowDialog() == true)
   {
       // Handle result
   }
   ```

## Getting Help

### If you're stuck:
1. Read the existing code
2. Check the INTERN_GUIDE.md for learning resources
3. Search online (StackOverflow, Microsoft Docs)
4. Ask your fellow interns
5. Ask the project lead

### Good questions to ask:
- "I'm trying to implement X, but I'm getting error Y. Here's what I've tried..."
- "What's the best way to display a list of items in WPF?"
- "Is it better to use approach A or approach B for this scenario?"

### Less helpful questions:
- "It doesn't work" (without details)
- "How do I do everything?" (be specific)

## Git Tips

### Keeping your branch up to date
```bash
git checkout main
git pull
git checkout your-branch
git merge main
```

### Undoing changes
```bash
# Discard changes to a file
git checkout -- filename

# Undo last commit (keep changes)
git reset --soft HEAD~1

# Undo last commit (discard changes) - BE CAREFUL
git reset --hard HEAD~1
```

## Remember

- 🎯 Focus on learning, not perfection
- 🤝 Help each other out
- 💬 Ask questions when stuck
- ✅ Test your code
- 📝 Write clear commit messages
- 🔍 Review others' code thoughtfully
- 🎉 Celebrate your progress!

Happy coding!
