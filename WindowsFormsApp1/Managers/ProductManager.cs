using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Managers
{
    internal class ProductManager : IManager<Product>
    {
        List<Product>products=new List<Product>();
        public void Add(Product model)
        {
            if (products.Contains(model))
            {
                Product degisecekProduct = Get(model.productId); //değiştireceğimiz kaydı bulmak için yazılır.
                degisecekProduct.productName = model.productName;
                degisecekProduct.productImage = model.productImage;
                degisecekProduct.Price=model.Price;
                degisecekProduct.stockQuantity=model.stockQuantity;
                degisecekProduct.categoryID=model.categoryID;
            }
            else
            {
                products.Add(model);
            }
        }

        public Product Get(int id)
        {
            return products.FirstOrDefault(x => x.productId == id);
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public bool Remove(int id)
        {
           return products.Remove(Get(id));
        }
    }
}
