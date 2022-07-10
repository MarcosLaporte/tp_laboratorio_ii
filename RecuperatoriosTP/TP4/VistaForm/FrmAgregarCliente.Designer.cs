
namespace VistaForm
{
    partial class FrmAgregarCliente
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
			this.lblNombre = new System.Windows.Forms.Label();
			this.lblApellido = new System.Windows.Forms.Label();
			this.lblDni = new System.Windows.Forms.Label();
			this.lblTelefono = new System.Windows.Forms.Label();
			this.tBxNombre = new System.Windows.Forms.TextBox();
			this.tBxApellido = new System.Windows.Forms.TextBox();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.tBxTelefono = new System.Windows.Forms.TextBox();
			this.tBxDni = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblNombre
			// 
			this.lblNombre.AutoSize = true;
			this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lblNombre.Location = new System.Drawing.Point(71, 40);
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.Size = new System.Drawing.Size(89, 28);
			this.lblNombre.TabIndex = 0;
			this.lblNombre.Text = "Nombre:";
			// 
			// lblApellido
			// 
			this.lblApellido.AutoSize = true;
			this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lblApellido.Location = new System.Drawing.Point(71, 81);
			this.lblApellido.Name = "lblApellido";
			this.lblApellido.Size = new System.Drawing.Size(90, 28);
			this.lblApellido.TabIndex = 1;
			this.lblApellido.Text = "Apellido:";
			// 
			// lblDni
			// 
			this.lblDni.AutoSize = true;
			this.lblDni.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lblDni.Location = new System.Drawing.Point(71, 162);
			this.lblDni.Name = "lblDni";
			this.lblDni.Size = new System.Drawing.Size(50, 28);
			this.lblDni.TabIndex = 3;
			this.lblDni.Text = "DNI:";
			// 
			// lblTelefono
			// 
			this.lblTelefono.AutoSize = true;
			this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lblTelefono.Location = new System.Drawing.Point(71, 121);
			this.lblTelefono.Name = "lblTelefono";
			this.lblTelefono.Size = new System.Drawing.Size(90, 28);
			this.lblTelefono.TabIndex = 2;
			this.lblTelefono.Text = "Teléfono:";
			// 
			// tBxNombre
			// 
			this.tBxNombre.Location = new System.Drawing.Point(201, 44);
			this.tBxNombre.Name = "tBxNombre";
			this.tBxNombre.PlaceholderText = "Juansito";
			this.tBxNombre.Size = new System.Drawing.Size(190, 27);
			this.tBxNombre.TabIndex = 4;
			// 
			// tBxApellido
			// 
			this.tBxApellido.Location = new System.Drawing.Point(201, 85);
			this.tBxApellido.Name = "tBxApellido";
			this.tBxApellido.PlaceholderText = "Gómez";
			this.tBxApellido.Size = new System.Drawing.Size(190, 27);
			this.tBxApellido.TabIndex = 5;
			// 
			// btnAgregar
			// 
			this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAgregar.Location = new System.Drawing.Point(12, 246);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(225, 73);
			this.btnAgregar.TabIndex = 8;
			this.btnAgregar.Text = "Agregar";
			this.btnAgregar.UseVisualStyleBackColor = true;
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCancelar.Location = new System.Drawing.Point(245, 246);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(225, 73);
			this.btnCancelar.TabIndex = 9;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// tBxTelefono
			// 
			this.tBxTelefono.Location = new System.Drawing.Point(201, 125);
			this.tBxTelefono.Name = "tBxTelefono";
			this.tBxTelefono.PlaceholderText = "1123341495";
			this.tBxTelefono.Size = new System.Drawing.Size(190, 27);
			this.tBxTelefono.TabIndex = 6;
			// 
			// tBxDni
			// 
			this.tBxDni.AccessibleDescription = "";
			this.tBxDni.AccessibleName = "";
			this.tBxDni.Location = new System.Drawing.Point(201, 166);
			this.tBxDni.Name = "tBxDni";
			this.tBxDni.PlaceholderText = "44247618";
			this.tBxDni.Size = new System.Drawing.Size(190, 27);
			this.tBxDni.TabIndex = 7;
			this.tBxDni.Tag = "";
			// 
			// FrmAgregarCliente
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(482, 331);
			this.ControlBox = false;
			this.Controls.Add(this.tBxDni);
			this.Controls.Add(this.tBxTelefono);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnAgregar);
			this.Controls.Add(this.tBxApellido);
			this.Controls.Add(this.tBxNombre);
			this.Controls.Add(this.lblDni);
			this.Controls.Add(this.lblTelefono);
			this.Controls.Add(this.lblApellido);
			this.Controls.Add(this.lblNombre);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmAgregarCliente";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Datos del cliente";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox tBxNombre;
        private System.Windows.Forms.TextBox tBxApellido;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox tBxTelefono;
        private System.Windows.Forms.TextBox tBxDni;
	}
}