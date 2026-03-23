using AirportSimulator.Events;
using AirportSimulator.Models;
using System;
using System.Collections.Generic;

namespace AirportSimulator.Controllers
{
    // Coordinates airplanes and forwards their events to the UI
    internal class ControlTower
    {
        private readonly List<Airplane> airplanes = new List<Airplane>(); // Stores all airplanes

        public event EventHandler<AirplaneEventArgs>? AirplaneTookOff; // Fired when a plane takes off
        public event EventHandler<AirplaneEventArgs>? AirplaneLanded;  // Fired when a plane lands
        public event EventHandler<AirplaneEventArgs>? AltitudeChanged; // Fired when altitude changes

        public void AddAirplane(Airplane plane) // Adds airplane and subscribes to its events
        {
            if (plane == null)
                return;

            airplanes.Add(plane);
            Subscribe(plane);
        }

        private void Subscribe(Airplane plane) // Subscribes to airplane events
        {
            plane.TakeOff += HandleTakeOff;
            plane.Landed += HandleLanding;
        }

        private void Unsubscribe(Airplane plane) // Unsubscribes from airplane events
        {
            plane.TakeOff -= HandleTakeOff;
            plane.Landed -= HandleLanding;
        }

        private void HandleTakeOff(object? sender, AirplaneEventArgs e) // Forwards takeoff event
        {
            AirplaneTookOff?.Invoke(this, e);
        }

        private void HandleLanding(object? sender, AirplaneEventArgs e) // Forwards landing and unsubscribes
        {
            AirplaneLanded?.Invoke(this, e);

            if (sender is Airplane plane)
            {
                Unsubscribe(plane);
            }
        }

        public bool AuthorizeTakeOff(Airplane plane) // Validates and starts flight
        {
            if (plane == null || plane.InFlight)
                return false;

            Unsubscribe(plane);
            Subscribe(plane);

            plane.StartFlight();
            return true;
        }

        public void ChangeAltitude(Airplane plane, int change) // Uses delegate to change altitude and notify
        {
            if (plane == null)
                return;

            try
            {
                Func<int, int> altitudeDelegate = plane.ChangeAltitude;
                int newAltitude = altitudeDelegate(change);

                var args = new AirplaneEventArgs(
                    plane.FlightNumber,
                    plane.Destination,
                    $"Flight {plane.FlightNumber} altitude changed to {newAltitude}",
                    newAltitude
                );

                AltitudeChanged?.Invoke(this, args);
            }
            catch (Exception ex)
            {
                var args = new AirplaneEventArgs(
                    plane.FlightNumber,
                    plane.Destination,
                    ex.Message,
                    plane.Altitude
                );

                AltitudeChanged?.Invoke(this, args);
            }
        }

        public bool RemoveAirplane(Airplane plane) // Removes plane if not in flight
        {
            if (plane == null || plane.InFlight)
                return false;

            Unsubscribe(plane);
            return airplanes.Remove(plane);
        }

        public List<Airplane> GetAllAirplanes() // Returns current airplane list
        {
            return airplanes;
        }
    }
}