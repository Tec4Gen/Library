using Epam.Library.Entities;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Epam.Library.DAL.Interface
{
    public interface IInstanceNewspaperDao
    {
        void Add(InstanceNewspaperDto instanceNewpaper, ref ICollection<ValidationFailure> errorList);
        void Remove(int id, ref ICollection<ValidationFailure> errorList);
        void Update(InstanceNewspaperDto instanceNewpaper, ref ICollection<ValidationFailure> errorList);
        InstanceNewspaperDto GetById(int id);
        IEnumerable<InstanceNewspaperDto> GetAllByIdNewspaper(int idNewspaper);
    }
}
