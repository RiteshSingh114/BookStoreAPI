using AutoMapper;
using BookStore.DataLayer;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookModel, Books>().ReverseMap();
        }
    }
}
