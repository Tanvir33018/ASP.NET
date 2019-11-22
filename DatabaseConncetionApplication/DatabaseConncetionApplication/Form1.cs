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

namespace DatabaseConncetionApplication
{
    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            StudentInfo Students = new StudentInfo();
            Students.name = NameTextBox.Text;
            Students.department = DepartmentTextBox.Text;
            Students.ID = Convert.ToInt32(IdTextBox.Text);

            string connectionString = @"Data Source=DESKTOP-92VTDCV\SQLEXPRESS;Initial Catalog=UniversityManagementSystem;     
                                                            Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(connectionString);

            sqlCon.Open();
            string query = "INSERT into StudentInfo ([Name], [Department],[ID]) VALUES ('" + Students.name + "','" + Students.department + "','" + Students.ID + "')";
            SqlCommand command = new SqlCommand(query, sqlCon);
            int row = 0;
            row = command.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("1 row inserted!");
            }
            sqlCon.Close();
        }
    }
}
