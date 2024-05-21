// See https://aka.ms/new-console-template for more information
using CsvHelper;
using CsvHelper.Configuration;
using Roga_Simple_Program;
using System.Globalization;

//create csv file
CSVGenerator.generateCsvFile();

string rootDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
string filePath = Path.Combine(rootDirectoryPath, "people_data.csv");


//find me the average age of all people.
var averageAge = CsvDataAnalyzer.GetAvgAgeFromCsv(filePath);
Console.WriteLine($"Average age of all people: {averageAge}");

//find me the total number of people weighing between 120lbs and 140lbs 
int countPeople = CsvDataAnalyzer.GetTotalBetweenWeightsFromCsv(filePath, 120, 140);
Console.WriteLine($"Total number of people weighing between 120lbs and 140lbs: {countPeople}");

//find me the average age of the people  weighing between 120lbs and 140lbs 
double averageAge120To140 = CsvDataAnalyzer.GetAvgAgeBetweenWeightsFromCsv(filePath, 120, 140);
Console.WriteLine($"Average age of people weighing between 120lbs and 140lbs: {averageAge120To140}");

