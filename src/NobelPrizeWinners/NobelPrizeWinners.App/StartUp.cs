namespace NobelPrizeWinners.App
{
    using Data;
    using Services;

    using System;

    public static class StartUp
    {
        public static void Main()
        {
            var db = new NobelPrizeWinnersDbContext();
            var winnerService = new WinnerService(db);

            Console.WriteLine("Please wait...");
            winnerService.PopulateDatabase();
            Console.WriteLine("Done! Have a nice day!");
        }
    }
}