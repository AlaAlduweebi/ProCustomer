using CustomersUI.Model;
using static CustomersUI.Model.Customer;
using static CustomersUI.Model.Customer.Travel;

namespace CustomerAPI.Interfaces
{
    public interface ICustomerDataGenerator
    {
        Company GetCompany(int customerId);
        List<Travel> GetTravelList(int customerId);
        List<Passenger> GetPassengersList(int customerId, int travelId);
        List<Transfer> GetTransfersList(int customerId, int travelId);
        List<Customer.Action> GetActionsList(int customerId, List<Travel> travels);
        List<Card> GetCardsList(int customerId);
    }
}
