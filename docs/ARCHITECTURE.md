# Project Architecture Overview

This document provides a high-level overview of the application architecture and design decisions.

## Technology Stack

### Core Technologies
- **Language**: C# 12
- **Framework**: .NET 10.0
- **UI Framework**: WPF (Windows Presentation Foundation)
- **MVVM Toolkit**: CommunityToolkit.Mvvm 8.3
- **Testing Framework**: xUnit

### Design Pattern
- **MVVM** (Model-View-ViewModel) with CommunityToolkit.Mvvm
  - Currently the project uses a simple code-behind approach
  - Interns should refactor to proper MVVM as they learn
  - Using the same toolkit as the production team

## Application Architecture

```
┌─────────────────────────────────────────────────┐
│                 Presentation Layer               │
│  ┌────────────┐  ┌──────────────┐  ┌──────────┐│
│  │ MainWindow │  │   Dialogs    │  │  Styles  ││
│  │   (.xaml)  │  │ (Add/Edit)   │  │  (.xaml) ││
│  └────────────┘  └──────────────┘  └──────────┘│
└─────────────────────────────────────────────────┘
                       │
                       ▼
┌─────────────────────────────────────────────────┐
│              ViewModel Layer (Future)            │
│  ┌─────────────────┐  ┌──────────────────────┐ │
│  │  MainViewModel  │  │  DeviceViewModel     │ │
│  │                 │  │  PhoneViewModel      │ │
│  └─────────────────┘  └──────────────────────┘ │
└─────────────────────────────────────────────────┘
                       │
                       ▼
┌─────────────────────────────────────────────────┐
│               Business Logic Layer               │
│  ┌──────────────────────────────────────────┐  │
│  │      InventoryDataService                 │  │
│  │  - GetAllDevices()                        │  │
│  │  - AddDevice()                            │  │
│  │  - CheckOutDevice()                       │  │
│  │  - CheckInDevice()                        │  │
│  └──────────────────────────────────────────┘  │
└─────────────────────────────────────────────────┘
                       │
                       ▼
┌─────────────────────────────────────────────────┐
│                  Data Layer                      │
│  ┌──────────────────────────────────────────┐  │
│  │  In-Memory Storage (List<T>)              │  │
│  │  → Future: SQLite Database via EF Core   │  │
│  └──────────────────────────────────────────┘  │
└─────────────────────────────────────────────────┘
```

## Core Components

### 1. Models (Data Layer)
**Location**: `src/IoTInventory/Models/`

**Purpose**: Define the data structures used throughout the application.

**Classes**:
- `Device` - Represents an IoT device
- `Phone` - Represents a phone used for data generation  
- `CheckOut` - Represents a checkout transaction

**Properties**:
- Simple data containers
- No business logic
- Public properties with getters/setters

### 2. Services (Business Logic)
**Location**: `src/IoTInventory/Services/`

**Purpose**: Handle business logic and data operations.

**Classes**:
- `InventoryDataService` - Main service for CRUD operations

**Responsibilities**:
- Data validation
- Business rules enforcement
- Data retrieval and storage
- Checkout/check-in logic

**Current Implementation**: In-memory storage using Lists  
**Future Enhancement**: Database integration with Entity Framework Core

### 3. Views (Presentation)
**Location**: `src/IoTInventory/`

**Purpose**: Display UI and handle user interaction.

**Files**:
- `MainWindow.xaml` - Main application window
- `MainWindow.xaml.cs` - Code-behind (event handlers)
- Future: Dialogs for Add/Edit operations

**Current State**: Basic placeholder UI  
**To Be Implemented**: 
- DataGrids with real data
- Dialog windows
- Search/filter controls

### 4. ViewModels (Future)
**Location**: `src/IoTInventory/ViewModels/`

**Purpose**: Bridge between Views and Models/Services (MVVM pattern).

**Using CommunityToolkit.Mvvm**:
The project uses CommunityToolkit.Mvvm (same as the production team) which provides:
- **ObservableObject** - Base class that implements INotifyPropertyChanged
- **[ObservableProperty]** - Attribute that auto-generates observable properties
- **[RelayCommand]** - Attribute that auto-generates ICommand implementations
- **ObservableValidator** - For input validation (advanced)

**Example**:
```csharp
public partial class DeviceViewModel : ObservableObject
{
    [ObservableProperty]
    private string _deviceName = "";
    
    [RelayCommand]
    private void AddDevice()
    {
        // Implementation
    }
}
```

**Responsibilities**:
- Prepare data for display
- Handle commands from UI
- Implement business logic coordination
- No direct UI code

**Current State**: Example provided (`ExampleViewModel.cs`) using CommunityToolkit.Mvvm  
**To Be Implemented**: MainViewModel, DeviceViewModel, PhoneViewModel

## Data Flow

### Current Implementation (Simple)
```
User Action → Event Handler → Service Method → Update Data → Refresh UI
```

