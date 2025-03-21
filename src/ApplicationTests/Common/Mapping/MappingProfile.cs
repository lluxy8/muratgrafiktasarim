using Application.Commands.Admin.Req;
using Application.Commands.Category.Req;
using Application.Commands.Project.Req;
using Application.Queries.Admin.Res;
using Application.Queries.Category.Res;
using Application.Queries.Project.Res;
using AutoMapper;
using Core.Entities;

namespace Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Admin Mappings
            CreateMap<Admin, GetAdminResult>();
            CreateMap<CreateAdminRequest, Admin>();
            CreateMap<UpdateAdminRequest, Admin>();

            // Category Mappings
            CreateMap<Category, GetCategoryByIdResult>();
            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<UpdateCategoryRequest, Category>();

            // Project Mappings
            CreateMap<Project, GetProjectByIdResult>();
            CreateMap<CreateProjectRequest, Project>();
            CreateMap<UpdateProjectRequest, Project>();
        }
    }
} 