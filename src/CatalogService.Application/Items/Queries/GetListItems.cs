using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using MediatR;
using AutoMapper.QueryableExtensions;
using CatalogService.Application.Items.Queries.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Application.Items.Queries;

public record GetListItemsQuery(
    ItemPaginationParameters PaginationParameters) : IRequest<IEnumerable<ItemModel>>
{
    public int? CategoryId { get; set; }

    public ItemPaginationParameters PaginationParameters { get; set; } = PaginationParameters;
};

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
        var itemsQuery = _context.Items.AsQueryable();
            
        //use filtration by categoryId
        if (request.CategoryId != null)
        {
            itemsQuery = itemsQuery.Where(item => item.CategoryId == request.CategoryId);
        }

        return await itemsQuery
            .OrderBy(item => item.ItemId)
            .Skip((request.PaginationParameters.PageNumber - 1) * request.PaginationParameters.PageSize)
            .Take(request.PaginationParameters.PageSize)
            .ProjectTo<ItemModel>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
