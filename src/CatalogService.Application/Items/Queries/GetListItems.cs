using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using MediatR;
using AutoMapper.QueryableExtensions;
using CatalogService.Application.Items.Queries.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Application.Items.Queries
{
    public record GetListItemsQuery : IRequest<IEnumerable<ItemModel>>;

    public class GetListItemsQueryHandler : IRequestHandler<GetListItemsQuery, IEnumerable<ItemModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetListItemsQueryHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemModel>> Handle(
            GetListItemsQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Items
                .ProjectTo<ItemModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
