using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace CustomerUI.Model
{
    public class Customer : ObservableObject
    {
        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set { SetProperty(ref isSelected, value); }
        }

        public Customer()
        {
            salutation = string.Empty;
            name = string.Empty;
            lastname = string.Empty;
            fullname = string.Empty;
            birthday = new DateOnly();
            maritalStatus = string.Empty;
            nationality = string.Empty;
            language = string.Empty;
            email = string.Empty;
            telNr = string.Empty;
            streetHnr = string.Empty;
            zipCity = string.Empty;
            country = string.Empty;
            memberNr = string.Empty;
            memberDate = new DateOnly();
            memberStatus = string.Empty;
            Cards = [];
            Travels = [];
            Actions = [];
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }
        private string salutation;

        public string Salutation
        {
            get { return salutation; }
            set { salutation = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
        private string lastname;
        public string Lastname
        {
            get { return lastname; }
            set { SetProperty(ref lastname, value); }
        }
        private string fullname;
        public string Fullname
        {
            get { return fullname; }
            set { fullname = value; }
        }
        private DateOnly birthday;
        public DateOnly Birthday
        {
            get { return birthday; }
            set { SetProperty(ref birthday, value); }
        }
        private string maritalStatus;
        public string MaritalStatus
        {
            get { return maritalStatus; }
            set { maritalStatus = value; }
        }
        private int weight;
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        private int height;
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        private string nationality;

        public string Nationality
        {
            get { return nationality; }
            set { nationality = value; }
        }

        private string language;
        public string Language
        {
            get { return language; }
            set { SetProperty(ref language, value); }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }
        private string telNr;
        public string TelNr
        {
            get { return telNr; }
            set { SetProperty(ref telNr, value); }
        }
        private string streetHnr;
        public string StreetHnr
        {
            get { return streetHnr; }
            set { SetProperty(ref streetHnr, value); }
        }
        private string zipCity;
        public string ZipCity
        {
            get { return zipCity; }
            set { SetProperty(ref zipCity, value); }
        }
        private string country;
        public string Country
        {
            get { return country; }
            set { SetProperty(ref country, value); }
        }
        private string memberNr;
        public string MemberNr
        {
            get { return memberNr; }
            set { SetProperty(ref memberNr, value); }
        }
        private DateOnly memberDate;
        public DateOnly MemberDate
        {
            get { return memberDate; }
            set { SetProperty(ref memberDate, value); }
        }
        private int travelsCount;
        public int TravelsCount
        {
            get { return travelsCount; }
            set { SetProperty(ref travelsCount, value); }
        }
        private string memberStatus;
        public string MemberStatus
        {
            get { return memberStatus; }
            set { SetProperty(ref memberStatus, value); }
        }


        public Company company { get; set; }
        public class Company : ObservableObject
        {
            public Company()
            {
                name = string.Empty;
                employmentType = string.Empty;
                streetHnr = string.Empty;
                zipCity = string.Empty;
                country = string.Empty;
                email = string.Empty;
                telNr = string.Empty;
                website = string.Empty;
                description = string.Empty;

            }
            private int id;
            public int Id
            {
                get { return id; }
                set { SetProperty(ref id, value); }
            }
            private int customerId;
            public int CustomerId
            {
                get { return customerId; }
                set { SetProperty(ref customerId, value); }
            }
            private string name;
            public string Name
            {
                get { return name; }
                set { SetProperty(ref name, value); }
            }
            private string employmentType;
            public string EmploymentType
            {
                get { return employmentType; }
                set { SetProperty(ref employmentType, value); }
            }
            private string streetHnr;
            public string StreetHnr
            {
                get { return streetHnr; }
                set { SetProperty(ref streetHnr, value); }
            }
            private string zipCity;
            public string ZipCity
            {
                get { return zipCity; }
                set { SetProperty(ref zipCity, value); }
            }
            private string country;
            public string Country
            {
                get { return country; }
                set { SetProperty(ref country, value); }
            }
            private string email;
            public string Email
            {
                get { return email; }
                set { SetProperty(ref email, value); }
            }
            private string telNr;
            public string TelNr
            {
                get { return telNr; }
                set { SetProperty(ref telNr, value); }
            }
            private string website;
            public string Website
            {
                get { return website; }
                set { SetProperty(ref website, value); }
            }
            private string description;
            public string Description
            {
                get { return description; }
                set { SetProperty(ref description, value); }
            }
            private int yearEstablished;
            public int YearEstablished
            {
                get { return yearEstablished; }
                set { SetProperty(ref yearEstablished, value); }
            }
            private int numberOfEmployees;
            public int NumberOfEmployees
            {
                get { return numberOfEmployees; }
                set { SetProperty(ref numberOfEmployees, value); }
            }
        }

        public List<Card> Cards { get; set; }
        public class Card : ObservableObject
        {
            public Card()
            {
                cardName = string.Empty;
                cardNr = string.Empty;
                travelIds = [];
                actionIds = [];
                exDate = new DateOnly();
            }

            private int id;
            public int Id
            {
                get { return id; }
                set { SetProperty(ref id, value); }
            }
            private int customerId;
            public int CustomerId
            {
                get { return customerId; }
                set { SetProperty(ref customerId, value); }
            }
            private List<int> travelIds;
            public List<int> TravelIds
            {
                get { return travelIds; }
                set { SetProperty(ref travelIds, value); }
            }
            private List<int> actionIds;
            public List<int> ActionIds
            {
                get { return actionIds; }
                set { SetProperty(ref actionIds, value); }
            }
            private int bookingsCount;
            public int BookingsCount
            {
                get { return bookingsCount; }
                set { SetProperty(ref bookingsCount, value); }
            }
            private string cardName;
            public string CardName
            {
                get { return cardName; }
                set { SetProperty(ref cardName, value); }
            }
            private string cardNr;
            public string CardNr
            {
                get { return cardNr; }
                set { SetProperty(ref cardNr, value); }
            }
            private DateOnly exDate;
            public DateOnly ExDate
            {
                get { return exDate; }
                set { SetProperty(ref exDate, value); }
            }
        }

        public List<Travel> Travels { get; set; }
        public class Travel : ObservableObject
        {
            public Travel()
            {
                departure = string.Empty;
                departureTime = new TimeSpan();
                arrival = string.Empty;
                arrivalTime = new TimeSpan();
                durationTime = new TimeSpan();
                travelStatus = string.Empty;
                seat = string.Empty;
                terminalId = string.Empty;
                Passengers = [];
            }
            private int id;
            public int Id
            {
                get { return id; }
                set { SetProperty(ref id, value); }
            }
            private int customerId;
            public int CustomerId
            {
                get { return customerId; }
                set { SetProperty(ref customerId, value); }
            }
            private int cardId;
            public int CardId
            {
                get { return cardId; }
                set { SetProperty(ref cardId, value); }
            }
            private int actionId;
            public int ActionId
            {
                get { return actionId; }
                set { SetProperty(ref actionId, value); }
            }
            private string departure;
            public string Departure
            {
                get { return departure; }
                set { SetProperty(ref departure, value); }
            }
            private TimeSpan departureTime;
            public TimeSpan DepartureTime
            {
                get { return departureTime; }
                set { SetProperty(ref departureTime, value); }
            }
            private string arrival;
            public string Arrival
            {
                get { return arrival; }
                set { SetProperty(ref arrival, value); }
            }
            private TimeSpan arrivalTime;
            public TimeSpan ArrivalTime
            {
                get { return arrivalTime; }
                set { SetProperty(ref arrivalTime, value); }
            }
            private TimeSpan durationTime;
            public TimeSpan DurationTime
            {
                get { return durationTime; }
                set { SetProperty(ref durationTime, value); }
            }
            private string travelStatus;
            public string TravelStatus
            {
                get { return travelStatus; }
                set { SetProperty(ref travelStatus, value); }
            }
            private string seat;
            public string Seat
            {
                get { return seat; }
                set { SetProperty(ref seat, value); }
            }
            private string terminalId;
            public string TerminalId
            {
                get { return terminalId; }
                set { SetProperty(ref terminalId, value); }
            }
            private int passengersCount;
            public int PassengersCount
            {
                get { return passengersCount; }
                set { SetProperty(ref passengersCount, value); }
            }
            private int transfersCount;
            public int TransfersCount
            {
                get { return transfersCount; }
                set { SetProperty(ref transfersCount, value); }
            }

            public List<Passenger> Passengers { get; set; }
            public class Passenger : ObservableObject
            {
                public Passenger()
                {
                    salutation = string.Empty;
                    name = string.Empty;
                    lastname = string.Empty;
                    fullname = string.Empty;
                    birthday = new DateOnly();
                    relationship = string.Empty;
                }
                private int id;
                public int Id
                {
                    get { return id; }
                    set { SetProperty(ref id, value); }
                }
                private int customerId;
                public int CustomerId
                {
                    get { return customerId; }
                    set { SetProperty(ref customerId, value); }
                }
                private int travelId;
                public int TravelId
                {
                    get { return travelId; }
                    set { SetProperty(ref travelId, value); }
                }
                private string salutation;
                public string Salutation
                {
                    get { return salutation; }
                    set { SetProperty(ref salutation, value); }
                }
                private string name;
                public string Name
                {
                    get { return name; }
                    set { SetProperty(ref name, value); }
                }
                private string lastname;
                public string Lastname
                {
                    get { return lastname; }
                    set { SetProperty(ref lastname, value); }
                }
                private string fullname;
                public string Fullname
                {
                    get { return fullname; }
                    set { SetProperty(ref fullname, value); }
                }
                private DateOnly birthday;
                public DateOnly Birthday
                {
                    get { return birthday; }
                    set { SetProperty(ref birthday, value); }
                }
                private string relationship;
                public string Relationship
                {
                    get { return relationship; }
                    set { SetProperty(ref relationship, value); }
                }
            }

            public List<Transfer> Transfers { get; set; }
            public class Transfer : ObservableObject
            {
                public Transfer()
                {
                    departureTime = new TimeSpan();
                    arrivalTime = new TimeSpan();
                    duration = new TimeSpan();
                }
                private int id;
                public int Id
                {
                    get { return id; }
                    set { SetProperty(ref id, value); }
                }
                private int customerId;
                public int CustomerId
                {
                    get { return customerId; }
                    set { SetProperty(ref customerId, value); }
                }
                private int travelId;
                public int TravelId
                {
                    get { return travelId; }
                    set { SetProperty(ref travelId, value); }
                }
                private TimeSpan departureTime;
                public TimeSpan DepartureTime
                {
                    get { return departureTime; }
                    set { SetProperty(ref departureTime, value); }
                }
                private TimeSpan arrivalTime;
                public TimeSpan ArrivalTime
                {
                    get { return arrivalTime; }
                    set { SetProperty(ref arrivalTime, value); }
                }
                private TimeSpan duration;
                public TimeSpan Duration
                {
                    get { return duration; }
                    set { SetProperty(ref duration, value); }
                }
            }
        }
        public List<Action> Actions { get; set; }
        public class Action : ObservableObject
        {
            public Action()
            {
                actionNr = string.Empty;
                date = new DateOnly();
                time = new TimeSpan();
                amount = string.Empty;
            }

            private int id;
            public int Id
            {
                get { return id; }
                set { SetProperty(ref id, value); }
            }
            private int customerId;
            public int CustomerId
            {
                get { return customerId; }
                set { SetProperty(ref customerId, value); }
            }
            private int cardId;
            public int CardId
            {
                get { return cardId; }
                set { SetProperty(ref cardId, value); }
            }
            private int travelId;
            public int TravelId
            {
                get { return travelId; }
                set { SetProperty(ref travelId, value); }
            }
            private string actionNr;
            public string ActionNr
            {
                get { return actionNr; }
                set { SetProperty(ref actionNr, value); }
            }
            private DateOnly date;
            public DateOnly Date
            {
                get { return date; }
                set { SetProperty(ref date, value); }
            }
            private TimeSpan time;
            public TimeSpan Time
            {
                get { return time; }
                set { SetProperty(ref time, value); }
            }
            private string amount;
            public string Amount
            {
                get { return amount; }
                set { SetProperty(ref amount, value); }
            }
        }
    }
}