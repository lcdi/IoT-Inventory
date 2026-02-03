# IoT Device Inventory System - Intern Guide
Note: The documentation found here is about the specifics to the **intern project only.**
For guides that pertain to both the IoT-Extraction team and the IoT-Programming team, please be sure to read
the full team documentation at The IoT-Extraction DocSite http://192.168.104.15/docs/onboarding/welcome.html
(only accessible while on Leahy Center network).

## Project Overview
This is the starter codebase for the IoT Device Inventory System. 
The goal is to create an application that allows IoT team members to check out IoT devices and phones for data generation purposes.

**Important**: This is a learning project! The current codebase is intentionally incomplete. 
Your job is to add the missing functionality and learn about software development in the process.

## What This Project Currently Has

### Basic Structure
- WPF application skeleton
- Basic model classes (Device, Phone, CheckOut)
- Mock data service with sample data
- Simple UI layout with tabs

### What's Missing?
- **Data display**: DataGrids to show devices and phones
- **CRUD operations**: Add, edit, delete functionality
- **Checkout system**: Ability to check out devices with phones
- **Search/filtering**: Find specific devices or phones
- **Unit tests**: Verify your code works correctly
- **Data persistence**: Currently data only lives in memory
- **Input validation**: Ensure users enter valid data
- **Error handling**: Gracefully handle problems

## Project Structure

```
IoT-Inventory/
├── src/
│   └── IoTInventory/
│       ├── Models/              # Data models (Device, Phone, CheckOut)
│       ├── ViewModels/          # TODO: Add ViewModels for MVVM pattern
│       ├── Views/               # TODO: Add additional windows/dialogs
│       ├── Services/            # Data services (currently mock data)
│       ├── MainWindow.xaml      # Main application window
│       └── App.xaml             # Application entry point
├── tests/                       # TODO: Add unit tests here
└── docs/                        # Documentation
```

## Getting Started

### Prerequisites
- .NET 10.0 SDK or later
- Visual Studio 2022 or Visual Studio Code with C# extension
- Git for version control

### Building the Project
```bash
cd src/IoTInventory
dotnet restore
dotnet build
dotnet run
```

## Learning Paths

Based on the project description, you can focus on different areas:

### Frontend Development
**Goal**: Create a user-friendly interface

**Tasks to implement**:
1. Replace placeholder borders with DataGrids to display devices and phones
2. Create dialog windows for adding new devices/phones
3. Implement a checkout dialog that shows available phones and devices
4. Add search/filter functionality to find items quickly
5. Display active checkouts with device-phone associations
6. Add status indicators (checked out vs available)

**Skills you'll learn**: WPF, XAML, UI/UX design, data binding

### Backend Development
**Goal**: Implement the core business logic

**Tasks to implement**:
1. Complete the `InventoryDataService` methods (Add, Update, Delete, etc.)
2. Implement checkout/check-in logic with validation
3. Add a proper ID generation system
4. Create filtering/search algorithms
5. Consider migrating from in-memory storage to SQLite database
6. Implement the MVVM pattern with ViewModels

**Skills you'll learn**: C#, algorithms, data structures, database basics, design patterns

### Testing
**Goal**: Ensure code quality through automated tests

**Tasks to implement**:
1. Write unit tests for the data service methods
2. Test checkout logic edge cases (already checked out, invalid IDs)
3. Create integration tests for the full checkout workflow
4. Set up test coverage reporting

**Skills you'll learn**: Unit testing, xUnit/NUnit, Test-Driven Development (TDD)

### CI/CD
**Goal**: Automate build and test processes

**Tasks to implement**:
1. Create a GitHub Actions workflow that builds the project
2. Add automatic test running on pull requests
3. Set up code linting (Done for you!)
4. Create release builds with versioning

**Skills you'll learn**: GitHub Actions, automation, DevOps basics

## Key Concepts to Research

### CommunityToolkit.Mvvm
This project uses the CommunityToolkit.Mvvm package (same as your team uses!) which simplifies MVVM development:
- **[ObservableProperty]** - Auto-generates properties with change notification
- **[RelayCommand]** - Auto-generates ICommand implementations
- **ObservableObject** - Base class for ViewModels
- Study the `ExampleViewModel.cs` to see these in action!

**We have a complete guide!** See [COMMUNITYTOOLKIT_MVVM_GUIDE.md](COMMUNITYTOOLKIT_MVVM_GUIDE.md) for detailed examples and best practices.

Learn more: [CommunityToolkit.Mvvm Documentation](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/)

### MVVM Pattern (Recommended!)
WPF works best with the Model-View-ViewModel pattern:
- **Model**: Your data classes (Device, Phone) - already created!
- **ViewModel**: Classes that prepare data for the View - needs to be created
- **View**: XAML UI - basic structure exists, needs enhancement

### Data Binding
Learn how to connect your UI to your data without manually updating it:
```xml
<TextBlock Text="{Binding DeviceName}"/>
<Button Command="{Binding AddDeviceCommand}" Content="Add Device"/>
```

With CommunityToolkit.Mvvm, your ViewModel code is much simpler:
```csharp
[ObservableProperty]
private string _deviceName = "";

[RelayCommand]
private void AddDevice()
{
    // Your logic here
}
```

### ObservableCollection
For lists that automatically update the UI when items are added/removed:
```csharp
public ObservableCollection<Device> Devices { get; set; }
```

## Resources

### WPF Learning
- [Microsoft WPF Documentation](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/)
- [WPF Tutorial](https://www.wpftutorial.net/)
- [MVVM Pattern Guide](https://docs.microsoft.com/en-us/dotnet/architecture/maui/mvvm)

### C# Learning
- [C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [C# Fundamentals for Beginners](https://docs.microsoft.com/en-us/shows/csharp-fundamentals-for-absolute-beginners/)

### Testing
- [xUnit Getting Started](https://xunit.net/docs/getting-started/netcore/cmdline)
- [Unit Testing Best Practices](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices)

## Code Review Guidelines

When reviewing each other's code, look for:
- ✅ Clear, descriptive variable and method names
- ✅ Appropriate comments explaining complex logic
- ✅ Error handling for edge cases
- ✅ Consistent code style
- ✅ Tests for new functionality
- ❌ Hardcoded values that should be configurable
- ❌ Copy-pasted code (consider extracting to a method)
- ❌ Missing null checks

## Questions?

Remember, this is a learning project! It's okay to:
- Ask questions
- Make mistakes
- Try different approaches
- Look things up
- Collaborate with other interns

The goal isn't to create perfect code, but to learn and grow as developers.

## Next Steps After This Semester

If you continue developing this:
1. Add user authentication
2. Connect to a real database
3. Deploy to a network
4. Add reporting features
5. Create a web version using Blazor or ASP.NET

Good luck, and have fun coding!
