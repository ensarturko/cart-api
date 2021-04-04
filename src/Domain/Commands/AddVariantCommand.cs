using MediatR;

namespace cart_api.Domain.Commands
{
    public class AddVariantCommand : IRequest<AddVariantResult>
    {
        public string Barcode { get; set; }

        public bool IsActive { get; set; }
        
        public int StockQuantity { get; set; }
    }

    public class AddVariantResult
    {
        
    }
}