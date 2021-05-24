using Flyer.UI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        // TODO: Check Fields are filled
        // TODO: Return Login Error Messages
        // TODO: Confirm User an reset password email was sent
        // TODO: Make these trully Async operations
        // TODO: Sweet animations

        private async void LoginMethod()
        {
            await Core.Firebase.User.SignIn(LoginEmail, LoginPassword);
        }

        private async void ForgotPasswordMethod()
        {
            await Core.Firebase.User.RequestForgotPassword(LoginEmail);
        }

        private async void CreateMethod()
        {
            await Core.Firebase.User.SignUp(CreateUserName, CreateEmail, CreatePassword);
        }
    }
}
