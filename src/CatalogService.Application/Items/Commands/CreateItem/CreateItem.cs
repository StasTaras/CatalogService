using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Items.Commands.CreateItem.Models;
using CatalogService.Application.Items.Queries.Models;
using CatalogService.Domain.Entities;
using MediatR;

namespace CatalogService.Application.Items.Commands.CreateItem
{
    public record CreateItemCommand(CreateItemModel CreateItemModel) : IRequest<ItemModel>;

    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, ItemModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateItemCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ItemModel> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var item = new Item
            {
                Name = request.CreateItemModel.Name,
                Image = request.CreateItemModel.Image,
                CategoryId = request.CreateItemModel.CategoryId,
                Amount = request.CreateItemModel.Amount,
                Description = request.CreateItemModel.Description,
                Price = request.CreateItemModel.Price
            }; 

            _context.Items.Add(item);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ItemModel>(item);
        }
    }
}
