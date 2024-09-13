using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using gestion_astreintes.Models;
using gestion_astreintes.Data;
using Microsoft.EntityFrameworkCore;
using gestion_astreintes.Repositories.Interfaces;

namespace gestion_astreintes.Repositories.Implementation
{
    public class AstreinteRepository : IAstreinteRepository
    {
        private DataContext context;

        public AstreinteRepository(DataContext context)
        {
            this.context = context;
        }
        public Astreinte GetAstreinteByID(int id)
        {
            return context.Astreintes.Include(t => t.Statut).Include(t => t.Employee).FirstOrDefault(t => t.Id == id);
        }
        public IEnumerable<Astreinte> GetAstreintes()
        {
            return context.Astreintes.Include(t => t.Statut).Include(t => t.Employee).ToList();
        }
        public int AddAstreinte(Astreinte astreinte)
        {
            astreinte.Statut = context.Statuts.FirstOrDefault(t => t.Id == 1);
            astreinte.Employee = context.TeamMembers.FirstOrDefault(t => t.Id == astreinte.Employee.Id);
            context.Astreintes.Add(astreinte);
            context.SaveChanges();

            return astreinte.Id;
        }

        public void EditAstreinte(Astreinte astreinte)
        {
            Astreinte existingAstreinte = context.Astreintes.Include(t => t.Statut).FirstOrDefault(t => t.Id == astreinte.Id);
            existingAstreinte.Name = astreinte.Name;
            existingAstreinte.DateDebut = astreinte.DateDebut;
            existingAstreinte.DateFin = astreinte.DateFin;
            existingAstreinte.Description = astreinte.Description;
            context.SaveChanges();
        }

        public void DeleteAstreinte(int astreinteId)
        {
            Astreinte astreinte = context.Astreintes.Find(astreinteId);
            context.Astreintes.Remove(astreinte);
            context.SaveChanges();
        }

        public bool CheckIfAstreinteNameExists(string astreinteName)
        {
            return context.Astreintes.Any(t => t.Name == astreinteName);
        }

        public void UpdateStatus(Astreinte astreinte)
        {
            Astreinte astreinteToChange = context.Astreintes.Include(t => t.Statut).FirstOrDefault(t => t.Id == astreinte.Id);
            astreinteToChange.Statut = context.Statuts.Find(astreinte.Statut.Id) ;
            context.SaveChanges();

        }

        public StatutAstreinte GetStatusById(int id)
        {
            StatutAstreinte statut = context.Statuts.Find(id);
            return statut; 
        }

    }

}
