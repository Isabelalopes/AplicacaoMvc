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
    public class PratoAplicacao
    {
        private readonly IRepositorio<Prato> repositorio;

        public PratoAplicacao(IRepositorio<Prato> repo)
        {
            repositorio = repo;
        }

        public void Excluir(Prato prato)
        {
            repositorio.Excluir(prato);
        }

        public void Salvar(Prato prato)
        {
            repositorio.Salvar(prato);
        }

        public IEnumerable<Prato> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public Prato ListarPorId(string id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
