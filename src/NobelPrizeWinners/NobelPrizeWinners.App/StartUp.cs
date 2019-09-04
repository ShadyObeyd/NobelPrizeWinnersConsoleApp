namespace NobelPrizeWinners.App
{
    using Data;
    using Services;

    public static class StartUp
    {
        public static void Main()
        {
            var db = new NobelPrizeWinnersDbContext();
            var winnerService = new WinnerService(db);

            winnerService.Run();
        }
    }
}