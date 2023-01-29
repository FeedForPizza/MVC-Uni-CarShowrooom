using CS.Models;
using Microsoft.Data.SqlClient;

namespace CS.Data
{
    internal class OrderDAO
    {
        private string connectionString = @"Data Source=DESKTOP-C7ALLTO;Initial Catalog=CarShowroom;Integrated Security=True";

        public List<Orders> FetchAll()
        {
            List<Orders> returnList = new List<Orders>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM [dbo].[orders]";
                SqlCommand command = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Orders orders = new Orders();
                        orders.OrderID = reader.GetInt32(0);

                        orders.Extra = reader.GetString(1);
                        orders.OriginalPrice = reader.GetDecimal(2);
                        orders.SumOfOrder = reader.GetDecimal(3);
                        orders.Quantity = reader.GetInt32(4);
                        orders.ClientFirstName = reader.GetString(5);
                        orders.ClientLastName = reader.GetString(6);
                        orders.ClientMiddleName = reader.GetString(7);
                        orders.Phone = reader.GetString(8);
                        orders.Address = reader.GetString(9);

                        returnList.Add(orders);
                    }
                }
            }

            return returnList;
        }
        public Orders FetchOne(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM [dbo].[orders] WHERE OrderID = @OrderID";
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.Add("@OrderID", System.Data.SqlDbType.Int).Value = id;
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                Orders orders = new Orders();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        
                        orders.OrderID = reader.GetInt32(0);
                        
                        orders.Extra = reader.GetString(1);
                        
                        orders.OriginalPrice = reader.GetDecimal(2);
                        orders.SumOfOrder = reader.GetDecimal(3);
                        orders.Quantity = reader.GetInt32(4);
                        orders.ClientFirstName = reader.GetString(5);
                        orders.ClientLastName = reader.GetString(6);
                        orders.ClientMiddleName = reader.GetString(7);
                        orders.Phone = reader.GetString(8);
                        orders.Address = reader.GetString(9);

                    }
                }
                return orders;
            }
        }

        internal int Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "DELETE FROM [dbo].[orders] WHERE OrderID = @OrderID";


                SqlCommand command = new SqlCommand(sqlQuery, con);

                command.Parameters.Add("@OrderID", System.Data.SqlDbType.Int, 1000).Value = id;


                con.Open();
                int deletedID = command.ExecuteNonQuery();
                return deletedID;
            }
        }

        public int Create(Orders orders)
        {


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "INSERT INTO [dbo].[orders](Extra," +
                    "Quantity,ClientFirstName,ClientMiddleName,ClientLastName,Phone,Address) Values(@Extra," +
                    "" +
                    "@Quantity,@ClientFirstName,@ClientMiddleName,@ClientLastName,@Phone,@Address)";

                SqlCommand command = new SqlCommand(sqlQuery, con);
                
                
                
                command.Parameters.Add("@Extra", System.Data.SqlDbType.VarChar, 1000).Value = orders.Extra;
                command.Parameters.Add("@Quantity", System.Data.SqlDbType.Int, 1000).Value = orders.Quantity;
                command.Parameters.Add("@ClientFirstName", System.Data.SqlDbType.VarChar, 1000).Value = orders.ClientFirstName;
                command.Parameters.Add("@ClientMiddleName", System.Data.SqlDbType.VarChar, 1000).Value = orders.ClientMiddleName;
                command.Parameters.Add("@ClientLastName", System.Data.SqlDbType.VarChar, 1000).Value = orders.ClientLastName;
                command.Parameters.Add("@Phone", System.Data.SqlDbType.VarChar, 1000).Value = orders.Phone;
                command.Parameters.Add("@Address", System.Data.SqlDbType.VarChar, 1000).Value = orders.Address;
                



                con.Open();
                int newID = command.ExecuteNonQuery();
                return newID;
            }

        }
        public int Edit(Orders orders)
        {


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "UPDATE [dbo].[orders] SET Extra = @Extra," +
                    "" +
                    "Quantity = @Quantity, ClientFirstName = @ClientFirstName" +
                    ",ClientMiddleName = @ClientMiddleName,ClientLastName = @ClientLastName," +
                    "Phone = @Phone,Address = @Address WHERE OrderID  = @OrderID";


                SqlCommand command = new SqlCommand(sqlQuery, con);
                
                command.Parameters.Add("@Extra", System.Data.SqlDbType.VarChar, 1000).Value = orders.Extra;
                
                command.Parameters.Add("@OriginalPrice", System.Data.SqlDbType.Decimal, 1000).Value = orders.OriginalPrice;
                command.Parameters.Add("@SumOfOrder", System.Data.SqlDbType.Decimal, 1000).Value = orders.SumOfOrder;
                command.Parameters.Add("@Quantity", System.Data.SqlDbType.Int, 1000).Value = orders.Quantity;
                command.Parameters.Add("@ClientFirstName", System.Data.SqlDbType.VarChar, 1000).Value = orders.ClientFirstName;
                command.Parameters.Add("@ClientMiddleName", System.Data.SqlDbType.VarChar, 1000).Value = orders.ClientMiddleName;
                command.Parameters.Add("@ClientLastName", System.Data.SqlDbType.VarChar, 1000).Value = orders.ClientLastName;
                command.Parameters.Add("@Phone", System.Data.SqlDbType.VarChar, 1000).Value = orders.Phone;
                command.Parameters.Add("@Address", System.Data.SqlDbType.VarChar, 1000).Value = orders.Address;
                


                con.Open();
                int newID = command.ExecuteNonQuery();
                return newID;
            }

        }
    }
}