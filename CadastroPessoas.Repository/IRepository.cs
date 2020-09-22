using System.Collections.Generic;

namespace CadastroPessoas.Repository
{
    public interface IRepository<TTipo>
    {
        List<TTipo> SelecionarTodos();
        int Adicionar(TTipo objeto);
    }
}