using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Student_Details
{
    public partial class FormStudent : Form
    {
        public FormStudent()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int someIdvalue = 1;
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-BLU06J6;Initial Catalog=\"Student Details\";Integrated Security=True;TrustServerCertificate=True");

            SqlCommand cmd = new SqlCommand("INSERT INTO  Student (Name,Grade,Address,Id) VALUES (@Name,@Grade,@Address,@Id)",con);
            cmd.Parameters.AddWithValue("@Id", someIdvalue);
            cmd.Parameters.AddWithValue("@Name",txtName.Text);
            cmd.Parameters.AddWithValue("@Grade", txtGrade.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            Console.WriteLine($"{i}row(S)insterted.");
            con.Close();

            if (i > 0)
            {
                MessageBox.Show("Data has been sucessfully saved!","Sucess",MessageBoxButtons.OK,MessageBoxIcon.Information );
            }
            else
            {
                MessageBox.Show("Data has not completed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtGrade.Clear();
            txtAddress.Clear();
            txtName.Focus();
        }
    }
}
