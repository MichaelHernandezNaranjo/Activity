using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Core.Entities
{
    public class sprint : baseEntity
    {
        public int CompanyId { get; set; }
        public int ProjectId { get; set; }
        public string SprintName { get; set; }
        public string Description { get; set; }
    }

    public class sprintRequest : sprint
    {
        public int SprintId { get; set; }
        public int CreationUserId { get; set; }
        public bool Active { get; set; }
    }
    public class sprintResponse : sprint
    {
        public DateTime CreationDate { get; set; }
        public List<projectUserResponse> ListProjectUser { get; set; } = new List<projectUserResponse>();
    }


}
