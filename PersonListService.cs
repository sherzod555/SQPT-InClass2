using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLSerilizer;
using Models;

namespace BLL.Company
{
    public class PersonListService
    {
        List<Person> people;
        Person[] peopleArray; 
        public PersonListService()
        {
            people = new List<Person>();
            peopleArray = new Person[] { };
        }

        public bool InitialCreate()
        {
            Person person1 = new Person("Tom", 29, new CompanyInfo("Microsoft", 1), 1);
            Person person2 = new Person("Bill", 25, new CompanyInfo("Apple", 2), 2);
            people.Add(person1);
            people.Add(person2);            
            return true; ;
        }

        public List<Person> getPeople()
        {            
            return people;
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
            peopleArray = people; 
        }

        public void CreatePeople(List<Person> people)
        {
            this.people = people; 
        }

        List<Person> newpeople;
        public void Create(Person person)
        {
           people.Add(person);
        }
    }
}
