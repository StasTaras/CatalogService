using CatalogService.Application.Common.Interfaces;
using MediatR;

namespace CatalogService.Application.Items.Commands.DeleteItem
{
    public record DeleteItemCommand(int ItemId) : IRequest;

    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.Items.FindAsync(request.ItemId, cancellationToken);
            if (item != null)
            {
                _context.Items.Remove(item);

                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new ArgumentNullException($"Item with id = {request.ItemId} was not found");
            }
        }
    }
}
