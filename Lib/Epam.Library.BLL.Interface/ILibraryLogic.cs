using Epam.Library.Entities;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Epam.Library.BLL.Interface
{
    public interface ILibraryLogic
    {
        void Add(AbstractPrintedProducts printedProducts, out ICollection<ValidationFailure> errorList);
        void Update(AbstractPrintedProducts printedProducts, out ICollection<ValidationFailure> errorList);
        IEnumerable<AbstractPrintedProducts> GetAllPrintedProducts();
    }
}
