using System;
using System.Collections.Generic;
using System.Windows;

namespace MunicipalServicesAppWPF
{
    public partial class ServiceRequestStatusWindow : Window
    {
        // Binary Search Tree for managing service requests
        private BinarySearchTree serviceRequestsTree = new BinarySearchTree();

        public ServiceRequestStatusWindow()
        {
            InitializeComponent();
            LoadServiceRequests();
        }

        private void LoadServiceRequests()
        {
            // Populate the BST with sample service requests
            serviceRequestsTree.Insert(new ServiceRequest(1, "Fix streetlight on Main St.", "Pending", DateTime.Now.AddDays(-5)));
            serviceRequestsTree.Insert(new ServiceRequest(2, "Repair water leak on Elm Rd.", "Completed", DateTime.Now.AddDays(-10)));
            serviceRequestsTree.Insert(new ServiceRequest(3, "Clean park near Central Ave.", "In Progress", DateTime.Now.AddDays(-3)));
            serviceRequestsTree.Insert(new ServiceRequest(4, "Remove fallen tree on Maple St.", "Pending", DateTime.Now.AddDays(-7)));
            serviceRequestsTree.Insert(new ServiceRequest(5, "Repair potholes on Oak Rd.", "Completed", DateTime.Now.AddDays(-15)));
            serviceRequestsTree.Insert(new ServiceRequest(6, "Replace damaged traffic sign on Pine St.", "In Progress", DateTime.Now.AddDays(-2)));
            serviceRequestsTree.Insert(new ServiceRequest(7, "Street sweeping on Cedar Ave.", "Pending", DateTime.Now.AddDays(-1)));
            serviceRequestsTree.Insert(new ServiceRequest(8, "Fix broken bench in Park Square.", "Completed", DateTime.Now.AddDays(-20)));
            serviceRequestsTree.Insert(new ServiceRequest(9, "Inspect damaged playground equipment.", "In Progress", DateTime.Now.AddDays(-4)));
            serviceRequestsTree.Insert(new ServiceRequest(10, "Clear blocked drainage on Birch Rd.", "Pending", DateTime.Now.AddDays(-8)));

            // Display all service requests in the DataGrid
            dataGridServiceRequests.ItemsSource = serviceRequestsTree.InOrderTraversal();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtSearchRequestId.Text, out int requestId))
            {
                // Search the BST for the request
                var result = serviceRequestsTree.Search(requestId);
                if (result != null)
                {
                    dataGridServiceRequests.ItemsSource = new List<ServiceRequest> { result };
                }
                else
                {
                    MessageBox.Show("Service request not found.", "Search Result", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Request ID.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to MainWindow
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void txtSearchRequestId_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Show or hide the placeholder based on whether the TextBox is empty
            txtSearchPlaceholder.Visibility = string.IsNullOrWhiteSpace(txtSearchRequestId.Text)
                ? Visibility.Visible
                : Visibility.Hidden;
        }
    }

    public class ServiceRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DateSubmitted { get; set; }

        public ServiceRequest(int id, string description, string status, DateTime dateSubmitted)
        {
            Id = id;
            Description = description;
            Status = status;
            DateSubmitted = dateSubmitted;
        }
    }
}
