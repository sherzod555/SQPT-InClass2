using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLSerilizer;
using Models;

namespace BLL.Company
{
    public class PersonService
    {
        XMLSer xmlser;
        public PersonService()
        {
            xmlser = new XMLSer();
        }

        private static bool InitialCreate(XMLSer xmlser)
        {
            Person person1 = new Person("Tom", 29, new CompanyInfo("Microsoft", 1), 1);
            Person person2 = new Person("Bill", 25, new CompanyInfo("Apple", 2), 2);
            Person[] people = new Person[] { person1, person2 };
            xmlser.SerializePeople(people);
            return true; ;
        }

        public List<Person> getPeople()
        {          
            var newpeople = xmlser.DeserializePeople(true);
            return newpeople;
        }

        public Person getPersonByID(int id)
        {
            var people = getPeople();

            if (people != null)
            {
                return people.Where(x => x.ID == id).FirstOrDefault(); 
            }
            return null; 
        }

        public void deletePersonByID(int id)
        {
            var people = getPeople();
            if (people != null)
            {
                people.Remove(getPersonByID(id));
                CreatePeople(people);  //update people.
            }
        }

        public void CreatePeople(Person[] people)
        {
            xmlser.SerializePeople(people);
        }

        public void CreatePeople(List<Person> people)
        {
            xmlser.SerializePeople(people);
        }

        List<Person> newpeople;
        public void Create(Person person)
        {
            

            newpeople = xmlser.DeserializePeople(true);

            if (newpeople != null)
            {
                newpeople.Add(person);
                xmlser.SerializePeople(newpeople);
            }
            else
            {
                newpeople = new List<Person>();
                newpeople.Add(person);
                xmlser.SerializePeople(newpeople);
            }
        }

        public string CreatePeople(Person per1)
        {
            throw new NotImplementedException();
        }
    }
}
