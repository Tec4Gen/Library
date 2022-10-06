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
    public class PatentLogic : IPatentLogic
    {
        private IPatentDao _patentDao;
        private IValidator<PatentDto> _validationPatent;

        public PatentLogic(IPatentDao patentDao, IValidator<PatentDto> validationPatent)
        {
            _patentDao = patentDao;
            _validationPatent = validationPatent;
        }
        public void Add(PatentDto patent, ref ICollection<ValidationFailure> errorList)
        {

            if (!_validationPatent.Validate(patent).IsValid)
            {
                errorList = _validationPatent.Validate(patent).Errors;
                return;
            }
           
            _patentDao.Add(patent, ref errorList);      
        }

        public IEnumerable<PatentDto> FindByAuthor(int authorId)
        {
           
            return _patentDao.FindByAuthor(authorId);
        }

        public IEnumerable<PatentDto> FindByTitle(string title)
        {
            return _patentDao.FindByTitle(title);
        }

        public IEnumerable<PatentDto> GetAll()
        {
            return _patentDao.GetAll();
        }

        public PatentDto GetById(int id)
        {
            return _patentDao.GetById(id); ;
        }

        public ILookup<int, PatentDto> GroupByYear()
        {
            return _patentDao.GroupByYear();
        }

        public void Remove(int id, out ICollection<ValidationFailure> errorList)
        {
            errorList = new List<ValidationFailure>();

            _patentDao.Remove(id, ref errorList);
        }

        public IEnumerable<PatentDto> SortedByYearForward()
        {
            return _patentDao.SortedByYearForward();
        }

        public IEnumerable<PatentDto> SortedByYearReverse()
        {
             return _patentDao.SortedByYearReverse();
        }

        public void Update(PatentDto patent, ref ICollection<ValidationFailure> errorList)
        {
            if (!_validationPatent.Validate(patent).IsValid)
            {
                errorList = _validationPatent.Validate(patent).Errors;
                return;
            }

            _patentDao.Update(patent, ref errorList);
        }
    }
}
