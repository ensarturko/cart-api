using System;
using System.ComponentModel.DataAnnotations;

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
