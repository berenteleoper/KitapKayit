using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Managers;

namespace WindowsFormsApp1
{
    public partial class FormProduct : Form
    {
        int id;
        public FormProduct()
        {
            InitializeComponent();
        }
        ProductManager mngr =new ProductManager();
        

        private void btnnew_Click(object sender, EventArgs e)
        {
            id = mngr.GetAll().Count > 0 ? mngr.GetAll().Max(x=>x.productId) : 0;
            if (id > 0)
                id++;
            else
                id = 1;
            btnadd.Enabled = true;
            btnremove.Enabled = true;
            txtproductid.Text=id.ToString();

        }

        private void btnimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog(); //burdan sonra özel filtreler eklenebilir seçilecek doyanın uzantısı vs. ofd.Filter ile ilerler
            pictureBox2.ImageLocation = ofd.FileName;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch; //resmi stretch yapmak için kullanılır
        }

        void Clear()
        {
            txtprice.Clear();
            txtproductid.Clear();
            txtproductName.Clear();
            txtquantity.Clear();
            cmbcategory.Text = "";
            pictureBox2.Image = null;

        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            // formun temel kısmına yani arkaplana dokunup propertiesten şimşek kısmıda load a çift tıklayınca geliyor
            //form ilk açıldığında tetiklenmesi için
            //combox a tüm verileri doldurmak için 
            cmbcategory.DataSource = CategoryManager.GetAllCategory(); //
            cmbcategory.DisplayMember = "catName"; //combobox ta görünecek alan için kategori adı
            cmbcategory.ValueMember = "catid"; //combobox ta Id değeri için kategori no //catefory calssındaki isimlendirmlerden geliyor camid ve catnaem

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            Product prd = new Product()
            {
                productId = Int32.Parse(txtproductid.Text),
                productName = txtproductName.Text,
                Price = decimal.Parse(txtprice.Text),
                stockQuantity = Int32.Parse(txtquantity.Text),
                productImage = pictureBox2.ImageLocation,
                categoryID = (int)cmbcategory.SelectedValue, // başına int yazarak hatayı engelliyoruz 02.10.2022 deki derste detayı anlatılacak

            };
            mngr.Add(prd);
            List();
            Clear();

        }
        void List()
        {
            dataGridView1.Rows.Clear(); // satırları temzileyip baştan yazı yazılmasına olanak sağlar
            foreach (var item in mngr.GetAll())
            {
                dataGridView1.Rows.Add(item.productId, item.productName, item.categoryID, item.Price, item.stockQuantity, Image.FromFile(item.productImage));
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //griedview e tıklayıp propertiesteki şimşekten cell click e iki kere tıklayınca buraya geliyoruz
            int row=e.RowIndex;
            txtproductid.Text = dataGridView1.Rows[row].Cells[0].Value.ToString();
            txtproductName.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
            cmbcategory.SelectedValue=dataGridView1.Rows[row].Cells[2].Value.ToString(); //combobox da ikinci formda ilk forma girişi yaptığımız kategorinin gelmesi için yazılır.
            txtprice.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();
            txtquantity.Text = dataGridView1.Rows[row].Cells[4].Value.ToString();
            pictureBox2.Image = (Image)dataGridView1.Rows[row].Cells[5].Value;

        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtproductid.Text))
            {
                DialogResult OnayMesaji = MessageBox.Show("Kaydı silmek istediğinizden emin misiniz?","Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (OnayMesaji==DialogResult.Yes)
                {
                    mngr.Remove(Int32.Parse(txtproductid.Text));
                    List();
                    Clear();

                }
               
            }
        }
    }
}
