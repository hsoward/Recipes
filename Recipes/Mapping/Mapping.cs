using System;
using AutoMapper;
using Recipes.Models;
using Recipes.Services.Models;
using Serilog;

namespace Recipes.Mapping
{
    public class Mapping
    {
        public static void RegisterMappings()
        {
            try
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.ValidateInlineMaps = false;

                    cfg.CreateMap<RecipeDto, Recipe>()
                    .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.name))
                    .ForMember(dest => dest.Calories, opts => opts.MapFrom(src => src.calories))
                    .ForMember(dest => dest.Type, opts => opts.MapFrom(src => src.type))
                    .ForMember(dest => dest.Image, opts => opts.MapFrom(src => src.image));
                });
            }
            catch (Exception e)
            {
                Log.Information("There was an error with Automapper: " + e);
            }
        }
    }
}
