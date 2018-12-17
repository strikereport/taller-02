namespace Taller_02_base_de_datos
{
    partial class RF5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.botonBuscarRF5 = new System.Windows.Forms.Button();
            this.VolverRF5 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // botonBuscarRF5
            // 
            this.botonBuscarRF5.Location = new System.Drawing.Point(233, 42);
            this.botonBuscarRF5.Name = "botonBuscarRF5";
            this.botonBuscarRF5.Size = new System.Drawing.Size(75, 23);
            this.botonBuscarRF5.TabIndex = 0;
            this.botonBuscarRF5.Text = "Buscar";
            this.botonBuscarRF5.UseVisualStyleBackColor = true;
            this.botonBuscarRF5.Click += new System.EventHandler(this.BuscarRF5_Click);
            // 
            // VolverRF5
            // 
            this.VolverRF5.Location = new System.Drawing.Point(233, 71);
            this.VolverRF5.Name = "VolverRF5";
            this.VolverRF5.Size = new System.Drawing.Size(75, 23);
            this.VolverRF5.TabIndex = 1;
            this.VolverRF5.Text = "Volver";
            this.VolverRF5.UseVisualStyleBackColor = true;
            this.VolverRF5.Click += new System.EventHandler(this.VolverRF5_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(86, 44);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "nombre";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Estudiante:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(86, 80);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 82);
            this.listBox1.TabIndex = 4;
            this.listBox1.Visible = false;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // RF5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 197);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.VolverRF5);
            this.Controls.Add(this.botonBuscarRF5);
            this.Name = "RF5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cursos por estudiante";
            this.Load += new System.EventHandler(this.RF5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonBuscarRF5;
        private System.Windows.Forms.Button VolverRF5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
    }
}