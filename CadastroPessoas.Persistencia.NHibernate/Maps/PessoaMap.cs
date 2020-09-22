using CadastroPessoas.Dominio;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace CadastroPessoas.Persistencia.NHibernate.Maps
{
    public class PessoaMap: ClassMapping<Pessoa>
    {
        public PessoaMap()
        {
            Table("Pessoas");
            Id(pk => pk.Id, (map) => { map.Generator(Generators.Identity); });
            Property(x => x.Nome);
            Property(x => x.Idade);
            Property(x => x.Endereco);
        }
    }
}