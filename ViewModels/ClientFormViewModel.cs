using SWD_WPF_Project.Models;
using SWD_WPF_Project.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace SWD_WPF_Project.ViewModels
{
    public class ClientFormViewModel : ViewModelBase
    {
        private readonly PeopleService _peopleService = new PeopleService();
        public ClientModel SelectedClient { get; set; }

        public ICommand SubmitClient { get; }
        public ICommand EditClient { get; }

        public ClientFormViewModel()
        {
            SelectedClient = new ClientModel();

            SubmitClient = new ViewModelCommand(ExecuteSubmitClientCommand);
        }

        public ClientFormViewModel(ClientModel client)
        {
            SelectedClient = client;

            EditClient = new ViewModelCommand(ExecuteEditClientCommand);
        }

        private void ExecuteSubmitClientCommand(object obj)
        {
            _peopleService.AddClient(SelectedClient);
        }

        private void ExecuteEditClientCommand(object obj)
        {
            _peopleService.EditClient(SelectedClient);
        }
    }
}
