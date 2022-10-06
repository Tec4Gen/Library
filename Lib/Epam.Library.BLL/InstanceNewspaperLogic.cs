using Epam.Library.BLL.Interface;
using Epam.Library.DAL.Interface;
using Epam.Library.Entities;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Epam.Library.BLL
{
    public class InstanceNewspaperLogic : IInstanceNewpaperLogic
    {
        private readonly IInstanceNewspaperDao _instanceNewspaperDao;
        private readonly IValidator<InstanceNewspaperDto> _validationInstanceNewspaper;
        public InstanceNewspaperLogic(IInstanceNewspaperDao instanceNewspaperDao, IValidator<InstanceNewspaperDto> validationInstanceNewspaper)
        {
            _instanceNewspaperDao = instanceNewspaperDao;
            _validationInstanceNewspaper = validationInstanceNewspaper;
        }

        public void Add(InstanceNewspaperDto instanceNewpaper, NewspaperDto newspaper, out ICollection<ValidationFailure> errorList)
        {
            
            if (!_validationInstanceNewspaper.Validate(instanceNewpaper).IsValid)
            {
                errorList = _validationInstanceNewspaper.Validate(instanceNewpaper).Errors;

                CheckDate(instanceNewpaper, newspaper, ref errorList);

                return;
            }

            errorList = new List<ValidationFailure>();

            CheckDate(instanceNewpaper, newspaper, ref errorList);

            if (!errorList.Any()) 
            {
                _instanceNewspaperDao.Add(instanceNewpaper, ref errorList);
            }
        }

        public IEnumerable<InstanceNewspaperDto> GetAllByIdNewspaper(int idNewspaper)
        {
            return _instanceNewspaperDao.GetAllByIdNewspaper(idNewspaper);
        }

        public InstanceNewspaperDto GetById(int id)
        {
            return _instanceNewspaperDao.GetById(id);
        }

        public void Remove(int id, out ICollection<ValidationFailure> errorList)
        {
            errorList = new List<ValidationFailure>();

            _instanceNewspaperDao.Remove(id, ref errorList);
        }

        public void Update(InstanceNewspaperDto instanceNewpaper, NewspaperDto newspaper, out ICollection<ValidationFailure> errorList)
        {
            errorList = new List<ValidationFailure>();

            _instanceNewspaperDao.Add(instanceNewpaper, ref errorList);
        }

        private void CheckDate(InstanceNewspaperDto instanceNewpaper, NewspaperDto newspaper, ref ICollection<ValidationFailure> errorList) 
        {
            if (newspaper.ReliseDate.Date != instanceNewpaper.ReliseDate.Date) 
            {
                errorList.Add(new ValidationFailure(nameof(instanceNewpaper), "The year of issue of the newspaper copy must coincide with the year of issue of the newspaper"));
            }

        }
    }
}
