using MvcApplication1.Aplicacao;
using MvcApplication1.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.UI.Web.Controllers
{
    public class PratoController : Controller
    {
        private readonly PratoAplicacao appPrato;

        public PratoController()
        {
            appPrato = PratoAplicacaoConstrutor.PratoAplicacaoADO();
        }


        public ActionResult Index()
        {
            var listaDePratos = appPrato.ListarTodos();
            return View(listaDePratos);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Prato prato)
        {
            if (ModelState.IsValid)
            {
                appPrato.Salvar(prato);
                return RedirectToAction("Index");
            }
            return View(prato);
        }

        public ActionResult Editar(string id)
        {
            var appPrato = PratoAplicacaoConstrutor.PratoAplicacaoADO();
            var prato = appPrato.ListarPorId(id);

            if (prato == null)
            {
                return HttpNotFound();
            }

            return View(prato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Prato prato)
        {
            if (ModelState.IsValid)
            {
                appPrato.Salvar(prato);
                return RedirectToAction("Index");
            }
            return View(prato);
        }

        public ActionResult Detalhes(string id)
        {
            var prato = appPrato.ListarPorId(id);

            if (prato == null)
            {
                return HttpNotFound();
            }

            return View(prato);
        }

        public ActionResult Excluir(string id)
        {
            var prato = appPrato.ListarPorId(id);

            if (prato == null)
            {
                return HttpNotFound();
            }

            return View(prato);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(string id)
        {
            var prato = appPrato.ListarPorId(id);
            appPrato.Excluir(prato);
            return RedirectToAction("Index");
        }
    }
}