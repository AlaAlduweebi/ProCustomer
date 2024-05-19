using CustomerAPI.Data;
using CustomerAPI.Enums;
using CustomerAPI.Initialization;
using CustomersUI.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CustomersAPI.Controllers
{
    public class BaseController : CustomerDataGenerator
    {
        protected readonly CustomerDbContext _context;

        public BaseController(CustomerDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Erstellt neue Kundendaten in der Datenbank.
        /// </summary>
        /// <param name="cutomerCount"></param>
        public async Task CreateCustomersDataAsync(int cutomerCount)
        {
            // Lösche zuerst alle vorhandenen Kunden aus der Datenbank
            _context.Customers.RemoveRange(_context.Customers);
            await _context.SaveChangesAsync();

            var customers = GenerateRandomCustomers(cutomerCount);

            // Füge alle Kunden auf einmal zur Datenbank hinzu
            _context.Customers.AddRange(customers);
            await _context.SaveChangesAsync();

            foreach (var customer in customers)
            {
                // Listen für den Kunden aus der Datenbank abrufen und aktualisieren
                var dbCustomer = _context.Customers.FirstOrDefault(c => c.Id == customer.Id);

                if (dbCustomer != null)
                {
                    await UpdateCustomerDetailsAsync(dbCustomer);

                    var dbCards = GetListFromDatabase(dbCustomer.Id, c => c.Cards);
                    var dbActions = GetListFromDatabase(dbCustomer.Id, c => c.Actions);
                    var dbTravels = GetListFromDatabase(dbCustomer.Id, c => c.Travels);

                    if ((dbCards != null) && (dbTravels != null) && (dbActions != null))
                    {
                        await UpdateTravelsAndActionsAsync(dbCustomer, dbTravels, dbActions);

                        await UpdateTravelsAndActionsForCardAsync(dbCards, dbTravels, dbActions);
                    }

                    await _context.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// Generiert eine Liste von zufälligen Kunden mit den angegebenen Anzahl von Kunden.
        /// </summary>
        /// <param name="cutomerCount"></param>
        /// <returns>Eine Liste von zufälligen Kunden.</returns>
        private List<Customer> GenerateRandomCustomers(int cutomerCount)
        {
            var cutomers = new List<Customer>();

            for (int i = 0; i < cutomerCount; i++)
            {
                var baseCostmer = GetBaseCostumer(i);
                var fullname = $"{baseCostmer.Name} {baseCostmer.Lastname}";
                var birthday = GenerateRandomDate(1940, 2000);
                var maritalStatus = GetRandomEnumValue<MaritalStatus>().ToString();
                var weight = Rand.Next(60, 100);
                var height = Rand.Next(150, 190);
                var nationality = GetRandomEnumValue<Nationality>().ToString();
                var language = GetRandomEnumValue<Language>().ToString();
                var email = $"{baseCostmer.Name}.{baseCostmer.Lastname}@example.com";
                var telNr = GenerateRandomTelNr();
                var streetHnr = staticData.StreetsHnrs[Rand.Next(staticData.StreetsHnrs.Count)];
                var zipCity = staticData.ZipCities[Rand.Next(staticData.ZipCities.Count)];
                var country = GetRandomEnumValue<Country>().ToString();
                var memberDate = GenerateRandomDate(2010, 2024);
                var memberNr = $"{baseCostmer.Name[..1]}{baseCostmer.Lastname[..1]}-{zipCity[..3]}-{country[..2]}-{telNr.Substring(4, 3)}";
                var memberStatus = GetRandomEnumValue<MemberStatus>().ToString();

                var customer = new Customer
                {
                    Salutation = baseCostmer.Salutation,
                    Name = baseCostmer.Name,
                    Lastname = baseCostmer.Lastname,
                    Fullname = fullname,
                    Birthday = birthday,
                    MaritalStatus = maritalStatus,
                    Weight = weight,
                    Height = height,
                    Nationality = nationality,
                    Language = language,
                    Email = email,
                    TelNr = telNr,
                    StreetHnr = streetHnr,
                    ZipCity = zipCity,
                    Country = country,
                    MemberDate = memberDate,
                    MemberNr = memberNr,
                    MemberStatus = memberStatus
                };

                cutomers.Add(customer);
            }
            return cutomers;
        }

        /// <summary>
        /// Aktualisiert die Details eines Kunden in der Datenbank, einschließlich seiner Reisen, Aktionen und Karten.
        /// </summary>
        /// <param name="dbCustomer"></param>
        private async Task UpdateCustomerDetailsAsync(Customer dbCustomer)
        {
            dbCustomer.company = GetCompany(dbCustomer.Id);
            dbCustomer.Travels = GetTravelList(dbCustomer.Id);
            dbCustomer.Actions = GetActionsList(dbCustomer.Id, dbCustomer.Travels);
            dbCustomer.Cards = GetCardsList(dbCustomer.Id);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Ruft eine Liste von einer Navigationseigenschaft aus der Datenbank ab, die einem bestimmten Kunden zugeordnet ist.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="customerId"></param>
        /// <param name="navigationProperty"></param>
        /// <returns>Eine Liste von Entitäten vom Typ T oder null, wenn der Kunde nicht gefunden wird.</returns>
        private List<T>? GetListFromDatabase<T>(int customerId, Expression<Func<Customer, ICollection<T>>> navigationProperty) where T : class
        {
            var customer = _context.Customers
                                    .Include(navigationProperty)
                                    .FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                return null;
            }

            var propertyName = (navigationProperty.Body as MemberExpression)?.Member.Name;
            var propertyValue = customer.GetType().GetProperty(propertyName)?.GetValue(customer);

            return propertyValue as List<T>;
        }

        /// <summary>
        /// Aktualisiert die Reisen und Aktionen eines Kunden in der Datenbank.
        /// </summary>
        /// <param name="dbCustomer"></param>
        /// <param name="dbTravels"></param>
        /// <param name="dbActions"></param>
        private async Task UpdateTravelsAndActionsAsync(Customer dbCustomer,
                                                   List<Customer.Travel> dbTravels,
                                                   List<Customer.Action> dbActions)
        {
            for (int i = 0; i < dbTravels.Count; i++)
            {
                dbTravels[i].ActionId = dbActions[i].Id;
                dbActions[i].TravelId = dbTravels[i].Id;

                var passengers = GetPassengersList(dbCustomer.Id, dbTravels[i].Id); // Passengers aktualisieren und speichern
                dbTravels[i].Passengers = passengers;
                dbTravels[i].PassengersCount = passengers.Count;

                var transfers = GetTransfersList(dbCustomer.Id, dbTravels[i].Id); // Transfers aktualisieren und speichern
                dbTravels[i].TransfersCount = transfers.Count;
                dbTravels[i].Transfers = transfers;

                dbCustomer.TravelsCount++;
            }

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Aktualisiert die Zuordnung von Reisen und Aktionen zu Karten und umgekehrt in der Datenbank.
        /// </summary>
        /// <param name="dbCards"></param>
        /// <param name="dbTravels"></param>
        /// <param name="dbActions"></param>
        private async Task UpdateTravelsAndActionsForCardAsync(List<Customer.Card> dbCards,
                                                          List<Customer.Travel> dbTravels,
                                                          List<Customer.Action> dbActions)
        {
            // Mische die Liste der Karten, um sicherzustellen, dass die Auswahl zufällig erfolgt
            var shuffledCards = dbCards.OrderBy(x => Rand.Next()).ToList();

            // Zähle die Anzahl der Karten und Reisen
            int totalCards = shuffledCards.Count;
            int totalTravels = dbTravels.Count;

            // Berechne die maximale Anzahl von Reisen pro Karte und den Rest
            int maxTravelsPerCard = totalTravels / totalCards;
            int remainingTravels = totalTravels % totalCards;

            int travelIndex = 0;

            foreach (var card in shuffledCards)
            {
                int travelsForThisCard = maxTravelsPerCard;

                // Überprüfe, ob es noch verbleibende Reisen gibt, die auf Karten aufgeteilt werden müssen
                if (remainingTravels > 0)
                {
                    travelsForThisCard++;
                    remainingTravels--;
                }

                // Weise Reisen dieser Karte zu
                for (int i = 0; i < travelsForThisCard; i++)
                {
                    if (travelIndex < totalTravels)
                    {
                        var travel = dbTravels[travelIndex];
                        travel.CardId = card.Id;
                        card.TravelIds.Add(travel.Id);

                        var action = dbActions[travelIndex];
                        action.CardId = card.Id;
                        card.ActionIds.Add(action.Id);

                        card.BookingsCount++; // Erhöhe die Anzahl der Buchungen für die Karte
                        travelIndex++;
                    }
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}