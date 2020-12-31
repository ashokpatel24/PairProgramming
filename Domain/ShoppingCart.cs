using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class ShoppingCart
    {
        private readonly List<string> _productsInCart;

        public double CartTotal { get; set; }

        public ShoppingCart()
        {
            _productsInCart = new List<string>();
        }

        public List<string> AddProduct(string productType, int quantity)
        {
            if (productType == "JEANS")
            {
                var totalJeansCustomerHave = _productsInCart.Count(x => x.Contains(productType));
                totalJeansCustomerHave += quantity;

                int totalPrice = 0;

                for (int i = 1; i <= totalJeansCustomerHave; i++)
                {
                    if (i % 3 == 0)
                    {
                        //free jeans 
                        continue;
                    }

                    totalPrice += 20;
                }

                CartTotal += totalPrice;
            }

            if (productType == "TSHIRT")
            {
                CartTotal += quantity * 10;
            }


            _productsInCart.Add(productType);
            return _productsInCart;
        }

        public List<string> GetProductsInCart()
        {
            return _productsInCart;
        }

        public List<string> GetProductsInCart(string productType)
        {
            return _productsInCart;
        }
    }
}