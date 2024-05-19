using CustomerUI.Base;
using CustomerUI.Model;
using CustomerUI.View.UserControls.TaskbarUCs.CustomerUCs.TasksListUCs;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;

namespace CustomerUI.ViewModel.TaskbarVMs.CustomerVMs
{
    public class CustomerVM : BaseViewModel
    {
        private System.Windows.Media.Brush memberStatusColor;
        public System.Windows.Media.Brush MemberStatusColor
        {
            get { return memberStatusColor; }
            set { SetProperty(ref memberStatusColor, value); }
        }

        public CustomerVM()
        {
            selectedControl = new ProfileUC();

            taskButtonName = string.Empty;
            shortCustomerName = string.Empty;

            InitializeTasksButtons();

            ButtonClick(Buttons[0]);
            ButtonClickCommand = new RelayCommand(ButtonClick);

            if (Customers.Count > 0)
            {
                UpdateSelectedCustomer(SelectedCustomer);
            }
            //else
            //{
            //    SelectedCustomer = new Customer(); // muss bearbeiten
            //}

            Messenger.Default.Register<Customer>(this, UpdateSelectedCustomer);
        }

        public void InitializeTasksButtons()
        {
            Buttons =
            [
                new("Profil", "M12,11A5,5,0,1,0,7,6,5.006,5.006,0,0,0,12,11Zm0-8A3,3,0,1,1,9,6,3,3,0,0,1,12,3ZM3,22V18a5.006,5.006,0,0,1,5-5h8a5.006,5.006,0,0,1,5,5v4a1,1,0,0,1-2,0V18a3,3,0,0,0-3-3H8a3,3,0,0,0-3,3v4a1,1,0,0,1-2,0Z"),
                new("Unternehmen", "M10,7H3A1,1,0,0,0,2,8V22h9V8A1,1,0,0,0,10,7ZM6,20H4V18H6Zm0-3H4V15H6Zm0-3H4V12H6Zm0-3H4V9H6Zm3,9H7V18H9Zm0-3H7V15H9Zm0-3H7V12H9Zm0-3H7V9H9ZM21.406,5.736,13,2V22h9V6.65A1,1,0,0,0,21.406,5.736ZM20,18H15V16h5Zm0-4H15V12h5Zm0-4H15V8h5Z"),
                new("Reisen", "M16.48 14h4.02a2.5 2.5 0 1 0 0-5H6.618a1 1 0 0 1-.894-.553l-.448-.894A1 1 0 0 0 4.382 7H2.517a1 1 0 0 0-.92 1.394l2.143 5a1 1 0 0 0 .92.606h3.863a1 1 0 0 1 .928 1.371L8.55 17.63A1 1 0 0 0 9.477 19h2.042a1 1 0 0 0 .781-.375l3.4-4.25a1 1 0 0 1 .78-.375zM9.5 8h4.75L12.3 5.4a1 1 0 0 0-.8-.4H9.618a1 1 0 0 0-.894 1.447L9.5 8z"),
                new("Transaktionen", "M15.2929 3.29289C15.6834 2.90237 16.3166 2.90237 16.7071 3.29289L22.3657 8.95147C23.1216 9.70743 22.5862 11 21.5172 11H2C1.44772 11 1 10.5523 1 10C1 9.44772 1.44772 9 2 9H19.5858L15.2929 4.70711C14.9024 4.31658 14.9024 3.68342 15.2929 3.29289ZM4.41421 15H22C22.5523 15 23 14.5523 23 14C23 13.4477 22.5523 13 22 13H2.48284C1.41376 13 0.878355 14.2926 1.63431 15.0485L7.29289 20.7071C7.68342 21.0976 8.31658 21.0976 8.70711 20.7071C9.09763 20.3166 9.09763 19.6834 8.70711 19.2929L4.41421 15Z"),
                new("Posteingang", "M14 14h4V2H2v12h4c0 1.1.9 2 2 2h4a2 2 0 0 0 2-2zM0 2C0 .9.9 0 2 0h16a2 2 0 0 1 2 2v16a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V2zm4 2h12v2H4V4zm0 3h12v2H4V7zm0 3h12v2H4v-2zm0 3h12v2H4V16z"),
                new("Karten", "M20 4H4c-1.103 0-2 .897-2 2v12c0 1.103.897 2 2 2h16c1.103 0 2-.897 2-2V6c0-1.103-.897-2-2-2zM4 6h16v2H4V6zm0 12v-6h16.001l.001 6H4z"),
                new("DatenBank", "M7 14C8.10457 14 9 13.1046 9 12C9 10.8954 8.10457 10 7 10C5.89543 10 5 10.8954 5 12C5 13.1046 5.89543 14 7 14Z M14 12C14 13.1046 13.1046 14 12 14C10.8954 14 10 13.1046 10 12C10 10.8954 10.8954 10 12 10C13.1046 10 14 10.8954 14 12Z M17 14C18.1046 14 19 13.1046 19 12C19 10.8954 18.1046 10 17 10C15.8954 10 15 10.8954 15 12C15 13.1046 15.8954 14 17 14Z")
            ];
        }

