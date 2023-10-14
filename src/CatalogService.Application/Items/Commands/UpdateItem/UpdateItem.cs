using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Items.Commands.UpdateItem.Models;
using MediatR;

namespace CatalogService.Application.Items.Commands.UpdateItem
{
    public record UpdateItemCommand(UpdateItemModel UpdateItemModel, int ItemId) : IRequest;

    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var items = await _context.Items.FindAsync(request.ItemId, cancellationToken);
            if (items != null)
            {
                items.Name = request.UpdateItemModel.Name;
                items.Image = request.UpdateItemModel.Image;
                items.Amount = request.UpdateItemModel.Amount;
                items.CategoryId = request.UpdateItemModel.CategoryId;
                items.Description = request.UpdateItemModel.Description;
                items.Price = request.UpdateItemModel.Price;

                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new ArgumentNullException($"Item with id = {request.ItemId} was not found");
            }
        }
    }
}
