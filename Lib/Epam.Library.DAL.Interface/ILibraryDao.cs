using Epam.Library.Entities;
using System.Collections.Generic;

namespace Epam.Library.DAL.Interface
{
    public interface ILibraryDao
    {
        IEnumerable<AbstractPrintedProducts> GetAllPrintedProducts();
    }
}
