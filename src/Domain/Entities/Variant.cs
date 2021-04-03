using System.ComponentModel.DataAnnotations;

namespace cart_api.Domain.Entities
{
    public class Variant : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string Barcode { get; set; }

        public bool IsActive { get; set; }
    }
}
