using System;
using System.Collections.Generic;
using System.Text;
using AgendaContatos.Models;

namespace AgendaContatos.Patterns
{
    public class FiltroPorTipo : IFiltroContato
    {
        public List<Contato> Filtrar(List<Contato> contatos, string termo)
        {
            return contatos.Where(c => c.GetTipo().ToLower().Contains(termo.ToLower()))
                .ToList();
        }
    }
}