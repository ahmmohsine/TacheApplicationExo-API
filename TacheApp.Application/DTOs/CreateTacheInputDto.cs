using System.ComponentModel.DataAnnotations;

namespace TacheApp.Application.DTOs
{
    public class CreateTacheInputDto
    {
        [Required(ErrorMessage = "Le titre est obligatoire.")]
        [StringLength(200, ErrorMessage = "Le titre ne peut pas dépasser 200 caractères.")]
        public string Titre { get; set; } = string.Empty;
    }
}
