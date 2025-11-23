using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio202
{
    public partial class Laboratorio202 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Se ejecuta al cargar la página
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpiar mensaje de error
                lblError.Text = "";

                // Obtener la dimensión ingresada por el usuario
                int n = Convert.ToInt32(txtDimension.Text);

                // Validar que sea un número positivo
                if (n <= 0)
                {
                    lblError.Text = "Por favor ingrese un número mayor a 0";
                    litMatriz.Text = "";
                    return;
                }

                // Validar que no sea muy grande (opcional, para evitar problemas de rendimiento)
                if (n > 20)
                {
                    lblError.Text = "Por favor ingrese un número menor o igual a 20";
                    litMatriz.Text = "";
                    return;
                }

                // Generar la matriz
                GenerarMatriz(n);
            }
            catch (FormatException)
            {
                lblError.Text = "Por favor ingrese un número válido";
                litMatriz.Text = "";
            }
            catch (Exception ex)
            {
                lblError.Text = "Error: " + ex.Message;
                litMatriz.Text = "";
            }
        }

        private void GenerarMatriz(int n)
        {
            StringBuilder matriz = new StringBuilder();

            // Iniciar la tabla HTML
            matriz.Append("<table>");

            // Recorrer cada fila
            for (int i = 0; i < n; i++)
            {
                matriz.Append("<tr>"); // Iniciar fila

                // Recorrer cada columna
                for (int j = 0; j < n; j++)
                {
                    // Verificar si está en la diagonal inversa
                    // La diagonal inversa cumple: i + j = n - 1
                    if (i + j == n - 1)
                    {
                        // Está en la diagonal inversa: colocar 1
                        matriz.Append("<td class='diagonal'>1</td>");
                    }
                    else
                    {
                        // No está en la diagonal: colocar 0
                        matriz.Append("<td class='zero'>0</td>");
                    }
                }

                matriz.Append("</tr>"); // Cerrar fila
            }

            // Cerrar la tabla HTML
            matriz.Append("</table>");

            // Mostrar la matriz en el Literal
            litMatriz.Text = matriz.ToString();
        }
    }
}