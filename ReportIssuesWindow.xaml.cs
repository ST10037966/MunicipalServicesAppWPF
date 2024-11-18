using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MunicipalServicesAppWPF
{
    /// <summary>
    /// Interaction logic for ReportIssuesWindow.xaml
    /// </summary>
    public partial class ReportIssuesWindow : Window
    {
        private List<ReportedIssue> reportedIssues = new List<ReportedIssue>();

        public ReportIssuesWindow()
        {
            InitializeComponent();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void AttachButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                // Handle the file selection
            }
        }
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string location = LocationTextBox.Text;
            ComboBoxItem selectedCategory = (ComboBoxItem)CategoryComboBox.SelectedItem;
            string category = selectedCategory.Content.ToString();
            TextRange textRange = new TextRange(DescriptionRichTextBox.Document.ContentStart, DescriptionRichTextBox.Document.ContentEnd);
            string description = textRange.Text;
            string attachmentPath = ""; // Add logic to handle attachment

            ReportedIssue issue = new ReportedIssue
            {
                Location = location,
                Category = category,
                Description = description,
                AttachmentPath = attachmentPath
            };

            reportedIssues.Add(issue);

            MessageBox.Show("Issue reported successfully!");
        }



    }
}
