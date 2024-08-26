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
    public class TeamRepository : ITeamRepository
    {
        private DataContext context;

        public TeamRepository(DataContext context) 
        {
            this.context = context;
        }
        public Team GetTeamByID(int id)
        {
            return context.Teams.Find(id);
        }
        public IEnumerable<Team> GetTeams()
        {
            return context.Teams.ToList();
        }
        public int AddTeam(Team team) {

            context.Teams.Add(team);
            context.SaveChanges();

            return team.Id;
        }

        public void EditTeam(Team team) {
            Team existingTeam = context.Teams.Find(team.Id);
            existingTeam.Name = team.Name;
            context.SaveChanges();
        }

        public void DeleteTeam(int teamId)
        {
            Team team = context.Teams.Find(teamId);
            context.Teams.Remove(team);
            context.SaveChanges();
        }
           
        public bool CheckIfTeamNameExists(string teamName)
        {
            return context.Teams.Any(t => t.Name == teamName);
        }

        public Team GetTeamDetailsById(int id)
        {
            Team team = context.Teams.Include(t => t.Members).ThenInclude(m => m.MemberType).FirstOrDefault(t => t.Id == id);
            return team;
        }
        
    }
   
}
