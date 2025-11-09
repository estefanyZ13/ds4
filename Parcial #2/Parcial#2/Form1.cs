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

namespace Parcial_2
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=(local);Database=RegistrosIMC;TrustServerCertificate=true;Integrated Security=SSPI;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        // BOTÓN 1
        private void button1_Click(object sender, EventArgs e)
        {
            // Lee el peso del textBox1
            double peso = Convert.ToDouble(textBox1.Text);

            // Lee la altura del textBox2
            double altura = Convert.ToDouble(textBox2.Text);

            // Si está en centímetros, convierte a metros
            if (altura > 3)
                altura = altura / 100;

            // Calcula el IMC
            double imc = peso / (altura * altura);

            if (imc < 18.5)
                textBox3.Text = "Bajo peso";
            else if (imc < 25)
                textBox3.Text = "Peso normal";
            else if (imc < 30)
                textBox3.Text = "Sobrepeso";
            else
                textBox3.Text = "Obesidad";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        // BOTÓN 2
        private void button2_Click(object sender, EventArgs e)
        {
            // Lee la altura
            double altura = Convert.ToDouble(textBox2.Text);

            // Convierte a metros si está en centímetros
            if (altura > 3)
                altura = altura / 100;

            // Convierte metros a pies
            double pies = altura * 3.28084;

            // Muestra el resultado con 2 decimales (F2 = 2 decimales)
            textBox4.Text = pies.ToString("F2") + " pies";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        // BOTÓN 3: Mostrar registros
        private void button3_Click(object sender, EventArgs e)
        {
            
            SqlConnection conexion = new SqlConnection(connectionString);
            conexion.Open();

            // Limpia el listBox
            listBox1.Items.Clear();

            // Busca los registros
            string query = "SELECT * FROM Registros ORDER BY Id DESC";
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataReader reader = cmd.ExecuteReader();

            
            while (reader.Read())
            {
               
                string registro = "Peso: " + reader["Peso"] + " kg | " +
                                "Altura: " + reader["Altura"] + " m | " +
                                "IMC: " + reader["IMC"] + " | " +
                                reader["Clasificacion"];

                listBox1.Items.Add(registro);
            }

            reader.Close();
            conexion.Close();
        }

        // BOTÓN 4
        private void button4_Click(object sender, EventArgs e)
        {
            // Lee los datos
            double peso = Convert.ToDouble(textBox1.Text);
            double altura = Convert.ToDouble(textBox2.Text);

            if (altura > 3)
                altura = altura / 100;

            double imc = peso / (altura * altura);
            string clasificacion = textBox3.Text;

            SqlConnection conexion = new SqlConnection(connectionString);
            conexion.Open();

            string query = @"INSERT INTO Registros (Peso, Altura, IMC, Clasificacion, Fecha) 
                            VALUES (@peso, @altura, @imc, @clasificacion, @fecha)";

            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@peso", peso);
            cmd.Parameters.AddWithValue("@altura", altura);
            cmd.Parameters.AddWithValue("@imc", imc);
            cmd.Parameters.AddWithValue("@clasificacion", clasificacion);
            cmd.Parameters.AddWithValue("@fecha", DateTime.Now);

            cmd.ExecuteNonQuery();
            conexion.Close();

            MessageBox.Show("Registro guardado");

            // Actualiza el listBox
            conexion.Open();
            listBox1.Items.Clear();

            string querySelect = "SELECT * FROM Registros ORDER BY Id DESC";
            SqlCommand cmdSelect = new SqlCommand(querySelect, conexion);
            SqlDataReader reader = cmdSelect.ExecuteReader();

            while (reader.Read())
            {
                string registro = "Peso: " + reader["Peso"] + " kg | " +
                                "Altura: " + reader["Altura"] + " m | " +
                                "IMC: " + reader["IMC"] + " | " +
                                reader["Clasificacion"];

                listBox1.Items.Add(registro);
            }

            reader.Close();
            conexion.Close();
        }
    }
}