using Flyer.UI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Flyer.Core.Firebase;

namespace Flyer.UI.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public LoginViewModel()
        {
            LoginCmd = new RelayCommand(LoginMethod);
            ForgotPasswordCmd = new RelayCommand(ForgotPasswordMethod);
            CreateCmd = new RelayCommand(CreateMethod);
        }

        public string LoginEmail { get; set; }
        public string LoginPassword { get; set; }

        public string CreateEmail { get; set; }
        public string CreatePassword { get; set; }
        public string CreateUserName { get; set; }

        public ICommand LoginCmd { get; private set; }
        public ICommand ForgotPasswordCmd { get; private set; }
        public ICommand CreateCmd { get; private set; }

#warning TODO: Check Fields are filled
#warning TODO: Return Login Error Messages
#warning TODO: Confirm User an reset password email was sent
#warning TODO: Make these trully Async operations
#warning TODO: Sweet animations

        private async void LoginMethod()
        {
            await User.SignIn(LoginEmail, LoginPassword);
            await Venue.GetAllVenues();
        }

        private async void ForgotPasswordMethod()
        {
            await User.RequestForgotPassword(LoginEmail);
        }

        private async void CreateMethod()
        {
            await User.SignUp(CreateUserName, CreateEmail, CreatePassword);
        }
    }
}
