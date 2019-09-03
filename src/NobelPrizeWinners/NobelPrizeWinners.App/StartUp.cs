namespace NobelPrizeWinners.App
{
    using OfficeOpenXml;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public static class StartUp
    {
        public static void Main()
        {
            string filePath = @""; // <-- Add file path

            FileInfo file = new FileInfo(filePath);

            List<NobelPrizeWinner> winners = new List<NobelPrizeWinner>();

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                int rowsCount = worksheet.Dimension.Rows;
                int colsCount = worksheet.Dimension.Columns;

                for (int row = 2; row <= 2; row++)
                {
                    string rawText = string.Empty;

                    for (int col = 1; col <= colsCount; col++)
                    {
                        try
                        {
                            rawText += worksheet.Cells[row, col].Value.ToString() + "@";
                        }
                        catch (NullReferenceException)
                        {
                            rawText += "N/A@";
                        }
                    }
                    string[] winnerTokens = rawText.Split('@', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

                    string year = winnerTokens[0];
                    string category = winnerTokens[1];
                    string name = winnerTokens[2];
                    string birthdate = winnerTokens[3];
                    string birthPlace = winnerTokens[4];
                    string country = winnerTokens[5];
                    string residence = winnerTokens[6];
                    string fieldOrLanguage = winnerTokens[7];
                    string prizeName = winnerTokens[8];
                    string motivation = winnerTokens[9];

                    NobelPrizeWinner winner = new NobelPrizeWinner(year, category, name, birthdate, birthPlace, country, residence, fieldOrLanguage, prizeName, motivation);
                    winners.Add(winner);
                }
            }

            var firstWinner = winners[0];

            Console.WriteLine(firstWinner.Year);
            Console.WriteLine(firstWinner.Category);
            Console.WriteLine(firstWinner.Name);
            Console.WriteLine(firstWinner.Birthdate);
            Console.WriteLine(firstWinner.BirthPlace);
            Console.WriteLine(firstWinner.Country);
            Console.WriteLine(firstWinner.Residence);
            Console.WriteLine(firstWinner.FieldOrLanguage);
            Console.WriteLine(firstWinner.PrizeName);
            Console.WriteLine(firstWinner.Motivation);
        }
    }
}