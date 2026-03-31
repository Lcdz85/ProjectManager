using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.ASPMVC.Models.TakePArt
{
    public class CreateTakePart_Form
    {
        [ScaffoldColumn(false)]
        public Guid ProjectId { get; set; }

        [DisplayName("Nouveau membre: ")]
        [Required(ErrorMessage = "Veuillez sélectionner un employé")]
        public Guid employeeId { get; set; }

        [DisplayName("Date de Début : ")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La date de début de participation doit être renseignée.")]
        public DateTime StartDate { get; set; }
    }
}
