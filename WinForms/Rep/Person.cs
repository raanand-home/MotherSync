using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformsTest
{
    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public float Price { get; set; }
        public int NumOfCarectersInName
        {
            get { return !string.IsNullOrEmpty(Name) ?   Name.Length :0 ; }
        }
    }
    public class Repository
    {
        public List<Person> Persons = new List<Person>();
        public Repository()
        {
            Persons.Add(new Person() { Name = "Ruth", Address = "Habsor 1", Price = 2.65F });
            Persons.Add(new Person() { Name = "Raanan", Address = "Habsor 1", Price = 6.65F });
        }
    }
}
