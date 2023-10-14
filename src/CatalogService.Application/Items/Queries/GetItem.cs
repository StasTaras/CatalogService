using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using MediatR;
using CatalogService.Application.Items.Queries.Models;

namespace CatalogService.Application.Items.Queries
{
    public record GetItemQuery(int ItemId) : IRequest<ItemModel>;

    public class GetItemQueryHandler : IRequestHandler<GetItemQuery, ItemModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetItemQueryHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ItemModel> Handle(
            GetItemQuery request,
            CancellationToken cancellationToken)
        {
            if (request.ItemId <= 0)
            {
                throw new ArgumentException(nameof(request.ItemId));
            }

            var res = await _context.Items.FindAsync(
                request.ItemId,
                cancellationToken);

            return _mapper.Map<ItemModel>(res);
        }
    }
}
