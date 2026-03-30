using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Entities
{
    public class Project
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Creationdate { get; set; }
        public Guid ProjectManagerId { get; set; }

        public Project(Guid projectId, string name, string description, DateTime creationdate, Guid projectManagerId)
        {
            ProjectId = projectId;
            Name = name;
            Description = description;
            Creationdate = creationdate;
            ProjectManagerId = projectManagerId;
        }

        public Project(string name, string description, Guid projectManagerId)
        {
            Name = name;
            Description = description;
            ProjectManagerId = projectManagerId;
        }
    }
}
