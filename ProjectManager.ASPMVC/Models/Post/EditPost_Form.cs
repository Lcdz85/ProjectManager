using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.ASPMVC.Models.Post
{
    public class EditPost_Form
    {
        [ScaffoldColumn(false)]
        public Guid EmployeeId { get; set; }

        [ScaffoldColumn(false)]
        public Guid ProjectId { get; set; }

        [DisplayName("Nouveau contenu : ")]
        public string Content { get; set; }

    }
}
