using System;
using System.Collections.Generic;
using MediatR;

namespace cart_api.Domain.Queries
{
    public class GetCartItemsQuery : IRequest<GetCartItemsQueryResult>
    {
        public Guid CartGuid { get; set; }
    }

    public class GetCartItemsQueryResult
    {
        public List<Entities.CartItem> CartItems { get; set; }
    }

    public class CartItem
    {
        public int Id { get; set; }
        public Guid CartGuid { get; set; }
        public int VariantId { get; set; }
    }
}