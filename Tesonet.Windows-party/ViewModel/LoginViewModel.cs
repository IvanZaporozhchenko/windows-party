using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Tesonet.Windows_party.Models;
using Tesonet.Windows_party.Services;
using Tesonet.Windows_party.Services.Interfaces;

namespace Tesonet.Windows_party.ViewModel
{  
    public class LoginViewModel : ViewModelBase
    {
        private readonly IApiService _apiService;
        private readonly INavigationService _navigationService;

        public LoginViewModel(IApiService apiService, INavigationService navigationService)
        {
            _apiService = apiService;
            _navigationService = navigationService;
        }

        public string UserName { get; set; }        

        public ICommand LoginClickCommand => new RelayCommand<PasswordBox>(LoginClick);

        private async void LoginClick(PasswordBox passwordBox)
        {
            var result = await _apiService.Login(new LoginModel
            {
                UserName = UserName,
                Password = passwordBox.Password
            });

            if (result)
            {
                _navigationService.ShowServerListView();
            }
        }
    }
}