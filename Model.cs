using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Models
{
    public class Person
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int Age { get; set; }
        public CompanyInfo Company { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public string Email { get; set; }

        public Person()
        { }

        public Person(string name, int age, CompanyInfo comp, int id)
        {
            Name = name;
            Age = age;
            Company = comp;
            ID = id;
        }
    }

    [Serializable]
    public class CompanyInfo
    {
        public string Name { get; set; }
        public int ID { get; set; }
       
        public CompanyInfo() { }

        public CompanyInfo(string name, int id)
        {
            Name = name;
            ID = id;
        }
    }
}
