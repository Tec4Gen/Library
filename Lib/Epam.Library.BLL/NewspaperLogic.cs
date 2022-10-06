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
    public class NewspaperLogic : INewspaperLogic
    {
        private readonly INewspaperDao _newspaperDao;
        private readonly IValidator<NewspaperDto> _validationNewspaper;

        public NewspaperLogic(INewspaperDao newspaperDao, IValidator<NewspaperDto> validationNewspaper)
        {
            _newspaperDao = newspaperDao;
            _validationNewspaper = validationNewspaper;
        }

        public void Add(NewspaperDto newspaper, ref ICollection<ValidationFailure> errorList)
        {
            if (!_validationNewspaper.Validate(newspaper).IsValid)
            {
                errorList = _validationNewspaper.Validate(newspaper).Errors;
                return;
            }

            _newspaperDao.Add(newspaper, ref errorList);
        }

        public IEnumerable<NewspaperDto> FindByTitle(string title)
        {
            return _newspaperDao.FindByTitle(title);
        }

        public IEnumerable<NewspaperDto> GetAll()
        {
          
            return _newspaperDao.GetAll();
          
        }

        public NewspaperDto GetById(int id)
        {
            return _newspaperDao.GetById(id);
        }

        public ILookup<int, NewspaperDto> GroupByYear()
        {
            return _newspaperDao.GroupByYear();
        }

        public void Remove(int id, out ICollection<ValidationFailure> errorList)
        {
            errorList = new List<ValidationFailure>();

            _newspaperDao.Remove(id, ref errorList);  
        }

        public IEnumerable<NewspaperDto> SortedByYearForward()
        {

            return _newspaperDao.SortedByYearForward();
     
        }

        public IEnumerable<NewspaperDto> SortedByYearReverse()
        {
           
            return _newspaperDao.SortedByYearForward();
           
        }

        public void Update(NewspaperDto newspaper, ref ICollection<ValidationFailure> errorList)
        {
            if (!_validationNewspaper.Validate(newspaper).IsValid)
            {
                errorList = _validationNewspaper.Validate(newspaper).Errors;
                return;
            }

            _newspaperDao.Update(newspaper, ref errorList);
        }

    }
}
