using CustomerUI.Base;
using CustomerUI.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CustomerUI.View.UserControls.TaskbarUCs.DatabaseUCs;
using CustomerUI.View.UserControls.TaskbarUCs.CustomerUCs.TasksListUCs;
using CustomerUI.View.UserControls.TaskbarUCs.CustomerUCs;

namespace CustomerUI.ViewModel.TaskbarVMs
{
    public class TaskbarVM : BaseViewModel
    {
        public ObservableCollection<TasksBottuns> Buttons { get; set; }

        public ICommand ButtonClickCommand { get; set; }

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

        public TaskbarVM()
        {
            InitializeTasksButtons();

            ButtonClickCommand = new RelayCommand(ButtonClick);

            Messenger.Default.Register<Customer>(this, UpdateSelectedCustomer);

            ButtonClick(Buttons[0]);
        }

        public void InitializeTasksButtons()
        {
            Buttons =
            [
                new("Konto", "M9.6,3.32a3.86,3.86,0,1,0,3.86,3.85A3.85,3.85,0,0,0,9.6,3.32M16.35,11a.26.26,0,0,0-.25.21l-.18,1.27a4.63,4.63,0,0,0-.82.45l-1.2-.48a.3.3,0,0,0-.3.13l-1,1.66a.24.24,0,0,0,.06.31l1,.79a3.94,3.94,0,0,0,0,1l-1,.79a.23.23,0,0,0-.06.3l1,1.67c.06.13.19.13.3.13l1.2-.49a3.85,3.85,0,0,0,.82.46l.18,1.27a.24.24,0,0,0,.25.2h1.93a.24.24,0,0,0,.23-.2l.18-1.27a5,5,0,0,0,.81-.46l1.19.49c.12,0,.25,0,.32-.13l1-1.67a.23.23,0,0,0-.06-.3l-1-.79a4,4,0,0,0,0-.49,2.67,2.67,0,0,0,0-.48l1-.79a.25.25,0,0,0,.06-.31l-1-1.66c-.06-.13-.19-.13-.31-.13L19.5,13a4.07,4.07,0,0,0-.82-.45l-.18-1.27a.23.23,0,0,0-.22-.21H16.46M9.71,13C5.45,13,2,14.7,2,16.83v1.92h9.33a6.65,6.65,0,0,1,0-5.69A13.56,13.56,0,0,0,9.71,13m7.6,1.43a1.45,1.45,0,1,1,0,2.89,1.45,1.45,0,0,1,0-2.89Z"),
                new("Aktivität", "M3 5.6A2.6 2.6 0 0 1 5.6 3h2.8A2.6 2.6 0 0 1 11 5.6v2.8A2.6 2.6 0 0 1 8.4 11H5.6A2.6 2.6 0 0 1 3 8.4V5.6ZM3 15.6A2.6 2.6 0 0 1 5.6 13h2.8a2.6 2.6 0 0 1 2.6 2.6v2.8A2.6 2.6 0 0 1 8.4 21H5.6A2.6 2.6 0 0 1 3 18.4v-2.8ZM13 5.6A2.6 2.6 0 0 1 15.6 3h2.8A2.6 2.6 0 0 1 21 5.6v2.8a2.6 2.6 0 0 1-2.6 2.6h-2.8A2.6 2.6 0 0 1 13 8.4V5.6ZM17 13a1 1 0 0 1 1 1v2h2a1 1 0 1 1 0 2h-2v2a1 1 0 1 1-2 0v-2h-2a1 1 0 1 1 0-2h2v-2a1 1 0 0 1 1-1Z"),
                new("Kunden", "M8,13 C6.34314575,13 5,11.6568542 5,10 C5,8.34314575 6.34314575,7 8,7 C9.65685425,7 11,8.34314575 11,10 C11,11.6568542 9.65685425,13 8,13 Z M16,13 C14.3431458,13 13,11.6568542 13,10 C13,8.34314575 14.3431458,7 16,7 C17.6568542,7 19,8.34314575 19,10 C19,11.6568542 17.6568542,13 16,13 Z M8,15 C10.3893851,15 12.5341111,16.0475098 14,17.7083512 C14,18.1839232 14,18.6144728 14,19 L2,19 C2,18.6144728 2,18.1839232 2,17.7083512 C3.46588891,16.0475098 5.61061495,15 8,15 Z M16,19 L16,16.9519717 L15.4994784,16.3848843 C15.1151403,15.949432 14.6965808,15.550843 14.2491048,15.1921858 C14.8126186,15.0663701 15.3985585,15 16,15 C18.3893851,15 20.5341111,16.0475098 22,17.7083512 L22,19 L16,19 Z"),
                new("Bericht", "M13,8h8c0.6,0,1-0.4,1-1s-0.4-1-1-1h-8c-0.6,0-1,0.4-1,1S12.4,8,13,8z M21,10h-8c-0.6,0-1,0.4-1,1s0.4,1,1,1h8c0.6,0,1-0.4,1-1S21.6,10,21,10z M3,12h6c0.6,0,1-0.4,1-1V5c0-0.6-0.4-1-1-1H3C2.4,4,2,4.4,2,5v6C2,11.6,2.4,12,3,12z M21,14H3c-0.6,0-1,0.4-1,1s0.4,1,1,1h18c0.6,0,1-0.4,1-1S21.6,14,21,14z M13,18H3c-0.6,0-1,0.4-1,1s0.4,1,1,1h10c0.6,0,1-0.4,1-1S13.6,18,13,18z"),
                new("Datenbank", "M8,16.5a1,1,0,1,0,1,1A1,1,0,0,0,8,16.5ZM12,2C8,2,4,3.37,4,6V18c0,2.63,4,4,8,4s8-1.37,8-4V6C20,3.37,16,2,12,2Zm6,16c0,.71-2.28,2-6,2s-6-1.29-6-2V14.73A13.16,13.16,0,0,0,12,16a13.16,13.16,0,0,0,6-1.27Zm0-6c0,.71-2.28,2-6,2s-6-1.29-6-2V8.73A13.16,13.16,0,0,0,12,10a13.16,13.16,0,0,0,6-1.27ZM12,8C8.28,8,6,6.71,6,6s2.28-2,6-2,6,1.29,6,2S15.72,8,12,8ZM8,10.5a1,1,0,1,0,1,1A1,1,0,0,0,8,10.5Z"),
                new("Anpassung", "M19.9,12.66a1,1,0,0,1,0-1.32L21.18,9.9a1,1,0,0,0,.12-1.17l-2-3.46a1,1,0,0,0-1.07-.48l-1.88.38a1,1,0,0,1-1.15-.66l-.61-1.83A1,1,0,0,0,13.64,2h-4a1,1,0,0,0-1,.68L8.08,4.51a1,1,0,0,1-1.15.66L5,4.79A1,1,0,0,0,4,5.27L2,8.73A1,1,0,0,0,2.1,9.9l1.27,1.44a1,1,0,0,1,0,1.32L2.1,14.1A1,1,0,0,0,2,15.27l2,3.46a1,1,0,0,0,1.07.48l1.88-.38a1,1,0,0,1,1.15.66l.61,1.83a1,1,0,0,0,1,.68h4a1,1,0,0,0,.95-.68l.61-1.83a1,1,0,0,1,1.15-.66l1.88.38a1,1,0,0,0,1.07-.48l2-3.46a1,1,0,0,0-.12-1.17ZM18.41,14l.8.9-1.28,2.22-1.18-.24a3,3,0,0,0-3.45,2L12.92,20H10.36L10,18.86a3,3,0,0,0-3.45-2l-1.18.24L4.07,14.89l.8-.9a3,3,0,0,0,0-4l-.8-.9L5.35,6.89l1.18.24a3,3,0,0,0,3.45-2L10.36,4h2.56l.38,1.14a3,3,0,0,0,3.45,2l1.18-.24,1.28,2.22-.8.9A3,3,0,0,0,18.41,14ZM11.64,8a4,4,0,1,0,4,4A4,4,0,0,0,11.64,8Zm0,6a2,2,0,1,1,2-2A2,2,0,0,1,11.64,14Z"),
                new("Hilfe", "M12 17C12.5523 17 13 16.5523 13 16C13 15.4477 12.5523 15 12 15C11.4477 15 11 15.4477 11 16C11 16.5523 11.4477 17 12 17Z M12,2C6.5,2,2,6.5,2,12s4.5,10,10,10s10-4.5,10-10S17.5,2,12,2z M12,20c-4.5,0-8-3.5-8-8s3.5-8,8-8s8,3.5,8,8 S16.5,20,12,20z M13,14h-2c0-2.6,2-2.1,2-4.2c0-0.4-0.2-1.3-1.1-1.3c-0.3,0-1,0.5-1,1.5H9c0,0-0.4-3,2.9-3C14.5,7,15,8.9,15,9.8 C15,12.1,13,12.3,13,14z"),
            ];
        }

        private void UpdateSelectedCustomer(Customer selectedCustomer)
        {
            if (selectedCustomer == null)
            {
                return;
            }
            SelectedCustomer = selectedCustomer;
        }

        private void ButtonClick(object parameter)
        {
            var button = parameter as TasksBottuns;
            if (button != null)
            {
                if (SelectedButton != null)
                {
                    SelectedButton.IsSelected = false;
                }
                button.IsSelected = true;
                SelectedButton = button;

                switch (button.Content)
                {
                    case "Einloggen":
                        break;
                    case "Aktivitäten":
                        SelectedControl = new TransactionsUC();
                        break;
                    case "Kunden":
                        Messenger.Default.Send(SelectedCustomer);
                        SelectedControl = new CustomerUC();
                        break;
                    case "Berichte":
                        SelectedControl = new InboxUC();
                        break;
                    case "Datenbank":
                        SelectedControl = new DatabaseUC();
                        break;
                    case "Einstellungen":
                        SelectedControl = new CardsUC();
                        break;
                    case "Hilfe":
                        SelectedControl = new CardsUC();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
