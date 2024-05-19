using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerUI.Interfaces
{
    public interface ICustomerService
    {
        Task GetAllCustomersAsync();
        Task DeleteCustomersDataAsync();
        Task CreateCustomersAsync(int customersCount);
    }
}
