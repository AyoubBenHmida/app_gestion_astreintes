using gestion_astreintes.Data;
using gestion_astreintes.Models;
using gestion_astreintes.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace gestion_astreintes.Repositories.Implementation

{
    public class TeamMemberRepository : ITeamMemberRepository
    {
        private DataContext context;
        public TeamMemberRepository(DataContext context) {
            this.context = context;
        }

        public TeamMember GetTeamMemberByID(int id)
        {
            return context.TeamMembers.Include(t => t.MemberType).Include(t => t.Team).FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<TeamMember> GetTeamMembers()
        {
            return context.TeamMembers.Include(t => t.MemberType).Include(t => t.Team).ToList();
        }

        public IEnumerable<TeamMember> GetTeamMembersByTeamId(int teamId)
        {
            return context.TeamMembers.Where(t => t.Team.Id == teamId);
        }

        public TeamMember GetTeamLeaderByTeamId(int teamId)
        {
            return context.TeamMembers
                .Include(t => t.MemberType)
                .Include(t => t.Team)
                .FirstOrDefault(t => t.MemberType.Id == 1 && t.Team.Id == teamId);
        }

        public int AddTeamMember(TeamMember teamMember)
        {
            context.TeamMembers.Add(teamMember);
            context.SaveChanges();
            return teamMember.Id;
        }

        public void EditTeamMember(TeamMember teamMember)
        {
            TeamMember existingTeamMember = context.TeamMembers.Include(t => t.MemberType).FirstOrDefault(t => t.Id == teamMember.Id);
            existingTeamMember.Name = teamMember.Name;
            existingTeamMember.Email = teamMember.Email;
            existingTeamMember.MemberType = context.TeamMembersMemberTypes.Find(teamMember.MemberType.Id) ;
            context.SaveChanges();
        }

        public void DeleteTeamMember(int teamMemberId)
        {
            TeamMember teamMember = context.TeamMembers.Find(teamMemberId);
            context.TeamMembers.Remove(teamMember);
            context.SaveChanges();
        }

        public bool CheckIfTeamMemberExists(TeamMember teamMember)
        {
            TeamMember member = context.TeamMembers.Include(t => t.MemberType).FirstOrDefault(t =>(t.Email == teamMember.Email));
            return member != null;

        }

        public bool CheckTeamMemberForEdit(TeamMember teamMember)
        {
            TeamMember member = context.TeamMembers.Include(t => t.MemberType).FirstOrDefault(t => (t.Email == teamMember.Email));
            if(member.Name == teamMember.Name)
            {
                if((member.Team == teamMember.Team)&&(member.MemberType == teamMember.MemberType)) {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }

        }

        public TeamMemberType GetMemberTypebyId(int id)
        {
            return context.TeamMembersMemberTypes.Find(id);
        }
    }
}
