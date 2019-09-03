namespace NobelPrizeWinners.Models.DataModels
{
    using System;

    public class NobelPrizeWinner
    {
        public NobelPrizeWinner()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

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