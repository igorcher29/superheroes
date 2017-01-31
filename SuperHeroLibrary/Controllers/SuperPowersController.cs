using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Concrete;
using Domain.Entities;
using PagedList;
using SuperHeroLibrary.ViewModels;

namespace SuperHeroLibrary.Controllers
{
    public class SuperPowersController : Controller
    {
        //private EFDbContext ctx = new EFDbContext();
        private EFSuperHeroesRepository repository = new EFSuperHeroesRepository();

        // GET: SuperPowers
        public ActionResult Index(string superhero, string search, string sortBy, int? page)
        {
            var viewModel = new SuperPowerIndexViewModel();
            var superPowers = repository.SuperPowers.Include(s => s.SuperHero);

            if (!String.IsNullOrEmpty(search))
            {
                superPowers = superPowers.Where(s => s.Name.Contains(search) || s.Description.Contains(search) || s.SuperHero.Name.Contains(search));                
                viewModel.Search = search;
            }

            var superheroes = superPowers.OrderBy(p => p.SuperHero.Name).Select(p => p.SuperHero.Name).Distinct();//?

            viewModel.SuperHeroesWithCount = from matchingSuperpowers in superPowers
                                             where matchingSuperpowers.SuperHeroId != null
                                             group matchingSuperpowers by
                                             matchingSuperpowers.SuperHero.Name into
                                             superheroGroup
                                             select new SuperHeroWithCount
                                             {
                                                 SuperHeroName = superheroGroup.Key,
                                                 SuperPowerCount = superheroGroup.Count()
                                             };

            if (!String.IsNullOrEmpty(superhero))
            {
                superPowers = superPowers.Where(s => s.SuperHero.Name == superhero);
                viewModel.SuperHero = superhero;
            }

            switch (sortBy)
            {
                case "rating_highest":
                    superPowers = superPowers.OrderBy(r => r.Rating);
                    break;
                case "rating_lowest":
                    superPowers = superPowers.OrderByDescending(r => r.Rating);
                    break;
                default:
                    superPowers = superPowers.OrderBy(r => r.Name);
                    break;
            }

            const int pageItems = 5;
            int currentPage = (page ?? 1);

            //viewModel.SuperPowers = superPowers;
            viewModel.SuperPowers = superPowers.ToPagedList(currentPage, pageItems);
            viewModel.SortBy = sortBy;

            viewModel.Sorts = new Dictionary<string, string>
            {
                { "Прокачка по возрастанию", "rating_highest" },
                { "Прокачка по убыванию", "rating_lowest"}
            };
            
            return View(viewModel);
        }

        // GET: SuperPowers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            SuperPower superPower = repository.GetSuperPower(id);

            if (superPower == null)
            {
                return HttpNotFound();
            }
            return View(superPower);
        }

        // GET: SuperPowers/Create
        public ActionResult Create()
        {
            ViewBag.SuperHeroId = new SelectList(repository.SuperHeroes, "Id", "Name");
            return View();
        }

        // POST: SuperPowers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperPower superPower, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                repository.SaveSuperPower(superPower, image);
                //return RedirectToAction("Index");
                return RedirectToAction
                    (
                    "Edit",
                    new
                    {
                        controller = "SuperHeroes",
                        action = "Edit",
                        id = superPower.SuperHeroId
                    }
                    );
            }

            ViewBag.SuperHeroId = new SelectList(repository.SuperHeroes, "Id", "Name", superPower.SuperHeroId);
            return View(superPower);
        }

        // GET: SuperPowers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuperPower superPower = repository.SuperPowers.Find(id);
            if (superPower == null)
            {
                return HttpNotFound();
            }
            ViewBag.SuperHeroId = new SelectList(repository.SuperHeroes, "Id", "Name", superPower.SuperHeroId);
            return View(superPower);
        }

        // POST: SuperPowers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuperPower superPower, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                repository.SaveSuperPower(superPower, image);
                
                return RedirectToAction
                    (
                    "Edit",
                    new
                        {
                            controller = "SuperHeroes",
                            action = "Edit",
                            id = superPower.SuperHeroId
                        }
                    );
            }
            ViewBag.SuperHeroId = new SelectList(repository.SuperHeroes, "Id", "Name", "Rating", superPower.SuperHeroId);
            return View(superPower);
        }

        // GET: SuperPowers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuperPower superPower = repository.GetSuperPower(id);
            if (superPower == null)
            {
                return HttpNotFound();
            }
            return View(superPower);
        }

        // POST: SuperPowers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //SuperPower superPower = repository.GetSuperPower(id);

            //ctx.SuperPowers.Remove(superPower);
            //ctx.SaveChanges();
            repository.DeleteSuperPower(id);
            return RedirectToAction("Index");
        }

        public FileContentResult GetImage(int superpowerId)
        {
            SuperPower superpower = repository.GetSuperPower(superpowerId);
            if (superpower != null)
            {
                return File(superpower.ImageData, superpower.ImageMimeType);
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
