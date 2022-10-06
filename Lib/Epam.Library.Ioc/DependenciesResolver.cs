using Epam.Library.NinjectBinds.AutoMapper;
using Epam.Library.NinjectBinds.Core;
using Ninject;
namespace Epam.Library.Ioc
{
    public static class DependenciesResolver
    {
        public static NinjectBindsCore _ninjectBinds { get; private set; }
        public static NinjectBindsAutoMapBinds _ninjectAutoMapBinds { get; private set; }
        public static StandardKernel Kernel { get; private set; }
        public static StandardKernel KernelMapper { get; private set; }

        static DependenciesResolver()
        {
            _ninjectBinds = new NinjectBindsCore();
            Kernel = new StandardKernel(_ninjectBinds);

            _ninjectAutoMapBinds = new NinjectBindsAutoMapBinds();
            KernelMapper = new StandardKernel(_ninjectAutoMapBinds);
        }
    }
}
