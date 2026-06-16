namespace AplicativoAgendaDeContatos.Views
{
    partial class FormPrincipal
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
            pnlEsquerda = new Panel();
            btnNovo = new Button();
            lstContatos = new ListBox();
            cmbFiltro = new ComboBox();
            cmbBusca = new ComboBox();
            textBusca = new TextBox();
            pnlDireita = new Panel();
            btnExcluir = new Button();
            btnEditar = new Button();
            lblExtraValor = new Label();
            lblExtraLabel = new Label();
            lblTipoValor = new Label();
            lblTipoLabel = new Label();
            lblCidadeValor = new Label();
            lblCidadeLabel = new Label();
            lblEmailValor = new Label();
            lblEmailLabel = new Label();
            lblTelefoneValor = new Label();
            lblTelefoneLabel = new Label();
            lblNomeValor = new Label();
            LblNomeLabel = new Label();
            pnlEsquerda.SuspendLayout();
            pnlDireita.SuspendLayout();
            SuspendLayout();
            // 
            // pnlEsquerda
            // 
            pnlEsquerda.BackColor = Color.White;
            pnlEsquerda.BorderStyle = BorderStyle.FixedSingle;
            pnlEsquerda.Controls.Add(btnNovo);
            pnlEsquerda.Controls.Add(lstContatos);
            pnlEsquerda.Controls.Add(cmbFiltro);
            pnlEsquerda.Controls.Add(cmbBusca);
            pnlEsquerda.Controls.Add(textBusca);
            pnlEsquerda.Location = new Point(10, 10);
            pnlEsquerda.Name = "pnlEsquerda";
            pnlEsquerda.Size = new Size(260, 480);
            pnlEsquerda.TabIndex = 0;
            // 
            // btnNovo
            // 
            btnNovo.BackColor = Color.FromArgb(83, 74, 183);
            btnNovo.FlatStyle = FlatStyle.Flat;
            btnNovo.ForeColor = Color.White;
            btnNovo.Location = new Point(10, 402);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(238, 34);
            btnNovo.TabIndex = 4;
            btnNovo.Text = "+ Novo Contato";
            btnNovo.UseVisualStyleBackColor = false;
            btnNovo.Click += btnNovo_Click;
            // 
            // lstContatos
            // 
            lstContatos.BorderStyle = BorderStyle.None;
            lstContatos.FormattingEnabled = true;
            lstContatos.Location = new Point(10, 82);
            lstContatos.Name = "lstContatos";
            lstContatos.Size = new Size(238, 300);
            lstContatos.TabIndex = 3;
            lstContatos.SelectedIndexChanged += lstContatos_SelectedIndexChanged;
            // 
            // cmbFiltro
            // 
            cmbFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltro.FormattingEnabled = true;
            cmbFiltro.Location = new Point(10, 46);
            cmbFiltro.Name = "cmbFiltro";
            cmbFiltro.Size = new Size(238, 28);
            cmbFiltro.TabIndex = 2;
            cmbFiltro.SelectedIndexChanged += cmbFiltro_SelectedIndexChanged;
            // 
            // cmbBusca
            // 
            cmbBusca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBusca.FormattingEnabled = true;
            cmbBusca.Items.AddRange(new object[] { "Nome", "Cidade" });
            cmbBusca.Location = new Point(164, 10);
            cmbBusca.Name = "cmbBusca";
            cmbBusca.Size = new Size(84, 28);
            cmbBusca.TabIndex = 1;
            cmbBusca.SelectedIndexChanged += cmbBusca_SelectedIndexChanged;
            // 
            // textBusca
            // 
            textBusca.Location = new Point(10, 10);
            textBusca.Name = "textBusca";
            textBusca.PlaceholderText = "Pesquisar...";
            textBusca.Size = new Size(150, 27);
            textBusca.TabIndex = 0;
            textBusca.TextChanged += textBusca_TextChanged;
            // 
            // pnlDireita
            // 
            pnlDireita.BackColor = Color.White;
            pnlDireita.BorderStyle = BorderStyle.FixedSingle;
            pnlDireita.Controls.Add(btnExcluir);
            pnlDireita.Controls.Add(btnEditar);
            pnlDireita.Controls.Add(lblExtraValor);
            pnlDireita.Controls.Add(lblExtraLabel);
            pnlDireita.Controls.Add(lblTipoValor);
            pnlDireita.Controls.Add(lblTipoLabel);
            pnlDireita.Controls.Add(lblCidadeValor);
            pnlDireita.Controls.Add(lblCidadeLabel);
            pnlDireita.Controls.Add(lblEmailValor);
            pnlDireita.Controls.Add(lblEmailLabel);
            pnlDireita.Controls.Add(lblTelefoneValor);
            pnlDireita.Controls.Add(lblTelefoneLabel);
            pnlDireita.Controls.Add(lblNomeValor);
            pnlDireita.Controls.Add(LblNomeLabel);
            pnlDireita.Location = new Point(280, 10);
            pnlDireita.Name = "pnlDireita";
            pnlDireita.Size = new Size(490, 480);
            pnlDireita.TabIndex = 1;
            // 
            // btnExcluir
            // 
            btnExcluir.Enabled = false;
            btnExcluir.FlatStyle = FlatStyle.Flat;
            btnExcluir.ForeColor = Color.Red;
            btnExcluir.Location = new Point(144, 420);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(110, 34);
            btnExcluir.TabIndex = 13;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnEditar
            // 
            btnEditar.Enabled = false;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.ForeColor = Color.Gray;
            btnEditar.Location = new Point(20, 420);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(110, 34);
            btnEditar.TabIndex = 12;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // lblExtraValor
            // 
            lblExtraValor.AutoSize = true;
            lblExtraValor.ForeColor = Color.FromArgb(30, 30, 30);
            lblExtraValor.Location = new Point(120, 200);
            lblExtraValor.Name = "lblExtraValor";
            lblExtraValor.Size = new Size(50, 20);
            lblExtraValor.TabIndex = 11;
            lblExtraValor.Text = "label1";
            // 
            // lblExtraLabel
            // 
            lblExtraLabel.AutoSize = true;
            lblExtraLabel.ForeColor = Color.Gray;
            lblExtraLabel.Location = new Point(20, 200);
            lblExtraLabel.Name = "lblExtraLabel";
            lblExtraLabel.Size = new Size(33, 20);
            lblExtraLabel.TabIndex = 10;
            lblExtraLabel.Text = "      ";
            // 
            // lblTipoValor
            // 
            lblTipoValor.AutoSize = true;
            lblTipoValor.ForeColor = Color.FromArgb(30, 30, 30);
            lblTipoValor.Location = new Point(120, 164);
            lblTipoValor.Name = "lblTipoValor";
            lblTipoValor.Size = new Size(50, 20);
            lblTipoValor.TabIndex = 9;
            lblTipoValor.Text = "label1";
            // 
            // lblTipoLabel
            // 
            lblTipoLabel.AutoSize = true;
            lblTipoLabel.ForeColor = Color.Gray;
            lblTipoLabel.Location = new Point(20, 164);
            lblTipoLabel.Name = "lblTipoLabel";
            lblTipoLabel.Size = new Size(42, 20);
            lblTipoLabel.TabIndex = 8;
            lblTipoLabel.Text = "Tipo:";
            lblTipoLabel.Click += lblTipoLabel_Click;
            // 
            // lblCidadeValor
            // 
            lblCidadeValor.AutoSize = true;
            lblCidadeValor.ForeColor = Color.FromArgb(30, 30, 30);
            lblCidadeValor.Location = new Point(120, 128);
            lblCidadeValor.Name = "lblCidadeValor";
            lblCidadeValor.Size = new Size(50, 20);
            lblCidadeValor.TabIndex = 7;
            lblCidadeValor.Text = "label1";
            // 
            // lblCidadeLabel
            // 
            lblCidadeLabel.AutoSize = true;
            lblCidadeLabel.ForeColor = Color.Gray;
            lblCidadeLabel.Location = new Point(20, 128);
            lblCidadeLabel.Name = "lblCidadeLabel";
            lblCidadeLabel.Size = new Size(59, 20);
            lblCidadeLabel.TabIndex = 6;
            lblCidadeLabel.Text = "Cidade:";
            // 
            // lblEmailValor
            // 
            lblEmailValor.AutoSize = true;
            lblEmailValor.ForeColor = Color.FromArgb(30, 30, 30);
            lblEmailValor.Location = new Point(120, 92);
            lblEmailValor.Name = "lblEmailValor";
            lblEmailValor.Size = new Size(50, 20);
            lblEmailValor.TabIndex = 5;
            lblEmailValor.Text = "label1";
            // 
            // lblEmailLabel
            // 
            lblEmailLabel.AutoSize = true;
            lblEmailLabel.ForeColor = Color.Gray;
            lblEmailLabel.Location = new Point(20, 92);
            lblEmailLabel.Name = "lblEmailLabel";
            lblEmailLabel.Size = new Size(55, 20);
            lblEmailLabel.TabIndex = 4;
            lblEmailLabel.Text = "E-mail:";
            // 
            // lblTelefoneValor
            // 
            lblTelefoneValor.AutoSize = true;
            lblTelefoneValor.ForeColor = Color.FromArgb(30, 30, 30);
            lblTelefoneValor.Location = new Point(120, 56);
            lblTelefoneValor.Name = "lblTelefoneValor";
            lblTelefoneValor.Size = new Size(50, 20);
            lblTelefoneValor.TabIndex = 3;
            lblTelefoneValor.Text = "label1";
            // 
            // lblTelefoneLabel
            // 
            lblTelefoneLabel.AutoSize = true;
            lblTelefoneLabel.ForeColor = Color.Gray;
            lblTelefoneLabel.Location = new Point(20, 56);
            lblTelefoneLabel.Name = "lblTelefoneLabel";
            lblTelefoneLabel.Size = new Size(69, 20);
            lblTelefoneLabel.TabIndex = 2;
            lblTelefoneLabel.Text = "Telefone:";
            // 
            // lblNomeValor
            // 
            lblNomeValor.AutoSize = true;
            lblNomeValor.ForeColor = Color.FromArgb(30, 30, 30);
            lblNomeValor.Location = new Point(120, 20);
            lblNomeValor.Name = "lblNomeValor";
            lblNomeValor.Size = new Size(50, 20);
            lblNomeValor.TabIndex = 1;
            lblNomeValor.Text = "label1";
            // 
            // LblNomeLabel
            // 
            LblNomeLabel.AutoSize = true;
            LblNomeLabel.ForeColor = Color.Gray;
            LblNomeLabel.Location = new Point(20, 20);
            LblNomeLabel.Name = "LblNomeLabel";
            LblNomeLabel.Size = new Size(53, 20);
            LblNomeLabel.TabIndex = 0;
            LblNomeLabel.Text = "Nome:";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 243);
            ClientSize = new Size(782, 473);
            Controls.Add(pnlDireita);
            Controls.Add(pnlEsquerda);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agenda de Contatos";
            Load += FormPrincipal_Load;
            pnlEsquerda.ResumeLayout(false);
            pnlEsquerda.PerformLayout();
            pnlDireita.ResumeLayout(false);
            pnlDireita.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlEsquerda;
        private ComboBox cmbBusca;
        private TextBox textBusca;
        private ComboBox cmbFiltro;
        private ListBox lstContatos;
        private Button btnNovo;
        private Panel pnlDireita;
        private Label lblTelefoneLabel;
        private Label lblNomeValor;
        private Label LblNomeLabel;
        private Label lblTipoLabel;
        private Label lblCidadeValor;
        private Label lblCidadeLabel;
        private Label lblEmailValor;
        private Label lblEmailLabel;
        private Label lblTelefoneValor;
        private Button btnExcluir;
        private Button btnEditar;
        private Label lblExtraValor;
        private Label lblExtraLabel;
        private Label lblTipoValor;
    }
}