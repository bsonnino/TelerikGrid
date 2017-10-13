using GalaSoft.MvvmLight;
using Serilog;
using Telerik.Data.Core;
using TelerikGrid.Model;

namespace TelerikGrid.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private readonly Customer _customer;

        public CustomerViewModel(Customer customer)
        {
            _customer = customer;
        }

        [Display(Header = "Id", PlaceholderText = "Customer Id")]
        public string Id
        {
            get => _customer.Id;
            set
            {
                Log.Verbose("Customer Id changed from {OldId} to {NewId}", _customer.Id,value);
                _customer.Id = value;
                RaisePropertyChanged();
            }
        }

        [Display(Header = "Name", PlaceholderText = "Customer name")]
        public string Name
        {
            get => _customer.Name;
            set
            {
                Log.Verbose("Customer Name changed from {OldName} to {NewName}", _customer.Name, value);
                _customer.Name = value;
                RaisePropertyChanged();
            }
        }

        [Display(Header = "Address", PlaceholderText = "Customer address")]
        public string Address
        {
            get => _customer.Address;
            set
            {
                Log.Verbose("Customer Address changed from {OldAddress} to {NewAddress}", _customer.Address, value);
                _customer.Address = value;
                RaisePropertyChanged();
            }
        }

        [Display(Header = "City", PlaceholderText = "Customer city")]
        public string City
        {
            get => _customer.City;
            set
            {
                Log.Verbose("Customer City changed from {OldCity} to {NewCity}", _customer.City, value);
                _customer.City = value;
                RaisePropertyChanged();
            }
        }

        [Display(Header = "Country", PlaceholderText = "Customer country")]
        public string Country
        {
            get => _customer.Country;
            set
            {
                Log.Verbose("Customer Country changed from {OldCountry} to {NewCountry}", _customer.Country, value);
                _customer.Country = value;
                RaisePropertyChanged();
            }
        }

        [Display(Header = "Phone", PlaceholderText = "Customer phone")]
        public string Phone
        {
            get => _customer.Phone;
            set
            {
                Log.Verbose("Customer Phone changed from {OldPhone} to {NewPhone}", _customer.Phone, value);
                _customer.Phone = value;
                RaisePropertyChanged();
            }
        }
    }
}
