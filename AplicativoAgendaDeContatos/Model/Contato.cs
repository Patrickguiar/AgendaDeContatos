using AplicativoAgendaDeContatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaContatos.Models
{
    public abstract class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }
        public bool Favorito { get; set; }

        public Contato() { }

        public Contato(string nome, string telefone, string email, Endereco endereco)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
            Favorito = false;
        }

        // Método abstrato: cada tipo de contato exibe suas informações de forma diferente
        public abstract string GetTipo();

        public override string ToString()
        {
            return $"{Nome} ({GetTipo()}) - {Telefone}";
        }
    }
}
