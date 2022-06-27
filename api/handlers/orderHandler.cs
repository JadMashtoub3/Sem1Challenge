using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;


namespace challengeAPI
{
    public class OrderDBHandler : DatabaseHandler
    {
 public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM [Order]", conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.Add(new Order()
                            {
                                OrderID = reader.GetInt32(0),
                                CustID = reader.GetString(1),
                                ProdID = reader.GetString(2),
                                OrderDate = reader.GetDateTime(3),
                                Quantity = reader.GetInt32(4),
                                ShipDate = reader.GetDateTime(5),
                                ShipMode = reader.GetString(6)
                            });
                        }
                    }
                }
                conn.Close();
            }
            if (orders.Count == 0) return null;

            return orders;
        }
 public string CreateNewOrder(int OrderID, string CustID, string ProdID, int Quantity, string ShipMode)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("ADD_ORDER", conn))
                {
                   
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pOrderID", OrderID);
                    command.Parameters.AddWithValue("@pCustID", CustID);
                    command.Parameters.AddWithValue("@pProdID", ProdID);
                    command.Parameters.AddWithValue("@pOrderDate", System.DateTime.Now);
                    command.Parameters.AddWithValue("@pQuantity", Quantity);
                    command.Parameters.AddWithValue("@pShipDate", System.DateTime.Now);
                    command.Parameters.AddWithValue("@pShipMode", ShipMode);

                     int rowsAffected = command.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected >= 1)
                    {
                        return "Added Order";
                    }
                    else
                    {
                        return "Order could not be added";
                    }
                }
            }
        }
        public string DeleteOrder(int OrderID)
        {
            
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("DELETE_ORDER", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pOrderID", OrderID);
                    int rowsAffected = command.ExecuteNonQuery();
                    conn.Close();
                     if (rowsAffected >= 1)
                    {
                        return "Deleted Order";
                    }
                    else
                    {
                        return "Order could not be Deleted";
                    }
                }
            }
        }
        public string UpdateOrder(Order newOrder)
        {
            int rowsAffected = 0;

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand($"UPDATE [Order] SET CustID = '{newOrder.CustID}', ProdID = '{newOrder.ProdID}', OrderDate = '{newOrder.OrderDate}', Quantity = {newOrder.Quantity}, ShipDate = '{newOrder.ShipDate}', ShipMode = '{newOrder.ShipMode}' WHERE OrderID = {newOrder.OrderID}", conn))
                {
                    rowsAffected = command.ExecuteNonQuery();
                }

                conn.Close();
            }
            return rowsAffected.ToString();
        }
    }
}