using AirportSimulator.Controllers;
using AirportSimulator.Events;
using AirportSimulator.Models;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Linq;

namespace AirportSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ControlTower tower = new ControlTower();
        
        private ObservableCollection<Airplane> airplanes = new ObservableCollection<Airplane>();

        public MainWindow()
        {
            InitializeComponent(); // Initialize UI
            AirplaneList.ItemsSource = airplanes; // Bind list to collection
            tower.AirplaneTookOff += OnTakeOff; // Subscribe to takeoff event
            tower.AirplaneLanded += OnLanded; // Subscribe to landing event
            tower.AltitudeChanged += OnAltitudeChanged; // Subscribe to altitude event
        }

        private void OnTakeOff(object? sender, AirplaneEventArgs e)
        {
            Log(e.Message); // Log takeoff
            AirplaneList.Items.Refresh(); // Refresh UI
        }

        private void OnLanded(object? sender, AirplaneEventArgs e)
        {
            Log(e.Message); // Log landing
            AirplaneList.Items.Refresh(); // Refresh UI
        }

        private void OnAltitudeChanged(object? sender, AirplaneEventArgs e)
        {
            Log(e.Message); // Log altitude change
            AirplaneList.Items.Refresh(); // Refresh UI
        }

        private void Log(string message)
        {
            LogList.Items.Add($"{DateTime.Now:HH:mm:ss} - {message}"); // Add log entry
            LogList.ScrollIntoView(LogList.Items[^1]); // Scroll to latest
        }

        private void AddAirplane_Click(object? sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text))
            {
                Log("Name required");
                return;
            }

            if (!int.TryParse(FlightNumberBox.Text, out int flightNumber))
            {
                Log("Invalid Flight Number");
                return;
            }

            if (!int.TryParse(TimeBox.Text, out int timeMinute))
            {
                Log("Invalid Flight Time");
                return;
            }

            if (string.IsNullOrWhiteSpace(DestinationBox.Text))
            {
                Log("Destination required");
                return;
            }

            if (airplanes.Any(p => p.FlightNumber == flightNumber))
            {
                Log("Flight number already exists");
                return;
            }

            var plane = new Airplane
            {
                Name = NameBox.Text,
                FlightNumber = flightNumber,
                Destination = DestinationBox.Text,
                FlightTime = TimeSpan.FromHours(timeMinute)
            };

            tower.AddAirplane(plane); // Register in control tower
            airplanes.Add(plane); // Add to UI list

            Log($"Flight {flightNumber} added.");

            NameBox.Clear();
            FlightNumberBox.Clear();
            DestinationBox.Clear();
            TimeBox.Clear();
        }

        private void TakeOff_Click(object? sender, RoutedEventArgs e)
        {
            var plane = AirplaneList.SelectedItem as Airplane; // Get selected plane

            if (plane == null)
            {
                Log("Select a plane first");
                return;
            }

            if (!tower.AuthorizeTakeOff(plane))
                Log("Plane already in flight."); // Prevent duplicate takeoff
        }

        private void Altitude_Click(object? sender, RoutedEventArgs e)
        {
            var plane = AirplaneList.SelectedItem as Airplane; // Get selected plane

            if (plane == null)
            {
                Log("Select a plane first");
                return;
            }

            tower.ChangeAltitude(plane, 1000); // Change altitude
        }

        private void Remove_Click(object? sender, RoutedEventArgs e)
        {
            var plane = AirplaneList.SelectedItem as Airplane; // Get selected plane

            if (plane == null)
            {
                Log("Select a plane first");
                return;
            }

            if (tower.RemoveAirplane(plane))
                airplanes.Remove(plane); // Remove from UI
            else
                Log("Cannot remove plane in flight."); // Prevent invalid removal
        }

    }
}