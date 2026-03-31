using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.ASPMVC.Models.Post
{
    public class CreatePost_Form
    {
        [DisplayName("Sujet : ")]
        [Required(ErrorMessage = "Sujet obligatoire.")]
        [MaxLength(255, ErrorMessage = "Le sujet ne peut dépasser 255 caractères.")]
        public string Subject { get; set; }

        [DisplayName("Contenu : ")]
        [Required(ErrorMessage = "Contenu obligatoire.")]
        public string Content { get; set; }

        [ScaffoldColumn(false)]
        Guid EmployeeId { get; set; }

        [ScaffoldColumn(false)]
        Guid ProjectId { get; set; }


    }
}
