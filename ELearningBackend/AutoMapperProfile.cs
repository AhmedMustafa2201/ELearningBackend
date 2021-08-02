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
                .ForPath(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForPath(dest => dest.Image, opt => opt.MapFrom(src => src.User.Image))
                .ForPath(dest => dest.PostLikes, opt => opt.MapFrom(src => src.PostLikes.Count))
                .ForPath(dest => dest.PostLikesArr, opt => opt.MapFrom(src => src.PostLikes.Select(p=>p.UserId)))
                .ForPath(dest => dest.PostDisLikesArr, opt => opt.MapFrom(src => src.PostDisLikes.Select(p=>p.UserId)))
                .ForPath(dest => dest.CommentsCount, opt => opt.MapFrom(src => src.Comments.Count));

            CreateMap<Post, PostCommentsDTO>()
                .ForPath(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForPath(dest => dest.Image, opt => opt.MapFrom(src => src.User.Image))
                .ForPath(dest => dest.PostLikes, opt => opt.MapFrom(src => src.PostLikes.Count))
                .ForPath(dest => dest.PostLikesArr, opt => opt.MapFrom(src => src.PostLikes.Select(p => p.UserId)))
                .ForPath(dest => dest.PostDisLikesArr, opt => opt.MapFrom(src => src.PostDisLikes.Select(p => p.UserId)));




            CreateMap<Comment, CommentDTO>()
                .ForPath(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForPath(dest => dest.Image, opt => opt.MapFrom(src => src.User.Image))
                .ForPath(dest => dest.CommentLikes, opt => opt.MapFrom(src => src.CommentLikes.Count))
                .ForPath(dest => dest.CommentLikesArr, opt => opt.MapFrom(src => src.CommentLikes.Select(p => p.UserId)))
                .ForPath(dest => dest.CommentDisLikesArr, opt => opt.MapFrom(src => src.CommentDisLikes.Select(p => p.UserId)));

        }
    }
}
