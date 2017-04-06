using MvcApplication1.Dominio;
using MvcApplication1.Dominio.contrato;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MvcApplication1.RepositorioADO
{
    public class RestauranteRepositorioADO : IRepositorio<Restaurante>
    {
        private Contexto contexto;

        public void Alterar(Restaurante restaurante)
        {
            var strQuery = "";
            strQuery += "UPDATE RESTAURANTE SET ";
            strQuery += string.Format(" Nome = '{0}' ", restaurante.Nome);
            strQuery += string.Format(" WHERE RestauranteId = {0} ", restaurante.Id);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Excluir(Restaurante restaurante)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM RESTAURANTE WHERE RestauranteId = {0}", restaurante.Id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Inserir(Restaurante restaurante)
        {
            var strQuery = "";
            strQuery += "INSERT INTO RESTAURANTE (Nome) ";
            strQuery += string.Format(" VALUES ('{0}')", restaurante.Nome);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Restaurante restaurante)
        {
            if (restaurante.Id > 0)
                Alterar(restaurante);
            else
                Inserir(restaurante);
        }

        public IEnumerable<Restaurante> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM RESTAURANTE ";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjetos(retornoDataReader);
            }
        }

        public Restaurante ListarPorId(string id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" SELECT * FROM RESTAURANTE WHERE RestauranteId = {0}", id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjetos(retornoDataReader).FirstOrDefault();
            }
        }

        private List<Restaurante> TransformaReaderEmListaDeObjetos(SqlDataReader reader)
        {
            var restaurantes = new List<Restaurante>();
            while (reader.Read())
            {
                var temObjeto = new Restaurante()
                {
                    Id = int.Parse(reader["RestauranteId"].ToString()),
                    Nome = reader["Nome"].ToString()
                };

                restaurantes.Add(temObjeto);
            }
            reader.Close();
            return restaurantes;
        }
    }
}
