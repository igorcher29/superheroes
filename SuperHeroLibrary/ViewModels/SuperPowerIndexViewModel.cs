using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using PagedList;

namespace SuperHeroLibrary.ViewModels
{
    public class SuperPowerIndexViewModel
    {
        public IPagedList<SuperPower> SuperPowers { get; set; }
        public string Search { get; set; }
        public IEnumerable<SuperHeroWithCount> SuperHeroesWithCount { get; set; }
        [Display(Name = "Имя супергероя")]
        public string SuperHero { get; set; }
        public string SortBy { get; set; }
        public Dictionary<string,string> Sorts { get; set; }

        public IEnumerable<SelectListItem> SuperHeroFilterItems
        {
            get
            {
                var allSuperHeroes = SuperHeroesWithCount.Select(h => new SelectListItem { Value = h.SuperHeroName, Text = h.SuperHeroNameWithCount });
                return allSuperHeroes;
            }
        }

    }

    public class SuperHeroWithCount
    {
        public int SuperPowerCount { get; set; }
        public string SuperHeroName { get; set; }
        public string SuperHeroNameWithCount
        {
            get
            {
                return SuperHeroName + " (" + SuperPowerCount.ToString() + ")";
            }
        }
    }
}