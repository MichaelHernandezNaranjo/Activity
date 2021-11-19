using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Core.Entities
{
    public class task : baseEntity
    {
        public int CompanyId { get; set; }
        public int ProjectId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public int? SprintId { get; set; }
    }

    public class taskRequest : task
    {
        public int TaskId { get; set; }
        public int CreationUserId { get; set; }
        public bool Active { get; set; }
    }
    public class taskResponse : task
    {
        public int TaskId { get; set; }
        public int taskStatusId { get; set; }
        public string taskStatusName { get; set; }
        public DateTime CreationDate { get; set; }
    }

}
