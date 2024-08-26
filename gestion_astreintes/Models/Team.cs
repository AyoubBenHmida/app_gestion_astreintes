using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace gestion_astreintes.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TeamMember> Members { get; set; }
    }
}
