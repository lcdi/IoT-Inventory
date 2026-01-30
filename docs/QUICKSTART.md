# Quick Start Guide

Get up and running with the IoT Inventory project in minutes!

## Prerequisites

### Required
- **Windows 10/11** (for WPF development)
- **.NET 10.0 SDK** - [Download here](https://dotnet.microsoft.com/download/dotnet/10.0)
- **Git** - [Download here](https://git-scm.com/downloads)

### Recommended IDEs (Pick One)
- **Visual Studio 2022** - [Download Community Edition](https://visualstudio.microsoft.com/downloads/)
  - During installation, select ".NET desktop development" workload
- **Visual Studio Code** - [Download here](https://code.visualstudio.com/)
  - Install C# extension from the marketplace
- **JetBrains Rider** - [Download here](https://www.jetbrains.com/rider/) (Free for students)

## Installation Steps

### 1. Verify .NET Installation
Open a terminal/command prompt and run:
```bash
dotnet --version
```
You should see version 10.0.x or higher.

### 2. Clone the Repository
```bash
git clone <repository-url>
cd IoT-Inventory
```

### 3. Restore Dependencies
```bash
dotnet restore
```

### 4. Build the Project
```bash
dotnet build
```
You should see "Build succeeded" with no errors.

### 5. Run the Application
```bash
cd src/IoTInventory
dotnet run
```
The application window should open!

### 6. Run the Tests
```bash
cd tests/IoTInventory.Tests
dotnet test
```
You should see 2 tests pass.

## Opening in Visual Studio

1. Open Visual Studio 2022
2. Click "Open a project or solution"
3. Navigate to the `IoT-Inventory` folder
4. Select `IoTInventory.sln`
5. Press F5 to run, or Ctrl+Shift+B to build

## Opening in VS Code

1. Open VS Code
2. File → Open Folder → Select `IoT-Inventory` folder
3. Install recommended extensions when prompted
4. Open terminal in VS Code (Ctrl+`)
5. Run: `dotnet build` then `dotnet run`

## Project Structure at a Glance

```
IoT-Inventory/
├── src/IoTInventory/           # Main application
│   ├── Models/                 # Data classes (Device, Phone, etc.)
│   ├── Services/               # Business logic
│   ├── ViewModels/             # MVVM ViewModels (example provided)
│   ├── Views/                  # Additional windows (empty for now)
│   ├── MainWindow.xaml         # Main UI
│   └── App.xaml                # Application entry point
├── tests/IoTInventory.Tests/   # Unit tests
├── docs/                       # All documentation
└── README.md                   # Project overview
```

## Common Issues and Solutions

### Issue: "dotnet: command not found"
**Solution**: .NET SDK not installed or not in PATH. Install from the link above.

### Issue: Build errors about missing packages
**Solution**: Run `dotnet restore` in the project directory.

### Issue: Application won't start
**Solution**: Make sure you're in the correct directory (`src/IoTInventory`) when running `dotnet run`.

### Issue: Tests fail
**Solution**: The provided tests should pass. If they don't, try:
```bash
dotnet clean
dotnet restore
dotnet build
dotnet test
```

### Issue: "The target framework 'net10.0-windows' is not supported"
**Solution**: You need .NET 10.0 SDK specifically. Update your SDK.

## Next Steps

1. **Read the Documentation**
   - Start with [INTERN_GUIDE.md](INTERN_GUIDE.md)
   - Review [CONTRIBUTING.md](CONTRIBUTING.md)
   - Check out [TASKS.md](TASKS.md) for things to work on

2. **Explore the Code**
   - Open and read through the existing model classes
   - Look at the MainWindow.xaml to see the UI structure
   - Study the ExampleViewModel to understand MVVM

3. **Pick Your First Task**
   - Check [TASKS.md](TASKS.md) for beginner-friendly tasks
   - Start with displaying devices in the DataGrid
   - Create a new branch for your work

4. **Ask Questions**
   - Don't hesitate to ask for help
   - Use the team chat/communication channel
   - Create issues on GitHub for bugs or questions

## Useful Commands Cheat Sheet

```bash
# Build the project
dotnet build

# Run the application
dotnet run

# Run tests
dotnet test

# Clean build artifacts
dotnet clean

# Restore dependencies
dotnet restore

# Create a new branch
git checkout -b feature/your-feature-name

# See changed files
git status

# Stage files for commit
git add .

# Commit changes
git commit -m "Your commit message"

# Push to GitHub
git push origin your-branch-name
```

## Getting Help

- 📚 Check the `docs/` folder for detailed guides
- 💬 Ask in the team communication channel
- 🐛 Create an issue on GitHub
- 👥 Pair program with another intern
- 🔍 Search online (Stack Overflow, Microsoft Docs)

## Learning Resources

- [C# Fundamentals](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [WPF Tutorial](https://www.wpftutorial.net/)
- [Git Basics](https://git-scm.com/book/en/v2/Getting-Started-Git-Basics)
- [MVVM Pattern](https://docs.microsoft.com/en-us/dotnet/architecture/maui/mvvm)

---

You're all set! Start exploring the code and have fun building. Remember, this is a learning project - making mistakes is part of the process! 🚀
