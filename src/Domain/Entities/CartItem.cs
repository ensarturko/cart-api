using System;
using System.ComponentModel.DataAnnotations;

namespace cart_api.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public Guid CartGuid { get; set; }

        public int VariantId { get; set; }
    }
}
