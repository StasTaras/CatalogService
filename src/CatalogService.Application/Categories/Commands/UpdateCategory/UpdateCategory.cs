using CatalogService.Application.Categories.Commands.UpdateCategory.Models;
using CatalogService.Application.Common.Interfaces;
using MediatR;

namespace CatalogService.Application.Categories.Commands.UpdateCategory
{
    public record UpdateCategoryCommand(UpdateCategoryModel UpdateCategoryModel, int CategoryId) : IRequest;

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(request.CategoryId, cancellationToken);
            if (category != null)
            {
                category.Name = request.UpdateCategoryModel.Name;
                category.Image = request.UpdateCategoryModel.Image;
                category.ParentCategoryId = request.UpdateCategoryModel.ParentCategoryId;

                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new ArgumentNullException($"Category with id = {request.CategoryId} was not found");
            }
        }
    }
}
