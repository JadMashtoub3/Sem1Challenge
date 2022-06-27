using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;


namespace challengeAPI
{
    public class CustomerDBHandler : DatabaseHandler
    {
 public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Customer", conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Customer()
                            {
                                CustID = reader.GetString(0),
                                FullName = reader.GetString(1),
                                SegID = reader.GetInt32(2),
                                Country = reader.GetString(3),
                                City = reader.GetString(4),
                                State = reader.GetString(5),
                                PostCode = reader.GetInt32(6),
                                Region = reader.GetString(7)

                            });
                        }
                    }
                }
                conn.Close();
            }
            if (customers.Count == 0) return null;

            return customers;
        }

    }
}
