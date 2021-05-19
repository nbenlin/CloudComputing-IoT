using MVVMApplication.Mobile.Models;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MVVMApplication.Mobile.Database
{
    public class PeopleDb
    {
        private readonly SQLiteConnection connection;
        public PeopleDb(string dbPath)
        {
            connection = new SQLiteConnection(dbPath);
            connection.CreateTable<Person>();
        }

        public void AddPerson(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                throw new Exception("First name and last name required!");
            connection.Insert(new Person()
            {
                FirstName = firstName,
                LastName = lastName,
                CreatedOn = DateTime.Now
            });
        }
            
        public IList<Person> GetPeople() 
            => connection.Table<Person>().ToList();
    }
}
