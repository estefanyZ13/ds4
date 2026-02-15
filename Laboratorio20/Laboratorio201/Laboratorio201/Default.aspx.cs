using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio201
{

        public partial class Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
            }

            protected void btnGenerar_Click(object sender, EventArgs e)
            {
                try
                {
                    int numero = Convert.ToInt32(txtNumero.Text);
                    StringBuilder tabla = new StringBuilder();
                    tabla.Append("<h3>Tabla del " + numero + "</h3>");

                    for (int i = 1; i <= 25; i++)
                    {
                        int resultado = numero * i;
                        tabla.Append(numero + " x " + i + " = " + resultado + "<br />");
                    }

                    lblResultado.Text = tabla.ToString();
                }
                catch (Exception)
                {
                    lblResultado.Text = "<span style='color:red;'>Por favor ingrese un número válido</span>";
                }
            }
        }
    }
