using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using cart_api.Domain.Queries;
using cart_api.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CartItem = cart_api.Domain.Entities.CartItem;

namespace cart_api.Application
{
    public class GetCartItemsQueryHandler : IRequestHandler<GetCartItemsQuery, GetCartItemsQueryResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCartItemsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetCartItemsQueryResult> Handle(GetCartItemsQuery request, CancellationToken cancellationToken)
        {
            var cartItems = await _dbContext.CartItems.Where(x => x.CartGuid == request.CartGuid).ToListAsync(cancellationToken: cancellationToken);

            return ToResult(cartItems);
        }

        private static GetCartItemsQueryResult ToResult(IEnumerable<CartItem> cartItems)
        {
            var result = new GetCartItemsQueryResult();
            foreach (var item in cartItems)
            {
                result.CartItems.Add(new CartItem
                {
                    Id = item.Id,
                    CartGuid = item.CartGuid,
                    VariantId = item.VariantId,
                    CreateTime = item.CreateTime
                });
            }

            return result;
        }
    }
}