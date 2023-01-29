using CS.Models;
using Microsoft.Data.SqlClient;

namespace CS.Data
{
    internal class StDAO
    {
        private string connectionString = @"Data Source=DESKTOP-C7ALLTO;Initial Catalog=CarShowroom;Integrated Security=True";
        public List<Storage> FetchAll()
        {
            List<Storage> returnList = new List<Storage>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM [dbo].[storage]";
                SqlCommand command = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Storage st = new Storage();
                        st.StorageID = reader.GetInt32(0);
                        st.YearOfManufacture = reader.GetDateTime(1);
                        st.Availability = reader.GetString(2);
                        st.Model = reader.GetString(3); 
                    }
                }
            }

            return returnList;
        }
    }
}