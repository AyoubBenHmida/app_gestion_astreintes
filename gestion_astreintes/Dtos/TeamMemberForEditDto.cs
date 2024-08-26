namespace gestion_astreintes.Dtos
{
    public class TeamMemberForEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int MemberTypeId { get; set; }
        public int TeamId { get; set; }
    }
}
