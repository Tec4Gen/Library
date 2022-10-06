using Epam.Library.Entities;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Epam.Library.BLL.Interface
{
    public interface IAuthorLogic
    {
        void Add(AuthorDto author, out ICollection<ValidationFailure> errorList);
        void Remove(int id, out ICollection<ValidationFailure> errorList);
        void Update(AuthorDto author, out ICollection<ValidationFailure> errorList);
        AuthorDto GetById(int id);
        IEnumerable<AuthorDto> GetAll();
        IEnumerable<AbstractPrintedProducts> FindAllPatentsAndBooks(AuthorDto author);
        IEnumerable<AuthorDto> GetAllAuthorByPatentId(int patentId);
        IEnumerable<AuthorDto> GetAllAuthorByBookId(int bookId);
    }
}
