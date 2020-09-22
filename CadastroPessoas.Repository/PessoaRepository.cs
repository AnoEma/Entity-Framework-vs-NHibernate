using CadastroPessoas.Dominio;
using CadastroPessoas.Persistencia.EF;
using System.Collections.Generic;
using System.Linq;

namespace CadastroPessoas.Repository
{
    public class PessoaRepository : IRepository<Pessoa>
    {
        public int Adicionar(Pessoa objeto)
        {
            CadastroPessoasDbContext context = new CadastroPessoasDbContext();
            context.Pessoas.Add(objeto);
            return context.SaveChanges();
        }

        public List<Pessoa> SelecionarTodos()
        {
            CadastroPessoasDbContext context = new CadastroPessoasDbContext();
            List<Pessoa> pessoas = context.Pessoas.OrderBy(x => x.Nome).ToList();
            context.Dispose();
            return pessoas;
        }
    }
}