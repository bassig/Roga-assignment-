using Newtonsoft.Json;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roga_Simple_Program
{
    public class CSVGenerator
    {

        public static void GenerateCsvFile()
        {
            var userFaker = new Faker<Person>()
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Age, f => f.Random.Number(18,71))
                .RuleFor(u => u.Weight, f => f.Random.Decimal(95,210))
                .RuleFor(u => u.Gender, f => f.PickRandom<Gender>());

            var users = userFaker.Generate(1000);

            WriteToCsv(users);
        }

        public static void WriteToCsv(List<Person> people)
        {
            string rootDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(rootDirectoryPath, "people_data.csv");
            
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine("Existing file deleted.");
            }

            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                streamWriter.WriteLine("First Name,Last Name,Age,Weight(lbs),Gender");

                foreach (Person person in people)
                {
                    streamWriter.WriteLine($"{person.FirstName},{person.LastName},{person.Age},{person.Weight},{person.Gender}");
                }
            }

            Console.WriteLine("CSV file generated and saved successfully.");
        }
    }
}
