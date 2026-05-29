namespace AplicativoAgendaDeContatos.Views
{
    partial class FormCadastro
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
            lblNome = new Label();
            lblTelefone = new Label();
            lblEmail = new Label();
            lblCidade = new Label();
            txtNome = new TextBox();
            txtTelefone = new TextBox();
            textEmail = new TextBox();
            txtCidade = new TextBox();
            cmbTipo = new ComboBox();
            lblTipo = new Label();
            lblExtra = new Label();
            txtExtra = new TextBox();
            btnSalvar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.ForeColor = Color.Gray;
            lblNome.Location = new Point(20, 20);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(53, 20);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome:";
            // 
            // lblTelefone
            // 
            lblTelefone.AutoSize = true;
            lblTelefone.ForeColor = Color.Gray;
            lblTelefone.Location = new Point(20, 62);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(69, 20);
            lblTelefone.TabIndex = 1;
            lblTelefone.Text = "Telefone:";
            lblTelefone.Click += lblTelefone_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.ForeColor = Color.Gray;
            lblEmail.Location = new Point(20, 104);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(55, 20);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "E-mail:";
            // 
            // lblCidade
            // 
            lblCidade.AutoSize = true;
            lblCidade.ForeColor = Color.Gray;
            lblCidade.Location = new Point(20, 146);
            lblCidade.Name = "lblCidade";
            lblCidade.Size = new Size(59, 20);
            lblCidade.TabIndex = 3;
            lblCidade.Text = "Cidade:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(120, 20);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(125, 27);
            txtNome.TabIndex = 4;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(120, 62);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(125, 27);
            txtTelefone.TabIndex = 5;
            // 
            // textEmail
            // 
            textEmail.Location = new Point(120, 104);
            textEmail.Name = "textEmail";
            textEmail.Size = new Size(125, 27);
            textEmail.TabIndex = 6;
            // 
            // txtCidade
            // 
            txtCidade.Location = new Point(120, 146);
            txtCidade.Name = "txtCidade";
            txtCidade.Size = new Size(125, 27);
            txtCidade.TabIndex = 7;
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(120, 188);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(220, 28);
            cmbTipo.TabIndex = 8;
            cmbTipo.SelectedIndexChanged += cmbTipo_SelectedIndexChanged;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.ForeColor = Color.Gray;
            lblTipo.Location = new Point(20, 191);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(42, 20);
            lblTipo.TabIndex = 9;
            lblTipo.Text = "Tipo:";
            // 
            // lblExtra
            // 
            lblExtra.AutoSize = true;
            lblExtra.ForeColor = Color.Gray;
            lblExtra.Location = new Point(20, 233);
            lblExtra.Name = "lblExtra";
            lblExtra.Size = new Size(69, 20);
            lblExtra.TabIndex = 10;
            lblExtra.Text = "Apelido: ";
            // 
            // txtExtra
            // 
            txtExtra.Location = new Point(120, 230);
            txtExtra.Name = "txtExtra";
            txtExtra.PlaceholderText = "Apelido";
            txtExtra.Size = new Size(220, 27);
            txtExtra.TabIndex = 11;
            // 
            // btnSalvar
            // 
            btnSalvar.BackColor = Color.FromArgb(83, 74, 183);
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.ForeColor = Color.White;
            btnSalvar.Location = new Point(120, 285);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(100, 34);
            btnSalvar.TabIndex = 12;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(234, 285);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 34);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormCadastro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(362, 333);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(txtExtra);
            Controls.Add(lblExtra);
            Controls.Add(lblTipo);
            Controls.Add(cmbTipo);
            Controls.Add(txtCidade);
            Controls.Add(textEmail);
            Controls.Add(txtTelefone);
            Controls.Add(txtNome);
            Controls.Add(lblCidade);
            Controls.Add(lblEmail);
            Controls.Add(lblTelefone);
            Controls.Add(lblNome);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCadastro";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Contato";
            Load += FormCadastro_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNome;
        private Label lblTelefone;
        private Label lblEmail;
        private Label lblCidade;
        private TextBox txtNome;
        private TextBox txtTelefone;
        private TextBox textEmail;
        private TextBox txtCidade;
        private ComboBox cmbTipo;
        private Label lblTipo;
        private Label lblExtra;
        private TextBox txtExtra;
        private Button btnSalvar;
        private Button btnCancelar;
    }
}