using gestion_astreintes.Dtos;
using gestion_astreintes.Models;

namespace gestion_astreintes.Services.Interfaces
{
    public interface ITeamMemberService
    {
        IEnumerable<TeamMemberDto> GetTeamMembers();
        TeamMemberDto GetTeamMemberByID(int TeamMemberId);
        EmpAstreintesDto GetAstreintesByEmployeeId(int EmployeeId);
        TeamMemberDto AddTeamMember(TeamMemberForCreationDto teamMemberForCreDto);
        void EditTeamMember(TeamMemberForEditDto teamMemberForEdit);
        void DeleteTeamMember(int TeamMemberId);
    }
}
