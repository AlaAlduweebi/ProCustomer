using CustomerUI.Base;
using CustomerUI.Model;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace CustomerUI.ViewModel
{
    public class CustomersListVM : BaseViewModel
    {
        public ICommand SelectedCustomerCommand { get; set; }
        public ICommand ClearFilterCommand { get; set; }
        public RelayCommand UpdateFilterCommand { get; set; }

        private ICollectionView filteredCustomers;
        public ICollectionView FilteredCustomers
        {
            get { return filteredCustomers; }
        }

        private string filterText;
        public string FilterText
        {
            get { return filterText; }
            set
            {
                if (filterText != value)
                {
                    filterText = value;
                    OnPropertyChanged(nameof(FilterText));
                    filteredCustomers.Refresh();
                }
            }
        }

        public CustomersListVM()
        {
            SelectedCustomerCommand = new RelayCommand(SendSelectedCustomer);

            Messenger.Default.Register<Customer>(this, UpdateSelectedCustomer);

            filteredCustomers = CollectionViewSource.GetDefaultView(Customers);
            filteredCustomers.Filter = PerformFiltering;
            ClearFilterCommand = new RelayCommand(ClearFilter);
        }

        private void SendSelectedCustomer(object parameter)
        {
            var selectedCustomer = parameter as Customer;
            if (selectedCustomer == null)
            {
                return;
            }
            Messenger.Default.Send(SelectedCustomer);
        }

        private void UpdateSelectedCustomer(Customer selectedCustomer)
        {
            if (selectedCustomer == null)
            {
                return;
            }
            SelectedCustomer = selectedCustomer;

            foreach (var customer in Customers)
            {
                customer.IsSelected = customer == SelectedCustomer;
            }
        }

        private bool PerformFiltering(object item)
        {
            if (string.IsNullOrWhiteSpace(filterText))
                return true;

            var customer = item as Customer;
            return customer != null && customer.Fullname.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void ClearFilter(object parameter)
        {
            FilterText = string.Empty;
        }
    }
}