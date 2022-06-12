
namespace VistaForm
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.btnAgregarCliente = new System.Windows.Forms.Button();
			this.btnAgregarPedido = new System.Windows.Forms.Button();
			this.btnBorrarCliente = new System.Windows.Forms.Button();
			this.btnPagarPend = new System.Windows.Forms.Button();
			this.lBxVentas = new System.Windows.Forms.ListBox();
			this.lBxClientes = new System.Windows.Forms.ListBox();
			this.rTBxClientes = new System.Windows.Forms.RichTextBox();
			this.rTBxVentas = new System.Windows.Forms.RichTextBox();
			this.lblVentas = new System.Windows.Forms.Label();
			this.lblDescVentas = new System.Windows.Forms.Label();
			this.lblClientes = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnAgregarCliente
			// 
			this.btnAgregarCliente.Location = new System.Drawing.Point(12, 442);
			this.btnAgregarCliente.Name = "btnAgregarCliente";
			this.btnAgregarCliente.Size = new System.Drawing.Size(224, 85);
			this.btnAgregarCliente.TabIndex = 0;
			this.btnAgregarCliente.Text = "Agregar cliente";
			this.btnAgregarCliente.UseVisualStyleBackColor = true;
			this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
			// 
			// btnAgregarPedido
			// 
			this.btnAgregarPedido.Location = new System.Drawing.Point(242, 442);
			this.btnAgregarPedido.Name = "btnAgregarPedido";
			this.btnAgregarPedido.Size = new System.Drawing.Size(224, 85);
			this.btnAgregarPedido.TabIndex = 1;
			this.btnAgregarPedido.Text = "Agregar pedido";
			this.btnAgregarPedido.UseVisualStyleBackColor = true;
			this.btnAgregarPedido.Click += new System.EventHandler(this.btnAgregarPedido_Click);
			// 
			// btnBorrarCliente
			// 
			this.btnBorrarCliente.Location = new System.Drawing.Point(472, 442);
			this.btnBorrarCliente.Name = "btnBorrarCliente";
			this.btnBorrarCliente.Size = new System.Drawing.Size(224, 85);
			this.btnBorrarCliente.TabIndex = 2;
			this.btnBorrarCliente.Text = "Eliminar cliente";
			this.btnBorrarCliente.UseVisualStyleBackColor = true;
			this.btnBorrarCliente.Click += new System.EventHandler(this.btnBorrarCliente_Click);
			// 
			// btnPagarPend
			// 
			this.btnPagarPend.Location = new System.Drawing.Point(702, 442);
			this.btnPagarPend.Name = "btnPagarPend";
			this.btnPagarPend.Size = new System.Drawing.Size(224, 85);
			this.btnPagarPend.TabIndex = 3;
			this.btnPagarPend.Text = "Pagar pendiente";
			this.btnPagarPend.UseVisualStyleBackColor = true;
			this.btnPagarPend.Click += new System.EventHandler(this.btnPagarPend_Click);
			// 
			// lBxVentas
			// 
			this.lBxVentas.FormattingEnabled = true;
			this.lBxVentas.ItemHeight = 20;
			this.lBxVentas.Location = new System.Drawing.Point(12, 32);
			this.lBxVentas.Name = "lBxVentas";
			this.lBxVentas.Size = new System.Drawing.Size(313, 404);
			this.lBxVentas.TabIndex = 4;
			this.lBxVentas.TabStop = false;
			this.lBxVentas.Click += new System.EventHandler(this.lBxVentas_Click);
			// 
			// lBxClientes
			// 
			this.lBxClientes.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lBxClientes.FormattingEnabled = true;
			this.lBxClientes.ItemHeight = 25;
			this.lBxClientes.Location = new System.Drawing.Point(662, 32);
			this.lBxClientes.Name = "lBxClientes";
			this.lBxClientes.Size = new System.Drawing.Size(262, 254);
			this.lBxClientes.TabIndex = 4;
			this.lBxClientes.Click += new System.EventHandler(this.lBxClientes_Click);
			// 
			// rTBxClientes
			// 
			this.rTBxClientes.BackColor = System.Drawing.SystemColors.Control;
			this.rTBxClientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rTBxClientes.Enabled = false;
			this.rTBxClientes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
			this.rTBxClientes.Location = new System.Drawing.Point(662, 292);
			this.rTBxClientes.Name = "rTBxClientes";
			this.rTBxClientes.ReadOnly = true;
			this.rTBxClientes.Size = new System.Drawing.Size(262, 144);
			this.rTBxClientes.TabIndex = 6;
			this.rTBxClientes.TabStop = false;
			this.rTBxClientes.Text = "";
			// 
			// rTBxVentas
			// 
			this.rTBxVentas.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.rTBxVentas.Location = new System.Drawing.Point(336, 32);
			this.rTBxVentas.Name = "rTBxVentas";
			this.rTBxVentas.ReadOnly = true;
			this.rTBxVentas.Size = new System.Drawing.Size(297, 404);
			this.rTBxVentas.TabIndex = 7;
			this.rTBxVentas.TabStop = false;
			this.rTBxVentas.Text = "";
			// 
			// lblVentas
			// 
			this.lblVentas.AutoSize = true;
			this.lblVentas.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblVentas.Location = new System.Drawing.Point(12, 9);
			this.lblVentas.Name = "lblVentas";
			this.lblVentas.Size = new System.Drawing.Size(112, 20);
			this.lblVentas.TabIndex = 8;
			this.lblVentas.Text = "Lista de ventas:";
			// 
			// lblDescVentas
			// 
			this.lblDescVentas.AutoSize = true;
			this.lblDescVentas.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblDescVentas.Location = new System.Drawing.Point(336, 9);
			this.lblDescVentas.Name = "lblDescVentas";
			this.lblDescVentas.Size = new System.Drawing.Size(156, 20);
			this.lblDescVentas.TabIndex = 9;
			this.lblDescVentas.Text = "Descripción de venta:";
			// 
			// lblClientes
			// 
			this.lblClientes.AutoSize = true;
			this.lblClientes.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblClientes.Location = new System.Drawing.Point(662, 9);
			this.lblClientes.Name = "lblClientes";
			this.lblClientes.Size = new System.Drawing.Size(119, 20);
			this.lblClientes.TabIndex = 10;
			this.lblClientes.Text = "Lista de clientes:";
			// 
			// FrmPrincipal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(936, 533);
			this.Controls.Add(this.lblClientes);
			this.Controls.Add(this.lblDescVentas);
			this.Controls.Add(this.lblVentas);
			this.Controls.Add(this.rTBxVentas);
			this.Controls.Add(this.rTBxClientes);
			this.Controls.Add(this.lBxClientes);
			this.Controls.Add(this.lBxVentas);
			this.Controls.Add(this.btnPagarPend);
			this.Controls.Add(this.btnBorrarCliente);
			this.Controls.Add(this.btnAgregarPedido);
			this.Controls.Add(this.btnAgregarCliente);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmPrincipal";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FrmPrincipal";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
			this.Load += new System.EventHandler(this.FrmPrincipal_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarCliente;
        private System.Windows.Forms.Button btnAgregarPedido;
        private System.Windows.Forms.Button btnBorrarCliente;
        private System.Windows.Forms.Button btnPagarPend;
        private System.Windows.Forms.ListBox lBxVentas;
        private System.Windows.Forms.ListBox lBxClientes;
        private System.Windows.Forms.RichTextBox rTBxClientes;
        private System.Windows.Forms.RichTextBox rTBxVentas;
		private System.Windows.Forms.Label lblVentas;
		private System.Windows.Forms.Label lblDescVentas;
		private System.Windows.Forms.Label lblClientes;
	}
}

