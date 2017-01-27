using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Domain.Entities;
using Domain.Concrete;

namespace Domain.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Domain.Concrete.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Domain.Concrete.EFDbContext context)
        {
            //var heroes = new List<SuperHero>
            //{
            //    new SuperHero {Name="Бэтмен", Description="Человек - летучая мышь"},
            //    new SuperHero {Name="Супермен", Description="Очень сильный и быстрый сверхчеловек"},
            //    new SuperHero {Name="Спайдермен", Description="Человек - паук"},
            //    new SuperHero {Name="Росомаха", Description="Создан из обычного человека по программе Оружие Икс"},
            //    new SuperHero {Name="Дэдпул", Description="Создан из обычного человека по программе Оружие Икс"},
            //    new SuperHero {Name="Охотница", Description="Суперзлодейка, входит во второй состав Общества Несправедливости"},
            //    new SuperHero {Name="Блэйд", Description="Настоящее имя Эрик Брукс, мастерски владеет холодным оружием"},
            //    new SuperHero {Name="Зелёная Стрела", Description="Вооружён луком и стрелами, косплеит Робина Гуда"},
            //    new SuperHero {Name="Нэмор", Description="Подводник, атлант"},
            //    new SuperHero {Name="Хеллбой", Description="Демон на службе сил добра"}
            //};
            //heroes.ForEach(c => context.SuperHeroes.AddOrUpdate(p => p.Name, c));
            //context.SaveChanges();

            //var powers = new List<SuperPower>
            //{
            //    new SuperPower {Name="Демоническая сила", Description="Обладание демоническимиспособностями, выходящими далеко за пределы человеческих возможностей", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "Хеллбой").Id },
            //    new SuperPower {Name="Способность жить под водой", Description="Способность нормально жить под водой, в силу особенностей систем дыхания и кровообращения", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "Зелёная Стрела").Id },
            //    new SuperPower {Name="Морозоустойчивость", Description="Способность противостоять низким теипературам", Rating = 89, SuperHeroId = heroes.Single(h => h.Name == "Зелёная Стрела").Id },
            //    new SuperPower {Name="Стрельба из лука", Description="Способность мастерски стрелять из лука стрелами специального назначения", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "Зелёная Стрела").Id },
            //    new SuperPower {Name="Чутьё на вампиров", Description="Спортивная подготовка выше среднего уровня", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "Блэйд").Id },
            //    new SuperPower {Name="Вампироустойчивость", Description="Устойчивость к превращению в вампира", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "Блэйд").Id },
            //    new SuperPower {Name="Устойчивость к травмам", Description="Способность восстанавливаться после ранения", Rating = 61, SuperHeroId = heroes.Single(h => h.Name == "Блэйд").Id },
            //    new SuperPower {Name="Устойчивость к ультрафиолету", Description="Способность противостоять ультрафиолетовым лучам солнечного света любой степени и интенсивности", Rating = 61, SuperHeroId = heroes.Single(h => h.Name == "Блэйд").Id },
            //    new SuperPower {Name="Бессмертие", Description="Неопределённо большая продолжительность жизни, вызванная способностью к регенерации", Rating = 61, SuperHeroId = heroes.Single(h => h.Name == "Блэйд").Id },
            //    new SuperPower {Name="Спортивная подготовка", Description="Спортивная подготовка выше среднего уровня", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "Охотница").Id },
            //    new SuperPower {Name="Мгновенная регенерация", Description="Способность моментально восстанавливаться после ранения", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "Дэдпул").Id },
            //    new SuperPower {Name="Устойчивость к вирусам", Description="Невосприимчивость к болезням и вирусам", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "Дэдпул").Id },
            //    new SuperPower {Name="Ментальная защита", Description="Невосприимчивость к ментальным атакам и чтению мыслей", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "Дэдпул").Id },
            //    new SuperPower {Name="Медвежья выносливость", Description="Способность долгое время действовать на пределе своих возможностей", Rating = 55, SuperHeroId = heroes.Single(h => h.Name == "Росомаха").Id },
            //    new SuperPower {Name="Восстановление тканей", Description="Способность восстанавливаться после ранения", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "Росомаха").Id },
            //    new SuperPower {Name="Устойчивость к ядам", Description="Невосприимчивость к токсичным веществам", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "Росомаха").Id },
            //    new SuperPower {Name="Неуязвимость", Description="Устройчивость к воздействию оружия", Rating = 75, SuperHeroId = heroes.Single(h => h.Name == "Супермен").Id },
            //    new SuperPower {Name="Суперскорость", Description="Очень высокая скорость движений и перемещения в пространстве", Rating = 59, SuperHeroId = heroes.Single(h => h.Name == "Супермен").Id },
            //    new SuperPower {Name="Суперсила", Description="Физическая сила гораздо выше обычной", Rating = 55, SuperHeroId = heroes.Single(h => h.Name == "Супермен").Id },
            //    new SuperPower {Name="Супервыносливость", Description="Способность долгое время действовать на пределе своих возможностей", Rating = 55, SuperHeroId = heroes.Single(h => h.Name == "Супермен").Id },
            //    new SuperPower {Name="Регенерация", Description="Способность восстанавливаться после ранения", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "Супермен").Id },
            //    new SuperPower {Name="Левитация", Description="Способность летать без использования технических средств", Rating = 55, SuperHeroId = heroes.Single(h => h.Name == "Супермен").Id },
            //    new SuperPower {Name="Суперинтеллект", Description="Умственные способности, значительно превышающие человеческие возможности", Rating = 55, SuperHeroId = heroes.Single(h => h.Name == "Бэтмен").Id },
            //    new SuperPower {Name="Шестое чувство", Description="Способность чувствовать опасность", Rating = 54, SuperHeroId = heroes.Single(h => h.Name == "Спайдермен").Id },
            //    new SuperPower {Name="Ночное зрения", Description="Способность видеть в темноте", Rating = 55, SuperHeroId = heroes.Single(h => h.Name == "Спайдермен").Id },
            //    new SuperPower {Name="Паучьи способности", Description="Токсичные жала, липучесть, способность создавать паутину", Rating = 55, SuperHeroId = heroes.Single(h => h.Name == "Спайдермен").Id }
            //};
            //powers.ForEach(c => context.SuperPowers.AddOrUpdate(p => p.Name, c));
            //context.SaveChanges();
        }        
    }
}
