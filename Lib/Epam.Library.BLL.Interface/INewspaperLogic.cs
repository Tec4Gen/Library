using Epam.Library.Entities;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Epam.Library.BLL.Interface
{
    public interface INewspaperLogic
    {
        void Add(NewspaperDto Newspaper, ref ICollection<ValidationFailure> errorList);
        void Remove(int id, out ICollection<ValidationFailure> errorList);
        void Update(NewspaperDto Newspaper, ref ICollection<ValidationFailure> errorList);
        NewspaperDto GetById(int id);
        IEnumerable<NewspaperDto> GetAll();
        IEnumerable<NewspaperDto> FindByTitle(string title);
        IEnumerable<NewspaperDto> SortedByYearForward();
        IEnumerable<NewspaperDto> SortedByYearReverse();
        ILookup<int, NewspaperDto> GroupByYear();
    }
}
