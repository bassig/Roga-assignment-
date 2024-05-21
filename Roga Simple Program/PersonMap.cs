using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roga_Simple_Program
{
    public sealed class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Map(p => p.FirstName).Index(0);
            Map(p => p.LastName).Index(1);
            Map(p => p.Age).Index(2);
            Map(p => p.Weight).Index(3);
            Map(p => p.Gender).Index(4);
        }
    }

}
