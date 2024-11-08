using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;

using System.Windows.Input;
using Microsoft.Win32;
using PROG7312_municipality.Model;
using PROG7312_municipality.Repositories;
using PROG7312_municipality.View;

namespace PROG7312_municipality.ViewModel
{
    public class ReportViewModel : ViewModelBase
    {
        private string _location;
        private string _description;
        private string _selectedCategory;
        private ObservableCollection<string> _categories;
        private string _filePath;


        private IReportRepository reportRepository;
        private UserRepository userRepository;

        //properties
        public string Location
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        public ObservableCollection<string> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }

        public string FilePath
        {
            get => _filePath;
            set
            {
                _filePath = value;
                OnPropertyChanged(nameof(FilePath));
            }
        }

        //commands
        public ICommand AttachMediaCommand { get; }
        public ICommand SubmitCommand { get; }
        public ICommand RetrieveCommand { get; }



        //constructor
        public ReportViewModel()
        {
            userRepository = new UserRepository();
            reportRepository = new ReportRepository();


            Categories = new ObservableCollection<string>
            {
                "Sanitaion",
                "Roads",
                "Utilities"
            };


            AttachMediaCommand = new ViewModelCommand(ExecuteAttachMediaCommand);
            // SubmitCommand = new ViewModelCommand(ExecuteSubmitCommand, CanExecuteSubmitCommand);
            SubmitCommand = new ViewModelCommand(ExecuteSubmitCommand);
         

            //Retrieve, need to change returns.
            //RetrieveCommand = new ViewModelCommand(ExecuteRetrieveCommand);
        }

        private void ExecuteAttachMediaCommand(object parameter)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog
            {

                Filter = "All Files|*.*|Image Files|*.jpg;*.jpeg;*.png|Document Files|*.pdf;*.docx;*.txt",
                Multiselect = false
            };

            // Show the file dialog and get the result
            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {

                FilePath = openFileDialog.FileName;
                string destinationDirectory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MediaAttachment");


                // Create a new file name based on the current date and time
                string newFileName = $"{DateTime.Now:yyyyMMddHHmmss}{System.IO.Path.GetExtension(FilePath)}";

                // Combine the directory and the new file name to get the full destination path
                string destinationPath = System.IO.Path.Combine(destinationDirectory, newFileName);

                // Ensure the destination directory exists, create it if it doesn't
                System.IO.Directory.CreateDirectory(destinationDirectory);

                // Copy the file to the destination path, overwriting if necessary
                System.IO.File.Copy(FilePath, destinationPath, true);


                FilePath = destinationPath;

            }
        }

        private bool CanExecuteSubmitCommand(object parameter)
        {
            if (string.IsNullOrWhiteSpace(Location) || string.IsNullOrWhiteSpace(Description))
            {

                return false;
            }
            else
            {


                return true;
            }

        }


        private void ExecuteSubmitCommand(object parameter)
        {
         
            Guid userId = Guid.Empty; // Initialize as an empty GUID

            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                userId = user.Id;
            }

            var reportModel = new ReportModel
            {
                Location = this.Location,
                Description = this.Description,
                SelectedCategory = this.SelectedCategory,
                FilePath = this.FilePath,
                UserID = userId
            };

            reportRepository.AddReport(reportModel);

            MessageBox.Show("Report Submitted Successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear fields
            Location = "";
            Description = "";
            SelectedCategory = "";
            FilePath = "";

            RatingWindow ratingWindow = new RatingWindow();
            ratingWindow.ShowDialog();

            ExecuteRetrieveCommand(1);

        }


        //change this method to retrive the list.
        private void ExecuteRetrieveCommand(object parameter)
        {
            Guid userId = Guid.Empty;
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                userId = user.Id;
            }

            // Get a list of reports by UserID
            var reports = reportRepository.GetReportsByUserId(userId);

            if (reports != null && reports.Any())
            {
                var message = new StringBuilder();

                foreach (var report in reports)
                {
                    message.AppendLine($"Location: {report.Location}");
                    message.AppendLine($"Description: {report.Description}");
                    message.AppendLine($"Category: {report.SelectedCategory}");
                    message.AppendLine($"File Path: {report.FilePath}");
                    message.AppendLine(new string('-', 30)); // Separator for readability
                }

                MessageBox.Show(message.ToString(), "Report Details", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No reports found for this user.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


    }


}