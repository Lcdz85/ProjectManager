using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Entities
{
    public class Post
    {
        public Guid PostId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ProjectId { get; set; }

        public Post(string subject, string content, Guid employeeId, Guid projectId)
        {
            Subject = subject;
            Content = content;
            EmployeeId = employeeId;
            ProjectId = projectId;
        }

        public Post(Guid postId, string subject, string content, DateTime sendDate, Guid employeeId, Guid projectId)
        {
            PostId = postId;
            Subject = subject;
            Content = content;
            SendDate = sendDate;
            EmployeeId = employeeId;
            ProjectId = projectId;
        }
    }
}
