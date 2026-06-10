
# Agenda de Contatos

Projeto desenvolvido para a disciplina de Programação Orientada a Objetos II.
Aplicativo desktop de gerenciamento de contatos desenvolvido em C# com Windows Forms.

## 🛠️ Tecnologias
- C# .NET — Windows Forms
- System.Text.Json para persistência de dados

## 📁 Estrutura do Projeto

```
AplicativoAgendaDeContatos/
├── Model/
│   ├── Contato.cs               # Classe abstrata base
│   ├── ContatoPessoal.cs        # Herança de Contato
│   ├── ContatoProfissional.cs   # Herança de Contato
│   ├── Endereco.cs              # Endereço do contato
│   └── ContatoRepositorio.cs   # Persistência em JSON
├── Controller/
│   └── ContatoController.cs    # Camada de controle (MVC)
├── Patterns/
│   ├── IFiltroContato.cs       # Interface Strategy
│   ├── FiltroPorNome.cs        # Filtro por nome
│   ├── FiltroPorCidade.cs      # Filtro por cidade
│   └── FiltroPorTipo.cs        # Filtro por tipo
└── Views/
    ├── FormPrincipal.cs        # Tela principal
    └── FormCadastro.cs         # Tela de cadastro/edição
```

## ✅ Funcionalidades
- Cadastro de contatos pessoais e profissionais
- Edição e exclusão de contatos
- Busca por nome ou cidade
- Filtro por tipo de contato (Pessoal / Profissional)
- Dados salvos automaticamente em arquivo JSON

## 🎯 Conceitos e Padrões Aplicados

**Orientação a Objetos**
- Classe abstrata: `Contato` como base para `ContatoPessoal` e `ContatoProfissional`
- Herança e polimorfismo: método `GetTipo()` implementado diferente em cada subclasse
- Interface: `IFiltroContato` define o contrato do padrão Strategy

**Padrão de Projeto — Strategy**
O padrão Strategy foi aplicado na camada de filtros. A interface `IFiltroContato` define o método `Filtrar`, e cada classe implementa sua própria lógica de filtragem. O `ContatoController` aceita qualquer filtro sem precisar conhecer sua implementação.

**Arquitetura MVC**
- **Model**: classes de domínio e repositório
- **View**: formulários Windows Forms
- **Controller**: intermediário entre View e Model

**Persistência JSON**
Os dados são salvos automaticamente no arquivo `contatos.json` a cada operação. O `ContatoConverter` resolve a serialização da classe abstrata `Contato`, gravando o campo `Tipo` para identificar a subclasse correta na leitura.

## 👥 Equipe
- Patrick Aguiar
- Artur Ribeiro
