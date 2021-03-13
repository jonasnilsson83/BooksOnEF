using AutoMapper;
using BooksOnEF.Api.PresentationModels;
using BooksOnEF.Core.DataModels;

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
            CreateMap<BookModel, Book>();
            CreateMap<AuthorModel, Author>();
        }
    }
}
