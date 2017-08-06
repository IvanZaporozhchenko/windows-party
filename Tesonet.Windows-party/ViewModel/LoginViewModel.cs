using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Tesonet.Windows_party.Models;
using Tesonet.Windows_party.Services;

namespace Tesonet.Windows_party.ViewModel
{  
    public class LoginViewModel : ViewModelBase
    {
        private readonly IApiService _apiService;

        public LoginViewModel(IApiService apiService)
        {
            _apiService = apiService;
        }
        
        public string UserName { get; set; }        

        public ICommand LoginButtonClickCommand => new RelayCommand<PasswordBox>(LoginButtonClick);

        private async void LoginButtonClick(PasswordBox passwordBox)
        {
            var result = await _apiService.Login(new LoginModel
            {
                UserName = UserName,
                Password = passwordBox.Password
            });

            if (result)
            {
               
            }
        }
    }
}