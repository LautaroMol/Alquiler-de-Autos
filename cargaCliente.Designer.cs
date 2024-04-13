namespace App1
{
    partial class cargaCliente
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
            this.txtdni = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtnom = new System.Windows.Forms.TextBox();
            this.txtap = new System.Windows.Forms.TextBox();
            this.txttel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnguard = new System.Windows.Forms.Button();
            this.btnelim = new System.Windows.Forms.Button();
            this.btnmod = new System.Windows.Forms.Button();
            this.btnmodi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtdni
            // 
            this.txtdni.Location = new System.Drawing.Point(50, 72);
            this.txtdni.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtdni.Name = "txtdni";
            this.txtdni.Size = new System.Drawing.Size(132, 22);
            this.txtdni.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Formulario clientes";
            // 
            // txtnom
            // 
            this.txtnom.Location = new System.Drawing.Point(50, 131);
            this.txtnom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtnom.Name = "txtnom";
            this.txtnom.Size = new System.Drawing.Size(132, 22);
            this.txtnom.TabIndex = 2;
            // 
            // txtap
            // 
            this.txtap.Location = new System.Drawing.Point(50, 193);
            this.txtap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtap.Name = "txtap";
            this.txtap.Size = new System.Drawing.Size(132, 22);
            this.txtap.TabIndex = 3;
            // 
            // txttel
            // 
            this.txttel.Location = new System.Drawing.Point(50, 255);
            this.txttel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txttel.Name = "txttel";
            this.txttel.Size = new System.Drawing.Size(132, 22);
            this.txttel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(210, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Dni";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(210, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nombres";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(210, 193);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Apellido/s";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(210, 259);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Telefono";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 408);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(585, 184);
            this.dataGridView1.TabIndex = 10;
            // 
            // btnguard
            // 
            this.btnguard.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnguard.Location = new System.Drawing.Point(50, 313);
            this.btnguard.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnguard.Name = "btnguard";
            this.btnguard.Size = new System.Drawing.Size(132, 55);
            this.btnguard.TabIndex = 11;
            this.btnguard.Text = "Guardar";
            this.btnguard.UseVisualStyleBackColor = true;
            this.btnguard.Click += new System.EventHandler(this.btnguard_Click);
            // 
            // btnelim
            // 
            this.btnelim.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnelim.Location = new System.Drawing.Point(234, 313);
            this.btnelim.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnelim.Name = "btnelim";
            this.btnelim.Size = new System.Drawing.Size(132, 55);
            this.btnelim.TabIndex = 12;
            this.btnelim.Text = "Eliminar";
            this.btnelim.UseVisualStyleBackColor = true;
            this.btnelim.Click += new System.EventHandler(this.btnelim_Click);
            // 
            // btnmod
            // 
            this.btnmod.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmod.Location = new System.Drawing.Point(305, 54);
            this.btnmod.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnmod.Name = "btnmod";
            this.btnmod.Size = new System.Drawing.Size(132, 55);
            this.btnmod.TabIndex = 13;
            this.btnmod.Text = "Buscar";
            this.btnmod.UseVisualStyleBackColor = true;
            this.btnmod.Click += new System.EventHandler(this.btnmod_Click);
            // 
            // btnmodi
            // 
            this.btnmodi.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmodi.Location = new System.Drawing.Point(417, 313);
            this.btnmodi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnmodi.Name = "btnmodi";
            this.btnmodi.Size = new System.Drawing.Size(132, 55);
            this.btnmodi.TabIndex = 14;
            this.btnmodi.Text = "Modificar";
            this.btnmodi.UseVisualStyleBackColor = true;
            this.btnmodi.Click += new System.EventHandler(this.btnmodi_Click);
            // 
            // cargaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 607);
            this.Controls.Add(this.btnmodi);
            this.Controls.Add(this.btnmod);
            this.Controls.Add(this.btnelim);
            this.Controls.Add(this.btnguard);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txttel);
            this.Controls.Add(this.txtap);
            this.Controls.Add(this.txtnom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtdni);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "cargaCliente";
            this.Text = "cargaCliente";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtdni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtnom;
        private System.Windows.Forms.TextBox txtap;
        private System.Windows.Forms.TextBox txttel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnguard;
        private System.Windows.Forms.Button btnelim;
        private System.Windows.Forms.Button btnmod;
        private System.Windows.Forms.Button btnmodi;
    }
}