using System;
using MediatR;

namespace cart_api.Domain.Commands
{
    public class AddToCartCommand : IRequest<AddToCartResult>
    {
        public Guid CartGuid { get; set; }
        public int CustomerId { get; set; }
        public int VariantId { get; set; }
    }

    public class AddToCartResult 
    {
        public string Message { get; set; }
    }
}