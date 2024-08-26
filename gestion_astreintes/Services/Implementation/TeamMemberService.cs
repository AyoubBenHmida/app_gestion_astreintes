using AutoMapper;
using gestion_astreintes.Dtos;
using gestion_astreintes.Exceptions;
using gestion_astreintes.Models;
using gestion_astreintes.Repositories.Interfaces;
using gestion_astreintes.Services.Interfaces;

namespace gestion_astreintes.Services.Implementation
{
    public class TeamMemberService : ITeamMemberService
    {
        private ITeamMemberRepository _teamMemberrepository;
        private ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public TeamMemberService(ITeamMemberRepository memberRepository, IMapper mapper , ITeamRepository teamRepository)
        {
            this._teamMemberrepository = memberRepository;
            this._teamRepository = teamRepository;
            _mapper = mapper;
        }

        public IEnumerable<TeamMemberDto> GetTeamMembers()
        {
            List<TeamMember> teamMembers = _teamMemberrepository.GetTeamMembers().ToList();
            return teamMembers.Select(t => _mapper.Map<TeamMember, TeamMemberDto>(t)).ToList();
            
        }

        public TeamMemberDto GetTeamMemberByID(int TeamMemberId)
        {
            TeamMember teamMember = _teamMemberrepository.GetTeamMemberByID(TeamMemberId);
            TeamMemberDto teamMemberDto = _mapper.Map<TeamMember, TeamMemberDto>(teamMember);
            return teamMemberDto;
        }

        public TeamMemberDto AddTeamMember(TeamMemberForCreationDto teamMemberForCreDto)
        {
            TeamMember teamMember = _mapper.Map<TeamMemberForCreationDto, TeamMember>(teamMemberForCreDto);
            teamMember.MemberType = _teamMemberrepository.GetMemberTypebyId(teamMember.MemberType.Id);
            teamMember.Team = _teamRepository.GetTeamByID(teamMember.Team.Id);
            if (_teamMemberrepository.CheckIfTeamMemberExists(teamMember))
            {
                throw new TeamMemberExistsException("this team member exists, you can't add it ");
            }
            
            int id = _teamMemberrepository.AddTeamMember(teamMember);
            TeamMemberDto teamMemberDto = _mapper.Map<TeamMember, TeamMemberDto>(teamMember);
            teamMemberDto.Id = id;
            return teamMemberDto;
        }

        public void EditTeamMember(TeamMemberForEditDto teamMemberForEdit)
        {
            if (_teamMemberrepository.GetTeamMemberByID(teamMemberForEdit.Id) != null)
            {
                TeamMember teamMember = _mapper.Map<TeamMemberForEditDto, TeamMember>(teamMemberForEdit);
                if (_teamMemberrepository.CheckTeamMemberForEdit(teamMember))
                {
                    throw new TeamMemberExistsException("this team Member exists, you can't add it ");
                }
                _teamMemberrepository.EditTeamMember(teamMember);
            }
            else
            {
                throw new TeamMemberIdExistsException("this team member don't exists");
            }  
        }

        public void DeleteTeamMember(int TeamMemberId)
        {
            if (_teamMemberrepository.GetTeamMemberByID(TeamMemberId) != null)
            {
                _teamMemberrepository.DeleteTeamMember(TeamMemberId);
            }
            else
            {
                throw new TeamIdExistsException("this team Member don't exists");
            }
        }
    }
}