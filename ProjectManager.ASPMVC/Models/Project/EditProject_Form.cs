using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.ASPMVC.Models.Project
{
    public class EditProject_Form
    {
        [ScaffoldColumn(false)]
        public Guid ProjectId { get; set; }

        [DisplayName("Nouvelle description : ")]
        public string Description { get; set; }
    }
}
