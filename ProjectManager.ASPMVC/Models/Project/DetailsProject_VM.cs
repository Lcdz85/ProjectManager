using System.ComponentModel.DataAnnotations;

namespace ProjectManager.ASPMVC.Models.Project
{
    public class DetailsProject_VM
    {
        [ScaffoldColumn(false)]
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Creationdate { get; set;}
    }
}
