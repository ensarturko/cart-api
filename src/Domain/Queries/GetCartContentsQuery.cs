using System;
using System.Collections.Generic;
using MediatR;

namespace cart_api.Domain.Queries
{
    public class GetCartContentsQuery : IRequest<GetCartContentsQueryResult>
    {
        
    }

    public class GetCartContentsQueryResult
    {
        public GetCartContentsQueryResult()
        {
            CartContents = new List<CartContent>();
        }
        public List<CartContent> CartContents { get; set; }
    }

    public class CartContent
    {
        public Guid CartGuid { get; set; }
        
        public int Id { get; set; }

        public int VariantId { get; set; }
    }
}