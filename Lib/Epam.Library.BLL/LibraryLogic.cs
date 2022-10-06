using Epam.Library.BLL.Interface;
using Epam.Library.DAL.Interface;
using Epam.Library.Entities;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Epam.Library.BLL
{
    public class LibraryLogic : ILibraryLogic
    {
        private readonly IBookLogic _bookLogic;
        private readonly IPatentLogic _patentLogic;
        private readonly INewspaperLogic _newspaperLogic;
        private readonly ILibraryDao _libraryDao;
        public LibraryLogic(IBookLogic bookLogic, IPatentLogic patentLogic, INewspaperLogic newspaperLogic, ILibraryDao libraryDao)
        {
            _bookLogic = bookLogic;
            _patentLogic = patentLogic;
            _newspaperLogic = newspaperLogic;
            _libraryDao = libraryDao;

        }
        public void Add(AbstractPrintedProducts printedProducts, out ICollection<ValidationFailure> errorList)
        {
            errorList = new List<ValidationFailure>();

            if (printedProducts is BookDto book)
            {
                _bookLogic.Add(book, ref errorList);
            }
            else if (printedProducts is NewspaperDto newspaper)
            {
                _newspaperLogic.Add(newspaper, ref errorList);
            }
            else if (printedProducts is PatentDto patent)
            {
                _patentLogic.Add(patent, ref errorList);
            }
        }

        public IEnumerable<AbstractPrintedProducts> GetAllPrintedProducts()
        {
            return _libraryDao.GetAllPrintedProducts();
        }
       
        public void Update(AbstractPrintedProducts printedProducts, out ICollection<ValidationFailure> errorList)
        {
            errorList = new List<ValidationFailure>();

            if (printedProducts is BookDto book)
            {
                _bookLogic.Update(book, ref errorList);
            }
            else if (printedProducts is NewspaperDto newspaper)
            {
                _newspaperLogic.Update(newspaper, ref errorList);
            }
            else if (printedProducts is PatentDto patent)
            {
                _patentLogic.Update(patent, ref errorList);
            }
        }
    }
}
