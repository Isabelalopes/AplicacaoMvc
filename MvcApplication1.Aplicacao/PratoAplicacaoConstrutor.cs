using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcApplication1.Dominio;
using MvcApplication1.RepositorioADO;
using MvcApplicattion1.RepositorioEF;

namespace MvcApplication1.Aplicacao
{
    public class PratoAplicacaoConstrutor
    {
        public static PratoAplicacao PratoAplicacaoADO()
        {
            return new PratoAplicacao(new PratoRepositorioADO());
        }

        public static PratoAplicacao PratoAplicacaoEF()
        {
            return new PratoAplicacao(new PratoRepositorioEF());
        }
    }
}
