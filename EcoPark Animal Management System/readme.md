# EcoPark Animal Management System

EcoPark Animal Management System is a C# Windows Forms application used to create, manage, and display animals in an ecological park.
Animals are organized by category and species, with both general and specific traits.

## What the program does

* Create animals by selecting:

  * Category (Mammal, Bird, Reptile)
  * Species (Dog, Cat, Cow, Chicken, Falcon, Raven, Frog, Snake, Turtle)
* Enter animal data through a popup input form
* Handle:

  * General animal information
  * Category-specific traits
  * Species-specific traits
* Display full animal details using overridden `ToString()` methods
* Display a summary list of all animals
* Delete animals from the system
* Load and show an image for each animal

## Design

The program is built using object-oriented programming principles.

### Interface

* `IAnimal` defines common properties and methods for all animals.

### Inheritance hierarchy

* `Animal` (abstract base class implementing IAnimal)
* `Mammal`, `Bird`, `Reptile` (abstract category classes)
* Species classes inherit from category classes.

### Polymorphism

Different species override methods such as:

* `ToStringSummary()`
* `GetAverageLifeSpan()`
* `DailyFoodRequirement()`
* `GetUpcomingEvents()`

### Generic Collection

Animals are stored using a reusable generic collection:

* `IListManager<T>`
* `ListManager<T>`
* `AnimalManager` manages all animal objects.

## Main files

* `Animal.cs` – base abstract class
* `IAnimal.cs` – interface for animal properties
* `ListManager.cs` – generic list manager
* `AnimalManager.cs` – manages animal collection
* `MainForm.cs` – main user interface
* `AnimalInputForm.cs` – popup form for animal creation
* `AboutForm.cs` – application information
* Category and species folders contain all animal types

## How to run

1. Open the solution in Visual Studio
2. Build the project
3. Run the application

## Author

Ahmed Algabri

## Version

2.0 (Assignment 2)
