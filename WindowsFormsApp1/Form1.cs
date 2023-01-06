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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCategory formCategory = new FormCategory();
            formCategory.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormProduct formProduct = new FormProduct();
            formProduct.Show();
        }

        private void button1_KeyDown(object sender, KeyEventArgs e) //design da bir kere tıklayıp properties den eventları açıp keydown seçeneğine iki kere tıklarsak burası gelir.
        {
            if (e.KeyCode==Keys.Enter) //Keycode enter tuşuna basıldığında da aynı işlemi yapması için girilir
            {
                button1.PerformClick();
            }
        }

        private void button2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                button2.PerformClick();
            }
        }
    }
}
