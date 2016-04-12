using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Transportadora.Models;

namespace Transportadora.Controllers
{
    public class LoginController : Controller
    {
        private AxadoEntities db = new AxadoEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        // POST: Login
        [HttpPost]
        public ActionResult Index(Models.Usuario model)
        {
            var usuario = db.Usuario.FirstOrDefault(c => c.Email == model.Email && c.Senha == model.Senha);

            if (usuario != null)
            {
                FormsAuthentication.SetAuthCookie(model.Email, false);
                Util.Comum.GravarUsuarioLogado(usuario);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErroLogin = "Dados de acesso incorretos!";

            }
            return View(usuario);

        }
    }

}
