using System;
using System.Collections.Generic;
using System.Text;
using AgendaContatos.Models;

namespace AgendaContatos.Patterns
{
    public class FiltroPorCidade : IFiltroContato
    {
        public List<Contato> Filtrar(List<Contato> contatos, string termo)
        {
            return contatos
                .Where(c => c.Endereco != null &&
                            c.Endereco.Cidade.ToLower().Contains(termo.ToLower()))
                .ToList();
        }
    }
}
