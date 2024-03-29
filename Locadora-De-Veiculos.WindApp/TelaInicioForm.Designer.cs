﻿namespace Locadora_De_Veiculos.WindApp
{
    partial class TelaInicioForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaInicioForm));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taxaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FuncionarioMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CatergoriasMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CondutoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veiculosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planosDeCobrançaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locacaoDevolucaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelRodape = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelRegistros = new System.Windows.Forms.Panel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbox = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnInserir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.btnDevolver = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.labelTipoCadastro = new System.Windows.Forms.ToolStripLabel();
            this.menu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.DimGray;
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(800, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taxaMenuItem,
            this.ClientesMenuItem,
            this.FuncionarioMenuItem,
            this.CatergoriasMenuItem,
            this.CondutoresToolStripMenuItem,
            this.veiculosToolStripMenuItem,
            this.planosDeCobrançaToolStripMenuItem,
            this.locacaoDevolucaoToolStripMenuItem});
            this.cadastrosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // taxaMenuItem
            // 
            this.taxaMenuItem.Name = "taxaMenuItem";
            this.taxaMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.taxaMenuItem.Size = new System.Drawing.Size(205, 22);
            this.taxaMenuItem.Text = "Taxas";
            this.taxaMenuItem.Click += new System.EventHandler(this.TaxasMenuItem_Click);
            // 
            // ClientesMenuItem
            // 
            this.ClientesMenuItem.Name = "ClientesMenuItem";
            this.ClientesMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.ClientesMenuItem.Size = new System.Drawing.Size(205, 22);
            this.ClientesMenuItem.Text = "Clientes";
            this.ClientesMenuItem.Click += new System.EventHandler(this.ClientesMenuItem_Click);
            // 
            // FuncionarioMenuItem
            // 
            this.FuncionarioMenuItem.Name = "FuncionarioMenuItem";
            this.FuncionarioMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.FuncionarioMenuItem.Size = new System.Drawing.Size(205, 22);
            this.FuncionarioMenuItem.Text = "Funcionários";
            this.FuncionarioMenuItem.Click += new System.EventHandler(this.FuncionarioMenuItem_Click);
            // 
            // CatergoriasMenuItem
            // 
            this.CatergoriasMenuItem.Name = "CatergoriasMenuItem";
            this.CatergoriasMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.CatergoriasMenuItem.Size = new System.Drawing.Size(205, 22);
            this.CatergoriasMenuItem.Text = "Catergorias";
            this.CatergoriasMenuItem.Click += new System.EventHandler(this.CatergoriasMenuItem_Click);
            // 
            // CondutoresToolStripMenuItem
            // 
            this.CondutoresToolStripMenuItem.Name = "CondutoresToolStripMenuItem";
            this.CondutoresToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.CondutoresToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.CondutoresToolStripMenuItem.Text = "Condutores";
            this.CondutoresToolStripMenuItem.Click += new System.EventHandler(this.CondutoresToolStripMenuItem_Click);
            // 
            // veiculosToolStripMenuItem
            // 
            this.veiculosToolStripMenuItem.Name = "veiculosToolStripMenuItem";
            this.veiculosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.veiculosToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.veiculosToolStripMenuItem.Text = "Veiculos";
            this.veiculosToolStripMenuItem.Click += new System.EventHandler(this.veiculosToolStripMenuItem_Click);
            // 
            // planosDeCobrançaToolStripMenuItem
            // 
            this.planosDeCobrançaToolStripMenuItem.Name = "planosDeCobrançaToolStripMenuItem";
            this.planosDeCobrançaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.planosDeCobrançaToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.planosDeCobrançaToolStripMenuItem.Text = "Planos de Cobrança";
            this.planosDeCobrançaToolStripMenuItem.Click += new System.EventHandler(this.planosDeCobrançaToolStripMenuItem_Click);
            // 
            // locacaoDevolucaoToolStripMenuItem
            // 
            this.locacaoDevolucaoToolStripMenuItem.Name = "locacaoDevolucaoToolStripMenuItem";
            this.locacaoDevolucaoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.locacaoDevolucaoToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.locacaoDevolucaoToolStripMenuItem.Text = "Locacao e Devolucao";
            this.locacaoDevolucaoToolStripMenuItem.Click += new System.EventHandler(this.locacaoDevolucaoToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Teal;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelRodape});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelRodape
            // 
            this.labelRodape.ForeColor = System.Drawing.Color.White;
            this.labelRodape.Name = "labelRodape";
            this.labelRodape.Size = new System.Drawing.Size(52, 17);
            this.labelRodape.Text = "[rodapé]";
            // 
            // panelRegistros
            // 
            this.panelRegistros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRegistros.Location = new System.Drawing.Point(0, 58);
            this.panelRegistros.Name = "panelRegistros";
            this.panelRegistros.Size = new System.Drawing.Size(800, 370);
            this.panelRegistros.TabIndex = 4;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 34);
            // 
            // toolbox
            // 
            this.toolbox.BackColor = System.Drawing.Color.Teal;
            this.toolbox.Enabled = false;
            this.toolbox.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolbox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.btnInserir,
            this.toolStripSeparator6,
            this.btnEditar,
            this.toolStripSeparator7,
            this.btnExcluir,
            this.toolStripSeparator2,
            this.btnDevolver,
            this.toolStripSeparator1,
            this.labelTipoCadastro});
            this.toolbox.Location = new System.Drawing.Point(0, 24);
            this.toolbox.Name = "toolbox";
            this.toolbox.Size = new System.Drawing.Size(800, 34);
            this.toolbox.TabIndex = 2;
            this.toolbox.Text = "toolStrip1";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 34);
            // 
            // btnInserir
            // 
            this.btnInserir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnInserir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnInserir.ForeColor = System.Drawing.Color.White;
            this.btnInserir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnInserir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Padding = new System.Windows.Forms.Padding(5);
            this.btnInserir.Size = new System.Drawing.Size(61, 31);
            this.btnInserir.Text = "Inserir";
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 34);
            // 
            // btnEditar
            // 
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Padding = new System.Windows.Forms.Padding(5);
            this.btnEditar.Size = new System.Drawing.Size(58, 31);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 34);
            // 
            // btnExcluir
            // 
            this.btnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExcluir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExcluir.ForeColor = System.Drawing.Color.White;
            this.btnExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Padding = new System.Windows.Forms.Padding(5);
            this.btnExcluir.Size = new System.Drawing.Size(63, 31);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnDevolver
            // 
            this.btnDevolver.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDevolver.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDevolver.ForeColor = System.Drawing.Color.White;
            this.btnDevolver.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDevolver.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Padding = new System.Windows.Forms.Padding(5);
            this.btnDevolver.Size = new System.Drawing.Size(77, 31);
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // labelTipoCadastro
            // 
            this.labelTipoCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTipoCadastro.ForeColor = System.Drawing.Color.White;
            this.labelTipoCadastro.Name = "labelTipoCadastro";
            this.labelTipoCadastro.Size = new System.Drawing.Size(122, 31);
            this.labelTipoCadastro.Text = "[tipoCadastro]";
            // 
            // TelaInicioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelRegistros);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolbox);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaInicioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locadora De Veículos";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolbox.ResumeLayout(false);
            this.toolbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taxaMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClientesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FuncionarioMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CatergoriasMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelRodape;
        private System.Windows.Forms.Panel panelRegistros;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStrip toolbox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnInserir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStripLabel labelTipoCadastro;
        private System.Windows.Forms.ToolStripMenuItem CondutoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem veiculosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planosDeCobrançaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locacaoDevolucaoToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnDevolver;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}