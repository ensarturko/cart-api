using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using cart_api.Domain.Queries;
using cart_api.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CartItem = cart_api.Domain.Entities.CartItem;

namespace cart_api.Application
{
    public class GetCartContentQueryHandler : IRequestHandler<GetCartContentsQuery, GetCartContentsQueryResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCartContentQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetCartContentsQueryResult> Handle(GetCartContentsQuery request, CancellationToken cancellationToken)
        {
            var cartItems = await _dbContext.CartItems.ToListAsync(cancellationToken: cancellationToken);

            return ToResult(cartItems);
        }

        private static GetCartContentsQueryResult ToResult(IEnumerable<CartItem> cartItems)
        {
            var result = new GetCartContentsQueryResult();

            foreach (var item in cartItems)
            {
                result.CartContents.Add(new CartContent
                {
                    Id = item.Id,
                    CartGuid = item.CartGuid,
                    VariantId = item.VariantId
                });
            }

            return result;
        }
    }
}