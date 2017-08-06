using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Tesonet.Windows_party.Models;
using Tesonet.Windows_party.Services;

namespace Tesonet.Windows_party.ViewModel
{
    public class ServerListViewModel : ViewModelBase
    {
        private readonly IApiService _apiService;
        private ObservableCollection<ServerModel> _serverModels;

        public ServerListViewModel(IApiService apiService)
        {
            _apiService = apiService;
            ServerModels = new ObservableCollection<ServerModel>();
            InitServerModels();
        }

        public ObservableCollection<ServerModel> ServerModels
        {
            get { return _serverModels; }
            set
            {
                _serverModels = value;
                RaisePropertyChanged(() => ServerModels);
            }
        }

        private async void InitServerModels()
        {
            var serverModels = await _apiService.GetServers();
            ServerModels = new ObservableCollection<ServerModel>(serverModels);
        }
    }
}