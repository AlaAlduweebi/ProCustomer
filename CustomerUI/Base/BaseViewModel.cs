using CustomerUI.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CustomerUI.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected readonly CustomerRepository customerRepository;

        private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customers
        {
            get { return customerRepository.Customers; }
            protected set
            {
                customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        private Customer selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                if (selectedCustomer != value)
                {
                    selectedCustomer = value;
                    OnPropertyChanged(nameof(SelectedCustomer));
                }
            }
        }

        public BaseViewModel()
        {
            customerRepository = CustomerRepository.Instance;

            customers = []; 
            selectedCustomer = new Customer(); 

            InitializeAsync();
        }

        private void InitializeAsync()
        {
            if (Customers.Any())
            {
                SelectedCustomer = Customers[0]; 
            }
        }
    }
}