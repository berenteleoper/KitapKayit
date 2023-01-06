using hafta5gun1.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hafta5gun1
{
    public partial class FormCategory : Form
    {
        int? Id; //soru işareti konularak null değerlere de izin veriyor hem değeri olabilir hem de olmayabilir anlamına gelir (has value değerini açar)
        string filename; //resim butonuna eklenen resmin yolunu tutmak için
        public FormCategory()
        {
            InitializeComponent();
        }
        CategoryManager mngr =new CategoryManager(); //bu yazılarak ön yüzle arka tarafı birbirine bağlıyoruz. Yazdığımız manageri buraya getirip kullnıyoruz

        private void button4_Click(object sender, EventArgs e)
        {
            //Yeni butonu
            btnadd.Enabled = true; //her butono basıldığında ekle ve sil tuşunu aktif hali getiriyor öncesinde enabled yapmak gerekiyor
            btnremove.Enabled = true;
            //Kategori id verebilmek için 
            Id = mngr.GetAll().Count > 0 ? mngr.GetAll().Max(x => x.catid) : 1; //metodlarda parantez olmalı mutlaka get all listeyi getiriyor //kategorilerin içindeki  en büyük id id lerin max ını almak için max kullanılıyor
            if (Id >1)                                                                  //Ternary(?) operatör if else i tek satırda yapmak gibi
            {
                Id++;
            }
            else   //listede hiç bir kategori yoksa 1 den başla 
            {
                Id = 1;
            }
        }

        private void btnimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); //Dosya seçmek için bir pencere 
            ofd.ShowDialog();
            filename = ofd.FileName;
            pictureBox1.ImageLocation = filename; // oluşan resmi  burası ile görebiliyoruz 
        }
    }
}
