using CS.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using CS.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using CS.Controllers;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS.Data
{
    internal class TDDAO 
    {

       
        private string connectionString = @"Data Source=DESKTOP-C7ALLTO;Initial Catalog=CarShowroom;Integrated Security=True";
        public List<TestDrive> FetchAll()
        {
            List<TestDrive> returnList = new List<TestDrive>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM [dbo].[testDrive]";
                SqlCommand command = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TestDrive td = new TestDrive();
                        td.TestDriveID = reader.GetInt32(0);
                        td.ClientFirstName = reader.GetString(1);
                        td.ClientMiddleName = reader.GetString(2);
                        td.ClientLastName = reader.GetString(3);
                        td.Phone = reader.GetString(4);
                        td.DateOTestDrive = reader.GetDateTime(5);
                        td.Model = reader.GetString(7);
                        returnList.Add(td);
                    }
                }
            }

            return returnList;
        }
        
        
        public TestDrive FetchOne(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM [dbo].[testDrive] WHERE TestDriveID = @TestDriveID";
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.Add("@TestDriveID", System.Data.SqlDbType.Int).Value = id;
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                TestDrive td = new TestDrive();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        td.TestDriveID = reader.GetInt32(0);
                        td.ClientFirstName = reader.GetString(1);
                        td.ClientMiddleName = reader.GetString(2);
                        td.ClientLastName = reader.GetString(3);
                        td.Phone = reader.GetString(4);
                        td.DateOTestDrive = reader.GetDateTime(5);
                        td.Model = reader.GetString(7);
                        
                    }
                }
                return td;
            }
        }

        

        
        

    }
}
