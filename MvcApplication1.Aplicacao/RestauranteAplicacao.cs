using MvcApplication1.Dominio;
using MvcApplication1.Dominio.contrato;
using MvcApplication1.RepositorioADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplication1.Aplicacao
{
    public class RestauranteAplicacao
    {
        private readonly IRepositorio<Restaurante> repositorio;

        public RestauranteAplicacao(IRepositorio<Restaurante> repo)
        {
            repositorio = repo;
        }

        public void Excluir(Restaurante restaurante)
        {
            repositorio.Excluir(restaurante);
        }

        public void Salvar(Restaurante restaurante)
        {
            repositorio.Salvar(restaurante);
        }

        public IEnumerable<Restaurante> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public Restaurante ListarPorId(string id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
