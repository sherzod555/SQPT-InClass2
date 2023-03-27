using BLL.Company;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.Space
{
    [TestClass]
    public class UnitTest1
    {

        [DataRow(23, "Jabbor")]
        [DataRow(24, "Abdullajon")]
        [DataRow(25, "Karimberdi")]
        [DataTestMethod]   //5
        public void TestPersonCreate(int studentId, string studentName)
        {
            PersonListService stdService = new PersonListService();
            Person per = new Person() { };
            per.Name = studentName;
            per.ID = studentId;
            
            stdService.Create(per);
            if (stdService.getPeople().Exists((x) => x.Name == studentName))
            {
                Console.WriteLine("Student added: " + studentName);
                Assert.IsTrue(true);
            }
            else
            {
                Console.WriteLine("AddPerson methods is failed to add student");
                Assert.IsTrue(false);
            }
        }


        [DataRow(29, "Tom")]
        [DataRow(25, "Bill")]
        [DataTestMethod]   //5
        public void TestPersonRemove(int studentId, string studentName)
        {
            PersonListService stdService = new PersonListService();
            stdService.InitialCreate();

            stdService.deletePersonByID(studentId);
            if (!stdService.getPeople().Exists((x) => x.Name == studentName))
            {
                Console.WriteLine("Student deleted: " + studentName);
                Assert.IsTrue(true);
            }
            else
            {
                Console.WriteLine("deletePersonByID method is failed to remove student");
                Assert.IsTrue(false);
            }
        }

        [DataRow(1)]
        [DataRow(2)]
        [DataTestMethod]
        public void JustTest(int id)
        {
            PersonListService personListService = new PersonListService();
            personListService.InitialCreate();

            personListService.deletePersonByID(id);

            Assert.IsFalse(personListService.getPeople().Exists(x=> x.ID == id));
        }
    }
}
