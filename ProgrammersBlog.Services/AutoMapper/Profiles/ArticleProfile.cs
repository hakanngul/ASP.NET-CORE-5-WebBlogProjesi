using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Services.AutoMapper.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            // CreatedDate kısmını DateTime.Now ile input yapıyoruz
            CreateMap<ArticleAddDto, Article>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            // ModifiedDate kısmını DateTime.Now ile input yapıyoruz
            CreateMap<ArticleUpdateDto, Article>().ForMember(dest=> dest.ModifiedDate, opt=> opt.MapFrom(x=> DateTime.Now));
            
        }
    }
}
