using KartotekaKontrahentowWpf.Interfaces;
using KartotekaKontrahentowWpf.Models;
using KartotekaKontrahentowWpf.Utilities;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KartotekaKontrahentowWpf.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region Properties and fields
        private Visibility _editionPanelVisibility;

        public Visibility EditionPanelVisibility
        {
            get { return _editionPanelVisibility; }
            set { SetProperty(ref _editionPanelVisibility, value); }
        }

        private ObservableCollection<IClient> _clientsList;

        public ObservableCollection<IClient> ClientsList
        {
            get { return _clientsList; }
            set { SetProperty(ref _clientsList, value); }
        }

        private string _clientName;

        public string ClientName
        {
            get { return _clientName; }
            set { SetProperty(ref _clientName, value); }
        }

        private string _clientCity;

        public string ClientCity
        {
            get { return _clientCity; }
            set { SetProperty(ref _clientCity, value); }
        }

        private string _clientCountry;

        public string ClientCountry
        {
            get { return _clientCountry; }
            set { SetProperty(ref _clientCountry, value); }
        }

        private string _clientStreet;

        public string ClientStreet
        {
            get { return _clientStreet; }
            set { SetProperty(ref _clientStreet, value); }
        }

        private string _clientStreetNumber;

        public string ClientStreetNumber
        {
            get { return _clientStreetNumber; }
            set { SetProperty(ref _clientStreetNumber, value); }
        }

        private bool _isBussinessClientChecked;

        public bool IsBussinessClientChecked
        {
            get { return _isBussinessClientChecked; }
            set { SetProperty(ref _isBussinessClientChecked, value); }
        }

        private bool _isEditMode;

        public bool IsEditMode
        {
            get { return _isEditMode; }
            set { _isEditMode = value; }
        }

        private IClient _editedClient;

        public IClient EditedClient
        {
            get { return _editedClient; }
            set { _editedClient = value; }
        }

        #endregion

        #region Commands
        public ICommand OpenAddClientPanelCommand { get; set; }
        public ICommand EditClientCommand { get; set; }
        public ICommand DeleteClientCommand { get; set; }
        public ICommand SaveEditedClientCommand { get; set; }
        public ICommand CancelEditedClientCommand { get; set; }
        public ICommand ShowListCommand { get; set; }
        #endregion

        #region Actions
        private void OpenAddClientPanel()
        {
            EditionPanelVisibility = Visibility.Visible;

            //ClientName = "";
            //ClientCity = "";
            //ClientCountry = "";
            //ClientStreet = "";
            //ClientStreetNumber = "";
            //IsBussinessClientChecked = false;
        }

        private void EditClient(IClient client)
        {
            EditionPanelVisibility = Visibility.Visible;
            ClientCity = client.City;
            ClientName = client.Name;
            ClientCountry = client.Country;
            ClientStreet = client.Street;
            ClientStreetNumber = client.StreetNumber;
            EditedClient = client;
            IsBussinessClientChecked = client.IsBusinessClient;
            IsEditMode = true;
        }

        private void DeleteClient(IClient client)
        {
            DeleteClientAsync(client);
        }

        private  async Task DeleteClientAsync(IClient client)
        {
            await ClientsSQL.DeleteClientAsync(client.Id);

            ClientsList = await ClientsSQL.GetClientsAsync();
        }

        private void SaveClient()
        {
            if(IsEditMode)
            {
                ModifyClient();
            }
            else
            {
                SaveNewClient();
            }            
        }

        private void CancelClientEdition()
        {
            ClientName = "";
            ClientCity = "";
            ClientCountry = "";
            ClientStreet = "";
            ClientStreetNumber = "";
            IsBussinessClientChecked = false;
            EditionPanelVisibility = Visibility.Hidden;
        }

        private void ShowList()
        {
            EditionPanelVisibility = Visibility.Hidden;
        }

        private async Task ModifyClient()
        {
            byte b = Convert.ToByte(IsBussinessClientChecked);

            await ClientsSQL.UpdateClientAsync(EditedClient.Id, ClientName, ClientCountry, ClientCity, ClientStreet, ClientStreetNumber, Convert.ToByte(IsBussinessClientChecked)).ConfigureAwait(false);

            ClientsList = await ClientsSQL.GetClientsAsync();

            ClientName = "";
            ClientCity = "";
            ClientCountry = "";
            ClientStreet = "";
            ClientStreetNumber = "";
            IsBussinessClientChecked = false;
            EditionPanelVisibility = Visibility.Hidden;
        }

        private async Task SaveNewClient()
        {
            if (ClientsList == null)
            {
                ClientsList = new ObservableCollection<IClient>();
            }

            await ClientsSQL.AddClientAsync(ClientName, ClientCountry, ClientCity, ClientStreet, ClientStreetNumber, Convert.ToByte(IsBussinessClientChecked)).ConfigureAwait(false);

            ClientsList = await ClientsSQL.GetClientsAsync();

            ClientName = "";
            ClientCity = "";
            ClientCountry = "";
            ClientStreet = "";
            ClientStreetNumber = "";
            IsBussinessClientChecked = false;
            EditionPanelVisibility = Visibility.Hidden;
        }
        #endregion

        public MainWindowViewModel()
        {
            OpenAddClientPanelCommand = new DelegateCommand(OpenAddClientPanel);
            EditClientCommand = new DelegateCommand<IClient>(EditClient);
            DeleteClientCommand = new DelegateCommand<IClient>(DeleteClient);
            SaveEditedClientCommand = new DelegateCommand(SaveClient);
            CancelEditedClientCommand = new DelegateCommand(CancelClientEdition);
            ShowListCommand = new DelegateCommand(ShowList);

            EditionPanelVisibility = Visibility.Hidden;
            IsEditMode = false;

            LoadData();
        }

        private async Task LoadData()
        {
            if (ClientsList == null)
            {
                ClientsList = new ObservableCollection<IClient>();
            }
            try
            {
                ClientsList = await ClientsSQL.GetClientsAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
