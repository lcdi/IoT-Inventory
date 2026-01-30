# Project Tasks

This document breaks down the project into specific, manageable tasks. Interns can claim tasks and track their progress here.

## How to Use This File
1. Pick a task from the "Available" section
2. Move it to "In Progress" and add your name
3. Create a branch: `git checkout -b feature/task-name`
4. When done, move to "Completed" and create a Pull Request

## Task Priority Legend
- 🔴 **Critical** - Core functionality needed first
- 🟡 **Important** - Should be done soon
- 🟢 **Nice to have** - Can be done anytime
- 🔵 **Advanced** - For those wanting a challenge

---

## 🔴 Critical Tasks (Do These First!)

### Display Devices in DataGrid
**Difficulty**: Beginner  
**Skills**: WPF, XAML, Data Binding  
**Description**: Replace the placeholder in the Devices tab with a real DataGrid that displays devices from the service.
- [ ] Add DataGrid to MainWindow.xaml Devices tab
- [ ] Bind DataGrid to device collection
- [ ] Display columns: Name, Type, Manufacturer, Model Number, Checked Out status
- [ ] Test with sample data

**Resources**:
- [WPF DataGrid Tutorial](https://www.wpftutorial.net/DataGrid.html)
- [Data Binding Overview](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/data/)

---

### Display Phones in DataGrid
**Difficulty**: Beginner  
**Skills**: WPF, XAML, Data Binding  
**Description**: Same as above but for the Phones tab.
- [ ] Add DataGrid to MainWindow.xaml Phones tab
- [ ] Bind DataGrid to phone collection
- [ ] Display columns: Name, Model, OS, Checked Out status, Checked Out By
- [ ] Test with sample data

---

### Implement Add Device Functionality
**Difficulty**: Intermediate  
**Skills**: WPF, C#, Forms  
**Description**: Create a dialog to add new devices to the inventory.
- [ ] Create AddDeviceDialog.xaml window
- [ ] Add input fields for all device properties
- [ ] Implement validation (required fields, valid formats)
- [ ] Complete the AddDevice method in InventoryDataService
- [ ] Wire up the "Add Device" button to open the dialog
- [ ] Refresh the grid after adding

**Tips**: Look at how dialog windows work in WPF (ShowDialog() method)

---

## 🟡 Important Tasks

### Implement Add Phone Functionality
**Difficulty**: Intermediate  
**Skills**: WPF, C#, Forms  
**Description**: Create a dialog to add new phones to the inventory.
- [ ] Create AddPhoneDialog.xaml window
- [ ] Add input fields for all phone properties
- [ ] Implement validation
- [ ] Complete the AddPhone method in InventoryDataService
- [ ] Wire up the "Add Phone" button
- [ ] Refresh the grid after adding

---

### Implement Basic Checkout System
**Difficulty**: Intermediate  
**Skills**: C#, Business Logic  
**Description**: Allow users to check out a device with a phone.
- [ ] Create CheckOutDialog.xaml with dropdowns for phone and device selection
- [ ] Add input fields for user name and purpose
- [ ] Implement CheckOutDevice method in InventoryDataService
- [ ] Update device and phone IsCheckedOut status
- [ ] Create CheckOut record
- [ ] Display success message

---

### Display Active Checkouts
**Difficulty**: Intermediate  
**Skills**: WPF, XAML, Data Binding  
**Description**: Show currently checked-out items in the Checkouts tab.
- [ ] Add DataGrid to Active Checkouts tab
- [ ] Display: Device name, Phone name, Checked out by, Date, Purpose
- [ ] Use data binding to show real checkout data
- [ ] Add "Check In" button for each row

---

### Implement Check-In Functionality
**Difficulty**: Intermediate  
**Skills**: C#, Business Logic  
**Description**: Allow users to return devices and phones.
- [ ] Complete CheckInDevice method in InventoryDataService
- [ ] Set CheckInDate on checkout record
- [ ] Update device and phone IsCheckedOut status
- [ ] Refresh all relevant displays
- [ ] Add confirmation dialog

---

## 🟢 Nice to Have

### Add Search/Filter for Devices
**Difficulty**: Intermediate  
**Skills**: C#, LINQ, UI  
**Description**: Let users search for specific devices.
- [ ] Add search TextBox above device grid
- [ ] Implement real-time filtering as user types
- [ ] Filter by name, type, or manufacturer
- [ ] Show count of filtered results

---

### Add Search/Filter for Phones
**Difficulty**: Intermediate  
**Skills**: C#, LINQ, UI  
**Description**: Let users search for specific phones.
- [ ] Add search TextBox above phone grid
- [ ] Implement real-time filtering
- [ ] Filter by name, model, or OS

---

### Show Phone-Device Association History
**Difficulty**: Intermediate  
**Skills**: C#, Data Relationships  
**Description**: When selecting a phone, show which devices have been used with it.
- [ ] Add "View History" button to phone grid
- [ ] Create PhoneHistoryDialog.xaml
- [ ] Show all devices ever checked out with this phone
- [ ] Display dates and purposes

---

### Add Edit Device/Phone Functionality
**Difficulty**: Intermediate  
**Skills**: WPF, Forms  
**Description**: Allow editing existing items.
- [ ] Add "Edit" button to device grid
- [ ] Create EditDeviceDialog (or reuse AddDeviceDialog)
- [ ] Load existing device data into form
- [ ] Implement UpdateDevice method in service
- [ ] Repeat for phones

---

### Add Status Indicators
**Difficulty**: Beginner  
**Skills**: XAML, Styling  
**Description**: Make it visually clear which items are checked out.
- [ ] Use colors or icons to show checked-out vs available
- [ ] Example: Green = Available, Red = Checked Out
- [ ] Update DataGrid cell styles

---

## 🔵 Advanced Tasks

### Implement MVVM Pattern
**Difficulty**: Advanced  
**Skills**: Design Patterns, Architecture  
**Description**: Refactor to proper MVVM architecture.
- [ ] Create MainViewModel class
- [ ] Create DeviceViewModel class
- [ ] Move UI logic from code-behind to ViewModels
- [ ] Use INotifyPropertyChanged or MVVM framework
- [ ] Update bindings in XAML

**Resources**:
- [MVVM Pattern Documentation](https://docs.microsoft.com/en-us/dotnet/architecture/maui/mvvm)

---

### Add SQLite Database
**Difficulty**: Advanced  
**Skills**: Database, Entity Framework Core  
**Description**: Replace in-memory storage with a real database.
- [ ] Install Entity Framework Core packages
- [ ] Create DbContext class
- [ ] Add migrations
- [ ] Update InventoryDataService to use database
- [ ] Handle database initialization

**Resources**:
- [EF Core Getting Started](https://docs.microsoft.com/en-us/ef/core/get-started/)

---

### Write Comprehensive Unit Tests
**Difficulty**: Intermediate  
**Skills**: Testing, xUnit  
**Description**: Add tests for all service methods.
- [ ] Test AddDevice with valid and invalid data
- [ ] Test checkout logic edge cases
- [ ] Test search/filter functionality
- [ ] Achieve >80% code coverage
- [ ] Add tests for ViewModels

---

### Add Input Validation Framework
**Difficulty**: Intermediate  
**Skills**: Validation, UX  
**Description**: Implement proper input validation.
- [ ] Use IDataErrorInfo or FluentValidation
- [ ] Show validation errors in UI
- [ ] Prevent invalid data from being saved
- [ ] Add helpful error messages

---

### Implement Data Export
**Difficulty**: Intermediate  
**Skills**: File I/O, CSV/Excel  
**Description**: Allow exporting inventory data.
- [ ] Add "Export" button
- [ ] Export devices to CSV
- [ ] Export checkouts to CSV
- [ ] Add date range filtering for exports

---

### Add Checkout History Report
**Difficulty**: Advanced  
**Skills**: Reporting, Data Analysis  
**Description**: Generate reports on device usage.
- [ ] Create ReportWindow.xaml
- [ ] Show most-used devices
- [ ] Show checkout frequency by user
- [ ] Add date range filters
- [ ] Optional: Add charts/graphs

---

### Enhance CI/CD Pipeline
**Difficulty**: Intermediate  
**Skills**: DevOps, GitHub Actions  
**Description**: Improve the automated workflow.
- [ ] Add code coverage reporting
- [ ] Add code linting with dotnet-format
- [ ] Create release artifacts
- [ ] Add automatic versioning

---

## Testing Tasks

### Write Tests for Data Service
- [ ] Test GetAllDevices
- [ ] Test GetAllPhones  
- [ ] Test AddDevice
- [ ] Test AddPhone
- [ ] Test CheckOutDevice
- [ ] Test CheckInDevice

### Write UI Tests (Advanced)
- [ ] Research WPF UI testing frameworks
- [ ] Add basic smoke tests
- [ ] Test critical user flows

---

## Documentation Tasks

### Document API/Methods
- [ ] Add XML documentation comments to all public methods
- [ ] Document model properties
- [ ] Create API documentation

### Create User Manual
- [ ] Write step-by-step usage guide
- [ ] Add screenshots
- [ ] Explain each feature

### Document Architecture
- [ ] Create architecture diagram
- [ ] Explain design decisions
- [ ] Document data models

---

## Task Status

### In Progress
*Move tasks here when you start working on them*

- **[Your Name]**: Task name
  - Branch: `feature/task-name`
  - Started: YYYY-MM-DD

### Completed
*Move tasks here when done and PR is merged*

- **[Name]**: Task name
  - Completed: YYYY-MM-DD
  - PR: #XX

---

## Notes

- Tasks can be split up or combined as needed
- Feel free to add new tasks if you identify something missing
- If you're stuck on a task, ask for help or try a different one
- Some tasks depend on others - check dependencies before starting

Happy coding! 🚀
