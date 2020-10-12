using System;
using System.Collections.Generic;

namespace CadastroPessoas.Repositorio
{
    public interface IRepositorio<TTipo>
    {
        List<TTipo> SelecionarTodos();
        void Adicionar(TTipo objeto, Action<int> callBack);
        List<TTipo> Selecionar(Func<TTipo, bool> whereClause);
    }
}