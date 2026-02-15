namespace Laboratorio_12_1
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
            this.Laboratorio12 = new System.Windows.Forms.Label();
            this.TiempoDeUso = new System.Windows.Forms.Label();
            this.Total = new System.Windows.Forms.Label();
            this.txtVelocidad = new System.Windows.Forms.TextBox();
            this.txtTiempo = new System.Windows.Forms.TextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtDistancia = new System.Windows.Forms.TextBox();
            this.Velocidad = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Laboratorio12
            // 
            this.Laboratorio12.AutoSize = true;
            this.Laboratorio12.Location = new System.Drawing.Point(111, 23);
            this.Laboratorio12.Name = "Laboratorio12";
            this.Laboratorio12.Size = new System.Drawing.Size(72, 13);
            this.Laboratorio12.TabIndex = 0;
            this.Laboratorio12.Text = "Laboratorio12";
            // 
            // TiempoDeUso
            // 
            this.TiempoDeUso.AutoSize = true;
            this.TiempoDeUso.Location = new System.Drawing.Point(27, 128);
            this.TiempoDeUso.Name = "TiempoDeUso";
            this.TiempoDeUso.Size = new System.Drawing.Size(75, 13);
            this.TiempoDeUso.TabIndex = 2;
            this.TiempoDeUso.Text = "TiempoDeUso";
            this.TiempoDeUso.Click += new System.EventHandler(this.TiempoDeUso_Click);
            // 
            // Total
            // 
            this.Total.AutoSize = true;
            this.Total.Location = new System.Drawing.Point(27, 216);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(31, 13);
            this.Total.TabIndex = 3;
            this.Total.Text = "Total";
            // 
            // txtVelocidad
            // 
            this.txtVelocidad.Location = new System.Drawing.Point(139, 66);
            this.txtVelocidad.Name = "txtVelocidad";
            this.txtVelocidad.Size = new System.Drawing.Size(170, 20);
            this.txtVelocidad.TabIndex = 4;
            // 
            // txtTiempo
            // 
            this.txtTiempo.Location = new System.Drawing.Point(139, 125);
            this.txtTiempo.Name = "txtTiempo";
            this.txtTiempo.Size = new System.Drawing.Size(170, 20);
            this.txtTiempo.TabIndex = 5;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(30, 162);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 6;
            this.btnCalcular.Text = "Calculo";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(139, 162);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(234, 162);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtDistancia
            // 
            this.txtDistancia.Location = new System.Drawing.Point(166, 213);
            this.txtDistancia.Name = "txtDistancia";
            this.txtDistancia.Size = new System.Drawing.Size(143, 20);
            this.txtDistancia.TabIndex = 9;
            // 
            // Velocidad
            // 
            this.Velocidad.AutoSize = true;
            this.Velocidad.Location = new System.Drawing.Point(27, 66);
            this.Velocidad.Name = "Velocidad";
            this.Velocidad.Size = new System.Drawing.Size(54, 13);
            this.Velocidad.TabIndex = 1;
            this.Velocidad.Text = "Velocidad";
            this.Velocidad.Click += new System.EventHandler(this.Velocidad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 267);
            this.Controls.Add(this.txtDistancia);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.txtTiempo);
            this.Controls.Add(this.txtVelocidad);
            this.Controls.Add(this.Total);
            this.Controls.Add(this.TiempoDeUso);
            this.Controls.Add(this.Velocidad);
            this.Controls.Add(this.Laboratorio12);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Laboratorio12;
        private System.Windows.Forms.Label TiempoDeUso;
        private System.Windows.Forms.Label Total;
        private System.Windows.Forms.TextBox txtVelocidad;
        private System.Windows.Forms.TextBox txtTiempo;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtDistancia;
        private System.Windows.Forms.Label Velocidad;
    }
}

