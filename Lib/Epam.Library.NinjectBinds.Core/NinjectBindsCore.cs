using Epam.Library.BLL;
using Epam.Library.BLL.Interface;
using Epam.Library.BLL.Validations;
using Epam.Library.DAL;
using Epam.Library.DAL.Interface;
using Epam.Library.Entities;
using FluentValidation;
using Ninject.Modules;

namespace Epam.Library.NinjectBinds.Core
{
    public class NinjectBindsCore : NinjectModule
    {
        public override void Load()
        {
            Bind<IAuthorDao>().To<AuthorDao>();
            Bind<IBookDao>().To<BookDao>();
            Bind<INewspaperDao>().To<NewspaperDao>();
            Bind<IPatentDao>().To<PatentDao>();
            Bind<ILibraryDao>().To<LibraryDao>();
            Bind<IInstanceNewspaperDao>().To<InstanceNewspaperDao>();

            Bind<IValidator<AuthorDto>>().To<ValidationAuthor>();
            Bind<IValidator<BookDto>>().To<ValidationBook>();
            Bind<IValidator<NewspaperDto>>().To<ValidationNewspaper>();
            Bind<IValidator<PatentDto>>().To<ValidationPatent>();


            Bind<IAuthorLogic>().To<AuthorLogic>();
            Bind<IBookLogic>().To<BookLogic>();
            Bind<INewspaperLogic>().To<NewspaperLogic>();
            Bind<IPatentLogic>().To<PatentLogic>();
            Bind<IInstanceNewpaperLogic>().To<InstanceNewspaperLogic>();
            Bind<ILibraryLogic>().To<LibraryLogic>();

        }
    }
}