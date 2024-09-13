using AutoMapper;
using gestion_astreintes.Dtos;
using gestion_astreintes.Exceptions;
using gestion_astreintes.Models;
using gestion_astreintes.Repositories.Interfaces;
using gestion_astreintes.Services.Interfaces;
using System.Xml.Serialization;

namespace gestion_astreintes.Services.Implementation
{
    public class TeamService : ITeamService
    {
        private ITeamRepository _teamRepository;
        private ITeamMemberRepository _teamMemberRepository;
        private readonly IMapper _mapper;
        public TeamService(ITeamRepository teamRepository, IMapper mapper, ITeamMemberRepository teamMemberRepository) { 
            this._teamRepository = teamRepository;
            this._teamMemberRepository = teamMemberRepository;
            _mapper = mapper;
        }
        public IEnumerable<TeamDto> GetTeams() { 
        
            List<Team> teams = _teamRepository.GetTeams().ToList();
            return teams.Select(t => _mapper.Map<Team , TeamDto>(t));
        }
        public TeamDto GetTeamByID(int TeamId)
        {
            Team team = _teamRepository.GetTeamByID(TeamId);
            if (team == null)
            {
                throw new EntityNotFoundException($"could not find Entity with id {TeamId}");
            }
            else
            {
                TeamDto teamDto = _mapper.Map<Team, TeamDto>(team);
                return teamDto;
            }
        }

        public TeamDetailsDto GetTeamDetailsById(int TeamId)
        {
            Team team = _teamRepository.GetTeamDetailsById(TeamId);
            TeamDetailsDto teamDetails = _mapper.Map<Team , TeamDetailsDto>(team);
            return teamDetails; 
        }
        public TeamDto AddTeam(TeamForCreationDto teamForCreDto) {
            if (_teamRepository.CheckIfTeamNameExists(teamForCreDto.Name))
            {
                throw new TeamExistsException("this team exists, you can't add it ");
            }
            Team team = _mapper.Map<TeamForCreationDto, Team>(teamForCreDto);
            int id = _teamRepository.AddTeam(team);
            TeamDto teamDto = _mapper.Map<Team, TeamDto>(team);
            teamDto.Id = id; 
            return teamDto ;
            } 


        public void EditTeam(TeamDto teamDto) {
            if (_teamRepository.GetTeamByID(teamDto.Id) != null)
            {
                if(_teamRepository.CheckIfTeamNameExists(teamDto.Name))
                {
                    throw new TeamExistsException("this team exists, you can't add it ");
                }
                
                 Team team = _mapper.Map<TeamDto, Team>(teamDto);
                _teamRepository.EditTeam(team);
                
            }
            throw new TeamIdExistsException("this team don't exists");
        }
        public void DeleteTeam(int TeamId)
        {
            if (_teamMemberRepository.GetTeamMembersByTeamId(TeamId).ToList().Count == 0)
            {
                _teamRepository.DeleteTeam(TeamId);
            }
            else
            {
                throw new TeamContainsMembers("This team contains members, you can't delete it");
            }
            
            
        }


    }
}
