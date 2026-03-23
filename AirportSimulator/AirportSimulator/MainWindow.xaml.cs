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
            InitializeComponent();
            AirplaneList.ItemsSource = airplanes;
            tower.AirplaneTookOff += OnTakeOff;
            tower.AirplaneLanded += OnLanded;
            tower.AltitudeChanged += OnAltitudeChanged;
        }


        private void OnTakeOff(object? sender, AirplaneEventArgs e)
        {
            Log(e.Message);
            AirplaneList.Items.Refresh();
        }

        private void OnLanded(object? sender, AirplaneEventArgs e)
        {
            Log(e.Message);
            AirplaneList.Items.Refresh();
        }

        private void OnAltitudeChanged(object? sender, AirplaneEventArgs e)
        {
            Log(e.Message);
            AirplaneList.Items.Refresh();
        }

        private void Log(string message)
        {
            LogList.Items.Add($"{DateTime.Now:HH:mm:ss} - {message}");
            LogList.ScrollIntoView(LogList.Items[^1]);
        }


        private void AddAirplane_Click(object? sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(NameBox.Text))
            {
                Log("Name required");
                return;
            }

            // Validate Flight Number
            if (!int.TryParse(FlightNumberBox.Text, out int flightNumber))
            {
                Log("Invalid Flight Number");
                return;
            }

            // Validate Time
            if (!int.TryParse(TimeBox.Text, out int timeMinute))
            {
                Log("Invalid Flight Time");
                return;
            }

            // Validate text fields
            if (string.IsNullOrWhiteSpace(DestinationBox.Text) ||
                string.IsNullOrWhiteSpace(NameBox.Text))
            {
                Log("Name and Destination required");
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

            tower.AddAirplane(plane);
            airplanes.Add(plane);

            Log($"Flight {flightNumber} added.");

            NameBox.Clear();
            FlightNumberBox.Clear();
            DestinationBox.Clear();
            TimeBox.Clear();

        }

        private void TakeOff_Click(object? sender, RoutedEventArgs e)
        {
            var plane = AirplaneList.SelectedItem as Airplane;

            if (plane == null) { 
                Log("Select a plane first");
            return; }

            if (!tower.AuthorizeTakeOff(plane))
                Log("Plane already in flight.");
        }

        private void Altitude_Click(object? sender, RoutedEventArgs e)
        {
            var plane = AirplaneList.SelectedItem as Airplane;

            if (plane == null)
            {
                Log("Select a plane first");
                return;
            }

            tower.ChangeAltitude(plane, 1000);
        }

        private void Remove_Click(object? sender, RoutedEventArgs e)
        {
            var plane = AirplaneList.SelectedItem as Airplane;

            if (plane == null)
            {
                Log("Select a plane first");
                return;
            }

            if (tower.RemoveAirplane(plane))
                airplanes.Remove(plane);
            else
                Log("Cannot remove plane in flight.");
        }

    }
}