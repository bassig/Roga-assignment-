using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roga_Simple_Program
{
    public class CsvDataAnalyzer
    {
        public static void AnalyzeCsv(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csvReader.Context.RegisterClassMap<PersonMap>();
                var people = csvReader.GetRecords<Person>().ToList();

                //find me the average age of all people.
                var averageAge = people.Average(person => person.Age);
                Console.WriteLine($"Average age of all people: {averageAge}");

                //find me the total number of people weighing between 120lbs and 140lbs 
                int countPeople = people.Count(person => person.Weight >= 120 && person.Weight <= 140);
                Console.WriteLine($"Total number of people weighing between 120lbs and 140lbs: {countPeople}");

                //find me the average age of the people  weighing between 120lbs and 140lbs 
                double averageAge120To140 = people.Where(person => person.Weight >= 120 && person.Weight <= 140).Average(person => person.Age);
                Console.WriteLine($"Average age of people weighing between 120lbs and 140lbs: {averageAge120To140}");
            }
        }

    }
}
