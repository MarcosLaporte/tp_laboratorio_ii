
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
			this.btnAgregarCliente = new System.Windows.Forms.Button();
			this.btnAgregarPedido = new System.Windows.Forms.Button();
			this.btnBorrarCliente = new System.Windows.Forms.Button();
			this.btnPagarPend = new System.Windows.Forms.Button();
			this.lBxVentas = new System.Windows.Forms.ListBox();
			this.rTBxVentas = new System.Windows.Forms.RichTextBox();
			this.lblVentas = new System.Windows.Forms.Label();
			this.lblDescVentas = new System.Windows.Forms.Label();
			this.lblClientes = new System.Windows.Forms.Label();
			this.dtgvClientes = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dtgvClientes)).BeginInit();
			this.SuspendLayout();
			// 
			// btnAgregarCliente
			// 
			this.btnAgregarCliente.Location = new System.Drawing.Point(662, 442);
			this.btnAgregarCliente.Name = "btnAgregarCliente";
			this.btnAgregarCliente.Size = new System.Drawing.Size(224, 85);
			this.btnAgregarCliente.TabIndex = 2;
			this.btnAgregarCliente.Text = "Agregar cliente";
			this.btnAgregarCliente.UseVisualStyleBackColor = true;
			this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
			// 
			// btnAgregarPedido
			// 
			this.btnAgregarPedido.Location = new System.Drawing.Point(12, 442);
			this.btnAgregarPedido.Name = "btnAgregarPedido";
			this.btnAgregarPedido.Size = new System.Drawing.Size(224, 85);
			this.btnAgregarPedido.TabIndex = 0;
			this.btnAgregarPedido.Text = "Agregar pedido";
			this.btnAgregarPedido.UseVisualStyleBackColor = true;
			this.btnAgregarPedido.Click += new System.EventHandler(this.btnAgregarPedido_Click);
			// 
			// btnBorrarCliente
			// 
			this.btnBorrarCliente.Location = new System.Drawing.Point(892, 442);
			this.btnBorrarCliente.Name = "btnBorrarCliente";
			this.btnBorrarCliente.Size = new System.Drawing.Size(224, 85);
			this.btnBorrarCliente.TabIndex = 3;
			this.btnBorrarCliente.Text = "Eliminar cliente";
			this.btnBorrarCliente.UseVisualStyleBackColor = true;
			this.btnBorrarCliente.Click += new System.EventHandler(this.btnBorrarCliente_Click);
			// 
			// btnPagarPend
			// 
			this.btnPagarPend.Location = new System.Drawing.Point(432, 442);
			this.btnPagarPend.Name = "btnPagarPend";
			this.btnPagarPend.Size = new System.Drawing.Size(224, 85);
			this.btnPagarPend.TabIndex = 1;
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
			// dtgvClientes
			// 
			this.dtgvClientes.AllowUserToResizeColumns = false;
			this.dtgvClientes.AllowUserToResizeRows = false;
			this.dtgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dtgvClientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dtgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgvClientes.Location = new System.Drawing.Point(662, 33);
			this.dtgvClientes.Name = "dtgvClientes";
			this.dtgvClientes.RowHeadersWidth = 51;
			this.dtgvClientes.RowTemplate.Height = 29;
			this.dtgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dtgvClientes.Size = new System.Drawing.Size(456, 403);
			this.dtgvClientes.TabIndex = 11;
			// 
			// FrmPrincipal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(1130, 533);
			this.Controls.Add(this.dtgvClientes);
			this.Controls.Add(this.lblClientes);
			this.Controls.Add(this.lblDescVentas);
			this.Controls.Add(this.lblVentas);
			this.Controls.Add(this.rTBxVentas);
			this.Controls.Add(this.lBxVentas);
			this.Controls.Add(this.btnPagarPend);
			this.Controls.Add(this.btnBorrarCliente);
			this.Controls.Add(this.btnAgregarPedido);
			this.Controls.Add(this.btnAgregarCliente);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmPrincipal";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Mi Farmacia";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
			this.Load += new System.EventHandler(this.FrmPrincipal_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtgvClientes)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarCliente;
        private System.Windows.Forms.Button btnAgregarPedido;
        private System.Windows.Forms.Button btnBorrarCliente;
        private System.Windows.Forms.Button btnPagarPend;
        private System.Windows.Forms.ListBox lBxVentas;
        private System.Windows.Forms.RichTextBox rTBxVentas;
		private System.Windows.Forms.Label lblVentas;
		private System.Windows.Forms.Label lblDescVentas;
		private System.Windows.Forms.Label lblClientes;
		private System.Windows.Forms.DataGridView dtgvClientes;
	}
}

