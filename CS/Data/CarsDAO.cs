using CS.Models;
using Microsoft.Data.SqlClient;

namespace CS.Data
{
    internal class CarsDAO
    {
        private string connectionString = @"Data Source=DESKTOP-C7ALLTO;Initial Catalog=CarShowroom;Integrated Security=True";
        public List<Cars> FetchAll()
        {
            List<Cars> returnList = new List<Cars>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM [dbo].[cars]";
                SqlCommand command = new SqlCommand(sqlQuery, con); 
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Cars cars = new Cars();
                        cars.CarsID = reader.GetInt32(0);
                        cars.Model = reader.GetString(1);
                        cars.HP = reader.GetInt32(2);
                        cars.TypeFuel = reader.GetString(5);  
                        cars.NumberOfSeats = reader.GetInt32(8);    
                        cars.YearOfManufacture = reader.GetDateTime(14);
                        cars.TypeCompartment = reader.GetString(16);
                        cars.OriginalPrice = reader.GetDecimal(17);   

                        returnList.Add(cars);
                    }
                }
            }

                return returnList;
        }

        internal List<Cars> SearchForName(string searchPhrase)
        {
            List<Cars> returnList = new List<Cars>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM [dbo].[cars] WHERE Model LIKE @SearchForModel";
                
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.Add("@SearchForModel", System.Data.SqlDbType.VarChar).Value = "%" 
                    + searchPhrase + "%";
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Cars cars = new Cars();
                        cars.CarsID = reader.GetInt32(0);
                        cars.Model = reader.GetString(1);
                        cars.HP = reader.GetInt32(2);
                        cars.MaxSpeed = reader.GetInt32(3);
                        cars.MinSpeed = reader.GetInt32(4);
                        cars.TypeFuel = reader.GetString(5);
                        cars.Capacity = reader.GetInt32(6);
                        cars.TypeEngine = reader.GetString(7);
                        cars.NumberOfSeats = reader.GetInt32(8);
                        cars.Height = reader.GetInt32(9);
                        cars.Weight = reader.GetInt32(10);
                        cars.AverageExpenseTOWN = reader.GetDecimal(11);
                        cars.AverageExpenseONROAD = reader.GetDecimal(12);
                        cars.AverageExpenseCOMBINED = reader.GetDecimal(13);
                        cars.YearOfManufacture = reader.GetDateTime(14);
                        cars.Doors = reader.GetInt32(15);
                        cars.TypeCompartment = reader.GetString(16);
                        cars.OriginalPrice = reader.GetDecimal(17);

                        returnList.Add(cars);
                    }
                }
            }
            return returnList;
        }

        internal int Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "DELETE FROM [dbo].[cars] WHERE CarsID = @CarsID";
                

                SqlCommand command = new SqlCommand(sqlQuery, con);

                command.Parameters.Add("@CarsID", System.Data.SqlDbType.Int, 1000).Value = id;
                

                con.Open();
                int deletedID = command.ExecuteNonQuery();
                return deletedID;
            }
        }

        public Cars FetchOne(int id)
        {
            

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM [dbo].[cars] WHERE CarsID = @id";
                SqlCommand command = new SqlCommand(sqlQuery, con);
                
                command.Parameters.Add("@id",System.Data.SqlDbType.Int).Value = id;
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                Cars cars = new Cars();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        cars.CarsID = reader.GetInt32(0);
                        cars.Model = reader.GetString(1);
                        cars.HP = reader.GetInt32(2);
                        cars.MaxSpeed = reader.GetInt32(3);
                        cars.MinSpeed = reader.GetInt32(4);
                        cars.TypeFuel = reader.GetString(5);
                        cars.Capacity = reader.GetInt32(6);
                        cars.TypeEngine = reader.GetString(7);
                        cars.NumberOfSeats = reader.GetInt32(8);
                        cars.Height = reader.GetInt32(9);
                        cars.Weight = reader.GetInt32(10);
                        cars.AverageExpenseTOWN = reader.GetDecimal(11);
                        cars.AverageExpenseONROAD = reader.GetDecimal(12);
                        cars.AverageExpenseCOMBINED = reader.GetDecimal(13);
                        cars.YearOfManufacture = reader.GetDateTime(14);
                        cars.Doors = reader.GetInt32(15);
                        cars.TypeCompartment = reader.GetString(16);
                        cars.OriginalPrice = reader.GetDecimal(17);
                        cars.PictureURL = reader.GetString(18);
                        
                    }
                }
                return cars;
            }

            
        }

        public int CreateOrUpdate(Cars newCars)
        {


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "";
                if(newCars.CarsID <= 0)
                {
                    sqlQuery = "INSERT INTO [dbo].[cars](Model,HP,MaxSpeed,MinSpeed,TypeFuel,Capacity" +
                    ",TypeEngine,NumberOfSeats,Height,Weight,AverageExpenseTOWN,AverageExpenseONROAD," +
                    "AverageExpenseCOMBINED,YearOfManufacture,Doors,TypeCompartment,OriginalPrice,PictureURL) Values(@Model,@HP,@MaxSpeed,@MinSpeed" +
                    ",@TypeFuel,@Capacity,@TypeEngine,@NumberOfSeats,@Height,@Weight," +
                    "@AverageExpenseTOWN,@AverageExpenseONROAD,@AverageExpenseCOMBINED," +
                    "@YearOfManufacture,@Doors,@TypeCompartment,@OriginalPrice,@PictureURL)";
                }
                else
                {
                    sqlQuery = "UPDATE [dbo].[cars] SET Model = @Model, HP=@HP, MaxSpeed = @MaxSpeed," +
                        "MinSpeed = @MinSpeed, TypeFuel = @TypeFuel,Capacity=@Capacity,TypeEngine = " +
                        "@TypeEngine,NumberOfSeats = @NumberOfSeats,Height = @Height,Weight = @Weight," +
                        " AverageExpenseTOWN = @AverageExpenseTOWN,AverageExpenseONROAD = @AverageExpenseONROAD," +
                        "AverageExpenseCOMBINED = @AverageExpenseCOMBINED,YearOfManufacture = @YearOfManufacture," +
                        "Doors = @Doors,TypeCompartment = @TypeCompartment,OriginalPrice=@OriginalPrice, PictureURL= @PictureURL " +
                        "WHERE CarsID = @CarsID";
                }
                    
                SqlCommand command = new SqlCommand(sqlQuery, con);

                command.Parameters.Add("@CarsID", System.Data.SqlDbType.Int, 1000).Value = newCars.CarsID;
                command.Parameters.Add("@Model", System.Data.SqlDbType.VarChar,1000).Value = newCars.Model;
                command.Parameters.Add("@HP", System.Data.SqlDbType.Int, 1000).Value = newCars.HP;
                command.Parameters.Add("@MaxSpeed", System.Data.SqlDbType.Int, 1000).Value = newCars.MaxSpeed;
                command.Parameters.Add("@MinSpeed", System.Data.SqlDbType.Int, 1000).Value = newCars.MinSpeed;
                command.Parameters.Add("@TypeFuel", System.Data.SqlDbType.VarChar, 1000).Value = newCars.TypeFuel;
                command.Parameters.Add("@Capacity", System.Data.SqlDbType.Int, 1000).Value = newCars.Capacity;
                command.Parameters.Add("@TypeEngine", System.Data.SqlDbType.VarChar, 1000).Value = newCars.TypeEngine;
                command.Parameters.Add("@NumberOfSeats", System.Data.SqlDbType.Int, 1000).Value = newCars.NumberOfSeats;
                command.Parameters.Add("@Height", System.Data.SqlDbType.Int, 1000).Value = newCars.Height;
                command.Parameters.Add("@Weight", System.Data.SqlDbType.Int, 1000).Value = newCars.Weight;
                command.Parameters.Add("@AverageExpenseTOWN", System.Data.SqlDbType.Decimal, 1000).Value = newCars.AverageExpenseTOWN;
                command.Parameters.Add("@AverageExpenseONROAD", System.Data.SqlDbType.Decimal, 1000).Value = newCars.AverageExpenseONROAD;
                command.Parameters.Add("@AverageExpenseCOMBINED", System.Data.SqlDbType.Decimal, 1000).Value = newCars.AverageExpenseCOMBINED;
                command.Parameters.Add("@YearOfManufacture", System.Data.SqlDbType.Date, 1000).Value = newCars.YearOfManufacture;
                command.Parameters.Add("@Doors", System.Data.SqlDbType.Int, 1000).Value = newCars.Doors;
                command.Parameters.Add("@TypeCompartment", System.Data.SqlDbType.VarChar, 1000).Value = newCars.TypeCompartment;
                command.Parameters.Add("@OriginalPrice", System.Data.SqlDbType.Decimal, 1000).Value = newCars.OriginalPrice;
                command.Parameters.Add("@PictureURL", System.Data.SqlDbType.VarChar, 1000).Value = newCars.PictureURL;
                con.Open();
                int newID = command.ExecuteNonQuery();
                return newID;
                }
                
            }

        }
}