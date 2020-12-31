using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CartModel
    {
        public string ProductName { get; set; }

        public string ProductQuantity { get; set; }

        public double TotalPrice { get; set; }
    }
}
