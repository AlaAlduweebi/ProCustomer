using CustomerUI.Base;
using CustomerUI.Model;

namespace CustomerUI.ViewModel.TaskbarVMs.CustomerVMs.TasksListVMs
{
    public class CompanyVM : BaseViewModel
    {
        public CompanyVM()
        {
            Messenger.Default.Register<Customer>(this, UpdateSelectedCustomer);
        }

        private void UpdateSelectedCustomer(Customer selectedCustomer)
        {
            if (selectedCustomer == null)
            {
                return;
            }

            SelectedCustomer = selectedCustomer;
        }
    }
}
