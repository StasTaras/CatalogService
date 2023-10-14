using AutoMapper;
using CatalogService.Application.Categories.Commands.CreateCategory.Models;
using CatalogService.Application.Categories.Queries.Models;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using MediatR;

namespace CatalogService.Application.Categories.Commands.CreateCategory
{
    public record CreateCategoryCommand(CreateCategoryModel CreateCategoryModel) : IRequest<CategoryModel>;

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
                Name = request.CreateCategoryModel.Name,
                Image = request.CreateCategoryModel.Image,
                ParentCategoryId = request.CreateCategoryModel.ParentCategoryId
            }; 

            _context.Categories.Add(category);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CategoryModel>(category);
        }
    }
}
