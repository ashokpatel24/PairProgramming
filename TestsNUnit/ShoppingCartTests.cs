using Domain;
using NUnit.Framework;
using System.Linq;

namespace TestsNUnit
{
    public class ShoppingCartTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("productA", 1)]
        public void Add_Product_To_Shopping_Cart(string productName, int expectedProductInCart)
        {
            var shoppingCart = new ShoppingCart();

            var productList = shoppingCart.AddProduct(productName, 5);
            Assert.AreEqual(productList.Count(), expectedProductInCart);
        }

        [TestCase("jeans", 2)]
        public void Add_ProductMultipleProduct_To_Shopping_Cart(string productType, int quantity)
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddProduct("productA", quantity);
            shoppingCart.AddProduct("productB", quantity);

            var productList = shoppingCart.GetProductsInCart();

            Assert.AreEqual(productList.Count(), 2);
        }

        [TestCase("JEANS", 2)]
        public void Add_Jeans_ToCart(string productType, int quantity)
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddProduct(productType, quantity);

            var products = shoppingCart.GetProductsInCart();

            Assert.AreEqual(40, shoppingCart.CartTotal);
        }

        [TestCase("JEANS", 2, 40)]
        [TestCase("TSHIRT", 2, 20)]
        public void Add_Products_To_Cart_Should_Return_Correct_Total(string productType, int quantity, double expectedCartTotal)
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddProduct(productType, quantity);

            var products = shoppingCart.GetProductsInCart();

            Assert.AreEqual(expectedCartTotal, shoppingCart.CartTotal);
        }

        [TestCase("JEANS", 3, 40)]
        [TestCase("JEANS", 6, 80)]
        [TestCase("JEANS", 10, 140)]
        public void Add_Three_Jeans_Should_Give_Price_For_Two(string productType, int quantity, double expectedCartTotal)
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddProduct(productType, quantity);

            var products = shoppingCart.GetProductsInCart();

            Assert.AreEqual(expectedCartTotal, shoppingCart.CartTotal);
        }

        [Test]
        public void Add_Three_Product_Should_Discount_For_Price_Of_Two()
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddProduct("JEANS", 2);
            shoppingCart.AddProduct("JEANS", 1);

            var jeansTotal = shoppingCart.GetProductsInCart("JEANS");


            Assert.AreEqual(40, shoppingCart.CartTotal);
        }
    }
}