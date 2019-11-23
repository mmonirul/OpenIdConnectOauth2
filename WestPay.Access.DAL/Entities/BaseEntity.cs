using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestPay.Access.DAL.Entities
{
    public class BaseEntity : ITrackable
    {
        //https://www.meziantou.net/entity-framework-core-generate-tracking-columns.htm
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
