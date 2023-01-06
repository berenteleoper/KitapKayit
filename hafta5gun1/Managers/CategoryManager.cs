using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace hafta5gun1.Managers
{
    internal class CategoryManager : IManager<Category>
    {
        List<Category>categories = new List<Category>(); // bütün categorilari içinde tutmak için
        public void Add(Category model)
        {
            //kaydın olup olmadığı sorgulanacak kategori içerisinde var mı yok mu diye bakılacak
            if (categories.Contains(model)) //true gönderirse update
            { 
                // update
                Category degisecekCategory= Get(model.catid); //get ile category içerisinde hali hazırda kaydın olup olmadığı kontrol ediliyor. (find,firs or default gibi)
                degisecekCategory.catName = model.catName;
                degisecekCategory.catImage = model.catImage;

            }
            else
            {
                // add
                categories.Add(model);
            }
            
            
        }

        public Category Get(int id)
        {
            return categories.FirstOrDefault(x => x.catid == id); //sadece category gitmesi yeterlidir. o sebeple first or default yeterli oluyor.
        }

        public List<Category> GetAll()
        {
            return categories;
        }

        public bool Remove(int id)
        {
            return categories.Remove(Get(id)); //listeden bulup getirip siliyor
           // categories.RemoveAll(x => x.catid == id); //direkt bulup siliyor ama biz bool değer istediğimiz için bunu kullanmıyoruz.
        }
    }
}
