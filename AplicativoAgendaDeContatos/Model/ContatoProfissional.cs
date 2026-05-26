using AplicativoAgendaDeContatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaContatos.Models
{
    public class ContatoProfissional : Contato
    {
        public string Empresa { get; set; }
        public string Cargo { get; set; }

        public ContatoProfissional() { }

        public ContatoProfissional(string nome, string telefone, string email, Endereco endereco, string empresa, string cargo)
            : base(nome, telefone, email, endereco)
        {
            Empresa = empresa;
            Cargo = cargo;
        }

        public override string GetTipo()
        {
            return "Profissional";
        }
    }
}
