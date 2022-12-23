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
    public class CourierFormViewModel : ViewModelBase
    {
        private readonly PeopleService _peopleService = new PeopleService();
        public CourierModel SelectedCourier { get; set; }

        public ICommand SubmitCourier { get; }
        public ICommand EditCourier { get; }

        public CourierFormViewModel()
        {
            SelectedCourier = new CourierModel();

            SubmitCourier = new ViewModelCommand(ExecuteSubmitCourierCommand);
        }

        public CourierFormViewModel(CourierModel courier)
        {
            SelectedCourier = courier;

            EditCourier = new ViewModelCommand(ExecuteEditCourierCommand);
        }

        private void ExecuteSubmitCourierCommand(object obj)
        {
            _peopleService.AddCourier(SelectedCourier);
        }

        private void ExecuteEditCourierCommand(object obj)
        {
            _peopleService.EditCourier(SelectedCourier);
        }
    }
}
