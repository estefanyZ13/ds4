using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_12_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Velocidad_Click(object sender, EventArgs e)
        {

        }

        private void TiempoDeUso_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try 
            {
                double Velocidad =Convert.ToDouble(txtVelocidad.Text);
                double TiempoDeUso = Convert.ToDouble(txtTiempo.Text);

                // calculos
                double Total = Velocidad*TiempoDeUso;
                // Mostrar resultados 
                txtDistancia.Text = Total.ToString();
            } catch {
                MessageBox.Show("Error: Ingrese números válidos");
            }
        }

        //Boton de Limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        { 
          txtVelocidad.Clear();
          txtTiempo.Clear();
          txtDistancia.Clear();
        }

        // Boton se salida 

        private void  btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
