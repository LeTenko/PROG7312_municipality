using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PROG7312_municipality
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            //var mainview = new MainWindow();
            //mainview.Show();

            var loginView = new LoginPortal();
            loginView.Show();

            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (!loginView.IsVisible && loginView.IsLoaded)
                {
                    var mainview = new MainWindow();
                    mainview.Show();
                    loginView.Close();
                }
            };
        }
    }







}
