using AplicativoAgendaDeContatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaContatos.Models
{
    public class ContatoPessoal : Contato
    {
        public string Apelido { get; set; }

        public ContatoPessoal() { }

        public ContatoPessoal(string nome, string telefone, string email, Endereco endereco, string apelido)
            : base(nome, telefone, email, endereco)
        {
            Apelido = apelido;
        }

        public override string GetTipo()
        {
            return "Pessoal";
        }
    }
}

