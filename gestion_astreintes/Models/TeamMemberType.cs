namespace gestion_astreintes.Models
{
    public class TeamMemberType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TeamMember> Members { get; set;}
    }
}
