
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
			this.btnHadrdcode = new System.Windows.Forms.Button();
			this.lBxCompras = new System.Windows.Forms.ListBox();
			this.lBxClientes = new System.Windows.Forms.ListBox();
			this.rTBxClientes = new System.Windows.Forms.RichTextBox();
			this.rTBxCompras = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// btnAgregarCliente
			// 
			this.btnAgregarCliente.Location = new System.Drawing.Point(12, 418);
			this.btnAgregarCliente.Name = "btnAgregarCliente";
			this.btnAgregarCliente.Size = new System.Drawing.Size(224, 85);
			this.btnAgregarCliente.TabIndex = 0;
			this.btnAgregarCliente.Text = "Agregar cliente";
			this.btnAgregarCliente.UseVisualStyleBackColor = true;
			this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
			// 
			// btnAgregarPedido
			// 
			this.btnAgregarPedido.Location = new System.Drawing.Point(242, 418);
			this.btnAgregarPedido.Name = "btnAgregarPedido";
			this.btnAgregarPedido.Size = new System.Drawing.Size(224, 85);
			this.btnAgregarPedido.TabIndex = 1;
			this.btnAgregarPedido.Text = "Agregar pedido";
			this.btnAgregarPedido.UseVisualStyleBackColor = true;
			this.btnAgregarPedido.Click += new System.EventHandler(this.btnAgregarPedido_Click);
			// 
			// btnBorrarCliente
			// 
			this.btnBorrarCliente.Location = new System.Drawing.Point(472, 418);
			this.btnBorrarCliente.Name = "btnBorrarCliente";
			this.btnBorrarCliente.Size = new System.Drawing.Size(224, 85);
			this.btnBorrarCliente.TabIndex = 2;
			this.btnBorrarCliente.Text = "Eliminar cliente";
			this.btnBorrarCliente.UseVisualStyleBackColor = true;
			this.btnBorrarCliente.Click += new System.EventHandler(this.btnBorrarCliente_Click);
			// 
			// btnHadrdcode
			// 
			this.btnHadrdcode.Location = new System.Drawing.Point(702, 418);
			this.btnHadrdcode.Name = "btnHadrdcode";
			this.btnHadrdcode.Size = new System.Drawing.Size(224, 85);
			this.btnHadrdcode.TabIndex = 3;
			this.btnHadrdcode.Text = "Agregar clientes existentes";
			this.btnHadrdcode.UseVisualStyleBackColor = true;
			this.btnHadrdcode.Click += new System.EventHandler(this.btnHadrdcode_Click);
			// 
			// lBxCompras
			// 
			this.lBxCompras.FormattingEnabled = true;
			this.lBxCompras.ItemHeight = 20;
			this.lBxCompras.Location = new System.Drawing.Point(12, 8);
			this.lBxCompras.Name = "lBxCompras";
			this.lBxCompras.Size = new System.Drawing.Size(313, 404);
			this.lBxCompras.TabIndex = 4;
			this.lBxCompras.TabStop = false;
			this.lBxCompras.Click += new System.EventHandler(this.lBxCompras_Click);
			// 
			// lBxClientes
			// 
			this.lBxClientes.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lBxClientes.FormattingEnabled = true;
			this.lBxClientes.ItemHeight = 25;
			this.lBxClientes.Location = new System.Drawing.Point(662, 8);
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
			this.rTBxClientes.Location = new System.Drawing.Point(662, 268);
			this.rTBxClientes.Name = "rTBxClientes";
			this.rTBxClientes.ReadOnly = true;
			this.rTBxClientes.Size = new System.Drawing.Size(262, 144);
			this.rTBxClientes.TabIndex = 6;
			this.rTBxClientes.TabStop = false;
			this.rTBxClientes.Text = "";
			// 
			// rTBxCompras
			// 
			this.rTBxCompras.Enabled = false;
			this.rTBxCompras.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.rTBxCompras.Location = new System.Drawing.Point(336, 8);
			this.rTBxCompras.Name = "rTBxCompras";
			this.rTBxCompras.ReadOnly = true;
			this.rTBxCompras.Size = new System.Drawing.Size(297, 404);
			this.rTBxCompras.TabIndex = 7;
			this.rTBxCompras.TabStop = false;
			this.rTBxCompras.Text = "";
			// 
			// FrmPrincipal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(936, 510);
			this.Controls.Add(this.rTBxCompras);
			this.Controls.Add(this.rTBxClientes);
			this.Controls.Add(this.lBxClientes);
			this.Controls.Add(this.lBxCompras);
			this.Controls.Add(this.btnHadrdcode);
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

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarCliente;
        private System.Windows.Forms.Button btnAgregarPedido;
        private System.Windows.Forms.Button btnBorrarCliente;
        private System.Windows.Forms.Button btnHadrdcode;
        private System.Windows.Forms.ListBox lBxCompras;
        private System.Windows.Forms.ListBox lBxClientes;
        private System.Windows.Forms.RichTextBox rTBxClientes;
        private System.Windows.Forms.RichTextBox rTBxCompras;
    }
}

