using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace TelerikGrid.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CustomersViewModel>();
            SimpleIoc.Default.Register<LogViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public CustomersViewModel Customers => ServiceLocator.Current.GetInstance<CustomersViewModel>();
        public LogViewModel Log => ServiceLocator.Current.GetInstance<LogViewModel>();
    }
}
