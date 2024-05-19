using CustomersUI.Model;

namespace CustomerAPI.Initialization
{
    public class StaticData
    {
        public List<Customer> BaseCostumer =
        [
            new() { Salutation = "Frau", Name = "Virginia", Lastname = "Rossi" },
            new() { Salutation = "Frau", Name = "Camille", Lastname = "Leclerc" },
            new() { Salutation = "Herr", Name = "Mark", Lastname = "Williams" },
            new() { Salutation = "Frau", Name = "Sophie", Lastname = "Müller" },
            new() { Salutation = "Herr", Name = "Luis", Lastname = "González" },
            new() { Salutation = "Frau", Name = "Emma", Lastname = "Smith"},
            new() { Salutation = "Frau", Name = "Marta", Lastname = "García" },
            new() { Salutation = "Frau", Name = "Andrea", Lastname = "Ricci" },
            new() { Salutation = "Frau", Name = "Elena", Lastname = "Martínez"},
            new() { Salutation = "Herr", Name = "Michael", Lastname = "Andersen"},
            new() { Salutation = "Frau", Name = "Anna", Lastname = "Novak"},
            new() { Salutation = "Herr", Name = "Sebastian", Lastname = "Kowalski"},
            new() { Salutation = "Frau", Name = "Marie", Lastname = "Lefèvre"},
            new() { Salutation = "Herr", Name = "Lucas", Lastname = "André"},
            new() { Salutation = "Frau", Name = "Sophia", Lastname = "Klein"},
            new() { Salutation = "Herr", Name = "Matías", Lastname = "Hernández"},
            new() { Salutation = "Herr", Name = "Federico", Lastname = "Moretti"},
            new() { Salutation = "Frau", Name = "Emily", Lastname = "Johnson"},
            new() { Salutation = "Herr", Name = "Giovanni", Lastname = "Bianchi"},
            new() { Salutation = "Frau", Name = "Isabella", Lastname = "Fischer"},
            new() { Salutation = "Herr", Name = "Hugo", Lastname = "López"},
            new() { Salutation = "Frau", Name = "Sofia", Lastname = "Andersson"},
            new() { Salutation = "Herr", Name = "Lucas", Lastname = "Müller"},
            new() { Salutation = "Frau", Name = "Amélie", Lastname = "Dubois"},
            new() { Salutation = "Herr", Name = "Oliver", Lastname = "Nilsson"},
            new() { Salutation = "Frau", Name = "Julia", Lastname = "Wagner"},
            new() { Salutation = "Herr", Name = "Marco", Lastname = "Ricci"},
            new() { Salutation = "Frau", Name = "Isabel", Lastname = "Pereira"},
            new() { Salutation = "Herr", Name = "Andreas", Lastname = "Schneider"},
            new() { Salutation = "Frau", Name = "Emilie", Lastname = "Larsson"}
        ];

