using FontAwesome.Sharp;
using PROG7312_municipality.Model;
using PROG7312_municipality.Repositories;
using System;
using System.Threading;
using System.Windows.Input;

namespace PROG7312_municipality.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;

        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }

            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }


        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }

            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public String Caption
        {
            get
            {
                return _caption;
            }

            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get
            {
                return _icon;
            }

            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        //-->commands
        public ICommand ShowReportViewCommand { get; }
        public ICommand ShowEventViewCommand { get; }
        public ICommand ShowStatusViewCommand { get; }




        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();

            //initialzie commands
       
            ShowReportViewCommand = new ViewModelCommand(ExecuteShowReportViewCommand);

            ShowEventViewCommand = new ViewModelCommand(ExecuteShowEventViewCommand);
            ShowStatusViewCommand = new ViewModelCommand(ExecuteShowStatusViewCommand);


            //default view
            ExecuteShowReportViewCommand(null);

            LoadCurrentUserData();
        }

        private void ExecuteShowStatusViewCommand(object obj)
        {
            CurrentChildView = new ComingSoonViewModel();
            Caption = "In Construction";
            Icon = IconChar.Digging;
        }

        private void ExecuteShowEventViewCommand(object obj)
        {
            CurrentChildView = new EventViewModel();
            Caption = "Events and Annoucements";
            Icon = IconChar.Bullhorn;
        }

        private void ExecuteShowReportViewCommand(object obj)
        {
            CurrentChildView = new ReportViewModel();
            Caption = "Report";
            Icon = IconChar.Flag;
        }

        

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"{user.FirstName} {user.LastName}";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid user, not logged in";
                //Hide child views.
            }
        }
    }
}
