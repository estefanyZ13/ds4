namespace Laboratorio_12_3
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ladoA = new System.Windows.Forms.Label();
            this.ladoB = new System.Windows.Forms.Label();
            this.ladoC = new System.Windows.Forms.Label();
            this.Semiperimetro = new System.Windows.Forms.Label();
            this.labelArea = new System.Windows.Forms.Label();
            this.btnSemiperimetro = new System.Windows.Forms.Button();
            this.btnArea = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSalida = new System.Windows.Forms.Button();
            this.textLadoA = new System.Windows.Forms.TextBox();
            this.textLadoB = new System.Windows.Forms.TextBox();
            this.textLadoC = new System.Windows.Forms.TextBox();
            this.textCalcular = new System.Windows.Forms.TextBox();
            this.textAreaTriangulo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ladoA
            // 
            this.ladoA.AutoSize = true;
            this.ladoA.Location = new System.Drawing.Point(18, 26);
            this.ladoA.Name = "ladoA";
            this.ladoA.Size = new System.Drawing.Size(143, 13);
            this.ladoA.TabIndex = 0;
            this.ladoA.Text = "Ingresa la longitud del lado A";
            this.ladoA.Click += new System.EventHandler(this.ladoA_Click);
            // 
            // ladoB
            // 
            this.ladoB.AutoSize = true;
            this.ladoB.Location = new System.Drawing.Point(12, 65);
            this.ladoB.Name = "ladoB";
            this.ladoB.Size = new System.Drawing.Size(143, 13);
            this.ladoB.TabIndex = 1;
            this.ladoB.Text = "Ingrese la longitud del lado B";
            // 
            // ladoC
            // 
            this.ladoC.AutoSize = true;
            this.ladoC.Location = new System.Drawing.Point(12, 108);
            this.ladoC.Name = "ladoC";
            this.ladoC.Size = new System.Drawing.Size(143, 13);
            this.ladoC.TabIndex = 2;
            this.ladoC.Text = "Ingrese la longitud del lado C";
            // 
            // Semiperimetro
            // 
            this.Semiperimetro.AutoSize = true;
            this.Semiperimetro.Location = new System.Drawing.Point(16, 194);
            this.Semiperimetro.Name = "Semiperimetro";
            this.Semiperimetro.Size = new System.Drawing.Size(114, 13);
            this.Semiperimetro.TabIndex = 3;
            this.Semiperimetro.Text = "Calcular Semiperimetro";
            this.Semiperimetro.Click += new System.EventHandler(this.labelSemiperimetro_Click);
            // 
            // labelArea
            // 
            this.labelArea.AutoSize = true;
            this.labelArea.Location = new System.Drawing.Point(16, 241);
            this.labelArea.Name = "labelArea";
            this.labelArea.Size = new System.Drawing.Size(93, 13);
            this.labelArea.TabIndex = 4;
            this.labelArea.Text = "Area del Triangulo";
            this.labelArea.Click += new System.EventHandler(this.labelArea_Click);
            // 
            // btnSemiperimetro
            // 
            this.btnSemiperimetro.Location = new System.Drawing.Point(15, 150);
            this.btnSemiperimetro.Name = "btnSemiperimetro";
            this.btnSemiperimetro.Size = new System.Drawing.Size(75, 23);
            this.btnSemiperimetro.TabIndex = 5;
            this.btnSemiperimetro.Text = "Semiperimetro";
            this.btnSemiperimetro.UseVisualStyleBackColor = true;
            this.btnSemiperimetro.Click += new System.EventHandler(this.btnSemiperimetro_Click);
            // 
            // btnArea
            // 
            this.btnArea.Location = new System.Drawing.Point(105, 150);
            this.btnArea.Name = "btnArea";
            this.btnArea.Size = new System.Drawing.Size(75, 23);
            this.btnArea.TabIndex = 6;
            this.btnArea.Text = "Area";
            this.btnArea.UseVisualStyleBackColor = true;
            this.btnArea.Click += new System.EventHandler(this.btnArea_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(192, 150);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSalida
            // 
            this.btnSalida.Location = new System.Drawing.Point(284, 150);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.Size = new System.Drawing.Size(75, 23);
            this.btnSalida.TabIndex = 8;
            this.btnSalida.Text = "Salida";
            this.btnSalida.UseVisualStyleBackColor = true;
            this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);
            // 
            // textLadoA
            // 
            this.textLadoA.Location = new System.Drawing.Point(167, 23);
            this.textLadoA.Name = "textLadoA";
            this.textLadoA.Size = new System.Drawing.Size(100, 20);
            this.textLadoA.TabIndex = 9;
            this.textLadoA.TextChanged += new System.EventHandler(this.textLadoA_TextChanged);
            // 
            // textLadoB
            // 
            this.textLadoB.Location = new System.Drawing.Point(167, 62);
            this.textLadoB.Name = "textLadoB";
            this.textLadoB.Size = new System.Drawing.Size(100, 20);
            this.textLadoB.TabIndex = 10;
            // 
            // textLadoC
            // 
            this.textLadoC.Location = new System.Drawing.Point(167, 101);
            this.textLadoC.Name = "textLadoC";
            this.textLadoC.Size = new System.Drawing.Size(100, 20);
            this.textLadoC.TabIndex = 11;
            // 
            // textCalcular
            // 
            this.textCalcular.Location = new System.Drawing.Point(167, 187);
            this.textCalcular.Name = "textCalcular";
            this.textCalcular.Size = new System.Drawing.Size(100, 20);
            this.textCalcular.TabIndex = 12;
            // 
            // textAreaTriangulo
            // 
            this.textAreaTriangulo.Location = new System.Drawing.Point(167, 234);
            this.textAreaTriangulo.Name = "textAreaTriangulo";
            this.textAreaTriangulo.Size = new System.Drawing.Size(100, 20);
            this.textAreaTriangulo.TabIndex = 13;
            this.textAreaTriangulo.TextChanged += new System.EventHandler(this.textAreaTriangulo_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 292);
            this.Controls.Add(this.textAreaTriangulo);
            this.Controls.Add(this.textCalcular);
            this.Controls.Add(this.textLadoC);
            this.Controls.Add(this.textLadoB);
            this.Controls.Add(this.textLadoA);
            this.Controls.Add(this.btnSalida);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnArea);
            this.Controls.Add(this.btnSemiperimetro);
            this.Controls.Add(this.labelArea);
            this.Controls.Add(this.Semiperimetro);
            this.Controls.Add(this.ladoC);
            this.Controls.Add(this.ladoB);
            this.Controls.Add(this.ladoA);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ladoA;
        private System.Windows.Forms.Label ladoB;
        private System.Windows.Forms.Label ladoC;
        private System.Windows.Forms.Label Semiperimetro;
        private System.Windows.Forms.Label labelArea;
        private System.Windows.Forms.Button btnSemiperimetro;
        private System.Windows.Forms.Button btnArea;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSalida;
        private System.Windows.Forms.TextBox textLadoA;
        private System.Windows.Forms.TextBox textLadoB;
        private System.Windows.Forms.TextBox textLadoC;
        private System.Windows.Forms.TextBox textCalcular;
        private System.Windows.Forms.TextBox textAreaTriangulo;
    }
}

