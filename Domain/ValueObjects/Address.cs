namespace Domain.ValueObjects
{
    public partial record Address
    {
        public string Country { get; init; } = string.Empty;
        public string Department { get; init; } = string.Empty;
        public string City { get; init; } = string.Empty;
        public string Line { get; init; } = string.Empty;
        public string PostalCode { get; init; } = string.Empty;
        private static readonly List<string> LINES = new List<string> { "carrera", "calle", "diagonal" };

        public Address(string country, string line, string department, string city, string postalCode)
        {
            this.Country = country;
            this.Line = line;
            this.Department = department;
            this.City = city;
            this.PostalCode = postalCode;
        }

        public static Address? Create(string country, string department, string city, string line, string postalCode)
        {
            if (string.IsNullOrEmpty(country) || string.IsNullOrEmpty(department) || string.IsNullOrEmpty(city) || !ValidateColombiaLine(line))
            {
                return null;
            }

            return new Address(country, line, department, city, postalCode);
        }

        private static bool ValidateColombiaLine(string line)
        {
            return LINES.Contains(line.ToLower());
        }
    }
}
