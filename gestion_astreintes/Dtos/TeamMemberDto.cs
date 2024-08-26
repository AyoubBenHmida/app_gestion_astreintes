namespace gestion_astreintes.Dtos
{
    public class TeamMemberDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int MemberTypeId { get; set; }
        public string MemberTypeName { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
    }
}
