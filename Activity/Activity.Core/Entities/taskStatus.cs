using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Core.Entities
{
    public class taskStatus : baseEntity
    {
        public int CompanyId { get; set; }
        public int ProjectId { get; set; }
        public string TaskStatusName { get; set; }
    }

    public class taskStatusRequest : taskStatus
    {
        public int TaskStatusId { get; set; }
        public int CreationUserId { get; set; }
        public bool Active { get; set; }
    }
    public class taskStatusResponse : taskStatus
    {
        public int TaskStatusId { get; set; }
        public DateTime CreationDate { get; set; }
    }


}
