using AutoMapper;
using ELearningBackend.DTOs;
using ELearningBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningBackend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Post, PostDTO>()
                .ForPath(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForPath(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForPath(dest => dest.Image, opt => opt.MapFrom(src => src.User.Image))
                .ForPath(dest => dest.PostLikes, opt => opt.MapFrom(src => src.PostLikes.Count));

            CreateMap<Comment, CommentDTO>()
                .ForPath(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForPath(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForPath(dest => dest.Image, opt => opt.MapFrom(src => src.User.Image))
                .ForPath(dest => dest.CommentLikes, opt => opt.MapFrom(src => src.CommentLikes.Count));

        }
    }
}
