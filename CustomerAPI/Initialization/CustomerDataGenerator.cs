using CustomerAPI.Enums;
using CustomerAPI.Interfaces;
using CustomersAPI.Initialization;
using CustomersUI.Model;
using static CustomersUI.Model.Customer;
using static CustomersUI.Model.Customer.Travel;

namespace CustomerAPI.Initialization
{
    public class CustomerDataGenerator : Initialize, ICustomerDataGenerator
    {
        public Company GetCompany(int customerId)
        {
            var companyId = Rand.Next(1, 15);

            var name = GetBaseCompany(companyId).Name;
            var employmentType = GetRandomEnumValue<EmploymentType>().ToString();
            var streetHnr = staticData.StreetsHnrs[Rand.Next(staticData.StreetsHnrs.Count)];
            var zipCity = staticData.ZipCities[Rand.Next(staticData.ZipCities.Count)];
            var country = GetRandomEnumValue<Country>().ToString();
            var telNr = GenerateRandomTelNr();
            var email = $"contact@{name}.com".Replace(" ", "").ToLower();
            var website = $"www.{name}.com".Replace(" ", "").ToLower();
            var description = GetBaseCompany(companyId).Description;
            var yearEstablished = GetBaseCompany(companyId).YearEstablished;
            var numberOfEmployees = GetBaseCompany(companyId).NumberOfEmployees;

            var company = new Company()
            {
                CustomerId = customerId,
                Name = name,
                EmploymentType = employmentType,
                StreetHnr = streetHnr,
                ZipCity = zipCity,
                Country = country,
                TelNr = telNr,
                Email = email,
                Website = website,
                Description = description,
                YearEstablished = yearEstablished,
                NumberOfEmployees = numberOfEmployees
            };

            return company;
        }

        public List<Travel> GetTravelList(int customerId)
        {
            var travels = new List<Travel>();

            for (int i = 1; i < 4; i++)
            {
                var departure = GetRandomEnumValue<TravelPoint>().ToString();
                var departureTime = GenerateRandomTime();
                var arrival = GetRandomEnumValue<TravelPoint>().ToString();
                var arrivalTime = GenerateRandomTime();
                var travelStatus = GetRandomEnumValue<TravelStatus>().ToString();
                var seat = GenerateRandomSeat();
                var terminal = GenerateTerminalId();
                var passengers = new List<Passenger>();
                var passengersCount = passengers.Count;
                var transfers = new List<Transfer>();

                travels.Add(new Travel()
                {
                    CustomerId = customerId,
                    CardId = 0,
                    ActionId = 0,
                    Departure = departure,
                    DepartureTime = departureTime,
                    Arrival = arrival,
                    ArrivalTime = arrivalTime,
                    Duration = new TimeSpan(),
                    TravelStatus = travelStatus,
                    Seat = seat,
                    TerminalId = terminal,
                    PassengersCount = passengersCount,
                    Passengers = passengers,
                    Transfers = transfers
                });
            }
            return travels;
        }

        public List<Passenger> GetPassengersList(int customerId, int travelId)
        {
            var passengers = new List<Passenger>();
            var passengersCount = Rand.Next(1, 4);

            for (int passengerId = 1; passengerId < passengersCount; passengerId++)
            {
                var passenger = staticData.BaseCostumer[Rand.Next(staticData.BaseCostumer.Count)];
                var fullname = $"{passenger.Name} {passenger.Lastname}";
                var birthday = GenerateRandomDate(1940, 2000);
                var relationship = GetRandomEnumValue<Relationship>().ToString();

                passengers.Add(new Passenger()
                {
                    CustomerId = customerId,
                    TravelId = travelId,
                    Salutation = passenger.Salutation,
                    Name = passenger.Name,
                    Lastname = passenger.Lastname,
                    Fullname = fullname,
                    Birthday = birthday,
                    Relationship = relationship
                });
            }
            return passengers;
        }

        public List<Transfer> GetTransfersList(int customerId, int travelId)
        {
            var transfers = new List<Transfer>();
            var transfersCount = Rand.Next(1, 4);

            for (int transferId = 1; transferId < transfersCount; transferId++)
            {
                var departureTime = GenerateRandomTime();
                var arrivalTime = GenerateRandomTime();

                transfers.Add(new Transfer()
                {
                    CustomerId = customerId,
                    TravelId = travelId,
                    DepartureTime = departureTime,
                    ArrivalTime = arrivalTime,
                    Duration = new TimeSpan()
                });
            }
            return transfers;
        }

        public List<Customer.Action> GetActionsList(int customerId, List<Travel> travels)
        {
            var actions = new List<Customer.Action>();

            for (int i = 0; i < travels.Count; i++)
            {
                var actionNr = GenerateActionNr();
                var date = GenerateRandomDate(2020, 2024);
                var time = GenerateRandomTime();
                var amount = GenerateRandomAmount(50.50m, 900.99m) + "€";

                var action = new Customer.Action
                {
                    CustomerId = customerId,
                    CardId = 0,
                    TravelId = 0,
                    ActionNr = actionNr,
                    Date = date,
                    Time = time,
                    Amount = amount
                };

                actions.Add(action);
            }
            return actions;
        }

        public List<Card> GetCardsList(int customerId)
        {
            var cards = new List<Card>();

            // Zufällige Anzahl von Karten für den Kunden generieren
            var numberOfCards = Rand.Next(1, 4); // Annahme: Maximal 3 Karten pro Kunde

            for (int i = 0; i < numberOfCards; i++)
            {
                var cardName = GetRandomEnumValue<CardName>().ToString();
                var cardNr = GenerateCardNumber();
                var exDate = GenerateRandomDate(2024, 2040);

                var card = new Card
                {
                    CustomerId = customerId,
                    CardName = cardName,
                    CardNr = cardNr,
                    ExDate = exDate,
                    TravelIds = [],
                    ActionIds = []
                };

                cards.Add(card);
            }
            return cards;
        }
    }
}
