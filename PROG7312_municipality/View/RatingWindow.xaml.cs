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
    /// Interaction logic for RatingWindow.xaml
    /// </summary>
    public partial class RatingWindow : Window
    {
        public RatingWindow()
        {
            InitializeComponent();
        }

        private int currentRating = 0;

        

        private void Star_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton star)
            {
                currentRating = int.Parse(star.Name.Substring(4));

                Star1.Foreground = currentRating >= 1 ? System.Windows.Media.Brushes.Gold : System.Windows.Media.Brushes.Gray;
                Star2.Foreground = currentRating >= 2 ? System.Windows.Media.Brushes.Gold : System.Windows.Media.Brushes.Gray;
                Star3.Foreground = currentRating >= 3 ? System.Windows.Media.Brushes.Gold : System.Windows.Media.Brushes.Gray;
                Star4.Foreground = currentRating >= 4 ? System.Windows.Media.Brushes.Gold : System.Windows.Media.Brushes.Gray;
                Star5.Foreground = currentRating >= 5 ? System.Windows.Media.Brushes.Gold : System.Windows.Media.Brushes.Gray;
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            //implement saving data to database.


            MessageBox.Show($"You rated: {currentRating} star(s)", "Thank You", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
