using PROG7312_municipality.Repositories;
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

namespace PROG7312_municipality.View
{
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
 



    public partial class CustomMessageBox : Window
    {
        public CustomMessageBox(EventItem eventDetails)
        {
            InitializeComponent();

            // Populate the UI with event details
            // Format and display the event details
            TitleText.Text = $"Title: {eventDetails.Title}";
  
            DescriptionText.Text = $"Description: {eventDetails.Description}";
            DateText.Text = $"Date: {eventDetails.EventDate:MMMM dd, yyyy}";
     
            LocationText.Text = $"Location: {eventDetails.Location ?? "N/A"}";
     
            ModifiedDateText.Text = $"Last Modified Date: {eventDetails.ModifiedDate:MMMM dd, yyyy}";
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }










}
