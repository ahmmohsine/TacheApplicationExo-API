namespace TacheApp.Application.DTOs
{
    public record TacheDto(int Id, string? Titre, DateTime DateCreation, bool Realisee);
}
