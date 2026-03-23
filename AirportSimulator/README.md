Airport Control Tower Simulation



Airport Control Tower Simulation is a C# WPF application that models a simplified flight departure system using delegates, events, and the publisher/subscriber pattern.



Airplanes are registered, authorized for take-off, monitored during flight, and notify the control tower when they take off and land.



What the program does

Create airplanes by entering:

Flight Name

Flight Number

Destination

Flight Time (in hours)

Add airplanes to the system

Display all registered airplanes with:

Flight information

Current status (Idle / Flying)

Current altitude

Authorize airplanes to take off

Simulate flight using a timer:

1 second represents 1 flight hour

Automatically trigger events:

Take-off event

Landing event

Display event logs in real time:

Take-off messages

Landing messages

Altitude changes

Change airplane altitude during flight using a delegate

Prevent invalid actions:

Cannot take off if already in flight

Cannot change altitude if not airborne

Cannot remove airplane while in flight

Remove airplanes from the system

Design



The system is built using object-oriented principles and event-driven architecture.



Publisher/Subscriber Pattern

Airplane (Publisher)

Raises events:

TakeOff

Landed

ControlTower (Subscriber + Publisher)

Subscribes to airplane events

Forwards events to the UI

MainWindow (Subscriber)

Subscribes to ControlTower events

Updates UI and logs messages

Delegates and Events

Event delegates:

Used for TakeOff and Landed notifications

Regular delegate:

Used to change altitude and return new value

Timer Simulation

Implemented using DispatcherTimer

Tick interval: 1 second

Each tick represents 1 flight hour

Flight ends when elapsed time equals FlightTime

Separation of Concerns

MainWindow

Handles UI only

ControlTower

Manages airplanes and event flow

Airplane

Handles flight logic and event publishing

Main files

Airplane.cs – flight model, timer, and event publisher

AirplaneEventArgs.cs – custom event data

ControlTower.cs – manages airplanes and event subscriptions

MainWindow.xaml – UI layout

MainWindow.xaml.cs – UI logic and event handling

How to run

Open the project in Visual Studio

Build the solution

Run the application

Author



Ahmed Algabri



Version



Assignment 4 – Delegates and Events

