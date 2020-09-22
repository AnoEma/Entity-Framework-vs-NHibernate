using CadastroPessoas.Dominio;
using CadastroPessoas.Persistencia.EF;
using CadastroPessoas.Persistencia.NHibernate.Maps;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using System.Collections.Generic;
using System.Linq;

namespace CadastroPessoas.Repositorio
{
    public class PessoaRepositorio : IRepositorio<Pessoa>
    {
        private ISessionFactory _sessionFactory;

        public PessoaRepositorio()
        {
            Configuration config = new Configuration();
            config.Configure();
            config.AddAssembly(typeof(Pessoa).Assembly);
            HbmMapping mapping = CreateMappings();
            config.AddDeserializedMapping(mapping, null);
            _sessionFactory = config.BuildSessionFactory();
        }

        private HbmMapping CreateMappings()
        {
            ModelMapper mapper = new ModelMapper();
            mapper.AddMapping(typeof(PessoaMap));
            return mapper.CompileMappingForAllExplicitlyAddedEntities();
        }

        public int Adicionar(Pessoa objeto)
        {    //Parametre Entity F
            //CadastroPessoasDbContext context = new CadastroPessoasDbContext();
            //context.Pessoas.Add(objeto);
            //return context.SaveChanges();

            //NHibr
            using(ISession session = _sessionFactory.OpenSession())
            {
                using(var transacao = session.BeginTransaction())
                {
                    session.Save(objeto);
                    transacao.Commit();
                    return 0;
                }
            }
        }

        public List<Pessoa> SelecionarTodos()
        {
            //CadastroPessoasDbContext context = new CadastroPessoasDbContext();
            //List<Pessoa> pessoas = context.Pessoas.OrderBy(x => x.Nome).ToList();
            //context.Dispose();
            //return pessoas;
            using(ISession session = _sessionFactory.OpenSession())
            {
                IQuery query = session.CreateQuery("FROM Pessoa");
                return query.List<Pessoa>().ToList();
            }
        }
    }
}