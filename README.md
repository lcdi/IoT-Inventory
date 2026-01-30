# IoT Device Inventory System

A WPF-based inventory management system for tracking IoT devices and phones used in data generation projects.

## Project Status
🚧 **In Development** - This is a learning project for IoT Programming/Software Engineering interns.

## Overview
This application allows IoT team members to:
- Track IoT devices and phones in the lab
- Check out devices and phones for development or data generation
- Link phones with devices to track which phone was used for data generation
- View available and checked-out equipment at a glance

## For Interns

### 📚 Start Here
1. **[Intern Guide](docs/INTERN_GUIDE.md)** - Complete onboarding guide with learning paths
2. **[Contributing Guide](docs/CONTRIBUTING.md)** - How to contribute code to the project

### Quick Start
```bash
# Clone the repository
git clone <repository-url>
cd IoT-Inventory

# Build and run
cd src/IoTInventory
dotnet restore
dotnet build
dotnet run
```

### Your Mission
This starter codebase has the basic structure, but **most of the functionality is missing**. Your job is to:
- Build out the user interface with working data grids
- Implement CRUD operations (Create, Read, Update, Delete)
- Add checkout/check-in functionality
- Write unit tests
- Improve the user experience

Don't worry if you're new to C# or WPF - that's the point! Use this as a learning opportunity.

## Project Structure
```
IoT-Inventory/
├── src/IoTInventory/       # Main application source code
│   ├── Models/             # Data models (Device, Phone, CheckOut)
│   ├── Services/           # Business logic and data access
│   └── MainWindow.xaml     # Main UI
├── tests/                  # Unit tests (to be added by interns)
├── docs/                   # Documentation
└── README.md               # This file
```

## Technology Stack
- **Language**: C# 12
- **Framework**: .NET 10.0
- **UI Framework**: WPF (Windows Presentation Foundation)
- **MVVM Toolkit**: CommunityToolkit.Mvvm 8.3
- **Architecture**: MVVM (Model-View-ViewModel) - to be implemented
- **Testing**: xUnit (to be added)

## Learning Objectives
Through this project, interns will gain experience with:
- Frontend development (WPF, XAML, UI/UX)
- Backend development (C#, data structures, algorithms)
- Unit testing and Test-Driven Development
- Version control with Git
- Code review practices
- Documentation
- CI/CD basics

## Current Features
- ✅ Basic application structure
- ✅ Model classes for Device, Phone, and CheckOut
- ✅ Mock data service
- ✅ Simple UI layout with tabs

## Planned Features (Your Work!)
- ⬜ Display devices and phones in data grids
- ⬜ Add new devices and phones
- ⬜ Check out devices with phones
- ⬜ Check in devices
- ⬜ Search and filter functionality
- ⬜ View active checkouts
- ⬜ Data persistence (SQLite)
- ⬜ Unit tests
- ⬜ Input validation
- ⬜ Error handling

## Documentation
- [Intern Onboarding Guide](docs/INTERN_GUIDE.md) - Comprehensive guide for getting started
- [CommunityToolkit.Mvvm Guide](docs/COMMUNITYTOOLKIT_MVVM_GUIDE.md) - Complete guide to the MVVM toolkit (team standard!)
- [Contributing Guide](docs/CONTRIBUTING.md) - Code standards and PR process
- [Original Project Proposal](IoTE_Internship_Planning.pdf) - The vision for this project

## Questions or Issues?
- Review the documentation first
- Ask fellow interns
- Create an issue in the GitHub repository
- Reach out to the project lead

## License
Internal use for Leahy Center for Digital Investigation.

---

**Remember**: This is a learning project. Making mistakes is part of the process. Focus on learning, collaboration, and growth! 🚀
