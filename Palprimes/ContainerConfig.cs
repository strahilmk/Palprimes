using Autofac;
using Palprimes.BL.BinaryNumber;
using Palprimes.BL.DecimalNumber;
using Palprimes.DAL;
using Palprimes.DAL.BinaryNumber;
using Palprimes.DAL.DecimalNumber;
using Palprimes.Handlers;

namespace Palprimes
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<Validator>().As<IValidator>();
            builder.RegisterType<PalprimeFinder>().As<IPalprimeFinder>();
            builder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>();
            builder.RegisterType<DecimalNumberDAL>().As<IDecimalNumberDAL>();
            builder.RegisterType<BinaryNumberDAL>().As<IBinaryNumberDAL>();
            builder.RegisterType<DecimalNumberBL>().As<IDecimalNumberBL>();
            builder.RegisterType<BinaryNumberBL>().As<IBinaryNumberBL>();

            return builder.Build();
        }
    }
}
