using Epam.Library.Entities;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Epam.Library.DAL.Interface
{
    public interface IPatentDao
    {
        void Add(PatentDto patent, ref ICollection<ValidationFailure> errorList);
        void Remove(int id, ref ICollection<ValidationFailure> errorList);
        void Update(PatentDto patent, ref ICollection<ValidationFailure> errorList);
        PatentDto GetById(int id);
        IEnumerable<PatentDto> GetAll();
        IEnumerable<PatentDto> FindByTitle(string title);
        IEnumerable<PatentDto> SortedByYearForward();
        IEnumerable<PatentDto> SortedByYearReverse();
        IEnumerable<PatentDto> FindByAuthor(int authorId);
        ILookup<int, PatentDto> GroupByYear();
    }
}
