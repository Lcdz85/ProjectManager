using System.ComponentModel.DataAnnotations;

namespace ProjectManager.ASPMVC.Models.Project
{
    public class ListProject_VM
    {
        [ScaffoldColumn(false)]
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
