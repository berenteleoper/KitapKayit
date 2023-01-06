using WindowsFormsApp1.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormCategory : Form
    {
        int? Id; //soru işareti konularak null değerlere de izin veriyor hem değeri olabilir hem de olmayabilir anlamına gelir (has value değerini açar)
        string filename; //resim butonuna eklenen resmin yolunu tutmak için
        
        public FormCategory()
        {
            InitializeComponent();
        }

        CategoryManager mngr =new CategoryManager(); //bu yazılarak ön yüzle arka tarafı birbirine bağlıyoruz. Yazdığımız manageri buraya getirip kullanıyoruz

        private void button4_Click(object sender, EventArgs e)
        {
            //Yeni butonu
            btnadd.Enabled = true; //her butono basıldığında ekle ve sil tuşunu aktif hali getiriyor öncesinde enabled yapmak gerekiyor
            btnremove.Enabled = true;
            //Kategori id verebilmek için 
            Id = mngr.GetAll().Count > 0 ? mngr.GetAll().Max(x => x.catid) : 0; //metodlarda parantez olmalı mutlaka get all listeyi getiriyor //kategorilerin içindeki  en büyük id id lerin max ını almak için max kullanılıyor
            if (Id >0)                                                                  //Ternary(?) operatör if else i tek satırda yapmak gibi
            {
                Id++;
            }
            else   //listede hiç bir kategori yoksa 1 den başla 
            {
                Id = 1;
            }
            txtId.Text = Id.ToString();
        }

        private void btnimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); //Dosya seçmek için bir pencere 
            ofd.ShowDialog();
            filename = ofd.FileName;
            pictureBox1.ImageLocation = filename; // oluşan resmi  burası ile görebiliyoruz 
        }

        void List()
        {
            dataGridView1.Rows.Clear();
            foreach (var item in mngr.GetAll())
            {
                dataGridView1.Rows.Add(item.catid, item.catName, Image.FromFile(item.catImage)); //Image.fromfile yazıdığında string değerinin resim haline dönüştürüyoruz.
            }
        }
        void clear()
        {
            txtId.Clear();
            txtName.Clear();
            pictureBox1.Image = null;
        }


        private void btnadd_Click(object sender, EventArgs e)
        {
            Category category = new Category()
            {
               catid = Int32.Parse(txtId.Text),
               catName = txtName.Text,
               catImage = filename
            };

            mngr.Add(category);
            List();
            clear();
           
        }
        

        
        
        private void datagridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex; //seçilen satırınindex no veriyor
            txtId.Text = dataGridView1.Rows[row].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
            pictureBox1.Image = (Image)dataGridView1.Rows[row].Cells[2].Value;
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                mngr.Remove(Int32.Parse(txtId.Text));
                List();
                clear();
            }
        }
    }
}
