using System;
using System.Collections.Generic;
using System.Text;
using AgendaContatos.Models;

namespace AgendaContatos.Patterns
{
    public class FiltroPorNome : IFiltroContato
    {
        public List<Contato> Filtrar(List<Contato> contatos, string termo)
        {
            return contatos
                .Where(c => c.Nome.ToLower().Contains(termo.ToLower()))
                .ToList();
        }
    }
}

