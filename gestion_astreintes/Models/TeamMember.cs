namespace gestion_astreintes.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public TeamMemberType MemberType { get; set; }
        public Team Team { get; set; }
    }
}
