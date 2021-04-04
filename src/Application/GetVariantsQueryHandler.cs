using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using cart_api.Domain.Commands;
using cart_api.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Variant = cart_api.Domain.Entities.Variant;

namespace cart_api.Application
{
    public class GetVariantsQueryHandler : IRequestHandler<GetVariantsQuery, GetVariantsQueryResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetVariantsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetVariantsQueryResult> Handle(GetVariantsQuery request, CancellationToken cancellationToken)
        {
            var variants = await _dbContext.Variants.Where(x => x.IsActive).OrderByDescending(x => x.CreateTime).ToListAsync(cancellationToken: cancellationToken);

            return ToResult(variants);
        }

        private static GetVariantsQueryResult ToResult(IEnumerable<Variant> variants)
        {
            var result = new GetVariantsQueryResult();

            foreach (var item in variants)
            {
                result.Variants.Add(new Domain.Commands.Variant
                {
                    Id = item.Id,
                    Barcode = item.Barcode,
                    StockQuantity = item.StockQuantity
                });
            }

            return result;
        }
    }
}