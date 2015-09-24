namespace AuthorityManagement.Data.Dependency
{
    using System.Data.Entity;

    using Apworks.Repositories;
    using Apworks.Repositories.EntityFramework;

    using AuthorityManagement.Data.Repositories;

    using Autofac;

    using Skymate.DependencyManagement;
    using Skymate.Logging;
    using Skymate.TypeFinders;

    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order
        {
            get { return -1; }
        }


        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, bool isActiveModule)
        {
            
            builder.Register(x => new AuthorityManagementContext())
                .As<DbContext>()
                .InstancePerLifetimeScope();

            var serviceAssembly = typeof(FunctionInRoleRepository).Assembly;
            builder.RegisterAssemblyTypes(serviceAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

           /* builder.RegisterType<FunctionRepository>().As<IFunctionRepository>().InstancePerLifetimeScope();
*/
        }
    }

}
