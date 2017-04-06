using MvcApplication1.Aplicacao;
using MvcApplication1.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Dos
{
    class Program
    {
        static void Main(string[] args)
        {
            var appRestaurante = RestauranteAplicacaoConstrutor.RestauranteAplicacaoADO();

            Console.WriteLine("Digite o nome do restaurante: ");
            string nome = Console.ReadLine();

            var restaurante1 = new Restaurante()
            {
                Nome = nome
            };

            //restaurante.Id = 5;

            //appRestaurante.Alterar(restaurante);

            //appRestaurante.Inserir(restaurante1);

            //appRestaurante.Excluir(5);

            appRestaurante.Salvar(restaurante1);

            var dados = appRestaurante.ListarTodos();

            foreach (var restaurante in dados)
            {
                Console.WriteLine("Id:{0}, Nome:{1}", restaurante.Id, restaurante.Nome);
                Console.ReadKey();
            }

        }
    }
}
