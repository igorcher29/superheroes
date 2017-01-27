using System;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Abstract;


namespace Domain.Concrete
{
    public class EFSuperHeroesRepository : ISuperHeroesRepository
    {
        private EFDbContext context = new EFDbContext();

        public void DeleteSuperPower(int superpowerId)
        {
            SuperPower superpower = GetSuperPower(superpowerId);
            if (superpower!=null)
            {
                context.SuperPowers.Remove(superpower);
                context.SaveChanges();
            }
        }
        public void DeleteSuperhero(int superheroId)
        {
            SuperHero superHero = GetSuperHero(superheroId);
            if (superHero != null)
            {
                foreach (var sp in superHero.SuperPowers)
                {
                    sp.SuperHeroId = null;
                }
                context.SuperHeroes.Remove(superHero);
                context.SaveChanges();
            }  
        }

        public void SaveSuperPower(SuperPower power, HttpPostedFileBase uploadImage)
        {
            if (power.Id == 0)
            {
                if (uploadImage != null)
                {
                    power.ImageMimeType = uploadImage.ContentType;
                    power.ImageData = new byte[uploadImage.ContentLength];
                    uploadImage.InputStream.Read(power.ImageData, 0, uploadImage.ContentLength);
                }
                context.SuperPowers.Add(power);
            }
            else
            {
                SuperPower dbEntry = context.SuperPowers.Find(power.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = power.Name;
                    dbEntry.Description = power.Description;
                    dbEntry.Rating = power.Rating;
                    if (uploadImage != null)
                    {
                        dbEntry.ImageMimeType = uploadImage.ContentType;
                        dbEntry.ImageData = new byte[uploadImage.ContentLength];
                        uploadImage.InputStream.Read(dbEntry.ImageData, 0, uploadImage.ContentLength);
                    }
                    context.Entry(dbEntry).State = EntityState.Modified;
                }
            }
            context.SaveChanges();
        }
        public void SaveSuperHero(SuperHero hero, HttpPostedFileBase uploadImage, string userId)
        {
            if (hero.Id == 0)
            {
                if (uploadImage != null)
                {
                    hero.ImageMimeType = uploadImage.ContentType;
                    hero.ImageData = new byte[uploadImage.ContentLength];
                    uploadImage.InputStream.Read(hero.ImageData, 0, uploadImage.ContentLength);
                }
                hero.UserId = userId;
                context.SuperHeroes.Add(hero);
            }
            else
            {
                SuperHero dbEntry = context.SuperHeroes.Find(hero.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = hero.Name;
                    dbEntry.Description = hero.Description;
                    hero.UserId = userId;

                    if (uploadImage!=null)
                    {
                        dbEntry.ImageMimeType = uploadImage.ContentType;
                        dbEntry.ImageData = new byte[uploadImage.ContentLength];
                        uploadImage.InputStream.Read(dbEntry.ImageData, 0, uploadImage.ContentLength);
                    }

                    context.Entry(dbEntry).State = EntityState.Modified;
                }
            }
            context.SaveChanges();
        }

        public SuperPower GetSuperPower(int? powerId)
        {
            SuperPower dbEntry = null;

            if (powerId != null)
            {
                dbEntry = context.SuperPowers.Find(powerId);
            }

            return dbEntry;
        }
        public SuperHero GetSuperHero(int? heroId)
        {
            SuperHero dbEntry = null;

            if (heroId != null)
            {
                dbEntry = context.SuperHeroes.Find(heroId);
            }
            
            return dbEntry;
        }

        public IEnumerable<SuperHero> GetSuperHeroesForUser(string userId)
        {
            return context.SuperHeroes.Where(c => c.UserId == userId).OrderBy(c => c.Name).ToList();
        }

        public DbSet<SuperHero> SuperHeroes
        {
            get
            {
                return context.SuperHeroes;
            }
        }

        public DbSet<SuperPower> SuperPowers
        {
            get
            {
                return context.SuperPowers;
            }
        }
    }
}
