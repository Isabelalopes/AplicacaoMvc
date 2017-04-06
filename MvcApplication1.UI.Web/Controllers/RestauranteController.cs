using MvcApplication1.Aplicacao;
using MvcApplication1.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.UI.Web.Controllers
{
    public class RestauranteController : Controller
    {
        // GET: Restaurante
        public ActionResult Index()
        {
            var appRestaurante = RestauranteAplicacaoConstrutor.RestauranteAplicacaoADO();
            var listaDeRestaurantes = appRestaurante.ListarTodos();
            return View(listaDeRestaurantes);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Restaurante restaurante)
        {
            if (ModelState.IsValid)
            {
                var appRestaurante = RestauranteAplicacaoConstrutor.RestauranteAplicacaoADO();
                appRestaurante.Salvar(restaurante);
                return RedirectToAction("Index");
            }
            return View(restaurante);
        }

        public ActionResult Editar(string id)
        {
            var appRestaurante = RestauranteAplicacaoConstrutor.RestauranteAplicacaoADO();
            var restaurante = appRestaurante.ListarPorId(id);

            if(restaurante == null)
            {
                return HttpNotFound();
            }

            return View(restaurante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Restaurante restaurante)
        {
            if (ModelState.IsValid)
            {
                var appRestaurante = RestauranteAplicacaoConstrutor.RestauranteAplicacaoADO();
                appRestaurante.Salvar(restaurante);
                return RedirectToAction("Index");
            }
            return View(restaurante);
        }

        public ActionResult Detalhes(string id)
        {
            var appRestaurante = RestauranteAplicacaoConstrutor.RestauranteAplicacaoADO();
            var restaurante = appRestaurante.ListarPorId(id);

            if (restaurante == null)
            {
                return HttpNotFound();
            }

            return View(restaurante);
        }

        public ActionResult Excluir(string id)
        {
            var appRestaurante = RestauranteAplicacaoConstrutor.RestauranteAplicacaoADO();
            var restaurante = appRestaurante.ListarPorId(id);

            if (restaurante == null)
            {
                return HttpNotFound();
            }

            return View(restaurante);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(string id)
        {
            var appRestaurante = RestauranteAplicacaoConstrutor.RestauranteAplicacaoADO();
            var restaurante = appRestaurante.ListarPorId(id);
            appRestaurante.Excluir(restaurante);
            return RedirectToAction("Index");
        }
    }
}