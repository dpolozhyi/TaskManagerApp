using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Models;
using DataArt.TaskManager.Entities;

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
                        e => e.Title,
                        opt => opt.MapFrom(
                            res => res.Title));
            });
        }
    }
}