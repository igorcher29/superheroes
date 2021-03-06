﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Concrete;
using Domain.Entities;
using Microsoft.AspNet.Identity.Owin;
using SuperHeroLibrary.Models;
using Microsoft.AspNet.Identity;

namespace SuperHeroLibrary.Controllers
{
    public class SuperHeroesController : Controller
    {
        private EFSuperHeroesRepository repository = new EFSuperHeroesRepository();

        private string CurrentUserId()
        {
            string userId = String.Empty;

            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByEmail(User.Identity.Name);

            if (user != null)
            {
                userId = user.Id;
            }

            return userId;
        }

        // GET: SuperHeroes
        [Authorize]
        public ActionResult Index()
        {   
            return View(repository.GetSuperHeroesForUser(CurrentUserId()));
        }

        // GET: SuperHeroes/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuperHero superHero = repository.GetSuperHero(id);
            if (superHero == null)
            {
                return HttpNotFound();
            }
            return View(superHero);
        }

        // GET: SuperHeroes/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperHeroes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperHero superHero, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                //ctx.SuperHeroes.Add(superHero);
                //ctx.SaveChanges();

                repository.SaveSuperHero(superHero, image, CurrentUserId());
                
                return RedirectToAction("Index");
            }

            return View(superHero);
        }

        // GET: SuperHeroes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuperHero superHero = repository.GetSuperHero(id);
            if (superHero == null)
            {
                return HttpNotFound();
            }
            return View(superHero);
        }

        // POST: SuperHeroes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuperHero superHero, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {                
                repository.SaveSuperHero(superHero, image, CurrentUserId());
                return RedirectToAction("Index");
            }
            return View(superHero);
        }

        // GET: SuperHeroes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuperHero superHero = repository.GetSuperHero(id);
            if (superHero == null)
            {
                return HttpNotFound();
            }
            return View(superHero);
        }

        // POST: SuperHeroes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.DeleteSuperhero(id);
            return RedirectToAction("Index");
        }

        public FileContentResult GetImage(int superheroId)
        {
            //SuperHero superhero = ctx.SuperHeroes.FirstOrDefault(s => s.Id == superheroId);
            SuperHero superhero = repository.GetSuperHero(superheroId);
            if (superhero != null)
            {
                return File(superhero.ImageData, superhero.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //ctx.Dispose();                               
            }
            base.Dispose(disposing);
        }
    }
}
