using AutoMapper;
using AutoMapper.QueryableExtensions;
using CatalogService.Application.Categories.Queries.Models;
using CatalogService.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Application.Categories.Queries
{
    public record GetCategoriesQuery : IRequest<IEnumerable<CategoryModel>>;

    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(
            IApplicationDbContext context, 
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryModel>> Handle(
            GetCategoriesQuery request, 
            CancellationToken cancellationToken)
        {
            return await _context.Categories
                .ProjectTo<CategoryModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
