using CustomerUI.Base;
using CustomerUI.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CustomerUI.ViewModel.TaskbarVMs
{
    public class DatabaseVM : BaseViewModel
    {
        public ICommand CreateDataCommand { get; private set; }
        public ICommand DeleteDataCommand { get; private set; }

        private ObservableCollection<DatabaseHistory> databaseHistory;
        public ObservableCollection<DatabaseHistory> DatabaseHistory
        {
            get { return databaseHistory; }
            set { SetProperty(ref databaseHistory, value); }
        }

        private ObservableCollection<DbStatistic> statistics;
        public ObservableCollection<DbStatistic> Statistics
        {
            get { return statistics; }
            set { SetProperty(ref statistics, value); }
        }

        private int customersCount;
        public int CustomersCount
        {
            get { return customersCount; }
            set { SetProperty(ref customersCount, value); }
        }

        public DatabaseVM()
        {
            CreateDataCommand = new RelayCommand(CreateData);
            DeleteDataCommand = new RelayCommand(DeleteData);

            databaseHistory = [];
            statistics = [];
            customersCount = Customers.Count;

            InitializeDatabaseHistory();
            InitializeStatistics();
        }

        private void InitializeDatabaseHistory()
        {
            DatabaseHistory =
            [
                new DatabaseHistory { User = "Ala Alduwebi", Action = "Löschung", Date = new DateOnly(2024, 4, 22), Time = new TimeSpan(12, 30, 0) },
                new DatabaseHistory { User = "Ala Alduwebi", Action = "Erstellung", Date = new DateOnly(2024, 4, 22), Time = new TimeSpan(12, 32, 0) }
            ];
        }

        private void InitializeStatistics()
        {
            var maxCount = Customers.Count * 3;
            Statistics =
            [
                new DbStatistic { Table = "Kunden", Count = Customers.Count, MaxCount = 30},
                new DbStatistic { Table = "Karten", Count = Customers.SelectMany(c => c.Cards).Count(), MaxCount = 90 },
                new DbStatistic { Table = "Aktionen", Count = Customers.SelectMany(c => c.Actions).Count(), MaxCount = 90 },
                new DbStatistic { Table = "Reisen", Count = Customers.SelectMany(c => c.Travels).Count(), MaxCount = 90 },
                new DbStatistic { Table = "Passagiere", Count = Customers.SelectMany(c => c.Travels).SelectMany(t => t.Passengers).Count(), MaxCount = 90 },
                new DbStatistic { Table = "Transfers", Count = Customers.SelectMany(c => c.Travels).SelectMany(t => t.Transfers).Count(), MaxCount = 90 }
            ];
        }

        private async void CreateData(object parameter)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Sind Sie sicher, dass Sie die aktuelle Daten löschen und neue Daten erstellen möchten?", "Neue Daten erstellen",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                int count = CustomersCount;
                await customerRepository.CreateCustomersAsync(count);

                InitializeStatistics();
                SelectedCustomer = Customers[0];
                Messenger.Default.Send(SelectedCustomer);
            }
        }

        private async void DeleteData(object parameter)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Sind Sie sicher, dass Sie die Daten löschen möchten?", "Daten löschen",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                SelectedCustomer = null;

                await customerRepository.DeleteCustomersDataAsync();

                InitializeStatistics();
                Messenger.Default.Send(SelectedCustomer);
            }
        }
    }
}
