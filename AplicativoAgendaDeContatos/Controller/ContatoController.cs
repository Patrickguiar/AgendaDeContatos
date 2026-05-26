using AgendaContatos.Models;
using AgendaContatos.Patterns;
using AplicativoAgendaDeContatos;

namespace AplicativoAgendaDeContatos.Controller
{
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
}