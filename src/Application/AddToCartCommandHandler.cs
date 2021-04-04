using System;
using System.Threading;
using System.Threading.Tasks;
using cart_api.Application.Exceptions;
using cart_api.Domain;
using cart_api.Domain.Commands;
using cart_api.Domain.Entities;
using cart_api.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cart_api.Application
{
    public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, AddToCartResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public AddToCartCommandHandler(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<AddToCartResult> Handle(AddToCartCommand request, CancellationToken token)
        {
            var variant = await _dbContext.Variants.FirstOrDefaultAsync(x => x.Id == request.VariantId, token);

            if (variant == null)
            {
                throw new UnprocessableEntityException("Variant does not exist", ErrorCode.StockOut);
            }
            
            if (variant.StockQuantity <= 0)
            {
                throw new UnprocessableEntityException("Stock is not enough", ErrorCode.StockOut);
            }
            
            var cart = await _dbContext.Carts.FirstOrDefaultAsync(x => x.Guid == request.CartGuid && x.Status == CartStatus.OPEN.ToString(), token);
            if (cart == null)
            {
                cart = new Cart
                {
                    Guid = new Guid(),
                    Status = CartStatus.OPEN.ToString(),
                    CustomerId = request.CustomerId
                };

                _dbContext.Carts.Add(cart);
            }

            _dbContext.CartItems.Add(new CartItem
            {
                CartGuid = cart.Guid,
                VariantId = request.VariantId
            });

            variant.StockQuantity--;

            await _dbContext.SaveChangesAsync(token);
            
            return new AddToCartResult
            {
                Message = "Successful."
            };
        }
    }
}