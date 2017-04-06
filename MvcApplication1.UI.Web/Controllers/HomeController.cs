using MvcApplication1.Aplicacao;
using MvcApplication1.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }

        //RESTAURANTES
        //............................................
        public ActionResult Restaurantes()
        {
            var restaurante = new Restaurante
            {
                Nome = ""
            };
            ViewData["Nome"] = restaurante.Nome;

            return View(restaurante);
        }

        //PRATOS
        //......................................................
        public ActionResult Pratos()
        {
            var prato = new Prato()
            {
                NomeRestaurante = "",
                Nome = "",
                Preco = 0
            };
            ViewData["NomeRestaurante"] = prato.NomeRestaurante;
            ViewData["Nome"] = prato.Nome;
            ViewData["Preco"] = prato.Preco;

            return View(prato);
        }
    }
}