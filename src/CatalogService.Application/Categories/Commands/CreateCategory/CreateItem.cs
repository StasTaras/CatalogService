using AutoMapper;
using CatalogService.Application.Categories.Queries.Models;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Items.Commands.CreateItem.Models;
using CatalogService.Domain.Entities;
using MediatR;

namespace CatalogService.Application.Categories.Commands.CreateCategory
{
    public record CreateCategoryCommand(CreateItemModel CreateItemModel) : IRequest<CategoryModel>;

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryModel> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.CreateItemModel.Name,
                Image = request.CreateItemModel.Image,
                ParentCategoryId = request.CreateItemModel.CategoryId,
            }; 

            _context.Categories.Add(category);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CategoryModel>(category);
        }
    }
}
