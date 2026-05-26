namespace AplicativoAgendaDeContatos
{
    partial class FormPrincipal
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
            // ── Controles ──
            txtBusca = new TextBox();
            cmbBusca = new ComboBox();
            cmbFiltro = new ComboBox();
            lstContatos = new ListBox();
            btnNovo = new Button();

            lblNomeLabel = new Label();
            lblNomeValor = new Label();
            lblTelefoneLabel = new Label();
            lblTelefoneValor = new Label();
            lblEmailLabel = new Label();
            lblEmailValor = new Label();
            lblCidadeLabel = new Label();
            lblCidadeValor = new Label();
            lblTipoLabel = new Label();
            lblTipoValor = new Label();
            lblExtraLabel = new Label();
            lblExtraValor = new Label();

            btnEditar = new Button();
            btnExcluir = new Button();

            pnlEsquerda = new Panel();
            pnlDireita = new Panel();

            SuspendLayout();

            // ── Form ──
            Text = "Agenda de Contatos";
            Size = new Size(800, 520);
            MinimumSize = new Size(800, 520);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(245, 245, 243);
            Font = new Font("Segoe UI", 9.5f);
            Load += FormPrincipal_Load;

            // ── Painel esquerdo ──
            pnlEsquerda.Size = new Size(260, 480);
            pnlEsquerda.Location = new Point(10, 10);
            pnlEsquerda.BackColor = Color.White;
            pnlEsquerda.BorderStyle = BorderStyle.FixedSingle;

            txtBusca.Location = new Point(10, 10);
            txtBusca.Size = new Size(150, 26);
            txtBusca.PlaceholderText = "Pesquisar...";
            txtBusca.TextChanged += txtBusca_TextChanged;

            cmbBusca.Location = new Point(164, 10);
            cmbBusca.Size = new Size(84, 26);
            cmbBusca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBusca.Items.AddRange(new string[] { "Nome", "Cidade" });
            cmbBusca.SelectedIndex = 0;
            cmbBusca.SelectedIndexChanged += cmbBusca_SelectedIndexChanged;

            cmbFiltro.Location = new Point(10, 46);
            cmbFiltro.Size = new Size(238, 26);
            cmbFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltro.SelectedIndexChanged += cmbFiltro_SelectedIndexChanged;

            lstContatos.Location = new Point(10, 82);
            lstContatos.Size = new Size(238, 310);
            lstContatos.BorderStyle = BorderStyle.None;
            lstContatos.ItemHeight = 22;
            lstContatos.SelectedIndexChanged += lstContatos_SelectedIndexChanged;

            btnNovo.Location = new Point(10, 402);
            btnNovo.Size = new Size(238, 34);
            btnNovo.Text = "+ Novo Contato";
            btnNovo.BackColor = Color.FromArgb(83, 74, 183);
            btnNovo.ForeColor = Color.White;
            btnNovo.FlatStyle = FlatStyle.Flat;
            btnNovo.FlatAppearance.BorderSize = 0;
            btnNovo.Click += btnNovo_Click;

            pnlEsquerda.Controls.AddRange(new Control[]
                { txtBusca, cmbBusca, cmbFiltro, lstContatos, btnNovo });

            // ── Painel direito ──
            pnlDireita.Size = new Size(490, 480);
            pnlDireita.Location = new Point(280, 10);
            pnlDireita.BackColor = Color.White;
            pnlDireita.BorderStyle = BorderStyle.FixedSingle;
            pnlDireita.Padding = new Padding(20);

            int y = 20;
            int labelX = 20;
            int valorX = 120;
            int larguraValor = 340;
            int espacamento = 36;

            void AdicionarCampo(Label lbl, Label val, string texto, ref int posY)
            {
                lbl.Text = texto;
                lbl.Location = new Point(labelX, posY);
                lbl.Size = new Size(90, 22);
                lbl.ForeColor = Color.Gray;

                val.Text = "-";
                val.Location = new Point(valorX, posY);
                val.Size = new Size(larguraValor, 22);
                val.ForeColor = Color.FromArgb(30, 30, 30);
                val.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);

                pnlDireita.Controls.Add(lbl);
                pnlDireita.Controls.Add(val);
                posY += espacamento;
            }

            AdicionarCampo(lblNomeLabel, lblNomeValor, "Nome:", ref y);
            AdicionarCampo(lblTelefoneLabel, lblTelefoneValor, "Telefone:", ref y);
            AdicionarCampo(lblEmailLabel, lblEmailValor, "E-mail:", ref y);
            AdicionarCampo(lblCidadeLabel, lblCidadeValor, "Cidade:", ref y);
            AdicionarCampo(lblTipoLabel, lblTipoValor, "Tipo:", ref y);
            AdicionarCampo(lblExtraLabel, lblExtraValor, "", ref y);

            btnEditar.Location = new Point(20, 420);
            btnEditar.Size = new Size(110, 34);
            btnEditar.Text = "Editar";
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Enabled = false;
            btnEditar.Click += btnEditar_Click;

            btnExcluir.Location = new Point(144, 420);
            btnExcluir.Size = new Size(110, 34);
            btnExcluir.Text = "Excluir";
            btnExcluir.FlatStyle = FlatStyle.Flat;
            btnExcluir.ForeColor = Color.FromArgb(163, 45, 45);
            btnExcluir.Enabled = false;
            btnExcluir.Click += btnExcluir_Click;

            pnlDireita.Controls.AddRange(new Control[] { btnEditar, btnExcluir });

            // ── Adiciona ao form ──
            Controls.AddRange(new Control[] { pnlEsquerda, pnlDireita });

            ResumeLayout(false);
        }

        private Panel pnlEsquerda, pnlDireita;
        private TextBox txtBusca;
        private ComboBox cmbBusca;
        private ComboBox cmbFiltro;
        private ListBox lstContatos;
        private Button btnNovo, btnEditar, btnExcluir;
        private Label lblNomeLabel, lblNomeValor;
        private Label lblTelefoneLabel, lblTelefoneValor;
        private Label lblEmailLabel, lblEmailValor;
        private Label lblCidadeLabel, lblCidadeValor;
        private Label lblTipoLabel, lblTipoValor;
        private Label lblExtraLabel, lblExtraValor;
    }
}