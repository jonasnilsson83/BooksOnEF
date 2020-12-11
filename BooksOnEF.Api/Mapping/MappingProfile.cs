using AutoMapper;
using BooksOnEF.Api.PresentationModels;
using BooksOnEF.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksOnEF.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to PresentationModel
            CreateMap<Book, BookModel>();
            CreateMap<Author, AuthorModel>();

            // PresentationModel -> Domain 
            //            CreateMap<Book, BookModel>();
            CreateMap<AuthorModel, Author>();


        }
    }
}
