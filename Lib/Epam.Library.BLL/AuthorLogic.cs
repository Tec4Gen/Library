using Epam.Library.BLL.Interface;
using Epam.Library.DAL.Interface;
using Epam.Library.Entities;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Epam.Library.BLL
{
    public class AuthorLogic : IAuthorLogic
    {
        private readonly IAuthorDao _authorDao;

        private readonly IValidator<AuthorDto> _validationAuthor;

        public AuthorLogic(IAuthorDao authorDao, IValidator<AuthorDto> validationAuthor)
        {
            _authorDao = authorDao;
            _validationAuthor = validationAuthor;
        }
        
        public void Add(AuthorDto author, out ICollection<ValidationFailure> errorList)
        {
           
            if (!_validationAuthor.Validate(author).IsValid)
            {
                errorList = _validationAuthor.Validate(author).Errors;
                return;
            }

            errorList = new List<ValidationFailure>();

             _authorDao.Add(author, ref errorList);
        }

        public IEnumerable<AbstractPrintedProducts> FindAllPatentsAndBooks(AuthorDto author)
        {
            foreach (var itemPrintedProducts in _authorDao.FindAllPatentsAndBooks(author))
            {
                yield return itemPrintedProducts;
            }
        }

        public IEnumerable<AuthorDto> GetAll()
        {
            foreach (var author in _authorDao.GetAll())
            {
                yield return author;
            }
        }

        public IEnumerable<AuthorDto> GetAllAuthorByBookId(int bookId)
        {
            return _authorDao.GetAllAuthorByBookId(bookId);
        }

        public IEnumerable<AuthorDto> GetAllAuthorByPatentId(int patentId)
        {
            return _authorDao.GetAllAuthorByPatentId(patentId);
        }

        public AuthorDto GetById(int id)
        {
            return _authorDao.GetById(id);
        }
        public void Remove(int id, out ICollection<ValidationFailure> errorList)
        {
            errorList = new List<ValidationFailure>();

            _authorDao.Remove(id, ref errorList);
    
        }

        public void Update(AuthorDto author, out ICollection<ValidationFailure> errorList)
        {
            errorList = new List<ValidationFailure>();

            _authorDao.Update(author, ref errorList);
        }
    }
}
