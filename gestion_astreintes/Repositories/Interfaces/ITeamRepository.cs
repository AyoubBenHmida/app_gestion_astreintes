using gestion_astreintes.Dtos;
using gestion_astreintes.Models;

namespace gestion_astreintes.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetTeams();
        Team GetTeamByID(int TeamId);
        int AddTeam(Team team);
        void EditTeam(Team team);
        void DeleteTeam(int teamId);
        bool CheckIfTeamNameExists(string teamName);
        Team GetTeamDetailsById(int teamId);
        
    }
}
