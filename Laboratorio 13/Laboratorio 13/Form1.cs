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
using System.Data;
using System.Data.SqlClient;


namespace Laboratorio_13
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=(local);Database=Northwind;TrustServerCertificate=true;Integrated Security=SSPI;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btn_conexion_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(connectionString);
            conexion.Open();
            MessageBox.Show("Se abrió la conexión con el servidor SQL Server y se seleccionó la base de datos");

            // Limpiar el listBox
            listBox1.Items.Clear();

            // Listar productos
            string query = "SELECT ProductName FROM [dbo].[Products]";
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                listBox1.Items.Add(reader["ProductName"].ToString());
            }

            conexion.Close();
            MessageBox.Show("Se cerró la conexión.");
        }
    }
}




