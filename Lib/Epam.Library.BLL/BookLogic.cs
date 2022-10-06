using Epam.Library.BLL.Interface;
using Epam.Library.DAL.Interface;
using Epam.Library.Entities;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.Library.BLL
{
    public class BookLogic : IBookLogic
    {
        private readonly IBookDao _bookDao;
        private readonly IValidator<BookDto> _validationBook;

        public BookLogic(IBookDao bookDao, IValidator<BookDto> validationBook)
        {
            _validationBook = validationBook;
            _bookDao = bookDao;
        }
        public void Add(BookDto book, ref ICollection<ValidationFailure> errorList)
        {
            if (!_validationBook.Validate(book).IsValid)
            {
                errorList = _validationBook.Validate(book).Errors;

                return;
            }

            _bookDao.Add(book, ref errorList);   
        }

        public IEnumerable<BookDto> FindByAuthor(int authorId)
        {
             return _bookDao.FindByAuthor(authorId);
        }

        public IEnumerable<BookDto> FindByTitle(string title)
        {
            return _bookDao.FindByTitle(title);
        }

        public IEnumerable<BookDto> GetAll()
        {
            return _bookDao.GetAll();
        }

        public ILookup<string, BookDto> GetGroupsBooksStartingWithSetOfCharacters(string pattern)
        {
          return _bookDao.GetGroupsBooksStartingWithSetOfCharacters(pattern);     
        }

        public BookDto GetById(int id)
        {
            return _bookDao.GetById(id);
        }

        public void Remove(int id, out ICollection<ValidationFailure> errorList)
        {
            errorList = new List<ValidationFailure>();

            _bookDao.Remove(id, ref errorList);
        }

        public IEnumerable<BookDto> SortedByYearForward()
        {  
            return _bookDao.SortedByYearForward(); 
        }

        public IEnumerable<BookDto> SortedByYearReverse()
        {
            return _bookDao.SortedByYearReverse();
        }

        public void Update(BookDto book, ref ICollection<ValidationFailure> errorList)
        {
            _bookDao.Update(book, ref errorList);
        }

        public ILookup<int, BookDto> GroupByYear()
        {
            return _bookDao.GroupByYear();
        }
    }
}