        public List<Customer.Company> BaseCompany =
        [
            new() { Name = "SolarTech Innovations", Description = "Führend in der Entwicklung innovativer Solartechnologie-Lösungen.", YearEstablished = 2000, NumberOfEmployees = 30 },
            new() { Name = "BlueWave Systems", Description = "Spezialisiert auf fortschrittliche Wasseraufbereitungs- und Reinigungssysteme.", YearEstablished = 2010, NumberOfEmployees = 100 },
            new() { Name = "EcoBuild Materials", Description = "Bietet nachhaltige und umweltfreundliche Baumaterialien.", YearEstablished = 2005, NumberOfEmployees = 80 },
            new() { Name = "FutureNow Technologies", Description = "Entwickelt Spitzentechnologien für die Herausforderungen von morgen.", YearEstablished = 2012, NumberOfEmployees = 200 },
            new() { Name = "ClearSky Energy", Description = "Engagiert für die Produktion von sauberen und nachhaltigen Energielösungen.", YearEstablished = 2002, NumberOfEmployees = 50 },
            new() { Name = "UrbanGreen Landscapes", Description = "Gestaltet und pflegt nachhaltige urbane Landschaften für die moderne Stadt.", YearEstablished = 2014, NumberOfEmployees = 120 },
            new() { Name = "BioGrow Agriculture", Description = "Nutzt Biotechnologie, um die Produktion und Nachhaltigkeit von Kulturen zu verbessern.", YearEstablished = 2008, NumberOfEmployees = 90 },
            new() { Name = "AquaPurity Solutions", Description = "Bietet innovative Lösungen für Wasserschutz und -management.", YearEstablished = 2006, NumberOfEmployees = 120 },
            new() { Name = "SmartMove Transportation", Description = "Pionier in intelligenten Transportlösungen zur Reduzierung der Umweltbelastung.", YearEstablished = 2013, NumberOfEmployees = 60 },
            new() { Name = "Infinity Software Solutions", Description = "Bietet umfassende und skalierbare Softwareentwicklungsdienste.", YearEstablished = 2003, NumberOfEmployees = 180 },
            new() { Name = "Visionary Designs Studio", Description = "Ein kreatives Designstudio, das die Grenzen der Innovation erweitert.", YearEstablished = 2009, NumberOfEmployees = 130 },
            new() { Name = "Quantum Development Labs", Description = "Forschung und Entwicklung im Bereich der Quantencomputertechnologie.", YearEstablished = 2015, NumberOfEmployees = 160 },
            new() { Name = "Galaxy Electronics", Description = "Hersteller von hochwertigen, innovativen Elektronikprodukten für den Weltmarkt.", YearEstablished = 2001, NumberOfEmployees = 70 },
            new() { Name = "Peak Performance Apparel", Description = "Produziert Hochleistungssportbekleidung für Sportprofis und Enthusiasten.", YearEstablished = 2004, NumberOfEmployees = 170 },
            new() { Name = "Golden Horizon Investments", Description = "Ein Finanzunternehmen, das sich auf nachhaltige und ethische Anlageoptionen konzentriert.", YearEstablished = 2007, NumberOfEmployees = 190 }
        ];

        public List<string> StreetsHnrs =
        [
            "Teufelstraße 4", "Avenue des Champs-Élysées 20", "789 Maple Avenue", "Bahnhofstraße 15", "Calle Mayor 7",
            "45 Oak Street", "Gran Vía 20", "Via Roma 12", "Carrer de Balmes 100", "Strandvejen 55", "Václavské náměstí 15",
            "ul. Nowy Świat 22", "Rue de Rivoli 10", "Avenida da Liberdade 200", "Kurfürstendamm 200", "Calle de Alcalá 50",
            "Via Montenapoleone 10", "123 Main Street", "Via del Corso 150", "Hauptstraße 7", "Calle Gran Vía 100",
            "Drottninggatan 5", "Hofbräuallee 7", "Rue du Faubourg Saint-Honoré 200", "Kungsgatan 25", "Landsberger Allee 123",
            "Viale Umberto I 50", "Rua Augusta 150", "Am Langenhorster Bahnhof 2", "Västra Ågatan 10"
        ];

        public List<string> ZipCities =
        [
            "15486 Rome", "75008 Paris", "Chicago, IL 60601", "10115 Berlin", "28001 Madrid", "New York, NY 10001", "28013 Madrid",
            "00184 Rom", "08008 Barcelona", "2900 Hellerup", "11000 Prag", "00-400 Warschau", "75001 Paris", "1250-147 Lissabon",
            "10719 Berlin", "28014 Madrid", "20121 Mailand", "Los Angeles, CA 90001", "00186 Rom", "70173 Stuttgart", "28013 Madrid",
            "11151 Stockholm", "80335 München", "75008 Paris", "11261 Stockholm", "10407 Berlin", "00185 Rom", "1100-053 Lissabon",
            "42551 Velbert", "75309 Uppsala"
        ];
    }
}
