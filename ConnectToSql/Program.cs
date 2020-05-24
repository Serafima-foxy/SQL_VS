using System;
using System.Data.SqlClient;

namespace ConnectToSql
{
    class Program
    {
        static void Main(string[] args)
        {
            //set the connection string
            string connString = @"Server =DESKTOP-8LTCMGG\SQLEXPRESS; 
                                Database = Users_Orders; 
                                Trusted_Connection = True;";

            //variables to store the query results
            int persID, persAge, ordSumm;
            string persFirstName, persLastName, persCity;

            try
            {
                //sql connection object
                using (SqlConnection conn = new SqlConnection(connString))
                {

                    //retrieve the SQL Server instance version
                    string query = @"SELECT p.ID,p.FirstName,p.LastName, p.Age, p.City, o.OrderSum
                                     FROM Persons p
                                     INNER JOIN Orders o on p.ID=o.ID;
                                     ";

                    //define the SqlCommand object
                    SqlCommand cmd = new SqlCommand(query, conn);

                    //open connection
                    conn.Open();

                    //execute the SQLCommand
                    SqlDataReader dr = cmd.ExecuteReader();

                    Console.WriteLine(Environment.NewLine + "Retrieving data from database..." + Environment.NewLine);
                    Console.WriteLine("SQL Query: \nSELECT Persons.ID, FirstName, LastName, Age, City, OrderSum\n" +
                                                    "FROM Persons\n" +
                                                    "INNER JOIN Orders\n" +
                                                    "ON Persons.ID=Orders.ID\n");
                    Console.WriteLine("Retrieved records:");

                    //check if there are records
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            persID = dr.GetInt32(0);
                            persFirstName = dr.GetString(1);
                            persLastName = dr.GetString(2);
                            persAge = dr.GetInt32(3);
                            persCity = dr.GetString(4);
                            ordSumm = dr.GetInt32(5);
                            //display retrieved record
                            Console.WriteLine("{0,3}|{1,8}|{2,12}|{3,3}|{4,12}|{5,6}|",
                                persID.ToString(), persFirstName,
                                persLastName, persAge.ToString(),
                                persCity, ordSumm.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }

                    //close data reader
                    dr.Close();

                    //close connection
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}