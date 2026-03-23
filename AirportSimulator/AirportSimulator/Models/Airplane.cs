using AirportSimulator.Events;
using System;
using System.Windows.Threading;

namespace AirportSimulator.Models
{
    // Represents a flight and manages its lifecycle and events
    internal class Airplane
    {

        public string Name { get; set; } = string.Empty; // I could be the flight oprator company
        public int FlightNumber { get; set; } // Unique flight identifier

        public string Destination { get; set; } = string.Empty; // Destination of the flight
        public TimeSpan FlightTime { get; set; } // Total duration of the flight
        public bool InFlight { get; private set; } // Indicates if plane is airborne
        public int Altitude { get; private set; } // Current altitude of the plane
        
        public TimeOnly DepartureTime { get; set; }

        private readonly DispatcherTimer timer; // Timer simulating flight progression
        private TimeSpan elapsedTime; // Elapsed flight time

        public event EventHandler<AirplaneEventArgs>? TakeOff; // Fired when plane takes off
        public event EventHandler<AirplaneEventArgs>? Landed;  // Fired when plane lands

        public Airplane() // Initializes timer and tick handler
        {
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += OnTimerTick;
        }

        public void StartFlight() // Starts flight if not already airborne
        {
            if (InFlight)
                return;
            DepartureTime = TimeOnly.FromDateTime(DateTime.Now);

            InFlight = true;
            elapsedTime = TimeSpan.Zero;
            Altitude = 1000;

            timer.Start();
            RaiseTakeOff();
        }

        private void OnTimerTick(object? sender, EventArgs e)
        {
            elapsedTime += TimeSpan.FromSeconds(1); // 1 sec = 1 flight hour

            if (elapsedTime >= FlightTime)
            {
                timer.Stop();
                InFlight = false;
                Altitude = 0;

                RaiseLanded();
            }
        }

        private void RaiseTakeOff() // Creates and raises takeoff event
        {
            var args = new AirplaneEventArgs(
                FlightNumber,
                Destination,
                $"Flight {FlightNumber} to {Destination} has taken off at {DepartureTime}",
                Altitude
            );

            TakeOff?.Invoke(this, args);
        }

        private void RaiseLanded() // Creates and raises landing event
        {
            
            var args = new AirplaneEventArgs(
                FlightNumber,
                Destination,
                $"Flight {FlightNumber} has landed at {Destination}",
                Altitude
            );

            Landed?.Invoke(this, args);
        }

        public int ChangeAltitude(int change) // Changes altitude if airborne and returns new value
        {
            if (!InFlight)
                throw new InvalidOperationException("Plane is not in flight.");

            Altitude += change;
            return Altitude;
        }

        public override string ToString()
        {
            return $"{Name} ({FlightNumber}) → {Destination} | {FlightTime.TotalHours} h | Alt: {Altitude} | {(InFlight ? "Flying" : "Idle")}";
        }
    }
}