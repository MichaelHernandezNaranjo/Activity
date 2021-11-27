using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Core.Entities
{
    public class project : baseEntity
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
    }

    public class projectRequest : project
    {
        //[System.Text.Json.Serialization.JsonIgnore]
        public int CompanyId { get; set; }
        public int ProjectId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public int CreationUserId { get; set; }
        public bool Active { get; set; }
        public List<projectUserRequest> ListProjectUser { get; set; }
    }
    public class projectResponse : project
    {
        public int ProjectId { get; set; }
        public DateTime CreationDate { get; set; }
        public List<projectUserResponse> ListProjectUser { get; set; } = new List<projectUserResponse>();
    }

    public class projectUserResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class projectUserRequest
    {
        public int UserId { get; set; }
    }

}
