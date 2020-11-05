using AppTCC.Models;
using AppTCC.Services;
using AppTCC.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppTCC.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private LoginService _loginService = new LoginService();
        public Command LoginCommand { get; }
        public Action ExibirAvisoDeLoginInvalido;
        public Action LoginComSucesso;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(async () =>
            {
                await OnSubmit();
            });
        }

        public async Task OnSubmit()
        {
            AuthenticateResponse response = await _loginService.Authenticate(username, password);

            if (response != null)
            {
                LoginComSucesso.Invoke();
            }
            else
            {
                ExibirAvisoDeLoginInvalido.Invoke();
            }
        }
    }
}
