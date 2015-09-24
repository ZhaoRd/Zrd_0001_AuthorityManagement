// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DependencyRegistrar.cs" company="Skymate">
//   copyright (C) 2015 skymate. All Right
// </copyright>
// <summary>
//   The dependency registrar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AuthorityManagement.Core.Dependency
{
    using AuthorityManagement.Core.Services;

    using Autofac;

    using Skymate.DependencyManagement;
    using Skymate.TypeFinders;

    /// <summary>
    /// 依赖注册.
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// 注册顺序.
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
            var serviceAssembly = typeof(SecurityDomainService).Assembly;
            builder.RegisterAssemblyTypes(serviceAssembly)
                .Where(t => t.Name.EndsWith("DomainService"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