Example: Adding a Device
1. User clicks "Add Device" button
2. Button Click event handler executes
3. Opens AddDeviceDialog
4. User fills form and clicks Save
5. Validates input
6. Calls `_dataService.AddDevice(device)`
7. Service adds device to in-memory list
8. Dialog closes
9. Main window refreshes device grid

### Future Implementation (MVVM)
```
User Action → Command → ViewModel Method → Service Method → Update Observable Collection
                                                             ↓
                                                    UI Auto-Updates via Binding
```

## Design Decisions

### Why WPF?
- Industry-standard for Windows desktop applications
- Good for learning UI development concepts
- Supports data binding (important for MVVM)
- Aligns with team's technology stack

### Why In-Memory Storage Initially?
- Simplifies initial development
- Allows focus on UI and logic first
- Easy to replace with database later
- No database setup required for beginners

### Why MVVM Pattern?
- Separates concerns (UI, logic, data)
- Makes testing easier
- Industry best practice for WPF
- Scalable for larger applications

### Why Not MVVM Initially?
- Too complex for initial project setup
- Allows interns to learn gradually
- Easier to understand simple code-behind first
- Can refactor to MVVM as learning progresses

## Data Model Relationships

```
┌─────────────┐
│   Phone     │
│ - Id        │◄────┐
│ - Name      │     │
│ - Model     │     │ Many checkouts
└─────────────┘     │ per phone
                    │
                    │
              ┌─────┴──────┐
              │  CheckOut  │
              │ - PhoneId  │
              │ - DeviceId │
              └─────┬──────┘
                    │
                    │ Many checkouts
                    │ per device
┌─────────────┐     │
│   Device    │     │
│ - Id        │◄────┘
│ - Name      │
│ - Type      │
└─────────────┘
```

## Future Enhancements

### Phase 1: Basic Functionality (Interns)
- Complete CRUD operations
- Working checkout system
- Basic UI with data display

### Phase 2: MVVM Refactor
- Implement ViewModels
- Add commanding (ICommand)
- Use ObservableCollections
- Remove code-behind logic

### Phase 3: Database Integration
- Add Entity Framework Core
- Create SQLite database
- Implement migrations
- Add proper data persistence

### Phase 4: Advanced Features
- User authentication
- Network deployment
- Reporting system
- Export functionality
- Advanced search/filtering

### Phase 5: Polish
- Improved UI/UX
- Error handling
- Input validation
- Logging system
- Performance optimization

## Testing Strategy

### Unit Tests
- Test service methods in isolation
- Test ViewModels (when implemented)
- Test business logic
- Mock dependencies

### Integration Tests
- Test complete workflows
- Test database interactions (future)
- Test UI interactions (advanced)

### Test Coverage Goals
- Services: >80% coverage
- ViewModels: >80% coverage
- Models: >60% coverage

## Security Considerations

### Current Scope (Learning Project)
- No authentication required
- Local-only application
- No sensitive data
- No network access

### Future Considerations (Production)
- User authentication
- Input sanitization
- SQL injection prevention (when using DB)
- Access control/permissions
- Audit logging

## Performance Considerations

### Current Implementation
- Small dataset (dozens of items)
- In-memory operations are fast
- No performance concerns

### Future Scaling
- For 1000+ items: Use virtualization in DataGrids
- For database: Add indexing on Id fields
- For search: Implement async operations
- For UI: Use background workers for long operations

## Code Organization Best Practices

### Naming Conventions
- **Classes**: `PascalCase` - `DeviceService`
- **Methods**: `PascalCase` - `GetAllDevices()`
- **Variables**: `camelCase` - `deviceList`
- **Private fields**: `_camelCase` - `_dataService`
- **Constants**: `PascalCase` - `MaxCheckoutDays`

### File Organization
- One class per file
- File name matches class name
- Group related classes in folders
- Keep files focused and small

### Method Design
- Methods should do one thing
- Keep methods short (<50 lines ideally)
- Use descriptive names
- Add XML documentation comments

## Learning Path

1. **Understand Models** → Simple data structures
2. **Understand Services** → Business logic and CRUD
3. **Understand Views** → WPF and XAML basics
4. **Add Functionality** → Build features incrementally
5. **Learn MVVM** → Refactor to proper architecture
6. **Add Testing** → Ensure code quality
7. **Optimize** → Improve performance and UX

## Resources

### Architecture Patterns
- [MVVM Pattern Guide](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/enterprise-application-patterns/mvvm)
- [CommunityToolkit.Mvvm Documentation](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/)
- [CommunityToolkit.Mvvm Tutorial](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/generators/observableproperty)
- [Clean Architecture](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures)

### WPF Development
- [WPF Architecture](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/advanced/wpf-architecture)
- [Data Binding](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/data/)

### Best Practices
- [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [Design Patterns](https://refactoring.guru/design-patterns)

---

This architecture provides a solid foundation for learning while being flexible enough to grow as you add features and improve your understanding of software design.
