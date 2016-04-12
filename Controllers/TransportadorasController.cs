using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Transportadora.Models;

namespace Transportadora.Controllers
{
    public class TransportadorasController : Controller
    {
        private AxadoEntities db = new AxadoEntities();

        // GET: Transportadoras
        public ActionResult Index()
        {
            var transportadora = db.Transportadora.Include(t => t.Categoria).Include(t => t.Usuario);
            return View(transportadora.ToList());
        }

        // GET: Transportadoras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var transportadora = db.Transportadora.Find(id);
            if (transportadora == null)
            {
                return HttpNotFound();
            }
            return View(transportadora);
        }

        // GET: Transportadoras/Create
        public ActionResult Create()
        {
            ViewBag.IdCategoria = new SelectList(db.Categoria, "ID", "Nome");
            return View();
        }

        // POST: Transportadoras/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IdCategoria,RazaoSocial,NomeFantasia,CNPJ")] Models.Transportadora transportadora)
        {
            if (ModelState.IsValid)
            {
                transportadora.DataCadastro = DateTime.Now;
                transportadora.IdUsuarioCadastro = Util.Comum.UsuarioLogado().ID;

                db.Transportadora.Add(transportadora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategoria = new SelectList(db.Categoria, "ID", "Nome", transportadora.IdCategoria);
            return View(transportadora);
        }

        // GET: Transportadoras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var transportadora = db.Transportadora.Find(id);
            if (transportadora == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategoria = new SelectList(db.Categoria, "ID", "Nome", transportadora.IdCategoria);
            
            return View(transportadora);
        }

        // POST: Transportadoras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IdCategoria,IdUsuarioCadastro,RazaoSocial,NomeFantasia,CNPJ,DataCadastro")] Models.Transportadora transportadora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transportadora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategoria = new SelectList(db.Categoria, "ID", "Nome", transportadora.IdCategoria);
            ViewBag.IdCategoria = new SelectList(db.Usuario, "ID", "Email", transportadora.IdCategoria);
            return View(transportadora);
        }

        // GET: Transportadoras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var transportadora = db.Transportadora.Find(id);
            if (transportadora == null)
            {
                return HttpNotFound();
            }
            return View(transportadora);
        }

        // POST: Transportadoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var transportadora = db.Transportadora.Find(id);
            db.Transportadora.Remove(transportadora);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
