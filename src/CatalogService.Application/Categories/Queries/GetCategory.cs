using AutoMapper;
using CatalogService.Application.Categories.Queries.Models;
using CatalogService.Application.Common.Interfaces;
using MediatR;

namespace CatalogService.Application.Categories.Queries
{
    public record GetCategoryQuery(int CategoryId) : IRequest<CategoryModel>;

    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryModel> Handle(
            GetCategoryQuery request,
            CancellationToken cancellationToken)
        {
            if (request.CategoryId <= 0)
            {
                throw new ArgumentException(nameof(request.CategoryId));
            }

            var res = await _context.Categories.FindAsync(
                request.CategoryId, 
                cancellationToken);

            return _mapper.Map<CategoryModel>(res);
        }
    }
}
