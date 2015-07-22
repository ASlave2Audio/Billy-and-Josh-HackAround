using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectBP.Models;

namespace ProjectBP.Models
{
    public class PersonnelRepository : IPersonnelRepository
    {
        private List<Personnel> personnel = new List<Personnel>();
       // private int _nextId = 1;

        public IEnumerable<Personnel> GetPersonnel()
        {
            return personnel;
        }

        //public Personnel Get(int id)
        //{
        //    return personnel.Find(p => p.ID == id);
        //}

        //public Personnel Add(Personnel person)
        //{
        //    if (person == null)
        //    {
        //        throw new ArgumentNullException("person");
        //    }
        //    person.ID = _nextId++;
        //    personnel.Add(person);
        //    return person;
        //}

        //public void Remove(int id)
        //{
        //    personnel.RemoveAll(p => p.ID == id);
        //}


    }
}