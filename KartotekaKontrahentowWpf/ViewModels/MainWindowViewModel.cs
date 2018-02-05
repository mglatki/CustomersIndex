using CustomersIndex.Interfaces;
using CustomersIndex.Models;
using CustomersIndex.Utilities;
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

namespace CustomersIndex.ViewModels
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

        private string _clientsPhoneNumber;

        public string ClientsPhoneNumber
        {
            get { return _clientsPhoneNumber; }
            set { SetProperty(ref _clientsPhoneNumber, value); }
        }

        private string _clientsEmailAdres;

        public string ClientsEmailAdres
        {
            get { return _clientsEmailAdres; }
            set { SetProperty(ref _clientsEmailAdres, value); }
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

        private string _selectedPanel;

        public string SelectedPanel
        {
            get { return _selectedPanel; }
            set { SetProperty(ref _selectedPanel, value); }
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
        }

        private void EditClient(IClient client)
        {
            EditionPanelVisibility = Visibility.Visible;
            SelectedPanel = "+";

            ClientCity = client.City;
            ClientName = client.Name;
            ClientCountry = client.Country;
            ClientStreet = client.Street;
            ClientStreetNumber = client.StreetNumber;
            ClientsPhoneNumber = client.Phone;
            ClientsEmailAdres = client.Email;
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
            CleanClientEditionPanelInputs();

            ShowList();
        }

        private void ShowList()
        {
            EditionPanelVisibility = Visibility.Hidden;

            SelectedPanel = "L";
        }

        private async Task ModifyClient()
        {
            byte b = Convert.ToByte(IsBussinessClientChecked);

            await ClientsSQL.UpdateClientAsync(EditedClient.Id, ClientName, ClientCountry, ClientCity, ClientStreet, ClientStreetNumber, ClientsPhoneNumber, ClientsEmailAdres, Convert.ToByte(IsBussinessClientChecked)).ConfigureAwait(false);

            ClientsList = await ClientsSQL.GetClientsAsync();

            CleanClientEditionPanelInputs();

            ShowList();
        }

        private async Task SaveNewClient()
        {
            if (ClientsList == null)
            {
                ClientsList = new ObservableCollection<IClient>();
            }

            await ClientsSQL.AddClientAsync(ClientName, ClientCountry, ClientCity, ClientStreet, ClientStreetNumber, ClientsPhoneNumber, ClientsEmailAdres, Convert.ToByte(IsBussinessClientChecked)).ConfigureAwait(false);

            ClientsList = await ClientsSQL.GetClientsAsync();

            CleanClientEditionPanelInputs();

            ShowList();
        }

        private void CleanClientEditionPanelInputs()
        {
            ClientName = "";
            ClientCity = "";
            ClientCountry = "";
            ClientStreet = "";
            ClientStreetNumber = "";
            IsBussinessClientChecked = false;
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
            SelectedPanel = "L";

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
