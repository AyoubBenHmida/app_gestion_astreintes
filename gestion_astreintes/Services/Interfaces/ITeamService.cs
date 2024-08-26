using gestion_astreintes.Dtos;
using gestion_astreintes.Models;

namespace gestion_astreintes.Services.Interfaces
{
    public interface ITeamService
    {
        IEnumerable<TeamDto> GetTeams();
        TeamDto GetTeamByID(int TeamId);
        TeamDto AddTeam(TeamForCreationDto teamForCreDto);
        void EditTeam(TeamDto teamDto);
        void DeleteTeam(int TeamId);
        TeamDetailsDto GetTeamDetailsById(int TeamId);
       
    }
}
