using CadastroPessoas.Dominio;
using CadastroPessoas.Persistencia.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroPessoas.Repositorio
{
    public class PessoaRepositorio : IRepositorio<Pessoa>
    {
        public async void Adicionar(Pessoa objeto, Action<int> callBack)
        {
            CadastroPessoasDbContext context = new CadastroPessoasDbContext();
            context.Pessoas.Add(objeto);
            await context.SaveChangesAsync().ContinueWith((taskAnterio) =>
            {
                int linhasAfetadas = taskAnterio.Result;
                callBack(linhasAfetadas);
            });
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