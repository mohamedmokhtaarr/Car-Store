using CarService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarService
{
    public partial class Form2 : Form
    {
        private object txtSensorType;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null&& textBox2.Text!=null && textBox3.Text != null && textBox4.Text != null && textBox5.Text != null && textBox6.Text != null ) {

                

                var DB = new DB();
                var valid = DB.IsValid(textBox3.Text);
                if (valid)
                {
                    string sqlQuery = "INSERT INTO Customers (first_name, last_name, email,password, phone, city)VALUES(" + "'" + textBox1.Text + "'" + ',' + "'" + textBox2.Text + "'" + ',' + "'" + textBox3.Text + "'" + ',' + "'" + textBox4.Text + "'" + ',' + "'" + textBox5.Text + "'" + ',' + "'" + textBox6.Text + "'" + ")";


                    if (DB.Insert(sqlQuery))
                        MessageBox.Show("User Added");

                }
                else
                {
                    MessageBox.Show("Invalid E-mail");
                }
            }
          else
            {
                MessageBox.Show("You Must Complete Your Informations");
            }  
          
        }
    }
}
