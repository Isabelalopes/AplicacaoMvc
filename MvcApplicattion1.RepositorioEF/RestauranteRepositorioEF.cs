using MvcApplication1.Dominio;
using MvcApplication1.Dominio.contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplicattion1.RepositorioEF
{
    public class RestauranteRepositorioEF : IRepositorio<Restaurante>
    {
        private readonly Contexto contexto;

        public RestauranteRepositorioEF()
        {
            contexto = new Contexto();
        }

        public void Excluir(Restaurante entidade)
        {
            var restauranteExcluir = contexto.Restaurantes.First(x => x.Id == entidade.Id);
            contexto.Set<Restaurante>().Remove(restauranteExcluir);
            contexto.SaveChanges();
        }

        public Restaurante ListarPorId(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return contexto.Restaurantes.First(x => x.Id == idInt);
        }

        public IEnumerable<Restaurante> ListarTodos()
        {
            return contexto.Restaurantes;
        }

        public void Salvar(Restaurante entidade)
        {
            if (entidade.Id > 0)
            {
                var restauranteAlterar = contexto.Restaurantes.First(x => x.Id == entidade.Id);
                restauranteAlterar.Nome = entidade.Nome;
            }
            else
            {
                contexto.Restaurantes.Add(entidade);
            }
            contexto.SaveChanges();
        }
    }
}
