using MvcApplication1.Dominio;
using MvcApplication1.Dominio.contrato;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MvcApplication1.RepositorioADO
{
    public class PratoRepositorioADO: IRepositorio<Prato>
    {
        private Contexto contexto;

        public void Alterar(Prato prato)
        {
            var strQuery = "";
            strQuery += "UPDATE PRATO SET ";
            strQuery += string.Format(" Nome do restaurante = '{0}' ", prato.NomeRestaurante);
            strQuery += string.Format(" Nome = '{0}' ", prato.Nome);
            strQuery += string.Format("Preco = '{0}' ", prato.Preco);
            strQuery += string.Format(" WHERE RestauranteId = {0} ", prato.Id);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Excluir(Prato prato)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM PRATO WHERE PratoId = {0}", prato.Id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Inserir(Prato prato)
        {
            var strQuery = "";
            strQuery += "INSERT INTO PRATO (NomeRestaurante, Nome, Preco) ";
            strQuery += string.Format(" VALUES ('{0}', '{1}', '{2}')", prato.NomeRestaurante, prato.Nome, prato.Preco);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Prato prato)
        {
            if (prato.Id > 0)
                Alterar(prato);
            else
                Inserir(prato);
        }

        public IEnumerable<Prato> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM PRATO ";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjetos(retornoDataReader);
            }
        }

        public Prato ListarPorId(string id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format(" SELECT * FROM PRATO WHERE PratoId = {0}", id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjetos(retornoDataReader).FirstOrDefault();
            }
        }

        private List<Prato> TransformaReaderEmListaDeObjetos(SqlDataReader reader)
        {
            var pratos = new List<Prato>();
            while (reader.Read())
            {
                var temObjeto = new Prato()
                {
                    Id = int.Parse(reader["PratoId"].ToString()),
                    NomeRestaurante = reader["NomeRestaurante"].ToString(),
                    Nome = reader["Nome"].ToString(),
                    Preco = decimal.Parse(reader["Preco"].ToString())
                };

                pratos.Add(temObjeto);
            }
            reader.Close();
            return pratos;
        }
    }
}
