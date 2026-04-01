using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.DAL.Entities;

namespace ProjectManager.BLL.Entities
{
    public class Project
    {
        public Guid ProjectId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime Creationdate { get; private set; }
        public Guid ProjectManagerId { get; set; }
        public IEnumerable<Employee> Members { get; set; }
        public int MembersCount { get; set; }

        public Project(Guid projectId, string name, string description, DateTime creationdate, Guid projectManagerId)
        {
            ProjectId = projectId;
            Name = name;
            Description = description;
            Creationdate = creationdate;
            ProjectManagerId = projectManagerId;
        }

        public Project(string name, string description)
        {
            ProjectId = Guid.NewGuid();
            Name = name;
            Description = description;
            Creationdate = DateTime.Now;
        }
        public Project(Guid projectId, string description)
        {
            ProjectId = projectId;
            Description = description;
        }
    }
}
