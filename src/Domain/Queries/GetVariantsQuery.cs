using System.Collections.Generic;
using MediatR;

namespace cart_api.Domain.Commands
{
    public class GetVariantsQuery : IRequest<GetVariantsQueryResult>
    {
        
    }

    public class GetVariantsQueryResult
    {
        public GetVariantsQueryResult()
        {
            Variants = new List<Variant>();
        }
        
        public List<Variant> Variants { get; set; }
    }

    public class Variant
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public bool IsActive { get; set; }
        public int StockQuantity { get; set; }
    }
}