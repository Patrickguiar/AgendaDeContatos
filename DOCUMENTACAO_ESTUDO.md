# 📚 DOCUMENTAÇÃO DO PROJETO - Agenda de Contatos

## 📖 Índice
1. [O que foi criado](#o-que-foi-criado)
2. [Explicação Detalhada do FormCadastro](#explicação-detalhada-do-formcadastro)
3. [Conceitos de POO1](#conceitos-de-poo1)
4. [Conceitos de POO2 - Padrões de Design](#conceitos-de-poo2---padrões-de-design)
5. [Estrutura do Projeto](#estrutura-do-projeto)
6. [Fluxo de Dados (MVC)](#fluxo-de-dados-mvc)
7. [Plano de Estudo](#plano-de-estudo)
8. [Exercícios Práticos](#exercícios-práticos)

---

## O que foi criado

### Arquivos Novos
1. **FormCadastro.cs** - Lógica principal do formulário
2. **FormCadastro.Designer.cs** - Interface gráfica (componentes visuais)

### Propósito
Criar um formulário que permite:
- ✅ Criar novo contato (Pessoal ou Profissional)
- ✅ Editar contato existente
- ✅ Validar dados antes de salvar
- ✅ Campos dinâmicos (mudam conforme o tipo de contato)

---

## Explicação Detalhada do FormCadastro

### 1️⃣ Os Construtores (Dois modos de uso)

```csharp
public FormCadastro(ContatoController controller)
// Modo 1: CRIAR um novo contato (formulário vazio)

public FormCadastro(ContatoController controller, Contato contato)
// Modo 2: EDITAR um contato existente (formulário pré-preenchido)
```

**Como é usado no FormPrincipal:**

```csharp
// Para CRIAR novo contato
private void btnNovo_Click(object sender, EventArgs e)
{
	var form = new FormCadastro(_controller);  // ← Vazio
	if (form.ShowDialog() == DialogResult.OK)
		CarregarLista();
}

// Para EDITAR contato existente
private void btnEditar_Click(object sender, EventArgs e)
{
	if (_contatoSelecionado == null) return;
	var form = new FormCadastro(_controller, _contatoSelecionado);  // ← Com dados
	if (form.ShowDialog() == DialogResult.OK)
		CarregarLista();
}
```

**Analogia:** É como um formulário em um banco que pode ser usado vazio (novo cliente) ou preenchido (alterando dados do cliente).

---

### 2️⃣ FormCadastro_Load (Ao abrir o formulário)

```csharp
private void FormCadastro_Load(object sender, EventArgs e)
{
	rbtnPessoal.Checked = true;  // Pessoal é selecionado por padrão
	rbtProfissional.Checked = false;

	if (_modoEdicao && _contatoEditado != null)
	{
		this.Text = "Editar Contato";
		btnSalvar.Text = "Atualizar";
		PreencherFormulario(_contatoEditado);  // ← Preenche os campos
	}
	else
	{
		this.Text = "Novo Contato";
		btnSalvar.Text = "Salvar";
	}

	AtualizarCamposExtras();  // ← Mostra/esconde campos
}
```

**O que acontece:**
- Se for **novo**: Título "Novo Contato", botão "Salvar", campos vazios
- Se for **edição**: Título "Editar Contato", botão "Atualizar", campos preenchidos

---

### 3️⃣ Preenchendo o Formulário (Modo Edição)

```csharp
private void PreencherFormulario(Contato contato)
{
	// Dados básicos
	txtNome.Text = contato.Nome;
	txtTelefone.Text = contato.Telefone;
	txtEmail.Text = contato.Email;

	// Endereço
	if (contato.Endereco != null)
	{
		txtRua.Text = contato.Endereco.Rua;
		txtNumero.Text = contato.Endereco.Numero;
		txtBairro.Text = contato.Endereco.Bairro;
		txtCidade.Text = contato.Endereco.Cidade;
		txtEstado.Text = contato.Endereco.Estado;
	}

	// Campos específicos conforme o tipo
	if (contato is ContatoPessoal cp)
	{
		rbtnPessoal.Checked = true;
		txtCampoExtra.Text = cp.Apelido;
	}
	else if (contato is ContatoProfissional cpr)
	{
		rbtProfissional.Checked = true;
		txtCampoExtra.Text = cpr.Empresa;
		txtCampoExtra2.Text = cpr.Cargo;
	}
}
```

**Conceito: Polimorfismo**
- Usa `is` para verificar o tipo real do contato
- Acessa propriedades específicas (Apelido, Empresa, Cargo)

---

### 4️⃣ Campos Dinâmicos (Mudando conforme o tipo)

```csharp
private void rbtnPessoal_CheckedChanged(object sender, EventArgs e)
{
	if (rbtnPessoal.Checked)
		AtualizarCamposExtras();
}

private void rbtProfissional_CheckedChanged(object sender, EventArgs e)
{
	if (rbtProfissional.Checked)
		AtualizarCamposExtras();
}

private void AtualizarCamposExtras()
{
	if (rbtnPessoal.Checked)
	{
		lblCampoExtra.Text = "Apelido:";
		lblCampoExtra.Visible = true;
		txtCampoExtra.Visible = true;

		lblCampoExtra2.Visible = false;  // ← Esconde o "Cargo"
		txtCampoExtra2.Visible = false;
	}
	else  // Profissional
	{
		lblCampoExtra.Text = "Empresa:";
		lblCampoExtra.Visible = true;
		txtCampoExtra.Visible = true;

		lblCampoExtra2.Text = "Cargo:";
		lblCampoExtra2.Visible = true;  // ← Mostra os dois
		txtCampoExtra2.Visible = true;
	}
}
```

**Por que é importante?**
- Contato Pessoal: tem "Apelido"
- Contato Profissional: tem "Empresa" + "Cargo"
- Ao trocar o tipo, os campos mudam automaticamente

**Conceito: UI Dinâmica**
- Mesma tela, conteúdo diferente conforme contexto

---

### 5️⃣ Validações (Essencial em qualquer sistema)

```csharp
private bool ValidarFormulario()
{
	// Nome obrigatório
	if (string.IsNullOrWhiteSpace(txtNome.Text))
	{
		MessageBox.Show("Por favor, preencha o nome.");
		txtNome.Focus();
		return false;
	}

	// Telefone obrigatório
	if (string.IsNullOrWhiteSpace(txtTelefone.Text))
	{
		MessageBox.Show("Por favor, preencha o telefone.");
		txtTelefone.Focus();
		return false;
	}

	// Email obrigatório
	if (string.IsNullOrWhiteSpace(txtEmail.Text))
	{
		MessageBox.Show("Por favor, preencha o email.");
		txtEmail.Focus();
		return false;
	}

	// Email no formato correto
	if (!ValidarEmail(txtEmail.Text))
	{
		MessageBox.Show("Por favor, insira um email válido.");
		txtEmail.Focus();
		return false;
	}

	// Todos os campos de endereço preenchidos
	if (string.IsNullOrWhiteSpace(txtRua.Text) || 
		string.IsNullOrWhiteSpace(txtNumero.Text) ||
		string.IsNullOrWhiteSpace(txtBairro.Text) || 
		string.IsNullOrWhiteSpace(txtCidade.Text) ||
		string.IsNullOrWhiteSpace(txtEstado.Text))
	{
		MessageBox.Show("Por favor, preencha todos os campos de endereço.");
		return false;
	}

	// Campos extras conforme o tipo
	if (rbtnPessoal.Checked && string.IsNullOrWhiteSpace(txtCampoExtra.Text))
	{
		MessageBox.Show("Por favor, preencha o apelido.");
		txtCampoExtra.Focus();
		return false;
	}

	if (rbtProfissional.Checked && 
		(string.IsNullOrWhiteSpace(txtCampoExtra.Text) || 
		 string.IsNullOrWhiteSpace(txtCampoExtra2.Text)))
	{
		MessageBox.Show("Por favor, preencha empresa e cargo.");
		return false;
	}

	return true;  // Tudo válido!
}
```

**Por que validar?**
- Evita dados incompletos no banco
- Melhora a experiência do usuário
- Garante integridade dos dados

---

### 6️⃣ Validação de Email (Método Específico)

```csharp
private bool ValidarEmail(string email)
{
	try
	{
		var addr = new System.Net.Mail.MailAddress(email);
		return addr.Address == email;
	}
	catch
	{
		return false;  // Email inválido
	}
}
```

**Como funciona:**
- `MailAddress` é uma classe .NET para validar emails
- Se conseguir criar um MailAddress, email é válido
- Se lançar exceção, email é inválido

---

### 7️⃣ Salvando o Contato (A Parte Mais Importante)

```csharp
private void btnSalvar_Click(object sender, EventArgs e)
{
	if (!ValidarFormulario())
		return;  // ← Se houver erro, não salva

	try
	{
		Contato contato;

		// PASSO 1: Criar o Endereço
		var endereco = new Endereco(
			txtRua.Text.Trim(),
			txtNumero.Text.Trim(),
			txtBairro.Text.Trim(),
			txtCidade.Text.Trim(),
			txtEstado.Text.Trim()
		);

		// PASSO 2: Criar o Contato (tipo correto)
		if (rbtnPessoal.Checked)
		{
			contato = new ContatoPessoal(
				txtNome.Text.Trim(),
				txtTelefone.Text.Trim(),
				txtEmail.Text.Trim(),
				endereco,
				txtCampoExtra.Text.Trim()  // Apelido
			);
		}
		else
		{
			contato = new ContatoProfissional(
				txtNome.Text.Trim(),
				txtTelefone.Text.Trim(),
				txtEmail.Text.Trim(),
				endereco,
				txtCampoExtra.Text.Trim(),   // Empresa
				txtCampoExtra2.Text.Trim()   // Cargo
			);
		}

		// PASSO 3: Salvar ou Atualizar
		if (_modoEdicao && _contatoEditado != null)
		{
			contato.Id = _contatoEditado.Id;  // ← Preserva o ID
			contato.Favorito = _contatoEditado.Favorito;  // ← Preserva favorito
			_controller.Atualizar(contato);  // ← Atualiza no repositório
			MessageBox.Show("Contato atualizado com sucesso!");
		}
		else
		{
			_controller.Adicionar(contato);  // ← Adiciona novo
			MessageBox.Show("Contato salvo com sucesso!");
		}

		// PASSO 4: Fechar o formulário
		this.DialogResult = DialogResult.OK;  // ← Sinal de sucesso
		this.Close();
	}
	catch (ArgumentException ex)
	{
		MessageBox.Show(ex.Message, "Erro de validação");
	}
	catch (Exception ex)
	{
		MessageBox.Show($"Erro ao salvar: {ex.Message}");
	}
}
```

**Fluxo Visual:**

```
Usuário clica SALVAR
		↓
Valida todos os campos
		↓
Cria objeto Endereco
		↓
Cria objeto Contato (Pessoal OU Profissional)
		↓
Se for edição: Atualiza (preserva ID)
Se for novo: Adiciona novo
		↓
Mostra mensagem de sucesso
		↓
Fecha o formulário (DialogResult.OK)
		↓
FormPrincipal recebe OK e recarrega a lista
```

---

### 8️⃣ Fechando o Formulário

```csharp
private void btnCancelar_Click(object sender, EventArgs e)
{
	this.DialogResult = DialogResult.Cancel;
	this.Close();
}
```

**O que é DialogResult?**
- `DialogResult.OK` = Usuário fez algo válido
- `DialogResult.Cancel` = Usuário desistiu

No FormPrincipal:
```csharp
if (form.ShowDialog() == DialogResult.OK)
	CarregarLista();  // ← Só recarrega se salvou com sucesso
```

---

## 🆕 Filtros em Cadeia (FormPrincipal - Nova Versão)

### O que foi atualizado?

**Antes:** FormPrincipal usava o Controller para filtrar
**Agora:** Filtros são aplicados diretamente na lista em cadeia (um após o outro)

### 1️⃣ Novo ComboBox: cmbBusca

```csharp
// No Designer:
cmbBusca.Location = new Point(164, 10);
cmbBusca.Size = new Size(84, 26);
cmbBusca.DropDownStyle = ComboBoxStyle.DropDownList;
cmbBusca.Items.AddRange(new string[] { "Nome", "Cidade" });
cmbBusca.SelectedIndex = 0;  // "Nome" por padrão
```

**Visualmente na tela:**
```
┌──────────────────────────────┐
│ [Pesquisar...] [Nome ▼]     │ ← txtBusca (150) + cmbBusca (84)
│ [Todos ▼]                   │ ← cmbFiltro (238)
│ ├─ João Pessoal             │
│ ├─ Maria Profissional       │ ← lstContatos
│ └─ Carlos Pessoal           │
│ [+ Novo Contato]            │
└──────────────────────────────┘
```

---

### 2️⃣ Novo Método CarregarLista() com Filtros em Cadeia

**ANTES (Controller fazia tudo):**
```csharp
private void CarregarLista()
{
    if (filtro == "Pessoal")
        contatos = _controller.Filtrar(new FiltroPorTipo(), "Pessoal");
    else if (!string.IsNullOrEmpty(termo))
        contatos = _controller.Filtrar(new FiltroPorNome(), termo);
    else
        contatos = _controller.ListarTodos();
}
```

**AGORA (Filtros aplicados em cadeia):**
```csharp
private void CarregarLista()
{
    // PASSO 1: Começar com ListarTodos()
    List<Contato> contatos = _controller.ListarTodos();

    // PASSO 2: Aplicar filtro por tipo (Pessoal/Profissional)
    string filtro = cmbFiltro.SelectedItem?.ToString() ?? "Todos";
    if (filtro == "Pessoal")
        contatos = new FiltroPorTipo().Filtrar(contatos, "Pessoal");
    else if (filtro == "Profissional")
        contatos = new FiltroPorTipo().Filtrar(contatos, "Profissional");

    // PASSO 3: Aplicar filtro de texto (Nome ou Cidade)
    string termo = txtBusca.Text.Trim();
    if (!string.IsNullOrEmpty(termo))
    {
        string tipoBusca = cmbBusca.SelectedItem?.ToString() ?? "Nome";
        if (tipoBusca == "Cidade")
            contatos = new FiltroPorCidade().Filtrar(contatos, termo);
        else
            contatos = new FiltroPorNome().Filtrar(contatos, termo);
    }

    // Atualizar a lista visual
    lstContatos.DataSource = null;
    lstContatos.DataSource = contatos;
    lstContatos.DisplayMember = "Nome";
}
```

**Por que em cadeia?**
- ✅ Cada filtro recebe a lista já filtrada do passo anterior
- ✅ Permite combinar múltiplos filtros
- ✅ Mais limpo e intuitivo

---

### 3️⃣ Novo Evento: cmbBusca_SelectedIndexChanged

```csharp
private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
{
    CarregarLista();  // ← Recarrega quando muda de "Nome" para "Cidade"
}
```

**Quando é acionado:**
- Usuário clica no combobox
- Seleciona "Nome" ou "Cidade"
- CarregarLista() é chamado automaticamente

---

### 4️⃣ Exemplos Práticos: Como Funciona

#### Exemplo 1: Buscar por Nome
```
┌─ Estado Inicial ─────────────────────┐
│ txtBusca: ""                         │
│ cmbBusca: "Nome"                    │
│ cmbFiltro: "Todos"                  │
│ Resultado: Todos os 5 contatos      │
└─────────────────────────────────────┘

          ↓ Usuário digita "João"

┌─ Após Digitar ──────────────────────┐
│ txtBusca: "João"                    │
│ cmbBusca: "Nome"                    │
│ cmbFiltro: "Todos"                  │
│                                     │
│ Executa CarregarLista():            │
│ 1. ListarTodos() → 5 contatos       │
│ 2. Tipo filter → nada (Todos)       │
│ 3. FiltroPorNome("João")            │
│    └─ Pesquisa "João" em todos      │
│ Resultado: 1 contato (João)         │
└─────────────────────────────────────┘
```

#### Exemplo 2: Buscar por Cidade
```
┌─ Estado Inicial ─────────────────────┐
│ txtBusca: ""                         │
│ cmbBusca: "Nome"                    │
│ cmbFiltro: "Todos"                  │
│ Resultado: Todos os 5 contatos      │
└─────────────────────────────────────┘

          ↓ Usuário muda para "Cidade"

┌─ Após Mudar Combobox ──────────────┐
│ txtBusca: "" (vazio)                │
│ cmbBusca: "Cidade"                  │
│ cmbFiltro: "Todos"                  │
│ Resultado: Todos os 5 (sem filtro)  │
└─────────────────────────────────────┘

          ↓ Usuário digita "São Paulo"

┌─ Após Digitar Cidade ──────────────┐
│ txtBusca: "São Paulo"               │
│ cmbBusca: "Cidade"                  │
│ cmbFiltro: "Todos"                  │
│                                     │
│ Executa CarregarLista():            │
│ 1. ListarTodos() → 5 contatos       │
│ 2. Tipo filter → nada (Todos)       │
│ 3. FiltroPorCidade("São Paulo")     │
│    └─ Pesquisa "São Paulo" em todos │
│ Resultado: 2 contatos (SP)          │
└─────────────────────────────────────┘
```

#### Exemplo 3: Combinando Filtros (PODEROSO!)
```
┌─ Cenário: Quero contatos PROFISSIONAIS do RIO DE JANEIRO ──┐

PASSO 1: Seleciona "Profissional" em cmbFiltro
│ lstContatos: 2 contatos (profissionais apenas)
│

PASSO 2: Seleciona "Cidade" em cmbBusca
│ lstContatos: 2 contatos (ainda os mesmos, sem termo)
│

PASSO 3: Digita "Rio de Janeiro" em txtBusca
│ Executa CarregarLista():
│ 1. ListarTodos() → 5 contatos (todos)
│ 2. FiltroPorTipo("Profissional") → 2 contatos
│ 3. FiltroPorCidade("Rio de Janeiro") → 1 contato
│
│ Resultado: 1 contato ✅
│ (Profissional + Rio de Janeiro)
└──────────────────────────────────────────────────────────┘

Fluxo Visual na Tela:
Before:  [J] [M] [C] [A] [L]  (todos 5)
         ↓ seleciona Profissional
After:   [M] [L]              (2 profissionais)
         ↓ digita "Rio"
Final:   [L]                  (1 profissional do Rio)
```

---

### 5️⃣ Diagrama do Fluxo de Filtros em Cadeia

```
                    ┌─ CarregarLista() ─┐
                    │ é chamada         │
                    └────────┬──────────┘
                             │
                             ↓
                  ┌──────────────────────┐
                  │ ListarTodos()        │
                  │ (5 contatos)         │
                  └────────┬─────────────┘
                           │
              ┌────────────┴────────────┐
              │                         │
              ↓                         ↓
    ┌──────────────────────┐  ┌──────────────────────┐
    │ FiltroPorTipo        │  │ (Se "Todos", pula)   │
    │ ("Pessoal" ou        │  │                      │
    │  "Profissional")     │  └──────────┬───────────┘
    │ Resultado: 2-3       │             │
    └────────┬─────────────┘             │
             │                           │
             └───────────┬───────────────┘
                         │
                         ↓
            ┌─────────────────────────┐
            │ Se houver termo digitado│
            └────────────┬────────────┘
                         │
         ┌───────────────┴───────────────┐
         │                               │
         ↓                               ↓
    ┌──────────────┐            ┌──────────────────┐
    │ FiltroPorNome│            │ FiltroPorCidade  │
    │("João")      │            │("São Paulo")     │
    └──────┬───────┘            └────────┬─────────┘
           │                             │
           └──────────┬──────────────────┘
                      │
                      ↓
            ┌─────────────────────┐
            │ Resultado Final     │
            │ (contatos filtrados)│
            └─────────────────────┘
```

---

### 6️⃣ Diferença Importante: Controller vs. Direto

**ANTES (com Controller):**
```csharp
contatos = _controller.Filtrar(new FiltroPorTipo(), "Pessoal");
// ↑ Controller recebe a estratégia e o termo
// ↑ Controller chama: filtro.Filtrar(repo.ListarTodos(), termo)
```

**AGORA (direto na View):**
```csharp
contatos = new FiltroPorTipo().Filtrar(contatos, "Pessoal");
// ↑ Cria a estratégia aqui
// ↑ Aplica na lista já filtrada (contatos já foi processada)
```

**Vantagem:**
- ✅ Mais controle sobre o fluxo
- ✅ Combina filtros facilmente
- ✅ Sem necessidade de passar pelo Controller
- ✅ View fica mais simples visualmente

---

## Conceitos de POO1

### 1. Abstração

**O que é?** Esconder complexidade, mostrando apenas o essencial.

```csharp
public abstract class Contato
{
	public string Nome { get; set; }
	public string Telefone { get; set; }

	// Método abstrato: obriga subclasses a implementar
	public abstract string GetTipo();

	public override string ToString()
	{
		return $"{Nome} ({GetTipo()}) - {Telefone}";
	}
}
```

**Por que é abstrata?**
- Nunca vamos criar `new Contato()` diretamente
- Sempre será ContatoPessoal ou ContatoProfissional
- `GetTipo()` é diferente pra cada tipo

**Na prática:**
```csharp
Contato c = new ContatoPessoal(...);  // ✅ Correto
Contato c = new Contato(...);         // ❌ Erro! Não pode instanciar abstrata
```

---

### 2. Herança

**O que é?** Uma classe filha herda propriedades e métodos da classe pai.

```csharp
// Classe PAI (abstrata)
public abstract class Contato
{
	public string Nome { get; set; }
	public string Telefone { get; set; }
}

// Classe FILHA 1
public class ContatoPessoal : Contato
{
	public string Apelido { get; set; }  // ← Campo extra

	public override string GetTipo()
	{
		return "Pessoal";
	}
}

// Classe FILHA 2
public class ContatoProfissional : Contato
{
	public string Empresa { get; set; }   // ← Campos extra
	public string Cargo { get; set; }

	public override string GetTipo()
	{
		return "Profissional";
	}
}
```

**Diagrama:**

```
		 Contato (PAI)
		/           \
ContatoPessoal   ContatoProfissional
	(FILHA)          (FILHA)
```

**Benefício:** Não repetir código!
- Nome, Telefone, Email estão em um lugar
- ContatoPessoal e ContatoProfissional reutilizam

---

### 3. Polimorfismo

**O que é?** Muitas formas. Um objeto pode agir de jeitos diferentes conforme seu tipo real.

**Exemplo 1: Método GetTipo()**

```csharp
List<Contato> contatos = new List<Contato>
{
	new ContatoPessoal(...),
	new ContatoProfissional(...),
	new ContatoPessoal(...)
};

foreach (var c in contatos)
{
	string tipo = c.GetTipo();  // ← Cada um retorna diferente!
	// ContatoPessoal retorna "Pessoal"
	// ContatoProfissional retorna "Profissional"
}
```

**Exemplo 2: Type Checking com `is`**

```csharp
Contato c = lstContatos.SelectedItem as Contato;

// Tratamento polimórfico
if (c is ContatoPessoal cp)
{
	lblExtraValor.Text = cp.Apelido;  // ← Acessa campo específico
}
else if (c is ContatoProfissional cpr)
{
	lblExtraValor.Text = $"{cpr.Empresa} - {cpr.Cargo}";  // ← Diferente!
}
```

**Benefício:** Escrever código genérico que funciona com qualquer tipo!

---

### 4. Encapsulamento

**O que é?** Proteger dados, permitindo acesso controlado.

```csharp
public class Contato
{
	// ❌ Ruim: acesso direto
	// public string nome;

	// ✅ Bom: propriedade controlada
	public string Nome { get; set; }

	public string Telefone { get; set; }

	public bool Favorito { get; set; }
}
```

**Por que?**
- Pode adicionar validação depois
- Pode mudar implementação interna
- Facilita manutenção

---

## Conceitos de POO2 - Padrões de Design

### 1. Strategy Pattern (Padrão Estratégia)

**O que é?** Definir uma família de algoritmos, encapsula cada um, e torná-los intercambiáveis.

**Problema:** Filtrar contatos por NOME, TIPO, CIDADE...

```csharp
// ❌ SEM Strategy (código repetido e ruim)
if (filtroTipo == "nome")
{
	lista = contatos.Where(c => 
		c.Nome.Contains(termo, StringComparison.OrdinalIgnoreCase)
	).ToList();
}
else if (filtroTipo == "tipo")
{
	lista = contatos.Where(c => 
		c.GetTipo() == termo
	).ToList();
}
else if (filtroTipo == "cidade")
{
	lista = contatos.Where(c => 
		c.Endereco?.Cidade == termo
	).ToList();
}
// ➜ Cada novo filtro exige alterar este código!
```

**✅ COM Strategy (padrão):**

```csharp
// 1. Interface (contrato)
public interface IFiltroContato
{
	List<Contato> Filtrar(List<Contato> contatos, string termo);
}

// 2. Estratégia 1: Filtrar por Nome
public class FiltroPorNome : IFiltroContato
{
	public List<Contato> Filtrar(List<Contato> contatos, string termo)
	{
		return contatos.Where(c => 
			c.Nome.Contains(termo, StringComparison.OrdinalIgnoreCase)
		).ToList();
	}
}

// 3. Estratégia 2: Filtrar por Tipo
public class FiltroPorTipo : IFiltroContato
{
	public List<Contato> Filtrar(List<Contato> contatos, string termo)
	{
		return contatos.Where(c => 
			c.GetTipo() == termo
		).ToList();
	}
}

// 4. Estratégia 3: Filtrar por Cidade
public class FiltroPorCidade : IFiltroContato
{
	public List<Contato> Filtrar(List<Contato> contatos, string termo)
	{
		return contatos.Where(c => 
			c.Endereco?.Cidade == termo
		).ToList();
	}
}

// 5. No Controller, usa a estratégia dinamicamente
public class ContatoController
{
	public List<Contato> Filtrar(IFiltroContato filtro, string termo)
	{
		return filtro.Filtrar(_repo.ListarTodos(), termo);
		// ➜ Não importa qual filtro é! Funciona igual.
	}
}

// 6. No FormPrincipal, NOVA FORMA (Filtros em Cadeia):
private void CarregarLista()
{
	// Começa com tudo
	List<Contato> contatos = _controller.ListarTodos();

	// Filtra por tipo se selecionado
	if (filtro == "Pessoal")
		contatos = new FiltroPorTipo().Filtrar(contatos, "Pessoal");
	else if (filtro == "Profissional")
		contatos = new FiltroPorTipo().Filtrar(contatos, "Profissional");

	// Filtra por texto (Nome ou Cidade)
	if (!string.IsNullOrEmpty(termo))
	{
		if (tipoBusca == "Cidade")
			contatos = new FiltroPorCidade().Filtrar(contatos, termo);
		else
			contatos = new FiltroPorNome().Filtrar(contatos, termo);
	}

	// Atualiza a tela
	lstContatos.DataSource = contatos;
}
```

**Vantagens da Nova Abordagem (Filtros em Cadeia):**
✅ Adicionar novo filtro = criar nova classe (sem alterar código existente)
✅ Cada filtro é independente
✅ Código mais limpo e testável
✅ **Novo:** Permite combinar múltiplos filtros facilmente
✅ **Novo:** Cada filtro recebe a lista já parcialmente filtrada

**Diagrama da Nova Forma (com Cadeia):**

```
		ListarTodos()
			│
			↓
	┌───────────────────┐
	│ FiltroPorTipo     │
	│ (Pessoal ou       │
	│  Profissional)    │
	└────────┬──────────┘
			 │
			 ↓
	┌───────────────────┐
	│ FiltroPorNome OU  │
	│ FiltroPorCidade   │
	│ (depende de       │
	│  cmbBusca)        │
	└────────┬──────────┘
			 │
			 ↓
		Resultado Final
		(múltiplos filtros
		 aplicados em sequência)
```

---

### 2. MVC Pattern (Model-View-Controller)

**O que é?** Separar a aplicação em 3 partes independentes:

#### **MODEL** (Dados)

```
Arquivo: Model/
├── Contato.cs (classe base)
├── ContatoPessoal.cs (específico)
├── ContatoProfissional.cs (específico)
├── Endereco.cs (complemento)
└── ContatoRepositorio.cs (persistência)
```

**Responsabilidade:** Representar os dados e lógica de negócio.

```csharp
public abstract class Contato
{
	public int Id { get; set; }
	public string Nome { get; set; }
	public string Telefone { get; set; }
	public string Email { get; set; }
	public Endereco Endereco { get; set; }
	public bool Favorito { get; set; }

	public abstract string GetTipo();
}
```

#### **CONTROLLER** (Lógica)

```
Arquivo: Controller/ContatoController.cs
```

**Responsabilidade:** Orquestrar as operações (criar, atualizar, listar, filtrar).

```csharp
public class ContatoController
{
	private readonly ContatoRepositorio _repo = new ContatoRepositorio();

	public List<Contato> ListarTodos() => _repo.ListarTodos();

	public void Adicionar(Contato c) => _repo.Adicionar(c);

	public void Atualizar(Contato c) => _repo.Atualizar(c);

	public void Remover(int id) => _repo.Remover(id);

	public List<Contato> Filtrar(IFiltroContato filtro, string termo) =>
		filtro.Filtrar(_repo.ListarTodos(), termo);
}
```

#### **VIEW** (Interface)

```
Arquivo: Views/
├── FormPrincipal.cs (lista + detalhe)
└── FormCadastro.cs (criar/editar)
```

**Responsabilidade:** Mostrar dados ao usuário e capturar interações.

```csharp
public partial class FormPrincipal : Form
{
	private readonly ContatoController _controller = new ContatoController();

	private void CarregarLista()
	{
		List<Contato> contatos = _controller.ListarTodos();
		lstContatos.DataSource = contatos;
	}

	private void btnNovo_Click(object sender, EventArgs e)
	{
		var form = new FormCadastro(_controller);
		if (form.ShowDialog() == DialogResult.OK)
			CarregarLista();
	}
}
```

---

### Fluxo de Dados (MVC)

```
┌─────────────────────────────────────────┐
│         VIEW (FormPrincipal)            │
│ ┌──────────────────────────────────┐   │
│ │ Usuário clica "Novo Contato"     │   │
│ └──────────────────────────────────┘   │
└──────────────┬──────────────────────────┘
			   │
			   ↓
┌─────────────────────────────────────────┐
│      VIEW (FormCadastro)                │
│ ┌──────────────────────────────────┐   │
│ │ Usuário preenche dados            │   │
│ │ Clica "Salvar"                    │   │
│ └──────────────────────────────────┘   │
└──────────────┬──────────────────────────┘
			   │
			   ↓
┌─────────────────────────────────────────┐
│  CONTROLLER (ContatoController)         │
│ ┌──────────────────────────────────┐   │
│ │ Recebe o objeto Contato          │   │
│ │ Chama: _repo.Adicionar(contato)  │   │
│ └──────────────────────────────────┘   │
└──────────────┬──────────────────────────┘
			   │
			   ↓
┌─────────────────────────────────────────┐
│  MODEL (ContatoRepositorio)             │
│ ┌──────────────────────────────────┐   │
│ │ Armazena contato na Lista        │   │
│ │ Gera um novo ID                  │   │
│ └──────────────────────────────────┘   │
└──────────────┬──────────────────────────┘
			   │
			   ↓
┌─────────────────────────────────────────┐
│         VIEW (FormPrincipal)            │
│ ┌──────────────────────────────────┐   │
│ │ Recarrega a lista de contatos    │   │
│ │ Novo contato aparece na tela     │   │
│ └──────────────────────────────────┘   │
└─────────────────────────────────────────┘
```

---

### 3. Repository Pattern

**O que é?** Abstrair o acesso aos dados.

```csharp
public class ContatoRepositorio
{
	private static List<Contato> _contatos = new List<Contato>();
	private static int _proximoId = 1;

	public void Adicionar(Contato c)
	{
		c.Id = _proximoId++;
		_contatos.Add(c);
	}

	public List<Contato> ListarTodos()
	{
		return _contatos;
	}

	public void Atualizar(Contato c)
	{
		var existente = _contatos.FirstOrDefault(x => x.Id == c.Id);
		if (existente != null)
		{
			// Atualizar campos
			existente.Nome = c.Nome;
			existente.Telefone = c.Telefone;
			// ... outros campos
		}
	}

	public void Remover(int id)
	{
		var contato = _contatos.FirstOrDefault(x => x.Id == id);
		if (contato != null)
			_contatos.Remove(contato);
	}
}
```

**Benefício:** Se depois precisar trocar de banco de dados (de Lista para SQL Server), só muda aqui!

---

## Estrutura do Projeto

```
AplicativoAgendaDeContatos/
│
├── Model/
│   ├── Contato.cs                 ← Classe abstrata (base)
│   ├── ContatoPessoal.cs          ← Herança (com Apelido)
│   ├── ContatoProfissional.cs     ← Herança (com Empresa, Cargo)
│   ├── Endereco.cs                ← Complemento
│   └── ContatoRepositorio.cs      ← Persistência (simulada em memória)
│
├── Controller/
│   └── ContatoController.cs       ← Lógica e orquestração
│
├── Patterns/
│   ├── IFiltroContato.cs          ← Interface Strategy
│   ├── FiltroPorNome.cs           ← Implementação
│   ├── FiltroPorTipo.cs           ← Implementação
│   └── FiltroPorCidade.cs         ← Implementação
│
├── Views/
│   ├── FormPrincipal.cs           ← Tela principal (lista + detalhe)
│   ├── FormPrincipal.Designer.cs
│   ├── FormPrincipal.resx
│   ├── FormCadastro.cs            ← Tela de cadastro (NOVO)
│   └── FormCadastro.Designer.cs   ← Designer (NOVO)
│
└── Program.cs                     ← Entrada da aplicação
```

---

## Fluxo de Dados (MVC)

### Criar um Novo Contato

```
1. FormPrincipal.btnNovo_Click
   ↓
2. Abre FormCadastro (vazio)
   ↓
3. Usuário preenche os dados
   ↓
4. FormCadastro.btnSalvar_Click
   ↓
5. Valida os dados
   ↓
6. Cria objeto ContatoPessoal ou ContatoProfissional
   ↓
7. Chama _controller.Adicionar(contato)
   ↓
8. Controller chama _repo.Adicionar(contato)
   ↓
9. Repositório adiciona à lista e gera ID
   ↓
10. FormCadastro fecha com DialogResult.OK
	↓
11. FormPrincipal.CarregarLista() recarrega a tela
	↓
12. Novo contato aparece na lista! ✅
```

### Editar um Contato Existente

```
1. FormPrincipal: usuário seleciona um contato
   ↓
2. FormPrincipal.btnEditar_Click
   ↓
3. Abre FormCadastro (com dados preenchidos)
   ↓
4. Usuário altera os campos
   ↓
5. FormCadastro.btnSalvar_Click (agora é "Atualizar")
   ↓
6. Valida os dados
   ↓
7. Chama _controller.Atualizar(contato)
   ↓
8. Controller chama _repo.Atualizar(contato)
   ↓
9. Repositório encontra o contato por ID e atualiza
   ↓
10. FormCadastro fecha com DialogResult.OK
	↓
11. FormPrincipal.CarregarLista() recarrega
	↓
12. Contato atualizado aparece na lista! ✅
```

### Filtrar Contatos (Strategy Pattern - Versão ANTIGA)

```
1. Usuário escolhe um filtro (Pessoal/Profissional)
   ↓
2. FormPrincipal.cmbFiltro_SelectedIndexChanged
   ↓
3. Chama CarregarLista()
   ↓
4. CarregarLista() chama:
   _controller.Filtrar(new FiltroPorTipo(), "Pessoal")
   ↓
5. ContatoController.Filtrar chama:
   filtro.Filtrar(_repo.ListarTodos(), "Pessoal")
   ↓
6. FiltroPorTipo.Filtrar executa:
   return contatos.Where(c => c.GetTipo() == "Pessoal").ToList()
   ↓
7. Resultado volta para FormPrincipal
   ↓
8. Lista atualizada mostra apenas contatos pessoais! ✅
```

---

### 🆕 Filtrar Contatos (Versão NOVA - Filtros em Cadeia)

```
1. Usuário escolhe filtro por TIPO (Pessoal/Profissional)
   ↓
2. Seleciona tipo de BUSCA (Nome/Cidade) em cmbBusca
   ↓
3. Digita TERMO na txtBusca
   ↓
4. Evento txtBusca_TextChanged ou cmbBusca_SelectedIndexChanged
   ↓
5. Chama CarregarLista()
   ↓
6. CarregarLista() executa EM CADEIA:

   PASSO 1: ListarTodos() → 5 contatos
   └─ [João(P), Maria(Pr), Carlos(P), Ana(Pr), Lucas(P)]

   PASSO 2: FiltroPorTipo → (apenas se tipo ≠ "Todos")
   └─ Se "Profissional" → [Maria(Pr), Ana(Pr)]

   PASSO 3: FiltroPorNome OU FiltroPorCidade
   └─ Se "São Paulo" → [Maria(Pr - SP)]

   RESULTADO: 1 contato ✅
   (Profissional + São Paulo)
```

**Diferença Visual:**

```
ANTES (Simples):
Pesquisa por NOME             Pesquisa por TIPO
└─ Ou um ou outro            └─ Não combina

DEPOIS (Cadeia - Poderoso):
Tipo PESSOAL + Cidade "SP"
└─ Combina múltiplos filtros! 🎯
```

---

## Plano de Estudo

### 📅 Semana 1: Entender a Estrutura (Fundamentos)

**Objetivo:** Ver como tudo funciona junto.

- [ ] Abra o projeto e execute
- [ ] Crie um contato pessoal e outro profissional
- [ ] Veja os dados aparecendo na lista
- [ ] Edite um contato e veja as mudanças
- [ ] Delete um contato

**Arquivos para ler:**
1. `Contato.cs` - Entenda a classe abstrata
2. `ContatoPessoal.cs` - Veja como herda
3. `ContatoProfissional.cs` - Veja diferenças
4. `Program.cs` - Entenda como a app inicia

**Exercício:**
- Desenhe um diagrama de classes no papel
- Mostre a herança e os campos de cada uma

---

### 📅 Semana 2: POO1 em Profundidade

**Objetivo:** Dominar Abstração, Herança, Polimorfismo.

**Leia e entenda:**
1. `Contato.cs` - Por que é abstrata?
2. `ContatoPessoal.cs` - Implemente um novo método
3. `FormPrincipal.cs` - Veja como trata tipos diferentes (polimorfismo)

**Exercício 1: Adicione um novo campo**
- Adicione `DataNascimento` em ContatoPessoal
- Adicione `DataAdmissao` em ContatoProfissional
- Atualize FormCadastro para permitir esses campos
- Mostre na tela de detalhe

**Exercício 2: Implemente um novo método**
- Crie um método `GetInfo()` em Contato
- ReturnFormat: "João - Pessoal - (11)99999-9999"
- Sobrescreva em ContatoPessoal e ContatoProfissional com formatos diferentes

---

### 📅 Semana 3: Strategy Pattern (Padrões)

**Objetivo:** Entender como reutilizar código com padrões.

**Leia:**
1. `IFiltroContato.cs` - Interface (contrato)
2. `FiltroPorNome.cs` - Uma implementação
3. `FiltroPorTipo.cs` - Outra implementação
4. `ContatoController.cs` - Como usa

**Exercício 1: Crie um novo filtro**
```csharp
// Arquivo: Patterns/FiltroPorTelefone.cs
public class FiltroPorTelefone : IFiltroContato
{
	public List<Contato> Filtrar(List<Contato> contatos, string termo)
	{
		return contatos.Where(c => 
			c.Telefone.Contains(termo)
		).ToList();
	}
}

// No FormPrincipal, adicione um combobox com "Filtrar por Telefone"
// Teste!
```

**Exercício 2: Entenda por que é melhor**
- Sem Strategy: cada filtro exigia alterar FormPrincipal
- Com Strategy: novo filtro é uma classe nova, FormPrincipal não muda!

---

### 📅 Semana 4: MVC + Windows Forms

**Objetivo:** Entender como dados fluem na aplicação.

**Leia:**
1. `ContatoController.cs` - Orquestrador
2. `ContatoRepositorio.cs` - Persistência
3. `FormPrincipal.cs` - View (lista)
4. `FormCadastro.cs` - View (cadastro)

**Exercício 1: Trace um fluxo**
- Crie um novo contato
- Localize cada método que é chamado
- Veja como o dado passa por Model → Controller → View

**Exercício 2: Adicione logging (debug)**
```csharp
// No ContatoController.Adicionar:
public void Adicionar(Contato c)
{
	Console.WriteLine($"[Controller] Adicionando: {c.Nome}");
	_repo.Adicionar(c);
	Console.WriteLine($"[Controller] Adicionado com ID: {c.Id}");
}

// No ContatoRepositorio.Adicionar:
public void Adicionar(Contato c)
{
	c.Id = _proximoId++;
	_contatos.Add(c);
	Console.WriteLine($"[Repositorio] Total de contatos: {_contatos.Count}");
}

// Rode e veja as mensagens no Output
```

---

### 📅 Semana 5+: Exercícios Avançados

Veja a seção abaixo.

---

## Exercícios Práticos

### 🟢 FÁCIL

#### Exercício 1: Campo Favorito
**Objetivo:** Adicione a funcionalidade de favoritar contatos.

**Passos:**
1. O campo `Favorito` já existe em Contato, mas não é usado
2. Adicione um **checkbox** "Favorito" no FormCadastro
3. Ao editar, marque o checkbox conforme o estado
4. Ao salvar, atualize o valor

**Código do FormCadastro (aproximado):**
```csharp
// Adicione no Designer:
private CheckBox chkFavorito;

// Ao carregar:
if (_modoEdicao)
	chkFavorito.Checked = _contatoEditado.Favorito;

// Ao salvar:
contato.Favorito = chkFavorito.Checked;
```

**Resultado esperado:**
- Criar um contato marcado como favorito
- Editar e desmarcar
- Ver as mudanças quando recarrega a lista

---

#### Exercício 2: Mostrar Favoritos na Lista
**Objetivo:** Adicione uma estrela (⭐) ao lado dos contatos favoritos.

**Dica:** No FormPrincipal, customize como os itens são exibidos:
```csharp
// Em vez de:
lstContatos.DisplayMember = "Nome";

// Crie uma classe para representação:
public class ContatoView
{
	public string Nome { get; set; }

	public override string ToString()
	{
		return Contato.Favorito ? $"⭐ {Contato.Nome}" : Contato.Nome;
	}
}
```

---

#### Exercício 3: Limpar Formulário
**Objetivo:** Adicione um botão "Limpar" no FormCadastro.

```csharp
private void btnLimpar_Click(object sender, EventArgs e)
{
	txtNome.Clear();
	txtTelefone.Clear();
	txtEmail.Clear();
	txtRua.Clear();
	txtNumero.Clear();
	txtBairro.Clear();
	txtCidade.Clear();
	txtEstado.Clear();
	txtCampoExtra.Clear();
	txtCampoExtra2.Clear();

	rbtnPessoal.Checked = true;
	txtNome.Focus();
}
```

---

### 🟡 MÉDIO

#### Exercício 4: Data de Cadastro
**Objetivo:** Adicione `DataCadastro` aos contatos.

**Passos:**
1. Adicione propriedade em `Contato.cs`:
```csharp
public DateTime DataCadastro { get; set; }
```

2. Ao criar contato novo:
```csharp
contato.DataCadastro = DateTime.Now;
```

3. Ao editar, preserve:
```csharp
contato.DataCadastro = _contatoEditado.DataCadastro;
```

4. Exiba no detalhe (FormPrincipal):
```csharp
lblDataValor.Text = c.DataCadastro.ToString("dd/MM/yyyy HH:mm");
```

**Resultado:** Veja quando cada contato foi criado.

---

#### Exercício 5: Ordenar Lista
**Objetivo:** Ordene contatos por nome (A-Z).

**No FormPrincipal.CarregarLista():**
```csharp
contatos = contatos.OrderBy(c => c.Nome).ToList();
lstContatos.DataSource = contatos;
```

**Desafio:** Adicione um combobox para escolher:
- Por nome (A-Z)
- Por nome (Z-A)
- Por data (mais recentes)
- Por tipo (Pessoal depois Profissional)

---

#### Exercício 6: Validação de Telefone
**Objetivo:** Valide se o telefone tem formato correto (ex: (11)99999-9999).

```csharp
private bool ValidarTelefone(string telefone)
{
	var regex = new System.Text.RegularExpressions.Regex(@"^\(\d{2}\)\d{4,5}-\d{4}$");
	return regex.IsMatch(telefone);
}

// No ValidarFormulario():
if (!ValidarTelefone(txtTelefone.Text))
{
	MessageBox.Show("Telefone deve estar no formato: (11)99999-9999");
	return false;
}
```

---

### 🔴 DIFÍCIL

#### Exercício 7: Busca em Tempo Real
**Objetivo:** Filtrar enquanto digita (como Google).

```csharp
private void txtBusca_TextChanged(object sender, EventArgs e)
{
	CarregarLista();  // Já faz isso!
}

// Mas melhore com debounce para não filtrar a cada letra
```

---

#### Exercício 8: Padrão Observer
**Objetivo:** Notifique quando um contato é criado/atualizado.

```csharp
// Criar uma classe Logger
public class ContatoLogger
{
	public void RegistrarAdicao(Contato c)
	{
		Console.WriteLine($"[LOG] Contato adicionado: {c.Nome}");
	}

	public void RegistrarAtualizacao(Contato c)
	{
		Console.WriteLine($"[LOG] Contato atualizado: {c.Nome}");
	}
}

// No Controller, chamar o logger
public class ContatoController
{
	private readonly ContatoLogger _logger = new ContatoLogger();

	public void Adicionar(Contato c)
	{
		_repo.Adicionar(c);
		_logger.RegistrarAdicao(c);
	}
}
```

---

#### Exercício 9: Salvar em Arquivo
**Objetivo:** Persistir contatos em um arquivo JSON.

```csharp
// Em ContatoRepositorio:
public void Salvar()
{
	var json = JsonConvert.SerializeObject(_contatos);
	File.WriteAllText("contatos.json", json);
}

public void Carregar()
{
	if (File.Exists("contatos.json"))
	{
		var json = File.ReadAllText("contatos.json");
		_contatos = JsonConvert.DeserializeObject<List<Contato>>(json) ?? new();
	}
}

// No Program.cs, carregue ao iniciar:
var repo = new ContatoRepositorio();
repo.Carregar();
```

---

#### Exercício 10: Implementar Decorator
**Objetivo:** Crie um `ContatoVIP` que estende `ContatoProfissional`.

```csharp
public class ContatoVIP : ContatoProfissional
{
	public string Beneficios { get; set; }
	public DateTime DataVip { get; set; }

	public override string GetTipo()
	{
		return "VIP";
	}
}

// No FormCadastro, permita escolher VIP
// Adicione campo "Benefícios"
```

---

## Resumo Rápido - Tabela de Referência

| Conceito | Arquivo | Aprenda |
|----------|---------|---------|
| **Classe Abstrata** | Contato.cs | `abstract class`, método abstrato |
| **Herança** | ContatoPessoal.cs | `: Contato`, `override` |
| **Polimorfismo** | FormPrincipal.cs | `is`, `GetTipo()` |
| **Encapsulamento** | Contato.cs | `{ get; set; }` |
| **Strategy** | IFiltroContato.cs | Interface + múltiplas implementações |
| **Strategy em Cadeia** | FormPrincipal.cs (novo) | Filtros aplicados sequencialmente |
| **MVC** | Toda a estrutura | Model/Controller/View separados |
| **Repository** | ContatoRepositorio.cs | Centralizar acesso aos dados |
| **Windows Forms** | FormCadastro.cs | Eventos, validação, diálogos |
| **UI Dinâmica** | FormCadastro.cs | Mostrar/esconder campos conforme contexto |
| **Filtros em Cadeia** | FormPrincipal.cs | Combinar múltiplos filtros |

---

## Dúvidas Frequentes

### P: Por que Contato é abstrata?
**R:** Porque nunca criamos um contato genérico. Sempre é Pessoal ou Profissional. A classe abstrata força a implementação em subclasses.

### P: O que é DialogResult?
**R:** É a resposta do formulário. `OK` = salvou com sucesso. `Cancel` = usuário desistiu. FormPrincipal só recarrega se receber `OK`.

### P: Como o Strategy melhora o código?
**R:** Sem Strategy, cada novo filtro exigia alterar FormPrincipal. Com Strategy, novo filtro é uma classe nova isolada.

### P: O que são "Filtros em Cadeia"?
**R:** É aplicar múltiplos filtros sequencialmente. Exemplo: Filtrar por tipo "Profissional", depois por cidade "São Paulo". Cada filtro recebe a lista já parcialmente filtrada do anterior.

### P: Como adicionar um novo filtro agora?
**R:** 
1. Crie uma nova classe `FiltroPor[Campo].cs` implementando `IFiltroContato`
2. No `FormPrincipal.CarregarLista()`, adicione uma condição `else if (tipoBusca == "[Campo]")`
3. Pronto! Sem alterar nenhuma outra classe.

### P: Qual é a diferença entre txtBusca e cmbBusca?
**R:** 
- **txtBusca**: TextBox onde o usuário digita o termo a buscar (ex: "João" ou "São Paulo")
- **cmbBusca**: ComboBox onde o usuário escolhe O QUE buscar (ex: "Nome" ou "Cidade")

### P: Posso ter um contato que é Pessoal E Profissional?
**R:** Não, com a estrutura atual. Seria necessário usar Composição ou Múltipla Herança (não recomendado em C#).

### P: Onde os contatos são salvos?
**R:** Atualmente, em memória (Lista). Para persistência real, use banco de dados (SQL Server, SQLite, etc).

### P: Por que os filtros não passam mais pelo Controller?
**R:** Porque queremos aplicar múltiplos filtros em sequência na View. Passar pelo Controller causaria recarregar `ListarTodos()` a cada filtro, perdendo o resultado do filtro anterior. Agora cada filtro trabalha com a lista já filtrada.

---

## Componentes da Tela (FormPrincipal)

### Painel Esquerdo (Lista)

```
┌─────────────────────────┐
│ [Pesquisar...] [Nome ▼]│  ← txtBusca (150px) + cmbBusca (84px)
│ [Todos ▼]              │  ← cmbFiltro (238px)
│ ┌───────────────────┐  │
│ │ João - Pessoal   │  │
│ │ Maria - Prof     │  │ ← lstContatos
│ │ Carlos - Pessoal │  │
│ │ Ana - Prof       │  │
│ │ Lucas - Pessoal  │  │
│ └───────────────────┘  │
│ [+ Novo Contato]       │  ← btnNovo
└─────────────────────────┘
```

### Painel Direito (Detalhes)

```
┌─────────────────────────┐
│ Nome: João              │
│ Telefone: (11)99999-9999│
│ E-mail: joao@email.com │
│ Cidade: São Paulo       │
│ Tipo: Pessoal           │
│ Apelido: João da Silva  │
│                         │
│ [Editar] [Excluir]      │
└─────────────────────────┘
```

---

## Próximos Passos

1. **Semana 1-5:** Siga o plano de estudo
2. **Exercícios 1-10:** Implemente conforme aprende
3. **Desafio Final:** Crie uma funcionalidade nova do zero usando esses padrões

**Dica:** Teste os filtros em cadeia combinando:
- ✅ Tipo (Pessoal/Profissional) + Nome
- ✅ Tipo (Pessoal/Profissional) + Cidade
- ✅ Sem tipo (Todos) + Nome
- ✅ Sem tipo (Todos) + Cidade

**Boa sorte! 🚀**
