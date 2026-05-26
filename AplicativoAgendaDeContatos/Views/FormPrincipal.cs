using AgendaContatos.Models;
using AgendaContatos.Patterns;
using AplicativoAgendaDeContatos.Controller;
using AplicativoAgendaDeContatos;

namespace AplicativoAgendaDeContatos
{
    public partial class FormPrincipal : Form
    {
        private readonly ContatoController _controller = new ContatoController();
        private Contato? _contatoSelecionado;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            cmbFiltro.Items.AddRange(new string[] { "Todos", "Pessoal", "Profissional" });
            cmbFiltro.SelectedIndex = 0;
            CarregarLista();
            LimparDetalhe();
        }

        // ── LISTA ─────────────────────────────────────────────

        private void CarregarLista()
        {
            // Começa com ListarTodos()
            List<Contato> contatos = _controller.ListarTodos();

            // Aplica filtro por tipo (Pessoal/Profissional) se selecionado
            string filtro = cmbFiltro.SelectedItem?.ToString() ?? "Todos";
            if (filtro == "Pessoal")
                contatos = new FiltroPorTipo().Filtrar(contatos, "Pessoal");
            else if (filtro == "Profissional")
                contatos = new FiltroPorTipo().Filtrar(contatos, "Profissional");

            // Aplica filtro de texto (Nome ou Cidade) se houver termo digitado
            string termo = txtBusca.Text.Trim();
            if (!string.IsNullOrEmpty(termo))
            {
                string tipoBusca = cmbBusca.SelectedItem?.ToString() ?? "Nome";
                if (tipoBusca == "Cidade")
                    contatos = new FiltroPorCidade().Filtrar(contatos, termo);
                else
                    contatos = new FiltroPorNome().Filtrar(contatos, termo);
            }

            lstContatos.DataSource = null;
            lstContatos.DataSource = contatos;
            lstContatos.DisplayMember = "Nome";
        }

        private void lstContatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            _contatoSelecionado = lstContatos.SelectedItem as Contato;
            ExibirDetalhe(_contatoSelecionado);
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            CarregarLista();
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarLista();
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarLista();
        }

        // ── DETALHE ───────────────────────────────────────────

        private void ExibirDetalhe(Contato? c)
        {
            if (c == null) { LimparDetalhe(); return; }

            lblNomeValor.Text = c.Nome;
            lblTelefoneValor.Text = c.Telefone;
            lblEmailValor.Text = c.Email;
            lblCidadeValor.Text = c.Endereco?.Cidade ?? "-";
            lblTipoValor.Text = c.GetTipo();

            if (c is ContatoPessoal cp)
            {
                lblExtraLabel.Text = "Apelido:";
                lblExtraValor.Text = cp.Apelido;
            }
            else if (c is ContatoProfissional cpr)
            {
                lblExtraLabel.Text = "Empresa:";
                lblExtraValor.Text = $"{cpr.Empresa} - {cpr.Cargo}";
            }

            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void LimparDetalhe()
        {
            lblNomeValor.Text = "-";
            lblTelefoneValor.Text = "-";
            lblEmailValor.Text = "-";
            lblCidadeValor.Text = "-";
            lblTipoValor.Text = "-";
            lblExtraLabel.Text = "";
            lblExtraValor.Text = "";
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        // ── BOTÕES ────────────────────────────────────────────

        private void btnNovo_Click(object sender, EventArgs e)
        {
            var form = new FormCadastro(_controller);
            if (form.ShowDialog() == DialogResult.OK)
                CarregarLista();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (_contatoSelecionado == null) return;
            var form = new FormCadastro(_controller, _contatoSelecionado);
            if (form.ShowDialog() == DialogResult.OK)
                CarregarLista();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_contatoSelecionado == null) return;

            var confirmacao = MessageBox.Show(
                $"Excluir {_contatoSelecionado.Nome}?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacao == DialogResult.Yes)
            {
                _controller.Remover(_contatoSelecionado.Id);
                LimparDetalhe();
                CarregarLista();
            }
        }
    }
}