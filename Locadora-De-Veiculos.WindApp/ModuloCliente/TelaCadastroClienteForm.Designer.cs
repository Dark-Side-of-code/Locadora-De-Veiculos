namespace Locadora_De_Veiculos.WindApp.ModuloCliente
{
    partial class TelaCadastroClienteForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.rb_F = new System.Windows.Forms.RadioButton();
            this.rb_J = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMask_Cpf_Cnpj = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.txtMask_Fone = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Cadastrar = new System.Windows.Forms.Button();
            this.btn_Voltar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Nome = new System.Windows.Forms.TextBox();
            this.groupBoxTipoCliente = new System.Windows.Forms.GroupBox();
            this.groupBoxTipoCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(109, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro De Cliente";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Location = new System.Drawing.Point(-3, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 30);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo de Cliente:";
            // 
            // rb_F
            // 
            this.rb_F.AutoSize = true;
            this.rb_F.Location = new System.Drawing.Point(6, 14);
            this.rb_F.Name = "rb_F";
            this.rb_F.Size = new System.Drawing.Size(93, 19);
            this.rb_F.TabIndex = 0;
            this.rb_F.TabStop = true;
            this.rb_F.Text = "Pessoa Física";
            this.rb_F.UseVisualStyleBackColor = true;
            // 
            // rb_J
            // 
            this.rb_J.AutoSize = true;
            this.rb_J.Location = new System.Drawing.Point(118, 15);
            this.rb_J.Name = "rb_J";
            this.rb_J.Size = new System.Drawing.Size(104, 19);
            this.rb_J.TabIndex = 1;
            this.rb_J.TabStop = true;
            this.rb_J.Text = "Pessoa Jurídica";
            this.rb_J.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "CPF/CNPJ:";
            // 
            // txtMask_Cpf_Cnpj
            // 
            this.txtMask_Cpf_Cnpj.Location = new System.Drawing.Point(151, 191);
            this.txtMask_Cpf_Cnpj.Name = "txtMask_Cpf_Cnpj";
            this.txtMask_Cpf_Cnpj.Size = new System.Drawing.Size(227, 23);
            this.txtMask_Cpf_Cnpj.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(106, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Email:";
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(151, 249);
            this.txt_Email.MaxLength = 200;
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(227, 23);
            this.txt_Email.TabIndex = 3;
            // 
            // txtMask_Fone
            // 
            this.txtMask_Fone.Location = new System.Drawing.Point(151, 278);
            this.txtMask_Fone.Mask = "(00) 00000-0000";
            this.txtMask_Fone.Name = "txtMask_Fone";
            this.txtMask_Fone.Size = new System.Drawing.Size(227, 23);
            this.txtMask_Fone.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(109, 283);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Fone:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(56, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(191, 21);
            this.label8.TabIndex = 15;
            this.label8.Text = "Informações do Cliente:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.Location = new System.Drawing.Point(-3, 331);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(482, 10);
            this.panel2.TabIndex = 17;
            // 
            // btn_Cadastrar
            // 
            this.btn_Cadastrar.BackColor = System.Drawing.Color.Teal;
            this.btn_Cadastrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cadastrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Cadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Cadastrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Cadastrar.ForeColor = System.Drawing.Color.White;
            this.btn_Cadastrar.Location = new System.Drawing.Point(224, 359);
            this.btn_Cadastrar.Name = "btn_Cadastrar";
            this.btn_Cadastrar.Size = new System.Drawing.Size(154, 36);
            this.btn_Cadastrar.TabIndex = 9;
            this.btn_Cadastrar.Text = "Cadastarar";
            this.btn_Cadastrar.UseVisualStyleBackColor = false;
            this.btn_Cadastrar.Click += new System.EventHandler(this.btn_Cadastrar_Click);
            // 
            // btn_Voltar
            // 
            this.btn_Voltar.BackColor = System.Drawing.Color.Teal;
            this.btn_Voltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Voltar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Voltar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Voltar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Voltar.ForeColor = System.Drawing.Color.White;
            this.btn_Voltar.Location = new System.Drawing.Point(91, 359);
            this.btn_Voltar.Name = "btn_Voltar";
            this.btn_Voltar.Size = new System.Drawing.Size(136, 36);
            this.btn_Voltar.TabIndex = 8;
            this.btn_Voltar.Text = "Voltar";
            this.btn_Voltar.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(99, 224);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 15);
            this.label10.TabIndex = 20;
            this.label10.Text = "Nome :";
            // 
            // txt_Nome
            // 
            this.txt_Nome.Location = new System.Drawing.Point(151, 220);
            this.txt_Nome.MaxLength = 300;
            this.txt_Nome.Name = "txt_Nome";
            this.txt_Nome.Size = new System.Drawing.Size(227, 23);
            this.txt_Nome.TabIndex = 5;
            // 
            // groupBoxTipoCliente
            // 
            this.groupBoxTipoCliente.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxTipoCliente.Controls.Add(this.rb_J);
            this.groupBoxTipoCliente.Controls.Add(this.rb_F);
            this.groupBoxTipoCliente.Location = new System.Drawing.Point(151, 145);
            this.groupBoxTipoCliente.Name = "groupBoxTipoCliente";
            this.groupBoxTipoCliente.Size = new System.Drawing.Size(227, 40);
            this.groupBoxTipoCliente.TabIndex = 1;
            this.groupBoxTipoCliente.TabStop = false;
            // 
            // TelaCadastroClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(460, 416);
            this.Controls.Add(this.groupBoxTipoCliente);
            this.Controls.Add(this.txt_Nome);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn_Voltar);
            this.Controls.Add(this.btn_Cadastrar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMask_Fone);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMask_Cpf_Cnpj);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "TelaCadastroClienteForm";
            this.groupBoxTipoCliente.ResumeLayout(false);
            this.groupBoxTipoCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rb_F;
        private System.Windows.Forms.RadioButton rb_J;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtMask_Cpf_Cnpj;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.MaskedTextBox txtMask_Fone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Cadastrar;
        private System.Windows.Forms.Button btn_Voltar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Nome;
        private System.Windows.Forms.GroupBox groupBoxTipoCliente;
    }
}
