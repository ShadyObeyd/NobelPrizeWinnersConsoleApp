﻿namespace NobelPrizeWinners.Services
{
    using NobelPrizeWinners.Data;
    using NobelPrizeWinners.Models.DataModels;
    using OfficeOpenXml;
    using System;
    using System.IO;
    using System.Linq;

    public class WinnerService
    {
        private readonly NobelPrizeWinnersDbContext db;

        public WinnerService(NobelPrizeWinnersDbContext db)
        {
            this.db = db;
        }

        public void PopulateDatabase()
        {
            string filePath = @"C:\Users\Shadi Obeid\Desktop\Nobel Prize Winners.xlsx"; // <-- Add file path

            FileInfo file = new FileInfo(filePath);

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                int rowsCount = worksheet.Dimension.Rows;
                int colsCount = worksheet.Dimension.Columns;

                for (int row = 1; row <= rowsCount; row++)
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
                    string[] winnerTokens = rawText.Split('@').Select(x => x.Trim()).ToArray();

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

                    bool recordExists = this.RecordExists(year, category, name, birthdate, birthPlace, country, residence, fieldOrLanguage, prizeName, motivation);

                    if (recordExists)
                    {
                        continue;
                    }

                    NobelPrizeWinner winner = new NobelPrizeWinner
                    {
                        Year = year,
                        Category = category,
                        Name = name,
                        Birthdate = birthdate,
                        BirthPlace = birthPlace,
                        Country = country,
                        Residence = residence,
                        FieldOrLanguage = fieldOrLanguage,
                        PrizeName = prizeName,
                        Motivation = motivation
                    };

                    this.db.NobelPrizeWinners.Add(winner);
                    this.db.SaveChanges();
                }
            }
        }

        private bool RecordExists(string year, string category, string name, string birthdate, string birthPlace, string country,
            string residence, string fieldOrLanguage, string prizeName, string motivation)
        {
            var nobelPrizeWinner = this.db.NobelPrizeWinners.FirstOrDefault(w => w.Year == year && w.Category == category && w.Name == name &&
                                                                            w.Birthdate == birthdate && w.BirthPlace == birthPlace && w.Country == country &&
                                                                            w.Residence == residence && w.FieldOrLanguage == fieldOrLanguage &&
                                                                            w.PrizeName == prizeName && w.Motivation == motivation);

            if (nobelPrizeWinner == null) 
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}