namespace AplicativoAgendaDeContatos
{
    partial class FormCadastro
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtNome = new TextBox();
            txtTelefone = new TextBox();
            txtEmail = new TextBox();
            txtCidade = new TextBox();
            txtExtra = new TextBox();
            cmbTipo = new ComboBox();
            lblNome = new Label();
            lblTelefone = new Label();
            lblEmail = new Label();
            lblCidade = new Label();
            lblTipo = new Label();
            lblExtra = new Label();
            btnSalvar = new Button();
            btnCancelar = new Button();

            SuspendLayout();

            // ── Form ──
            Text = "Cadastro de Contato";
            Size = new Size(380, 380);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9.5f);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Load += FormCadastro_Load;

            int y = 20;
            int labelX = 20;
            int inputX = 120;
            int inputW = 220;
            int espaco = 42;

            void AdicionarCampo(Label lbl, string texto, Control input, ref int posY)
            {
                lbl.Text = texto;
                lbl.Location = new Point(labelX, posY + 3);
                lbl.Size = new Size(90, 22);
                lbl.ForeColor = Color.Gray;

                input.Location = new Point(inputX, posY);
                input.Size = new Size(inputW, 26);

                Controls.Add(lbl);
                Controls.Add(input);
                posY += espaco;
            }

            AdicionarCampo(lblNome, "Nome:", txtNome, ref y);
            AdicionarCampo(lblTelefone, "Telefone:", txtTelefone, ref y);
            AdicionarCampo(lblEmail, "E-mail:", txtEmail, ref y);
            AdicionarCampo(lblCidade, "Cidade:", txtCidade, ref y);

            // ComboBox tipo
            lblTipo.Text = "Tipo:";
            lblTipo.Location = new Point(labelX, y + 3);
            lblTipo.Size = new Size(90, 22);
            lblTipo.ForeColor = Color.Gray;
            cmbTipo.Location = new Point(inputX, y);
            cmbTipo.Size = new Size(inputW, 26);
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.SelectedIndexChanged += cmbTipo_SelectedIndexChanged;
            Controls.Add(lblTipo);
            Controls.Add(cmbTipo);
            y += espaco;

            txtExtra.PlaceholderText = "Apelido";
            AdicionarCampo(lblExtra, "Apelido:", txtExtra, ref y);

            // Botões
            btnSalvar.Location = new Point(inputX, y);
            btnSalvar.Size = new Size(100, 34);
            btnSalvar.Text = "Salvar";
            btnSalvar.BackColor = Color.FromArgb(83, 74, 183);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.FlatAppearance.BorderSize = 0;
            btnSalvar.Click += btnSalvar_Click;

            btnCancelar.Location = new Point(inputX + 114, y);
            btnCancelar.Size = new Size(100, 34);
            btnCancelar.Text = "Cancelar";
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Click += btnCancelar_Click;

            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);

            ResumeLayout(false);
        }

        private TextBox txtNome, txtTelefone, txtEmail, txtCidade, txtExtra;
        private ComboBox cmbTipo;
        private Label lblNome, lblTelefone, lblEmail, lblCidade, lblTipo, lblExtra;
        private Button btnSalvar, btnCancelar;
    }
}