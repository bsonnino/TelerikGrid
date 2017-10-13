﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Serilog;
using TelerikGrid.Model;

namespace TelerikGrid.ViewModel
{
    public class CustomersViewModel : ViewModelBase
    {
        readonly ObservableCollection<CustomerViewModel> _customers = 
            new ObservableCollection<CustomerViewModel>(
                Customer.GetCustomers().Select(c => new CustomerViewModel(c)));

        public CustomersViewModel()
        {
            _selectedCustomer = _customers.Count > 0 ? _customers[0] : null;
            _newCustomerCommand = new RelayCommand(AddCustomer);
            _deleteCustomerCommand = new RelayCommand(DeleteCustomer, () => SelectedCustomer != null);
            CustomersByCountry = _customers.GroupBy(c => c.Country)
                .Select(g => new CustomerCountry(g.Key, g.Count()))
                .OrderByDescending(c => c.NumCustomers);
        }

        public IEnumerable<CustomerCountry> CustomersByCountry { get; }

        private CustomerViewModel _selectedCustomer;
        private readonly RelayCommand _newCustomerCommand;
        private readonly RelayCommand _deleteCustomerCommand;
        
        public ObservableCollection<CustomerViewModel> Customers => _customers;

        public CustomerViewModel SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                RaisePropertyChanged();
                _deleteCustomerCommand.RaiseCanExecuteChanged();
                Log.Debug("Customer changed to {@Customer}", SelectedCustomer);
            }
        }

        public ICommand NewCustomerCommand => _newCustomerCommand ;

        private void AddCustomer()
        {
            var customer = new CustomerViewModel(new Customer());
            _customers.Add(customer);
            SelectedCustomer = customer;
            Log.Information("Added new Customer");
        }

        public ICommand DeleteCustomerCommand => _deleteCustomerCommand;

        

        private void DeleteCustomer()
        {
            Log.Warning("Deleting Customer {@Customer}", SelectedCustomer);
            _customers.Remove(SelectedCustomer);
            SelectedCustomer = null;
        }
    }

    public class CustomerCountry
    {
        public CustomerCountry(string country, int numCustomers)
        {
            Country = country;
            NumCustomers = numCustomers;
        }

        public string Country { get; }
        public int NumCustomers { get; }
    }
}
