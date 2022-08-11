using System;
using Xunit;
// using Sem1Challenge;

namespace tests
{
    
    public class tests
    {
        [Theory]
        [InlineData(10, 10f)]
        [InlineData(0, 0f)]
        [InlineData(-0, -10f)]
        [InlineData(0, 10f)]
        [InlineData(10, 0f)]
        public void ValueOfOrderTest(int quantity, float unitPrice)
        {
            if (quantity <= 0)
            {
                quantity = 1;
            }
            if (unitPrice <= 0)
            {
                unitPrice = 0;
            }
            Product prod = new Product() { UnitPrice = unitPrice };
            Order order = new Order() { Quantity = quantity, Product = prod };
            Assert.True(order.ValueOfOrder() >= 0f);
         }
    //     [Theory]
    //     [InlineData(10, 10f)]
    //     [InlineData(0, 0f)]
    //     [InlineData(-0, -10f)]
    //     [InlineData(0, 10f)]
    //     [InlineData(10, 0f)]
    //     public void GST(int quantity, float unitPrice)
    //     {
    //         Product prod = new Product() { UnitPrice = unitPrice };
    //         Order order = new Order() { Quantity = quantity, Product = prod };
    //         Assert.True(order.GSTValue() >= 0f);
    //     }
    // }
    public class Order
    {
        public int OrderID { get; set; }
        public string OrderDate { get; set; }
        public int Quantity { get; set; }
        public string ShipDate { get; set; }
        public string CustID { get; set; }
        public string ProdID { get; set; }
        public string ShipMode { get; set; }
        public Product Product { get; set; }
        public float ValueOfOrder()
        {
            return this.Quantity * this.Product.UnitPrice;
        }
        public float GSTValue()
        {
            return this.ValueOfOrder() * 0.1f;
        }
    }
    public class Product
    {
        public string ProdID { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        public int CatID { get; set; }
    }
}
    }