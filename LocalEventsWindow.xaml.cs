using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MunicipalServicesAppWPF
{
    public partial class LocalEventsWindow : Window
    {
        private SortedDictionary<string, List<string>> eventsDictionary;

        public LocalEventsWindow()
        {
            InitializeComponent();
            LoadEvents();
            AddPlaceholderText(null, null); // Initialize the placeholder text
        }

        private void LoadEvents()
        {
            eventsDictionary = new SortedDictionary<string, List<string>>
    {
        { "2024-09-12", new List<string> { "Community Cleanup", "Town Hall Meeting" } },
        { "2024-09-17", new List<string> { "Health Fair", "Concert in the Park" } },
        { "2024-09-18", new List<string> { "Farmers' Market", "Art in the Park" } },
        { "2024-09-19", new List<string> { "Outdoor Movie Night", "Youth Sports Registration" } },
        { "2024-09-22", new List<string> { "Local Theater Performance", "Book Fair" } },
        { "2024-09-23", new List<string> { "Community Potluck", "Health Workshop" } },
        { "2024-09-25", new List<string> { "Environmental Awareness Day", "Craft Fair" } },
        { "2024-09-26", new List<string> { "Charity Run/Walk", "Family Fun Day" } },
        { "2024-09-29", new List<string> { "Cultural Festival", "Community Safety Meeting" } },
        { "2024-10-07", new List<string> { "Gardening Workshop", "Pet Adoption Day" } },
        { "2024-10-08", new List<string> { "Music Festival", "Open Mic Night" } }
    };

            DisplayEvents(eventsDictionary);
        }


        private void DisplayEvents(SortedDictionary<string, List<string>> events)
        {
            lstEvents.Items.Clear();
            foreach (var entry in events)
            {
                lstEvents.Items.Add(new
                {
                    Date = entry.Key,
                    EventNames = string.Join(", ", entry.Value)
                });
            }
        }


        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = txtSearch.Text.ToLower();
            var filteredEvents = eventsDictionary
                .Where(pair => pair.Value.Any(eventName => eventName.ToLower().Contains(searchQuery)))
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            DisplayEvents(new SortedDictionary<string, List<string>>(filteredEvents));
            DisplayRecommendations(searchQuery);
        }

        private void DisplayRecommendations(string searchQuery)
        {
            var recommendedEvents = eventsDictionary
                .Where(pair => pair.Value.Any(eventName => eventName.ToLower().Contains(searchQuery)))
                .SelectMany(pair => pair.Value)
                .Distinct()
                .ToList();

            if (recommendedEvents.Any())
            {
                MessageBox.Show($"Based on your search, you might also be interested in: {string.Join(", ", recommendedEvents)}");
            }
        }

        private void AddPlaceholderText(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearchPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void RemovePlaceholderText(object sender, RoutedEventArgs e)
        {
            txtSearchPlaceholder.Visibility = Visibility.Hidden;
        }
        private void BackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
