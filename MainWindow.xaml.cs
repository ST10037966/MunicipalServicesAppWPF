using System.Windows;
using System.Windows.Navigation;

namespace MunicipalServicesAppWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ReportIssuesButton_Click(object sender, RoutedEventArgs e)
        {
            ReportIssuesWindow reportIssuesWindow = new ReportIssuesWindow();
            reportIssuesWindow.Show();
            this.Close();
        }

        private void LocalEventsButton_Click(object sender, RoutedEventArgs e)
        {
            LocalEventsWindow localEventsWindow = new LocalEventsWindow();
            localEventsWindow.Show();
            this.Close();
        }

        private void ServiceRequestStatusButton_Click(object sender, RoutedEventArgs e)
        {
            ServiceRequestStatusWindow serviceRequestStatusWindow = new ServiceRequestStatusWindow();
            serviceRequestStatusWindow.Show();
            this.Close();
        }
    }
}

