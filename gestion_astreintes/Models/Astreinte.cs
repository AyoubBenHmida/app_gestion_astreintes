namespace gestion_astreintes.Models
{
    public class Astreinte
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateDebut { get; set; }   
        public DateTime DateFin {  get; set; }
        public string Description { get; set; }
        public StatutAstreinte Statut { get; set; }
        public TeamMember Employee { get; set; }
    }
}
