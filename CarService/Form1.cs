using CarService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string Query = "SELECT * FROM Customers WHERE email = '" + textBox1.Text + "' AND PASSWORD = '" + textBox2.Text + "'";
            var db = new DB();
           var isfound= db.isFound(Query);

            if (isfound)
            {
                var home = new Form3();
                home.Show();
            }
            else
            {
                MessageBox.Show("Not Found");
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var signUp = new Form2();
            signUp.Show();
        }
    }
}
