using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcApplication1.RepositorioADO;
using MvcApplicattion1.RepositorioEF;

namespace MvcApplication1.Aplicacao
{
    public class RestauranteAplicacaoConstrutor
    {
        public static RestauranteAplicacao RestauranteAplicacaoADO()
        {
            return new RestauranteAplicacao(new RestauranteRepositorioADO());
        }

        public static RestauranteAplicacao RestauranteAplicacaoEF()
        {
            return new RestauranteAplicacao(new RestauranteRepositorioEF());
        }
    }
}
