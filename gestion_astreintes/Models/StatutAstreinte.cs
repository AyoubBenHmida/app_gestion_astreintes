namespace gestion_astreintes.Models
{
    public class StatutAstreinte
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Astreinte> Astreintes { get; set; }
    }
}
