using MvcApplication1.Dominio;
using MvcApplication1.Dominio.contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplicattion1.RepositorioEF
{
    public class PratoRepositorioEF : IRepositorio<Prato>
    {
        private readonly Contexto contexto;

        public PratoRepositorioEF()
        {
            contexto = new Contexto();
        }

        public void Excluir(Prato entidade)
        {
            var pratoExcluir = contexto.Pratos.First(x => x.Id == entidade.Id);
            contexto.Set<Prato>().Remove(pratoExcluir);
            contexto.SaveChanges();
        }

        public Prato ListarPorId(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return contexto.Pratos.First(x => x.Id == idInt);
        }

        public IEnumerable<Prato> ListarTodos()
        {
            return contexto.Pratos;
        }

        public void Salvar(Prato entidade)
        {
            if (entidade.Id > 0)
            {
                var pratoAlterar = contexto.Pratos.First(x => x.Id == entidade.Id);
                pratoAlterar.NomeRestaurante = entidade.NomeRestaurante;
                pratoAlterar.Nome = entidade.Nome;
                pratoAlterar.Preco = entidade.Preco;
            }
            else
            {
                contexto.Pratos.Add(entidade);
            }
            contexto.SaveChanges();
        }
    }
}
