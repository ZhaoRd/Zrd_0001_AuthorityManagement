// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DependencyRegistrar.cs" company="SGS">
//   copyright (C) 2015 sgs. All Right
// </copyright>
// <summary>
//   The dependency registrar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AuthorityManagement.Web.Dependency
{
    using AuthorityManagement.Applications;

    using Autofac;

    using Castle.Windsor;

    using Skymate.DependencyManagement;
    using Skymate.Logging;
    using Skymate.TypeFinders;

    /// <summary>
    /// The dependency registrar.
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Gets the order.
        /// </summary>
        public int Order
        {
            get { return 0; }
        }

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        /// <param name="typeFinder">
        /// The type finder.
        /// </param>
        /// <param name="isActiveModule">
        /// The is active module.
        /// </param>
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, bool isActiveModule)
        {
            var serviceAssembly = typeof(FunctionService).Assembly;
            builder.RegisterAssemblyTypes(serviceAssembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
