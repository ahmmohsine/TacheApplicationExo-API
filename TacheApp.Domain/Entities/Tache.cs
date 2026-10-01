using TacheApp.Domain.Common;
using TacheApp.Domain.Common.Errors;

namespace TacheApp.Domain.Entities;

public class Tache
{
    public int Id { get; private set; }
    public string Titre { get; private set; } = string.Empty;
    public bool Realisee { get; private set; }
    public DateTime DateCreation { get; set; }
    public Tache(int id, string titre, DateTime dateCreation, bool realisee = false)
    {
        Id = id;
        Titre = titre;
        DateCreation = dateCreation;
        Realisee = realisee;
    }
    public Tache(string titre)
    {
        Titre = titre;
    }
    public Result Update(string nouveauTitre, bool realisee)
    {
        if (string.IsNullOrWhiteSpace(nouveauTitre))
        {
            return Result.Failure(DomainErrors.Tache.TitleRequired);
        }

        Titre = nouveauTitre;
        Realisee = realisee;

        return Result.Success();
    }

    public void Cloturer()
    {
        Realisee = true;
    }
}