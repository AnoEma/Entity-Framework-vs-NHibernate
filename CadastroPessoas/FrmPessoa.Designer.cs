namespace CadastroPessoas
{
    partial class FrmPessoa
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
            this.dgvPessoa = new System.Windows.Forms.DataGridView();
            this.bntAdicionarPessoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPessoa)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPessoa
            // 
            this.dgvPessoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPessoa.Location = new System.Drawing.Point(13, 13);
            this.dgvPessoa.Name = "dgvPessoa";
            this.dgvPessoa.Size = new System.Drawing.Size(472, 150);
            this.dgvPessoa.TabIndex = 0;
            // 
            // bntAdicionarPessoa
            // 
            this.bntAdicionarPessoa.Location = new System.Drawing.Point(13, 179);
            this.bntAdicionarPessoa.Name = "bntAdicionarPessoa";
            this.bntAdicionarPessoa.Size = new System.Drawing.Size(75, 23);
            this.bntAdicionarPessoa.TabIndex = 1;
            this.bntAdicionarPessoa.Text = "Adicionar";
            this.bntAdicionarPessoa.UseVisualStyleBackColor = true;
            this.bntAdicionarPessoa.Click += new System.EventHandler(this.bntAdicionarPessoa_Click);
            // 
            // FrmPessoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 225);
            this.Controls.Add(this.bntAdicionarPessoa);
            this.Controls.Add(this.dgvPessoa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmPessoa";
            this.Text = "Cadastro de pessoas";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPessoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPessoa;
        private System.Windows.Forms.Button bntAdicionarPessoa;
    }
}

