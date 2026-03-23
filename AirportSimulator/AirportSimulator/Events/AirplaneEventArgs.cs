using System;

namespace AirportSimulator.Events
{
    // Carries flight data between publisher and subscribers
    internal class AirplaneEventArgs : EventArgs
    {
        public int FlightNumber { get; } // Flight identifier
        public string Destination { get;  }   // Flight destination
        public string Message { get; } // Status message for UI/log
        public DateTime Timestamp { get; } // Time of event
        public int Altitude { get; } // Current altitude

        public AirplaneEventArgs(int flightNumber, string destination, string message, int altitude) // Initializes event data
        {
            FlightNumber = flightNumber;
            Destination = destination;
            Message = message;
            Timestamp = DateTime.Now;
            Altitude = altitude;
        }
    }
}