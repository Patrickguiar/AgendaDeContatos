using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaContatos.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; } = "";
        public string Numero { get; set; } = "";
        public string Bairro { get; set; } = "";
        public string Cidade { get; set; } = "";
        public string Estado { get; set; } = "";

        public Endereco() { }

        public Endereco(string rua, string numero, string bairro, string cidade, string estado)
        {
            if (string.IsNullOrWhiteSpace(rua) || string.IsNullOrWhiteSpace(numero) || string.IsNullOrWhiteSpace(bairro) ||
               string.IsNullOrWhiteSpace(cidade) || string.IsNullOrWhiteSpace(estado))
            {
                throw new ArgumentException("Todos os campos do endereço devem ser preenchidos.");
            }
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        public override string ToString()
        {
            return $"{Rua}, {Numero} - {Bairro}, {Cidade}/{Estado}";
        }
    }
}