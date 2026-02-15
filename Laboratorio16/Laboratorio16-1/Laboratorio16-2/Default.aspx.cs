using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio16_1
{
    public partial class WebForm1 : Page
    {
        static float a, d;
        static string b;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            if ((txtDisplay.Text == "+") || (txtDisplay.Text == "-") || (txtDisplay.Text == "*") || (txtDisplay.Text == "/"))
            {
                txtDisplay.Text = "";
            }
            txtDisplay.Text = txtDisplay.Text + btn10.Text;
        }

        protected void b2_Click(object sender, EventArgs e)
        {
            if ((txtDisplay.Text == "+") || (txtDisplay.Text == "-") || (txtDisplay.Text == "*") || (txtDisplay.Text == "/"))
            {
                txtDisplay.Text = "";
            }
            txtDisplay.Text = txtDisplay.Text + btn11.Text;
        }

        protected void b3_Click(object sender, EventArgs e)
        {
            if ((txtDisplay.Text == "+") || (txtDisplay.Text == "-") || (txtDisplay.Text == "*") || (txtDisplay.Text == "/"))
            {
                txtDisplay.Text = "";
            }
            txtDisplay.Text = txtDisplay.Text + btn12.Text;
        }

        protected void b4_Click(object sender, EventArgs e)
        {
            if ((txtDisplay.Text == "+") || (txtDisplay.Text == "-") || (txtDisplay.Text == "*") || (txtDisplay.Text == "/"))
            {
                txtDisplay.Text = "";
            }
            txtDisplay.Text = txtDisplay.Text + btn13.Text;
        }

        protected void b5_Click(object sender, EventArgs e)
        {
            if ((txtDisplay.Text == "+") || (txtDisplay.Text == "-") || (txtDisplay.Text == "*") || (txtDisplay.Text == "/"))
            {
                txtDisplay.Text = "";
            }
            txtDisplay.Text = txtDisplay.Text + btn14.Text;
        }

        protected void b6_Click(object sender, EventArgs e)
        {
            if ((txtDisplay.Text == "+") || (txtDisplay.Text == "-") || (txtDisplay.Text == "*") || (txtDisplay.Text == "/"))
            {
                txtDisplay.Text = "";
            }
            txtDisplay.Text = txtDisplay.Text + btn15.Text;
        }

        protected void b7_Click(object sender, EventArgs e)
        {
            if ((txtDisplay.Text == "+") || (txtDisplay.Text == "-") || (txtDisplay.Text == "*") || (txtDisplay.Text == "/"))
            {
                txtDisplay.Text = "";
            }
            txtDisplay.Text = txtDisplay.Text + btn7.Text;
        }

        protected void b8_Click(object sender, EventArgs e)
        {
            if ((txtDisplay.Text == "+") || (txtDisplay.Text == "-") || (txtDisplay.Text == "*") || (txtDisplay.Text == "/"))
            {
                txtDisplay.Text = "";
            }
            txtDisplay.Text = txtDisplay.Text + btn8.Text;
        }

        protected void b9_Click(object sender, EventArgs e)
        {
            if ((txtDisplay.Text == "+") || (txtDisplay.Text == "-") || (txtDisplay.Text == "*") || (txtDisplay.Text == "/"))
            {
                txtDisplay.Text = "";
            }
            txtDisplay.Text = txtDisplay.Text + btn9.Text;
        }

        protected void b0_Click(object sender, EventArgs e)
        {
            if ((txtDisplay.Text == "+") || (txtDisplay.Text == "-") || (txtDisplay.Text == "*") || (txtDisplay.Text == "/"))
            {
                txtDisplay.Text = "";
            }
            txtDisplay.Text = txtDisplay.Text + btn0.Text;
        }

        protected void add_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text != "")
            {
                a = Convert.ToInt32(txtDisplay.Text);
                b = "+";
                txtDisplay.Text = b;
            }
        }

        protected void sub_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text != "")
            {
                a = Convert.ToInt32(txtDisplay.Text);
                b = "-";
                txtDisplay.Text = b;
            }
        }

        protected void mul_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text != "")
            {
                a = Convert.ToInt32(txtDisplay.Text);
                b = "*";
                txtDisplay.Text = b;
            }
        }

        protected void div_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text != "")
            {
                a = Convert.ToInt32(txtDisplay.Text);
                b = "/";
                txtDisplay.Text = b;
            }
        }

        protected void eql_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "+" || txtDisplay.Text == "-" || txtDisplay.Text == "*" || txtDisplay.Text == "/")
            {
                txtDisplay.Text = "Error";
                return;
            }

            d = Convert.ToInt32(txtDisplay.Text);

            if (b == "/")
            {
                if (d != 0)
                {
                    a = a / d;
                }
                else
                {
                    txtDisplay.Text = "Error";
                    return;
                }
            }
            else if (b == "+")
            {
                a = a + d;
            }
            else if (b == "-")
            {
                a = a - d;
            }
            else if (b == "*")
            {
                a = a * d;
            }

            txtDisplay.Text = a.ToString();
        }

        protected void clr_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "";
            a = 0;
            d = 0;
            b = "";
        }
    }
}