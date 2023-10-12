using AutoMapper;
using CatalogService.Application.Categories.Queries.Models;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Common.Mappings
{
    public class MappingExtensions : Profile
    {
        public MappingExtensions()
        {
            CreateMap<Category, CategoryModel>();
        }
    }
}
