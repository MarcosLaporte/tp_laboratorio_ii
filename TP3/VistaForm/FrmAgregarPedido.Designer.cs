
namespace VistaForm
{
    partial class FrmAgregarPedido
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
            this.lblTipoProducto = new System.Windows.Forms.Label();
            this.cBxTipo = new System.Windows.Forms.ComboBox();
            this.cBxProducto = new System.Windows.Forms.ComboBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.rTBxPedido = new System.Windows.Forms.RichTextBox();
            this.lblPedido = new System.Windows.Forms.Label();
            this.btnRePedido = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblPrecioUnidad = new System.Windows.Forms.Label();
            this.lblPrecioTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTipoProducto
            // 
            this.lblTipoProducto.AutoSize = true;
            this.lblTipoProducto.Location = new System.Drawing.Point(41, 23);
            this.lblTipoProducto.Name = "lblTipoProducto";
            this.lblTipoProducto.Size = new System.Drawing.Size(125, 20);
            this.lblTipoProducto.TabIndex = 0;
            this.lblTipoProducto.Text = "Tipo de producto";
            // 
            // cBxTipo
            // 
            this.cBxTipo.FormattingEnabled = true;
            this.cBxTipo.Location = new System.Drawing.Point(41, 46);
            this.cBxTipo.Name = "cBxTipo";
            this.cBxTipo.Size = new System.Drawing.Size(195, 28);
            this.cBxTipo.TabIndex = 1;
            this.cBxTipo.SelectedValueChanged += new System.EventHandler(this.cBxTipo_SelectedValueChanged);
            // 
            // cBxProducto
            // 
            this.cBxProducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cBxProducto.FormattingEnabled = true;
            this.cBxProducto.Location = new System.Drawing.Point(41, 103);
            this.cBxProducto.Name = "cBxProducto";
            this.cBxProducto.Size = new System.Drawing.Size(195, 28);
            this.cBxProducto.TabIndex = 3;
            this.cBxProducto.Text = "Seleccione un tipo!";
            this.cBxProducto.SelectedValueChanged += new System.EventHandler(this.cBxProducto_SelectedValueChanged);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(41, 80);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(69, 20);
            this.lblProducto.TabIndex = 2;
            this.lblProducto.Text = "Producto";
            // 
            // lblUnidad
            // 
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUnidad.Location = new System.Drawing.Point(37, 180);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(78, 25);
            this.lblUnidad.TabIndex = 8;
            this.lblUnidad.Text = "Unidad:";
            this.lblUnidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(281, 23);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(195, 77);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(281, 116);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(195, 77);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // rTBxPedido
            // 
            this.rTBxPedido.Location = new System.Drawing.Point(20, 316);
            this.rTBxPedido.Name = "rTBxPedido";
            this.rTBxPedido.ReadOnly = true;
            this.rTBxPedido.Size = new System.Drawing.Size(483, 181);
            this.rTBxPedido.TabIndex = 13;
            this.rTBxPedido.TabStop = false;
            this.rTBxPedido.Text = "";
            // 
            // lblPedido
            // 
            this.lblPedido.AutoSize = true;
            this.lblPedido.Location = new System.Drawing.Point(20, 293);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(231, 20);
            this.lblPedido.TabIndex = 13;
            this.lblPedido.Text = "Descripción completa del pedido";
            // 
            // btnRePedido
            // 
            this.btnRePedido.Location = new System.Drawing.Point(281, 208);
            this.btnRePedido.Name = "btnRePedido";
            this.btnRePedido.Size = new System.Drawing.Size(195, 77);
            this.btnRePedido.TabIndex = 12;
            this.btnRePedido.Text = "Realizar pedido";
            this.btnRePedido.UseVisualStyleBackColor = true;
            this.btnRePedido.Click += new System.EventHandler(this.btnRePedido_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotal.Location = new System.Drawing.Point(37, 225);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(59, 25);
            this.lblTotal.TabIndex = 15;
            this.lblTotal.Text = "Total:";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPrecioUnidad
            // 
            this.lblPrecioUnidad.AutoSize = true;
            this.lblPrecioUnidad.Font = new System.Drawing.Font("Times New Roman", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblPrecioUnidad.Location = new System.Drawing.Point(141, 184);
            this.lblPrecioUnidad.Name = "lblPrecioUnidad";
            this.lblPrecioUnidad.Size = new System.Drawing.Size(81, 20);
            this.lblPrecioUnidad.TabIndex = 17;
            this.lblPrecioUnidad.Text = "________";
            this.lblPrecioUnidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPrecioTotal
            // 
            this.lblPrecioTotal.AutoSize = true;
            this.lblPrecioTotal.Font = new System.Drawing.Font("Times New Roman", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblPrecioTotal.Location = new System.Drawing.Point(141, 229);
            this.lblPrecioTotal.Name = "lblPrecioTotal";
            this.lblPrecioTotal.Size = new System.Drawing.Size(81, 20);
            this.lblPrecioTotal.TabIndex = 18;
            this.lblPrecioTotal.Text = "________";
            this.lblPrecioTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmAgregarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 519);
            this.ControlBox = false;
            this.Controls.Add(this.lblPrecioTotal);
            this.Controls.Add(this.lblPrecioUnidad);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnRePedido);
            this.Controls.Add(this.lblPedido);
            this.Controls.Add(this.rTBxPedido);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lblUnidad);
            this.Controls.Add(this.cBxProducto);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.cBxTipo);
            this.Controls.Add(this.lblTipoProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAgregarPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAgregarPedido";
            this.Load += new System.EventHandler(this.FrmAgregarPedido_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTipoProducto;
        private System.Windows.Forms.ComboBox cBxTipo;
        private System.Windows.Forms.ComboBox cBxProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.RichTextBox rTBxPedido;
        private System.Windows.Forms.Label lblPedido;
        private System.Windows.Forms.Button btnRePedido;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPrecioUnidad;
        private System.Windows.Forms.Label lblPrecioTotal;
    }
}