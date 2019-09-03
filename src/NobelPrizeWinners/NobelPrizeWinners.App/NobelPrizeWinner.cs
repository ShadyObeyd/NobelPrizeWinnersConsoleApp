namespace NobelPrizeWinners.App
{
    public class NobelPrizeWinner
    {
        public NobelPrizeWinner(string year, string category, string name, string birthdate, string birthplace, string country, string residence,
            string fieldOrLanguage, string prizeName, string motivation)
        {
            this.Year = year;
            this.Category = category;
            this.Name = name;
            this.Birthdate = birthdate;
            this.BirthPlace = birthplace;
            this.Country = country;
            this.Residence = residence;
            this.FieldOrLanguage = fieldOrLanguage;
            this.PrizeName = prizeName;
            this.Motivation = motivation;
        }
        public string Year { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }

        public string Birthdate { get; set; }

        public string BirthPlace { get; set; }

        public string Country { get; set; }

        public string Residence { get; set; }

        public string FieldOrLanguage { get; set; }

        public string PrizeName { get; set; }

        public string Motivation { get; set; }
    }
}
