// See https://aka.ms/new-console-template for more information
using CsvHelper;
using CsvHelper.Configuration;
using Roga_Simple_Program;
using System.Globalization;

//create csv file
CSVGenerator.GenerateCsvFile();

string rootDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
string filePath = Path.Combine(rootDirectoryPath, "people_data.csv");

//analyze csv
CsvDataAnalyzer.AnalyzeCsv(filePath);

