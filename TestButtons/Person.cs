using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestButtons
{
    public class Person
    {
        public string Name { get; set; }
        public string Famly { get; set; }
    }

    public class staff
    {
        public List<Person> Persons = new List<Person>();
        public staff() {
            Persons.Add(new Person() { Name = "Name 1", Famly = "vvv" });
            Persons.Add(new Person() { Name = "Name 2", Famly = "eeee" });
        }

    }
}
