using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cart_api.Domain.Entities
{
    public class Cart : BaseEntity
    {
        [Key] 
        public Guid Guid { get; set; }

        public int CustomerId { get; set; }

        public string Status { get; set; }
    }
}
