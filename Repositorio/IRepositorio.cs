using System.Collections.Generic;

namespace CadastroPessoas.Repositorio
{
    public interface IRepositorio<TTipo>
    {
        List<TTipo> SelecionarTodos();
        int Adicionar(TTipo objeto);
    }
}