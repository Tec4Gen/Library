using Epam.Library.DAL.Interface;
using Epam.Library.Entities;
using System.Collections.Generic;

namespace Epam.Library.FakeDAL
{
    public class LibraryDao : ILibraryDao
    {
        public IEnumerable<AbstractPrintedProducts> GetAllPrintedProducts()
        {
            return DataStore.LibraryStorage.Values;
        }
    }
}
