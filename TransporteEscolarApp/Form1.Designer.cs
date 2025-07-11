﻿
using System;

namespace TransporteEscolarApp
{
    partial class Form1
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
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblBecado = new System.Windows.Forms.Label();
            this.dgvResumen = new System.Windows.Forms.DataGridView();
            this.btnResumen = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dtpFechaFiltro = new System.Windows.Forms.DateTimePicker();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnGestionEstudiantes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumen)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.BackColor = System.Drawing.SystemColors.Info;
            this.txtCodigoBarras.Location = new System.Drawing.Point(509, 607);
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(259, 20);
            this.txtCodigoBarras.TabIndex = 0;
            this.txtCodigoBarras.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.Moccasin;
            this.btnRegistrar.Location = new System.Drawing.Point(856, 597);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(95, 39);
            this.btnRegistrar.TabIndex = 1;
            this.btnRegistrar.Text = "Registrar Estudiante";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.SystemColors.Info;
            this.lblNombre.Location = new System.Drawing.Point(444, 52);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre";
            this.lblNombre.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblBecado
            // 
            this.lblBecado.AutoSize = true;
            this.lblBecado.BackColor = System.Drawing.SystemColors.Info;
            this.lblBecado.Location = new System.Drawing.Point(444, 121);
            this.lblBecado.Name = "lblBecado";
            this.lblBecado.Size = new System.Drawing.Size(44, 13);
            this.lblBecado.TabIndex = 3;
            this.lblBecado.Text = "Becado";
            // 
            // dgvResumen
            // 
            this.dgvResumen.BackgroundColor = System.Drawing.Color.Moccasin;
            this.dgvResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResumen.Location = new System.Drawing.Point(292, 170);
            this.dgvResumen.Name = "dgvResumen";
            this.dgvResumen.Size = new System.Drawing.Size(839, 316);
            this.dgvResumen.TabIndex = 4;
            // 
            // btnResumen
            // 
            this.btnResumen.BackColor = System.Drawing.Color.Moccasin;
            this.btnResumen.Location = new System.Drawing.Point(292, 499);
            this.btnResumen.Name = "btnResumen";
            this.btnResumen.Size = new System.Drawing.Size(95, 41);
            this.btnResumen.TabIndex = 5;
            this.btnResumen.Text = "Tirar Resumen";
            this.btnResumen.UseVisualStyleBackColor = false;
            this.btnResumen.Click += new System.EventHandler(this.btnResumen_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Beige;
            this.textBox1.Location = new System.Drawing.Point(292, 35);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(122, 39);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "\r\nNombre del Estudiante";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Beige;
            this.textBox2.Location = new System.Drawing.Point(292, 108);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(122, 42);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "\r\nBecado o no Becado";
            // 
            // dtpFechaFiltro
            // 
            this.dtpFechaFiltro.Location = new System.Drawing.Point(1166, 170);
            this.dtpFechaFiltro.Name = "dtpFechaFiltro";
            this.dtpFechaFiltro.Size = new System.Drawing.Size(212, 20);
            this.dtpFechaFiltro.TabIndex = 8;
            this.dtpFechaFiltro.ValueChanged += new System.EventHandler(this.dtpFechaFiltro_ValueChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Beige;
            this.lblTotal.Location = new System.Drawing.Point(1012, 499);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(89, 13);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "Total Estudiantes";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(1149, 451);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(101, 35);
            this.btnImprimir.TabIndex = 10;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnGestionEstudiantes
            // 
            this.btnGestionEstudiantes.Location = new System.Drawing.Point(1258, 63);
            this.btnGestionEstudiantes.Name = "btnGestionEstudiantes";
            this.btnGestionEstudiantes.Size = new System.Drawing.Size(120, 49);
            this.btnGestionEstudiantes.TabIndex = 11;
            this.btnGestionEstudiantes.Text = "Gestionar Estudiantes";
            this.btnGestionEstudiantes.UseVisualStyleBackColor = true;
            this.btnGestionEstudiantes.Click += new System.EventHandler(this.btnGestionEstudiantes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1451, 850);
            this.Controls.Add(this.btnGestionEstudiantes);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dtpFechaFiltro);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnResumen);
            this.Controls.Add(this.dgvResumen);
            this.Controls.Add(this.lblBecado);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtCodigoBarras);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        #endregion

        private System.Windows.Forms.TextBox txtCodigoBarras;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblBecado;
        private System.Windows.Forms.DataGridView dgvResumen;
        private System.Windows.Forms.Button btnResumen;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DateTimePicker dtpFechaFiltro;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnGestionEstudiantes;
    }
}

