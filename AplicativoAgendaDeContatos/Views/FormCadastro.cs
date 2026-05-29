using AgendaContatos.Models;
using AplicativoAgendaDeContatos.Controller;

namespace AplicativoAgendaDeContatos.Views
{
    public partial class FormCadastro : Form
    {
        private readonly ContatoController _controller;
        private readonly Contato? _contatoEditando;

        public FormCadastro(ContatoController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        public FormCadastro(ContatoController controller, Contato contato)
        {
            InitializeComponent();
            _controller = controller;
            _contatoEditando = contato;
        }

        private void FormCadastro_Load(object sender, EventArgs e)
        {
            cmbTipo.Items.AddRange(new string[] { "Pessoal", "Profissional" });
            cmbTipo.SelectedIndex = 0;

            if (_contatoEditando != null)
                PreencherCampos(_contatoEditando);
        }

        private void PreencherCampos(Contato c)
        {
            txtNome.Text = c.Nome;
            txtTelefone.Text = c.Telefone;
            textEmail.Text = c.Email;
            txtCidade.Text = c.Endereco?.Cidade ?? "";
            cmbTipo.SelectedItem = c.GetTipo();

            if (c is ContatoPessoal cp)
                txtExtra.Text = cp.Apelido;
            else if (c is ContatoProfissional cpr)
                txtExtra.Text = $"{cpr.Empresa};{cpr.Cargo}";
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedItem?.ToString() == "Pessoal")
            {
                lblExtra.Text = "Apelido:";
                txtExtra.PlaceholderText = "Apelido";
            }
            else
            {
                lblExtra.Text = "Empresa/Cargo:";
                txtExtra.PlaceholderText = "Empresa;Cargo";
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtTelefone.Text))
            {
                MessageBox.Show("Nome e telefone são obrigatórios.",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var endereco = new Endereco { Cidade = txtCidade.Text };

            if (cmbTipo.SelectedItem?.ToString() == "Pessoal")
            {
                var contato = _contatoEditando as ContatoPessoal
                              ?? new ContatoPessoal();
                contato.Nome = txtNome.Text;
                contato.Telefone = txtTelefone.Text;
                contato.Email = textEmail.Text;
                contato.Endereco = endereco;
                contato.Apelido = txtExtra.Text;

                if (_contatoEditando == null)
                    _controller.Adicionar(contato);
                else
                    _controller.Atualizar(contato);
            }
            else
            {
                var partes = txtExtra.Text.Split(';');
                var contato = _contatoEditando as ContatoProfissional
                              ?? new ContatoProfissional();
                contato.Nome = txtNome.Text;
                contato.Telefone = txtTelefone.Text;
                contato.Email = textEmail.Text;
                contato.Endereco = endereco;
                contato.Empresa = partes.Length > 0 ? partes[0] : "";
                contato.Cargo = partes.Length > 1 ? partes[1] : "";

                if (_contatoEditando == null)
                    _controller.Adicionar(contato);
                else
                    _controller.Atualizar(contato);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void lblTelefone_Click(object sender, EventArgs e) { }

   
    }
}