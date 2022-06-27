using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;


namespace challengeAPI
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private OrderDBHandler dbHandler = new OrderDBHandler();

        [HttpGet]
        [Route("/orders")]
        public IEnumerable<Order> Get()
        {
            return dbHandler.GetAllOrders();
        }

         /// <summary>
        /// Create a new order
        /// </summary>
        /// <param name="custID"></param>
        /// <param name="prodID"></param>
        /// <param name="quantity"></param>
        /// <param name="shipMode"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/add-order")]
        public string CreateNewOrder(int OrderID, string CustID, string ProdID, int Quantity, string ShipMode)
        {
            return dbHandler.CreateNewOrder(OrderID, CustID, ProdID, Quantity, ShipMode);
        }
           /// <summary>
        /// Delete an order
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("/delete-order")]
        public string DeleteOrder(int OrderID)
        {
            return dbHandler.DeleteOrder(OrderID);
        }
    }
}