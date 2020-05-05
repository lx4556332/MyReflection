using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Model
{
    public class Company
    {
        public string Name { get; set; }

        public DateTime CreateTime { get; set; }

        public string CreatorId { get; set; }

        public string LastModifierId { get; set; }

        public DateTime? LastModifyTime { get; set; }
    }
}
