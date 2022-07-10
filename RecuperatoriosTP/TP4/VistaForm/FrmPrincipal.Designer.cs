
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
			this.lblClientes = new System.Windows.Forms.Label();
			this.dtgvClientes = new System.Windows.Forms.DataGridView();
			this.btnModificarCliente = new System.Windows.Forms.Button();
			this.dtgvVentas = new System.Windows.Forms.DataGridView();
			this.lblVentas = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dtgvClientes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtgvVentas)).BeginInit();
			this.SuspendLayout();
			// 
			// btnAgregarCliente
			// 
			this.btnAgregarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAgregarCliente.Location = new System.Drawing.Point(549, 441);
			this.btnAgregarCliente.Name = "btnAgregarCliente";
			this.btnAgregarCliente.Size = new System.Drawing.Size(175, 85);
			this.btnAgregarCliente.TabIndex = 3;
			this.btnAgregarCliente.Text = "Agregar cliente";
			this.btnAgregarCliente.UseVisualStyleBackColor = true;
			this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
			// 
			// btnAgregarPedido
			// 
			this.btnAgregarPedido.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAgregarPedido.Location = new System.Drawing.Point(12, 441);
			this.btnAgregarPedido.Name = "btnAgregarPedido";
			this.btnAgregarPedido.Size = new System.Drawing.Size(175, 85);
			this.btnAgregarPedido.TabIndex = 0;
			this.btnAgregarPedido.Text = "Agregar pedido";
			this.btnAgregarPedido.UseVisualStyleBackColor = true;
			this.btnAgregarPedido.Click += new System.EventHandler(this.btnAgregarPedido_Click);
			// 
			// btnBorrarCliente
			// 
			this.btnBorrarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBorrarCliente.Location = new System.Drawing.Point(728, 441);
			this.btnBorrarCliente.Name = "btnBorrarCliente";
			this.btnBorrarCliente.Size = new System.Drawing.Size(175, 85);
			this.btnBorrarCliente.TabIndex = 4;
			this.btnBorrarCliente.Text = "Eliminar cliente";
			this.btnBorrarCliente.UseVisualStyleBackColor = true;
			this.btnBorrarCliente.Click += new System.EventHandler(this.btnBorrarCliente_Click);
			// 
			// btnPagarPend
			// 
			this.btnPagarPend.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnPagarPend.Location = new System.Drawing.Point(370, 441);
			this.btnPagarPend.Name = "btnPagarPend";
			this.btnPagarPend.Size = new System.Drawing.Size(175, 85);
			this.btnPagarPend.TabIndex = 2;
			this.btnPagarPend.Text = "Pagar pendiente";
			this.btnPagarPend.UseVisualStyleBackColor = true;
			this.btnPagarPend.Click += new System.EventHandler(this.btnPagarPend_Click);
			// 
			// lblClientes
			// 
			this.lblClientes.AutoSize = true;
			this.lblClientes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblClientes.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblClientes.ForeColor = System.Drawing.SystemColors.Highlight;
			this.lblClientes.Location = new System.Drawing.Point(412, 9);
			this.lblClientes.Name = "lblClientes";
			this.lblClientes.Size = new System.Drawing.Size(66, 20);
			this.lblClientes.TabIndex = 10;
			this.lblClientes.Text = "Clientes:";
			this.lblClientes.Click += new System.EventHandler(this.lblClientes_Click);
			// 
			// dtgvClientes
			// 
			this.dtgvClientes.AllowUserToAddRows = false;
			this.dtgvClientes.AllowUserToDeleteRows = false;
			this.dtgvClientes.AllowUserToResizeColumns = false;
			this.dtgvClientes.AllowUserToResizeRows = false;
			this.dtgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dtgvClientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dtgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgvClientes.Location = new System.Drawing.Point(412, 32);
			this.dtgvClientes.Name = "dtgvClientes";
			this.dtgvClientes.ReadOnly = true;
			this.dtgvClientes.RowHeadersWidth = 51;
			this.dtgvClientes.RowTemplate.Height = 29;
			this.dtgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dtgvClientes.Size = new System.Drawing.Size(494, 403);
			this.dtgvClientes.TabIndex = 11;
			// 
			// btnModificarCliente
			// 
			this.btnModificarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnModificarCliente.Location = new System.Drawing.Point(191, 441);
			this.btnModificarCliente.Name = "btnModificarCliente";
			this.btnModificarCliente.Size = new System.Drawing.Size(175, 85);
			this.btnModificarCliente.TabIndex = 1;
			this.btnModificarCliente.Text = "Modificar cliente";
			this.btnModificarCliente.UseVisualStyleBackColor = true;
			this.btnModificarCliente.Click += new System.EventHandler(this.btnModificarCliente_Click);
			// 
			// dtgvVentas
			// 
			this.dtgvVentas.AllowUserToAddRows = false;
			this.dtgvVentas.AllowUserToDeleteRows = false;
			this.dtgvVentas.AllowUserToResizeColumns = false;
			this.dtgvVentas.AllowUserToResizeRows = false;
			this.dtgvVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dtgvVentas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dtgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgvVentas.Location = new System.Drawing.Point(11, 32);
			this.dtgvVentas.Name = "dtgvVentas";
			this.dtgvVentas.ReadOnly = true;
			this.dtgvVentas.RowHeadersWidth = 51;
			this.dtgvVentas.RowTemplate.Height = 29;
			this.dtgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dtgvVentas.Size = new System.Drawing.Size(395, 403);
			this.dtgvVentas.TabIndex = 12;
			// 
			// lblVentas
			// 
			this.lblVentas.AutoSize = true;
			this.lblVentas.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblVentas.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
			this.lblVentas.ForeColor = System.Drawing.SystemColors.Highlight;
			this.lblVentas.Location = new System.Drawing.Point(11, 9);
			this.lblVentas.Name = "lblVentas";
			this.lblVentas.Size = new System.Drawing.Size(58, 20);
			this.lblVentas.TabIndex = 13;
			this.lblVentas.Text = "Ventas:";
			this.lblVentas.Click += new System.EventHandler(this.lblVentas_Click);
			// 
			// FrmPrincipal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(918, 533);
			this.Controls.Add(this.lblVentas);
			this.Controls.Add(this.dtgvVentas);
			this.Controls.Add(this.btnModificarCliente);
			this.Controls.Add(this.dtgvClientes);
			this.Controls.Add(this.lblClientes);
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
			((System.ComponentModel.ISupportInitialize)(this.dtgvVentas)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarCliente;
        private System.Windows.Forms.Button btnAgregarPedido;
        private System.Windows.Forms.Button btnBorrarCliente;
        private System.Windows.Forms.Button btnPagarPend;
		private System.Windows.Forms.Button btnModificarCliente;
		private System.Windows.Forms.Label lblClientes;
		private System.Windows.Forms.DataGridView dtgvClientes;
		private System.Windows.Forms.DataGridView dtgvVentas;
		private System.Windows.Forms.Label lblVentas;
	}
}

