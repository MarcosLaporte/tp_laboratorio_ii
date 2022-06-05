
namespace VistaForm
{
    partial class FrmMontoSenia
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
            this.label1 = new System.Windows.Forms.Label();
            this.rBtnCompleto = new System.Windows.Forms.RadioButton();
            this.rBtnNada = new System.Windows.Forms.RadioButton();
            this.rBtnPersonalizado = new System.Windows.Forms.RadioButton();
            this.tBxSenia = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione el monto de seña:";
            // 
            // rBtnCompleto
            // 
            this.rBtnCompleto.AutoSize = true;
            this.rBtnCompleto.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rBtnCompleto.Location = new System.Drawing.Point(42, 53);
            this.rBtnCompleto.Name = "rBtnCompleto";
            this.rBtnCompleto.Size = new System.Drawing.Size(106, 27);
            this.rBtnCompleto.TabIndex = 1;
            this.rBtnCompleto.TabStop = true;
            this.rBtnCompleto.Text = "Completo";
            this.rBtnCompleto.UseVisualStyleBackColor = true;
            // 
            // rBtnNada
            // 
            this.rBtnNada.AutoSize = true;
            this.rBtnNada.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rBtnNada.Location = new System.Drawing.Point(42, 92);
            this.rBtnNada.Name = "rBtnNada";
            this.rBtnNada.Size = new System.Drawing.Size(72, 27);
            this.rBtnNada.TabIndex = 2;
            this.rBtnNada.TabStop = true;
            this.rBtnNada.Text = "Nada";
            this.rBtnNada.UseVisualStyleBackColor = true;
            // 
            // rBtnPersonalizado
            // 
            this.rBtnPersonalizado.AutoSize = true;
            this.rBtnPersonalizado.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rBtnPersonalizado.Location = new System.Drawing.Point(42, 131);
            this.rBtnPersonalizado.Name = "rBtnPersonalizado";
            this.rBtnPersonalizado.Size = new System.Drawing.Size(140, 27);
            this.rBtnPersonalizado.TabIndex = 3;
            this.rBtnPersonalizado.TabStop = true;
            this.rBtnPersonalizado.Text = "Personalizado:";
            this.rBtnPersonalizado.UseVisualStyleBackColor = true;
            // 
            // tBxSenia
            // 
            this.tBxSenia.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tBxSenia.Location = new System.Drawing.Point(188, 131);
            this.tBxSenia.Name = "tBxSenia";
            this.tBxSenia.Size = new System.Drawing.Size(110, 30);
            this.tBxSenia.TabIndex = 4;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(12, 183);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(140, 67);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(185, 183);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 67);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmMontoSenia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 262);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.tBxSenia);
            this.Controls.Add(this.rBtnPersonalizado);
            this.Controls.Add(this.rBtnNada);
            this.Controls.Add(this.rBtnCompleto);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMontoSenia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMontoSenia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rBtnCompleto;
        private System.Windows.Forms.RadioButton rBtnNada;
        private System.Windows.Forms.RadioButton rBtnPersonalizado;
        private System.Windows.Forms.TextBox tBxSenia;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}