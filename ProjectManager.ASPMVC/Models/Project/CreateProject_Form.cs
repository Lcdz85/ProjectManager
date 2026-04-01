using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.ASPMVC.Models.Project
{
    public class CreateProject_Form
    {
        [DisplayName("Nom du projet :")]
        public string Name { get; set; }

        [DisplayName("Description :")]
        public string Description { get; set; }
    }
}
