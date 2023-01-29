using CS.Models;
using Microsoft.Data.SqlClient;

namespace CS.Data
{
    internal class CEDAO
    {
        private string connectionString = @"Data Source=DESKTOP-C7ALLTO;Initial Catalog=CarShowroom;Integrated Security=True";
        public List<CarExtra> FetchAll()
        {
            List<CarExtra> returnList = new List<CarExtra>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM [dbo].[carExtra]";
                SqlCommand command = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CarExtra ce= new CarExtra();
                        ce.ExtraID = reader.GetInt32(0);
                        ce.ExtraName = reader.GetString(1);
                        ce.Price = reader.GetDecimal(2);

                        returnList.Add(ce);
                    }
                }
            }

            return returnList;
        }
    }
}