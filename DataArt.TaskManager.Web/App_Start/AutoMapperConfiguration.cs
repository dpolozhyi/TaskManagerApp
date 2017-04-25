using AutoMapper;
using DataArt.TaskManager.Entities;
using DataArt.TaskManager.BL;

namespace TaskManagerApp
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Task, TaskViewModel>()
                    .ForMember(
                        e => e.IsDone,
                        opt => opt.MapFrom(
                            res => res.IsDone))
                    .ForMember(
                        e => e.Category,
                        opt => opt.MapFrom(
                            res => res.Category.Name))
                    .ForMember(
                        e => e.Category,
                        opt => opt.MapFrom(
                            res => res.Category))
                    .ForMember(
                        e => e.Title,
                        opt => opt.MapFrom(
                            res => res.Title));

                config.CreateMap<TaskViewModel, Task>()
                    .ForMember(
                        e => e.IsDone,
                        opt => opt.MapFrom(
                            res => res.IsDone))
                    .ForMember(
                        e => e.Category,
                        opt => opt.MapFrom(
                            res => res.Category))
                    .ForMember(
                        e => e.Category,
                        opt => opt.MapFrom(
                            res => res.Category))
                    .ForMember(
                        e => e.Title,
                        opt => opt.MapFrom(
                            res => res.Title));

                config.CreateMap<Category, CategoryViewModel>()
                    .ForMember(
                        e => e.Id,
                        opt => opt.MapFrom(
                            res => res.Id))
                    .ForMember(
                        e => e.Name,
                        opt => opt.MapFrom(
                            res => res.Name));

                config.CreateMap<CategoryViewModel, Category>()
                    .ForMember(
                        e => e.Id,
                        opt => opt.MapFrom(
                            res => res.Id))
                    .ForMember(
                        e => e.Name,
                        opt => opt.MapFrom(
                            res => res.Name));
            });
        }
    }
}