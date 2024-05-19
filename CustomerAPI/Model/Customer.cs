using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomersUI.Model
{
    public class Customer
    {
        public Customer()
        {
            Salutation = string.Empty;
            Name = string.Empty;
            Lastname = string.Empty;
            Fullname = string.Empty;
            Birthday = new DateOnly();
            MaritalStatus = string.Empty;
            Nationality = string.Empty;
            Language = string.Empty;
            Email = string.Empty;
            TelNr = string.Empty;
            StreetHnr = string.Empty;
            ZipCity = string.Empty;
            Country = string.Empty;
            MemberNr = string.Empty;
            MemberDate = new DateOnly();
            MemberStatus = string.Empty;

            company = new Company();
            Cards = [];
            Travels = [];
            Actions = [];
        }

        public int Id { get; set; }
        public string Salutation { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Fullname { get; set; }
        public DateOnly Birthday { get; set; }
        public string MaritalStatus { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public string Nationality { get; set; }
        public string Language { get; set; }
        public string Email { get; set; }
        public string TelNr { get; set; }
        public string StreetHnr { get; set; }
        public string ZipCity { get; set; }
        public string Country { get; set; }
        public string MemberNr { get; set; }
        public DateOnly MemberDate { get; set; }
        public int TravelsCount { get; set; }
        public string MemberStatus { get; set; }

        public Company company { get; set; }
        public class Company
        {
            public Company()
            {
                Name = string.Empty;
                EmploymentType = string.Empty;
                StreetHnr = string.Empty;
                ZipCity = string.Empty;
                Country = string.Empty;
                Email = string.Empty;
                TelNr = string.Empty;
                Website = string.Empty;
                Description = string.Empty;

            }
            public int Id { get; set; }
            public int CustomerId { get; set; }
            public string Name { get; set; }
            public string EmploymentType { get; set; }
            public string StreetHnr { get; set; }
            public string ZipCity { get; set; }
            public string Country { get; set; }
            public string Email { get; set; }
            public string TelNr { get; set; }
            public string Website { get; set; }
            public string Description { get; set; }
            public int YearEstablished { get; set; }
            public int NumberOfEmployees { get; set; }
        }

        public List<Card> Cards { get; set; }
        public class Card
        {
            public Card()
            {
                CardName = string.Empty;
                CardNr = string.Empty;
                TravelIds = [];
                ActionIds = [];
                ExDate = new DateOnly();
            }

            public int Id { get; set; }
            public int CustomerId { get; set; }
            public List<int> TravelIds { get; set; }
            public List<int> ActionIds { get; set; }
            public int BookingsCount { get; set; }
            public string CardName { get; set; }
            public string CardNr { get; set; }
            public DateOnly ExDate { get; set; }
        }

        public List<Travel> Travels { get; set; }
        public class Travel
        {
            public Travel()
            {
                Departure = string.Empty;
                DepartureTime = new TimeSpan();
                Arrival = string.Empty;
                ArrivalTime = new TimeSpan();
                Duration = new TimeSpan();
                TravelStatus = string.Empty;
                Seat = string.Empty;
                TerminalId = string.Empty;
                Passengers = [];
                Transfers = [];
            }

            public int Id { get; set; }
            public int CustomerId { get; set; }
            public int CardId { get; set; }
            public int ActionId { get; set; }
            public string Departure { get; set; }
            public TimeSpan DepartureTime { get; set; }
            public string Arrival { get; set; }
            public TimeSpan ArrivalTime { get; set; }
            public TimeSpan Duration { get; set; }
            public string TravelStatus { get; set; }
            public string Seat { get; set; }
            public string TerminalId { get; set; }
            public int PassengersCount { get; set; }
            public int TransfersCount { get; set; }

            public List<Passenger> Passengers { get; set; }
            public class Passenger
            {
                public Passenger()
                {
                    Salutation = string.Empty;
                    Name = string.Empty;
                    Lastname = string.Empty;
                    Fullname = string.Empty;
                    Birthday = new DateOnly();
                    Relationship = string.Empty;
                }
                public int Id { get; set; }
                public int CustomerId { get; set; }
                public int TravelId { get; set; }
                public string Salutation { get; set; }
                public string Name { get; set; }
                public string Lastname { get; set; }
                public string Fullname { get; set; }
                public DateOnly Birthday { get; set; }
                public string Relationship { get; set; }
            }

            public List<Transfer> Transfers { get; set; }
            public class Transfer
            {
                public Transfer()
                {
                    DepartureTime = new TimeSpan();
                    ArrivalTime = new TimeSpan();
                    Duration = new TimeSpan();
                }
                public int Id { get; set; }
                public int CustomerId { get; set; }
                public int TravelId { get; set; }
                public TimeSpan DepartureTime { get; set; }
                public TimeSpan ArrivalTime { get; set; }
                public TimeSpan Duration { get; set; }
            }
        }

        public List<Action> Actions { get; set; }
        public class Action
        {
            public Action()
            {
                ActionNr = string.Empty;
                Date = new DateOnly();
                Time = new TimeSpan();
                Amount = string.Empty;
            }

            public int Id { get; set; }
            public int CustomerId { get; set; }
            public int CardId { get; set; }
            public int TravelId { get; set; }
            public string ActionNr { get; set; }
            public DateOnly Date { get; set; }
            public TimeSpan Time { get; set; }
            public string Amount { get; set; }
        }
    }
}
