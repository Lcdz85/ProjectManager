using System.ComponentModel.DataAnnotations;

namespace ProjectManager.ASPMVC.Models.Post
{
    public class DetailsPost_VM
    {
        [ScaffoldColumn(false)]

        public Guid PostId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
        public string EmployeeName { get; set; }
        public string ProjectName { get; set; }
    }
}
