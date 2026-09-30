namespace TacheApp.Domain.Entities
{
    public class Tache
    {
        public int Id { get; set; }
        public string? Titre { get; set; }
        public DateTime DateCreation { get; set; }
        public bool Realisee { get; set; }
    }
}
