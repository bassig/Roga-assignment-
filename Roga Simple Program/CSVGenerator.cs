using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roga_Simple_Program
{
    public class CSVGenerator
    {
        
        public static void generateCsvFile()
        {
            List<Person> people = new List<Person>();

            Random random = new Random();

            for (int i= 0; i < 1000; i++)
            {
                Person person = new Person
                {
                    FirstName = GenerateRandomFirstName(),
                    LastName = GenerateRandomLastName(),
                    Age = random.Next(18, 71),
                    Weight = Math.Round(random.NextDouble() * (300 - 100) + 100, 1),
                    Gender = (Gender)random.Next(Enum.GetValues(typeof(Gender)).Length)
                };

                people.Add(person);
            }
            writeToCsv(people);
        }

        static string GenerateRandomFirstName() {
            string firstNamesjson = File.ReadAllText("namesJsons/first.names.json");
            List<string> firstNames = JsonConvert.DeserializeObject<List<string>>(firstNamesjson);
            Random random = new Random();
            return firstNames[random.Next(firstNames.Count)];
        }

        static string GenerateRandomLastName()
        {
            string lastNamesjson = File.ReadAllText("namesJsons/last.names.json");
            List<string> lastNames = JsonConvert.DeserializeObject<List<string>>(lastNamesjson);
            Random random = new Random();
            return lastNames[random.Next(lastNames.Count)];
        }

        public static void writeToCsv(List<Person> people)
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
