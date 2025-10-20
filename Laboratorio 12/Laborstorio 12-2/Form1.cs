using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laborstorio_12_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textNota1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Nota1_Click(object sender, EventArgs e)
        {

        }

        private void Nota2_Click(object sender, EventArgs e)
        {

        }

        private void Nota3_Click(object sender, EventArgs e)
        {

        }

        private void btnPromedio_Click(object sender, EventArgs e)
        {
            try
            {
                double Nota1 = Convert.ToDouble(textNota1.Text);
                double Nota2 = Convert.ToDouble(textNota2.Text);
                double Nota3 = Convert.ToDouble(textNota3.Text);

                //Promedio 
                double Promedio = (Nota1 + Nota2 + Nota3) / 3;
                //Mostra el promedio de mis tres notas
                textPromedio.Text = Promedio.ToString();

            }
            catch 
            {
                MessageBox.Show("Error: Ingrese números válidos");

            }

        }
        //boton de reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            textNota1.Clear();
            textNota2.Clear();
            textNota3.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            
                this.Close();
            
        }
    }
}
