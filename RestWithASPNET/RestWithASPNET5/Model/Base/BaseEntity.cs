using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5.Model.Base
{
    public class BaseEntity
    {
        [System.ComponentModel.DataAnnotations.Schema.Column("id")]
        public long id { get; set; }
    }
}
