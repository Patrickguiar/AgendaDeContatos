using System;
using System.Collections.Generic;
using System.Text;
using AgendaContatos.Models;

namespace AgendaContatos.Patterns
{
    public interface IFiltroContato
    {
        List<Contato> Filtrar(List<Contato> contatos, string termo);
    }
}



