namespace gestion_astreintes.Dtos
{
    public class TeamDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TeamMemberForTeamDetailsDto TeamLeader { get; set; }
        public ICollection<TeamMemberForTeamDetailsDto> Employees { get; set;}
    }
}
