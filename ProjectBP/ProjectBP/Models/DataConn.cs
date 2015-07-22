using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ProjectBP.Models
{
    public static class DataConn
    {
        public static string dbConn = "Data Source=localhost; user id=appuser; password=app_password; initial catalog=app;";

        public static List<Personnel> Read()
        {
            var people = new List<Personnel>();

            using (IDbConnection conn = new SqlConnection(dbConn))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Person ORDER BY Id asc";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            people.Add(new Personnel()
                            {
                                ID = Convert.ToInt32(reader["id"]),
                                FirstName = Convert.ToString(reader["firstName"]),
                                LastName = Convert.ToString(reader["lastName"])
                            });
                        }
                    }
                }
            }
            return people;
        }

        public static Personnel GetPerson(int id)
        {

            //return Read().Where(x => x.ID == id).FirstOrDefault();

            var person = new Personnel();

            using (IDbConnection conn = new SqlConnection(dbConn))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Person Where ID = " + id;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                                person.ID = Convert.ToInt32(reader["id"]);
                                person.FirstName = Convert.ToString(reader["firstName"]);
                                person.LastName = Convert.ToString(reader["lastName"]);
                            
                        }
                    }
                }
            }
            return person;
        }

        public static int Create(Personnel personnel)
        {
            var newPersonId = 0;
            using (IDbConnection conn = new SqlConnection(dbConn))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    var fname = personnel.FirstName.Replace("'", "''").Trim();
                    var lname = personnel.LastName.Replace("'", "''").Trim();

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT into person values ('" + fname + "', '" + lname + "'); SELECT SCOPE_IDENTITY();";
                    newPersonId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return newPersonId;
        }

        public static void Delete(int id)
        {
            using (IDbConnection conn = new SqlConnection(dbConn))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Person WHERE ID = " + id;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool Update(Personnel person)
        {
            var isSuccesful = false;

            using (IDbConnection conn = new SqlConnection(dbConn))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Update Person SET FirstName= '" + person.FirstName + "'," + "LastName='" + person.LastName + "' WHERE ID=" + person.ID;
                    cmd.ExecuteNonQuery();
                    isSuccesful = true;
                }
            }
            return isSuccesful;
        }
    }
}