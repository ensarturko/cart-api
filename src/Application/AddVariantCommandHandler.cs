using System.Threading;
using System.Threading.Tasks;
using cart_api.Domain.Commands;
using cart_api.Infrastructure;
using MediatR;
using Variant = cart_api.Domain.Entities.Variant;

namespace cart_api.Application
{
    public class AddVariantCommandHandler : IRequestHandler<AddVariantCommand, AddVariantResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public AddVariantCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddVariantResult> Handle(AddVariantCommand request, CancellationToken cancellationToken)
        {
            await _dbContext.Variants.AddAsync(new Variant
            {
                Barcode = request.Barcode,
                IsActive = request.IsActive,
                StockQuantity = request.StockQuantity
            }, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return new AddVariantResult();
        }
    }
}