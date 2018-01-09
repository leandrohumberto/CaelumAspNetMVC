using AutoMapper;
using BlogWeb.Models;
using BlogWeb.ViewModels;

namespace BlogWeb
{
    public class AutoMapperConfig
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.Initialize(cfg => 
            {
                cfg.CreateMap<Post, PostModel>();
                cfg.CreateMap<PostModel, Post>()
                .ForMember(p => p.Autor, options =>
                {
                    options.MapFrom(m => new Usuario { Id = m.AutorId.Value });
                    options.Condition(m => m.AutorId != null && m.AutorId != 0);
                });
                cfg.CreateMap<PostsPorMesModel, PostsPorMes>();
                cfg.CreateMap<PostsPorMes, PostsPorMesModel>();
                cfg.CreateMap<int, Tag>().ConvertUsing(i => new Tag { Id = i });
                cfg.CreateMap<Tag, int>().ConvertUsing(t => t.Id);
            });
        }
    }
}