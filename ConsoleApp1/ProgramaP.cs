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
    class ProgramP
    {
        static void Main(string[] args)
        {
            var appPrato = PratoAplicacaoConstrutor.PratoAplicacaoADO();

            Console.WriteLine("Digite o nome do restaurante: ");
            string nomeRestaurante = Console.ReadLine();

            Console.WriteLine("Digite o nome do prato: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o preco do prato: ");
            string preco = Console.ReadLine();

            var prato1 = new Prato()
            {
                NomeRestaurante = nomeRestaurante,
                Nome = nome,
                Preco = decimal.Parse(preco)
            };
        }
    }
}
