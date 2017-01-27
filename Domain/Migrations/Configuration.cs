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
            //    new SuperHero {Name="������", Description="������� - ������� ����"},
            //    new SuperHero {Name="��������", Description="����� ������� � ������� ������������"},
            //    new SuperHero {Name="����������", Description="������� - ����"},
            //    new SuperHero {Name="��������", Description="������ �� �������� �������� �� ��������� ������ ���"},
            //    new SuperHero {Name="������", Description="������ �� �������� �������� �� ��������� ������ ���"},
            //    new SuperHero {Name="��������", Description="�������������, ������ �� ������ ������ �������� ����������������"},
            //    new SuperHero {Name="�����", Description="��������� ��� ���� �����, ��������� ������� �������� �������"},
            //    new SuperHero {Name="������ ������", Description="������� ����� � ��������, �������� ������ ����"},
            //    new SuperHero {Name="�����", Description="���������, ������"},
            //    new SuperHero {Name="�������", Description="����� �� ������ ��� �����"}
            //};
            //heroes.ForEach(c => context.SuperHeroes.AddOrUpdate(p => p.Name, c));
            //context.SaveChanges();

            //var powers = new List<SuperPower>
            //{
            //    new SuperPower {Name="������������ ����", Description="��������� ��������������������������, ���������� ������ �� ������� ������������ ������������", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "�������").Id },
            //    new SuperPower {Name="����������� ���� ��� �����", Description="����������� ��������� ���� ��� �����, � ���� ������������ ������ ������� � ��������������", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "������ ������").Id },
            //    new SuperPower {Name="������������������", Description="����������� ������������� ������ ������������", Rating = 89, SuperHeroId = heroes.Single(h => h.Name == "������ ������").Id },
            //    new SuperPower {Name="�������� �� ����", Description="����������� ��������� �������� �� ���� �������� ������������ ����������", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "������ ������").Id },
            //    new SuperPower {Name="����� �� ��������", Description="���������� ���������� ���� �������� ������", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "�����").Id },
            //    new SuperPower {Name="�������������������", Description="������������ � ����������� � �������", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "�����").Id },
            //    new SuperPower {Name="������������ � �������", Description="����������� ����������������� ����� �������", Rating = 61, SuperHeroId = heroes.Single(h => h.Name == "�����").Id },
            //    new SuperPower {Name="������������ � �������������", Description="����������� ������������� ���������������� ����� ���������� ����� ����� ������� � �������������", Rating = 61, SuperHeroId = heroes.Single(h => h.Name == "�����").Id },
            //    new SuperPower {Name="����������", Description="������������ ������� ����������������� �����, ��������� ������������ � �����������", Rating = 61, SuperHeroId = heroes.Single(h => h.Name == "�����").Id },
            //    new SuperPower {Name="���������� ����������", Description="���������� ���������� ���� �������� ������", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "��������").Id },
            //    new SuperPower {Name="���������� �����������", Description="����������� ����������� ����������������� ����� �������", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "������").Id },
            //    new SuperPower {Name="������������ � �������", Description="����������������� � �������� � �������", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "������").Id },
            //    new SuperPower {Name="���������� ������", Description="����������������� � ���������� ������ � ������ ������", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "������").Id },
            //    new SuperPower {Name="�������� ������������", Description="����������� ������ ����� ����������� �� ������� ����� ������������", Rating = 55, SuperHeroId = heroes.Single(h => h.Name == "��������").Id },
            //    new SuperPower {Name="�������������� ������", Description="����������� ����������������� ����� �������", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "��������").Id },
            //    new SuperPower {Name="������������ � ����", Description="����������������� � ��������� ���������", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "��������").Id },
            //    new SuperPower {Name="������������", Description="������������� � ����������� ������", Rating = 75, SuperHeroId = heroes.Single(h => h.Name == "��������").Id },
            //    new SuperPower {Name="�������������", Description="����� ������� �������� �������� � ����������� � ������������", Rating = 59, SuperHeroId = heroes.Single(h => h.Name == "��������").Id },
            //    new SuperPower {Name="���������", Description="���������� ���� ������� ���� �������", Rating = 55, SuperHeroId = heroes.Single(h => h.Name == "��������").Id },
            //    new SuperPower {Name="�����������������", Description="����������� ������ ����� ����������� �� ������� ����� ������������", Rating = 55, SuperHeroId = heroes.Single(h => h.Name == "��������").Id },
            //    new SuperPower {Name="�����������", Description="����������� ����������������� ����� �������", Rating = 65, SuperHeroId = heroes.Single(h => h.Name == "��������").Id },
            //    new SuperPower {Name="���������", Description="����������� ������ ��� ������������� ����������� �������", Rating = 55, SuperHeroId = heroes.Single(h => h.Name == "��������").Id },
            //    new SuperPower {Name="��������������", Description="���������� �����������, ����������� ����������� ������������ �����������", Rating = 55, SuperHeroId = heroes.Single(h => h.Name == "������").Id },
            //    new SuperPower {Name="������ �������", Description="����������� ����������� ���������", Rating = 54, SuperHeroId = heroes.Single(h => h.Name == "����������").Id },
            //    new SuperPower {Name="������ ������", Description="����������� ������ � �������", Rating = 55, SuperHeroId = heroes.Single(h => h.Name == "����������").Id },
            //    new SuperPower {Name="������ �����������", Description="��������� ����, ���������, ����������� ��������� �������", Rating = 55, SuperHeroId = heroes.Single(h => h.Name == "����������").Id }
            //};
            //powers.ForEach(c => context.SuperPowers.AddOrUpdate(p => p.Name, c));
            //context.SaveChanges();
        }        
    }
}
