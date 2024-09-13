using AutoMapper;
using gestion_astreintes.Dtos;
using gestion_astreintes.Models;

namespace gestion_astreintes.AutoMapper.Converters
{
    public class TeamToTeamDetailsDtoConverter : ITypeConverter<Team , TeamDetailsDto>
    {
        private readonly IMapper _mapper;
        public TeamToTeamDetailsDtoConverter(IMapper mapper) {
            _mapper = mapper;
        }
        public TeamDetailsDto Convert(Team team , TeamDetailsDto teamDetailsDto , ResolutionContext context)
        {
            return new TeamDetailsDto
            {
                Id = team.Id,
                Name = team.Name,
                TeamLeader = _mapper.Map<TeamMemberForTeamDetailsDto>(team.Members.FirstOrDefault(t => t.MemberType.Id == 1)) ,
                Employees = _mapper.Map<List<TeamMemberForTeamDetailsDto>>(team.Members.Where(t => t.MemberType.Id == 2))
            };
        }
    }
}
