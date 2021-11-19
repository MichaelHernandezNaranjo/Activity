using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Core.Entities
{
    public class company: baseEntity
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }

    public class companyRequest : company
    {
        public int CreationUserId { get; set; }
        public int Active { get; set; }
    }
    public class companyResponse : company
    {

    }
}
