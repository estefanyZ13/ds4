using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_12_3
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

        private void textLadoA_TextChanged(object sender, EventArgs e)
        {

        }
        private void ladoA_Click(object sender, EventArgs e)
        {

        }
        private void textSemiperimetro_TextChanged(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelSemiperimetro_Click(object sender, EventArgs e)
        {

        }

        private void labelArea_Click(object sender, EventArgs e)
        {

        }

        private void textAreaTriangulo_TextChanged(object sender, EventArgs e)
        {

        }

        // Calculo del semiperimetro de un triangulo
        private void btnSemiperimetro_Click(object sender, EventArgs e)
        {
            try
            {
                double LadoA = Convert.ToDouble(textLadoA.Text);
                double LadoB = Convert.ToDouble(textLadoB.Text);
                double LadoC = Convert.ToDouble(textLadoC.Text);

                // Calculo del Semiperimetro
                double Semiperimetro = (LadoA + LadoB + LadoC) / 2;

                //MOstrar resultados 
                // EL TEXTBOX              // LABEL
                textCalcular.Text= Semiperimetro.ToString();
              

            }
            catch
            {
                MessageBox.Show("Error: Ingrese números válidos");
            }
        }
        // Calculo del Area de un triangulo
        private void btnArea_Click(object sender, EventArgs e)
        {
            try
            {
                double LadoA = Convert.ToDouble(textLadoA.Text);
                double LadoB = Convert.ToDouble(textLadoB.Text);
                double LadoC = Convert.ToDouble(textLadoC.Text);

                //calcular se miperimetro
                double s = (LadoA + LadoB + LadoC) / 2;

                // Calculo del Semiperimetro
                double labelArea = Math.Sqrt(s * (s - LadoA) * (s - LadoB) * (s - LadoC));
                //MOstrar resultados 
                // EL TEXTBOX   NAME           // LABEL
                //Math.Sqrt(s * (s - ladoA) * (s - ladoB) * (s - ladoC));
                textAreaTriangulo.Text = labelArea.ToString();

            }
            catch
            {
                MessageBox.Show("Error: Ingrese números válidos");

            }
        }
        //Boton de Limpiar
        private void btnReset_Click(object sender, EventArgs e)
        {
            textLadoA.Clear();
            textLadoB.Clear();
            textLadoC.Clear();
            textAreaTriangulo.Clear();
            textCalcular.Clear();

        }

        // Boton se salida 
        private void btnSalida_Click(object sender, EventArgs e)
        {
        this.Close();
        }
    } 
}


