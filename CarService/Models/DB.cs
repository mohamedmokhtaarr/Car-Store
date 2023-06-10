using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models
{
    public class DB
    {
        public SqlDataAdapter adpt { get; set; }
        public DataTable dt { get; set; }
        public SqlConnection connection { get; set; }
        public SqlCommand sc { get; set; }
        public DB()
        {
            sc = new SqlCommand();  
            connection = new SqlConnection(@"Data Source=.;Initial Catalog=Car_services;Integrated Security=True");
            adpt = new SqlDataAdapter();
            dt = new DataTable();   
             
        }
       public bool Insert (string sqlQuery)
        {
            try
            {
                connection.Open();
                sc.CommandText = sqlQuery;
                sc.Connection = connection;
                sc.ExecuteNonQuery();
                connection.Close();
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }
        public bool get (string sqlQuery) {

            try
            {
                connection.Open();
                sc.CommandText = sqlQuery;
                sc.Connection = connection;
                adpt.SelectCommand = sc;
                adpt.Fill(dt);
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool isFound(string sqlQuery)
        {   
            get(sqlQuery);
            if (dt.Rows.Count == 1)
            {
                return true;    
            }
            return false;
        }

        public bool IsValid(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }

    }
}
