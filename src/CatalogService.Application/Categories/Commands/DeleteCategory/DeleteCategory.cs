using CatalogService.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Application.Categories.Commands.DeleteCategory
{
    public record DeleteCategoryCommand(int CategoryId) : IRequest;

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories
                .Include(i => i.Items)
                .SingleOrDefaultAsync(e => e.CategoryId == request.CategoryId, cancellationToken);
            if (category != null)
            {
                _context.Items.RemoveRange(category.Items);
                _context.Categories.Remove(category);

                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new ArgumentNullException($"Category with id = {request.CategoryId} was not found");
            }
        }
    }
}
