using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerApp.Models;

namespace TaskManagerApp
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<TaskModel, TaskViewModel>()
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
                            res => res.Description));

                config.CreateMap<TaskViewModel, TaskModel>()
                    .ForMember(
                        e => e.IsDone,
                        opt => opt.MapFrom(
                            res => res.IsDone))
                    .ForMember(
                        e => e.Category,
                        opt => opt.MapFrom(
                            res => res.Category))
                    .ForMember(
                        e => e.Description,
                        opt => opt.MapFrom(
                            res => res.Title));
            });
        }
    }
}