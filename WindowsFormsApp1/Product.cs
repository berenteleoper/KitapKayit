using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Product
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public decimal Price { get; set; }
        public int stockQuantity { get; set; }
        public int categoryID { get; set; }
        public string productImage { get; set; }
    }
}
