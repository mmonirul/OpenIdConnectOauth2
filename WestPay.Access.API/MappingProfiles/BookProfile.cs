using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestPay.Access.API.Dtos;
using WestPay.Access.DAL.Entities.Library;

namespace WestPay.Access.API.MappingProfiles
{
    // Rename to LibraryProfile
    public class BookProfile : Profile 
    {
        public BookProfile()
        {
            CreateMap<Book, BookViewModel>().ReverseMap();

            CreateMap<Author, AuthorViewModel>().ReverseMap();
        }
    }
}
