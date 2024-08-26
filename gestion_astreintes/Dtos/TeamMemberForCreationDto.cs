namespace gestion_astreintes.Dtos
{
    public class TeamMemberForCreationDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int MemberTypeId { get; set; }
        public int teamId { get; set; }
    }
}
