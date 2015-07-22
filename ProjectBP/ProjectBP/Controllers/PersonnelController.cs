using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectBP.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjectBP.Controllers
{
    public class PersonnelController : ApiController
    {
        [HttpGet]
        public IEnumerable<Personnel> index()
        {
            var personnel = DataConn.Read();
            return personnel;
        }

        [HttpGet]
        public Personnel GetPerson(int id)
        {
            return DataConn.GetPerson(id);
        }

        [HttpPost]
        public int CreatePerson(Personnel personnel)
        {
            return DataConn.Create(personnel);
        }

        [HttpPost]
        public bool UpdatePerson(Personnel person)
        {
           return DataConn.Update(person);
        }

        [HttpPost]
        public void DeletePerson(int id)
        {
            DataConn.Delete(id);            
        }
    }
}
