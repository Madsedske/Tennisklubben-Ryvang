using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tennisklubben_Ryvang
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Create_User(object sender, EventArgs e)
        {
            string mail = typeEmailX.Text;
            string password = typePasswordX.Text;
            string name = typeNameX.Text;
            string adress = typeAdressX.Text;
            string phone = typePhoneX.Text;
            string age = typeAgeX.Text;
            string cardNumber = typeCardNumberX.Text;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Persons"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand("Insert_Person", conn))
                {
                    // A stored procedure that finds the column shown as a string with an @, the type
                    // and sets it to the input value of the user - Customers
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = mail;
                    cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = password;
                    cmd.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = adress;
                    cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = name;
                    cmd.Parameters.AddWithValue("@PhoneNumber", SqlDbType.Int).Value = phone;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Persons_Payment"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand("Insert_Persons_Payment", conn))
                {
                    if (Convert.ToInt32(age) < 18)
                    {
                        cardNumber = "0";
                    }
                    // A stored procedure that finds the column shown as a string with an @, the type
                    // and sets it to the input value of the user - Customers
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = mail;
                    cmd.Parameters.AddWithValue("@PhoneNumber", SqlDbType.Int).Value = phone;
                    cmd.Parameters.AddWithValue("@Age", SqlDbType.Int).Value = age;
                    cmd.Parameters.AddWithValue("@CreditCard", SqlDbType.Int).Value = cardNumber;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Bruger oprettet!')</script>");
        }
    }
}