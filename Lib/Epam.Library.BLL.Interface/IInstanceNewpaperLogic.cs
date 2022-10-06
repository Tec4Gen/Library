using Epam.Library.Entities;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Epam.Library.BLL.Interface
{
    public interface IInstanceNewpaperLogic
    {
        void Add(InstanceNewspaperDto instanceNewspaper, NewspaperDto newspaper, out ICollection<ValidationFailure> errorList);
        void Remove(int id, out ICollection<ValidationFailure> errorList);
        void Update(InstanceNewspaperDto instanceNewspaper, NewspaperDto newspaper, out ICollection<ValidationFailure> errorList);
        InstanceNewspaperDto GetById(int id);
        IEnumerable<InstanceNewspaperDto> GetAllByIdNewspaper(int idNewspaper);
    }
}
