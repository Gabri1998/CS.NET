# EcoPark Animal Management System

EcoPark Animal Management System is a C# Windows Forms application used to create, manage, and display animals in an ecological park.  
Animals are organized by category and species, with both general and specific traits.

## What the program does

- Create animals by selecting:
  - Category (Mammal, Bird, Reptile)
  - Species (Dog, Cat, Cow, Chicken, Falcon, Raven, Frog, Snake, Turtle)
- Enter animal data through a popup input form
- Handle:
  - General animal information
  - Category-specific traits
  - Species-specific traits
- Display full animal details using overridden `ToString()` methods
- List all created animals
- Load and show an image for each animal
- Scrollable output for long descriptions

## Design

- Uses object-oriented programming
- Inheritance hierarchy:
  - Animal (base class)
  - Mammal, Bird, Reptile (abstract categories)
  - Species classes inherit from categories
- Polymorphism through overridden `ToString()`
- Validation inside property setters

## Main files

- `Animal.cs` – base class for all animals
- `MainForm.cs` – main user interface
- `AnimalInputForm.cs` – popup form for animal creation
- `AboutForm.cs` – application info
- Category and species folders contain all animal types

## How to run

1. Open the solution in Visual Studio
2. Build the project
3. Run the application

## Notes

- The `CategoryType` enum is included for future expansion
- `.vs`, `bin`, and `obj` folders are ignored in Git
- The project is structured for easy extension

## Author

Ahmed Algabri

## Version

1.0