        private void UpdateSelectedCustomer(Customer selectedCustomer)
        {
            if (selectedCustomer == null)
            {
                return;
            }

            SelectedCustomer = selectedCustomer;

            ShortCustomerName = $"{SelectedCustomer.Name[..1]}{SelectedCustomer.Lastname[..1]}";

            if (SelectedCustomer.MemberStatus == "Aktiv")
            {
                MemberStatusColor = new SolidColorBrush(Colors.Green);
            }
            else
            {
                MemberStatusColor = new SolidColorBrush(Colors.Red);
            }
        }

        #region Next und Backbuttons

        private ICommand nextCustomerCommand;
        public ICommand NextCustomerCommand
        {
            get
            {
                nextCustomerCommand ??= new RelayCommand(NextCustomer, CanMoveNext);
                return nextCustomerCommand;
            }
        }

        private ICommand _previousCustomerCommand;
        public ICommand PreviousCustomerCommand
        {
            get
            {
                _previousCustomerCommand ??= new RelayCommand(PreviousCustomer, CanMovePrevious);
                return _previousCustomerCommand;
            }
        }

        private void NextCustomer(object parameter)
        {
            var nextCustomerIndex = -1;
            for (int i = 0; i < Customers.Count; i++)
            {
                if (Customers[i].Id == SelectedCustomer.Id)
                {
                    nextCustomerIndex = i + 1;
                    break;
                }
            }

            if (nextCustomerIndex >= 0 && nextCustomerIndex < Customers.Count)
            {
                SelectedCustomer = Customers[nextCustomerIndex];
                Messenger.Default.Send(SelectedCustomer);
            }
        }

        private void PreviousCustomer(object parameter)
        {
            var previousCustomerIndex = -1;
            for (int i = 0; i < Customers.Count; i++)
            {
                if (Customers[i].Id == SelectedCustomer.Id)
                {
                    previousCustomerIndex = i - 1;
                    break;
                }
            }

            if (previousCustomerIndex >= 0 && previousCustomerIndex < Customers.Count)
            {
                SelectedCustomer = Customers[previousCustomerIndex];
                Messenger.Default.Send(SelectedCustomer);
            }
        }

        private bool CanMoveNext(object? parameter)
        {
            var currentIndex = Customers.IndexOf(Customers.FirstOrDefault(c => c.Id == SelectedCustomer.Id));
            return currentIndex < Customers.Count - 1;
        }

        private bool CanMovePrevious(object? parameter)
        {
            var currentIndex = Customers.IndexOf(Customers.FirstOrDefault(c => c.Id == SelectedCustomer.Id));
            return currentIndex > 0;
        }

        #endregion

        #region Tasks Buttons

        private System.Windows.Controls.UserControl selectedControl;
        public System.Windows.Controls.UserControl SelectedControl
        {
            get { return selectedControl; }
            set { SetProperty(ref selectedControl, value); }
        }

        private TasksBottuns selectedButton;
        public TasksBottuns SelectedButton // um den vorherigen gedruckten Button wieder not isselcted
        {
            get { return selectedButton; }
            set { SetProperty(ref selectedButton, value); }
        }

        private string taskButtonName;
        public string TaskButtonName
        {
            get { return taskButtonName; }
            set { SetProperty(ref taskButtonName, value); }
        }

        private string shortCustomerName;
        public string ShortCustomerName
        {
            get { return shortCustomerName; }
            set { SetProperty(ref shortCustomerName, value); }
        }

        private System.Threading.Timer timer;

        public ObservableCollection<TasksBottuns> Buttons { get; set; }
        public ICommand ButtonClickCommand { get; set; }

        private void ButtonClick(object parameter)
        {
            var button = parameter as TasksBottuns;
            if (button != null)
            {
                if (SelectedButton != null)
                {
                    SelectedButton.IsSelected = false;
                    SelectedButton.Content = SelectedButton.Content.Replace(" > >", ""); // Lösche ">"
                }

                button.IsSelected = true;
                SelectedButton = button;
                TaskButtonName = button.Content;

                StartTimer();

                switch (button.Content)
                {
                    case "Profil":
                        SelectedControl = new ProfileUC();
                        break;
                    case "Unternehmen":
                        //Messenger.Default.Send(SelectedCustomer);
                        SelectedControl = new CompanyUC();
                        break;
                    case "Transaktionen":
                        SelectedControl = new TransactionsUC();
                        break;
                    case "Posteingang":
                        SelectedControl = new InboxUC();
                        break;
                    case "Karten":
                        SelectedControl = new CardsUC();
                        break;
                    case "Weitere":
                        SelectedControl = new MoreUC();
                        break;
                    default:
                        break;
                }
            }

        }

        private void StartTimer()
        {
            timer?.Dispose();

            timer = new System.Threading.Timer(async (state) =>
            {
                // Warte eine halbe Sekunde
                await Task.Delay(150);

                // Füge einen weiteren ">" hinzu
                SelectedButton.Content += " >";
                OnPropertyChanged(nameof(Buttons));

                // Warte noch eine halbe Sekunde
                await Task.Delay(150);

                // Füge einen weiteren ">" hinzu
                SelectedButton.Content += " >";
                OnPropertyChanged(nameof(Buttons));
            }, null, 0, Timeout.Infinite);
        }

        #endregion
    }
}
