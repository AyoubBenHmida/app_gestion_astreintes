using gestion_astreintes.Models;

namespace gestion_astreintes.Repositories.Interfaces
{
    public interface ITeamMemberRepository
    {
        IEnumerable<TeamMember> GetTeamMembers();
        TeamMember GetTeamMemberByID(int TeamMemberId);
        int AddTeamMember(TeamMember teamMember);
        void EditTeamMember(TeamMember teamMember);
        void DeleteTeamMember(int teamMemberId);
        bool CheckIfTeamMemberExists(TeamMember teamMember);
        bool CheckTeamMemberForEdit(TeamMember teamMember);
        TeamMemberType GetMemberTypebyId(int id);
        IEnumerable<TeamMember> GetTeamMembersByTeamId(int teamId);
        TeamMember GetTeamLeaderByTeamId(int teamId);

    }
}
