using CustomerUI.Interfaces;
using CustomerUI.Model;
using CustomerUI.View.UserControls;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace CustomerUI.Base
{
    public class CustomerRepository : ICustomerService, INotifyPropertyChanged
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

        private readonly HttpClient HttpClient = new();

        private static CustomerRepository instance;
        public static CustomerRepository Instance => instance ??= new CustomerRepository();

        private System.Windows.Controls.UserControl selectedUpdateControl;
        public System.Windows.Controls.UserControl SelectedUpdateControl
        {
            get { return selectedUpdateControl; }
            set { SetProperty(ref selectedUpdateControl, value); }
        }

        private Visibility visibilityUpdateUC = Visibility.Collapsed;
        public Visibility VisibilityUpdateUC
        {
            get { return visibilityUpdateUC; }
            set { SetProperty(ref visibilityUpdateUC, value); }
        }

        private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customers
        {
            get
            {
                if (customers == null)
                {
                    customers = new ObservableCollection<Customer>();
                    GetAllCustomersAsync();
                }
                return customers;
            }
        }

        public CustomerRepository()
        {
            selectedUpdateControl = new UpdateUC();
        }
        public async Task GetAllCustomersAsync()
        {
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            VisibilityUpdateUC = Visibility.Visible;

            try
            {
                var requestUri = $"https://localhost:44371/all";
                var response = await HttpClient.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var deserializedCustomers = JsonConvert.DeserializeObject<ObservableCollection<Customer>>(responseBody);

                customers.Clear();

                foreach (var customer in deserializedCustomers)
                {
                    customers.Add(customer);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Fehler beim Laden der Kunden: " + ex.Message);
            } finally
            {
                System.Windows.MessageBox.Show("Datenbank erfolgreich aktualisiert.");

                Mouse.OverrideCursor = null;
                VisibilityUpdateUC = Visibility.Hidden;
            }
        }

        public async Task DeleteCustomersDataAsync()
        {
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            VisibilityUpdateUC = Visibility.Visible;

            try
            {
                var requestUri = $"https://localhost:44371/delete";
                var response = await HttpClient.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();

                customers.Clear();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Fehler beim Löschen der Daten: " + ex.Message);
            } finally
            {
                System.Windows.MessageBox.Show("Daten in der Datenbank erfolgreich gelöscht.");

                Mouse.OverrideCursor = null;
                VisibilityUpdateUC = Visibility.Hidden;
            }
        }

        public async Task CreateCustomersAsync(int customersCount)
        {
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            VisibilityUpdateUC = Visibility.Visible;

            try
            {
                var requestUri = $"https://localhost:44371/create/customersCount={customersCount}";
                var response = await HttpClient.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();

                await GetAllCustomersAsync();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Fehler beim Aktualisieren der Datenbank: " + ex.Message);
            } finally
            {

                Mouse.OverrideCursor = null;
                VisibilityUpdateUC = Visibility.Hidden;
            }
        }
    }
}
