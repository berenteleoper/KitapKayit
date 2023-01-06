using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hafta5gun1.Managers
{
    internal interface IManager<T> where T : class //Interfacein referans olduğu 
    {
        void Add(T model); // T yazarak category class ını ve diğer classları tek bir interface de çalıştırılabilir. Yukarıda <> işareti ile başlayan satır yazılması gerekir.
        bool Remove(int id);
        T Get(int id);   //id ye göre bulmak içi iki class da da çalışması için sadece T yazarak tek interface de işi çözebiliriz.(Geriye de döndürmesi gerektiği için void yazılmaz.
        List<T> GetAll(); // <> işareti arasında listesi yapılacak elemanlar girilir.
    }
}
