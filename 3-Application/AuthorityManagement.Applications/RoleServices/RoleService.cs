namespace AuthorityManagement.Applications.RoleServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AuthorityManagement.Core.Domains;
    using AuthorityManagement.Core.Repositories;
    using AuthorityManagement.Presentations.RoleServices;
    using AuthorityManagement.Presentations.RoleServices.Dtos;

    using AutoMapper;

    using Skymate;
    using Skymate.Engines;
    using Skymate.Entities;

    /// <summary>
    /// The role service.
    /// </summary>
    public class RoleService : IRoleService
    {
        /// <summary>
        /// The role repository.
        /// </summary>
        private readonly IRoleRepository roleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleService"/> class.
        /// </summary>
        /// <param name="roleRepository">
        /// The role repository.
        /// </param>
        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="roleInput">
        /// The role input.
        /// </param>
        public void Add(RoleInputDto roleInput)
        {
            Guard.ArgumentNotNull(() => roleInput);

            var toAdd = Mapper.Map<Role>(roleInput);

            using (var unitOfWork = EngineContext.Current.Resolve<ISkymateUnitOfWork>())
            {
                if (toAdd.ID == Guid.Empty)
                {
                    toAdd.ID = GuidHelper.GenerateGuid();
                }

                this.roleRepository.Add(toAdd);

                unitOfWork.Commit();
            }
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="roleInput">
        /// The role input.
        /// </param>
        public void Update(RoleInputDto roleInput)
        {
            Guard.ArgumentNotNull(() => roleInput);
            Guard.ArgumentNotEmpty(() => roleInput.Id);

            using (var unitOfWork = EngineContext.Current.Resolve<ISkymateUnitOfWork>())
            {
                var toUpdate = this.roleRepository.GetByKey(roleInput.Id);
                toUpdate = Mapper.Map(roleInput, toUpdate);

                this.roleRepository.Update(toUpdate);

                unitOfWork.Commit();
            }
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="roleid">
        /// The roleid.
        /// </param>
        public void Delete(Guid roleid)
        {
            using (var unitOfWork = EngineContext.Current.Resolve<ISkymateUnitOfWork>())
            {
                var toRemove = this.roleRepository.GetByKey(roleid);
                
                this.roleRepository.Remove(toRemove);

                unitOfWork.Commit();
            }
        }

        /// <summary>
        /// The get role by id.
        /// </summary>
        /// <param name="roleid">
        /// The roleid.
        /// </param>
        /// <returns>
        /// The <see cref="RoleInputDto"/>.
        /// </returns>
        public RoleInputDto GetRoleById(Guid roleid)
        {
            var role = this.roleRepository.GetByKey(roleid);
            return Mapper.Map<RoleInputDto>(role);
        }

        /// <summary>
        /// The get all roles.
        /// </summary>
        /// <param name="pageIndex">
        /// The page index.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <param name="total">
        /// The total.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<RoleListOutputDto> GetAllRoles(int pageIndex, int pageSize, out int total)
        {

            var query = this.roleRepository.FindAll();

            total = query.Count();
            query = query.OrderBy(u => u.ID)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            return query.ToList().Select(Mapper.Map<RoleListOutputDto>);
        }

        /// <summary>
        /// The get all roles.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<RoleListOutputDto> GetAllRoles()
        {
            var query = this.roleRepository.FindAll();

            return query.ToList().Select(Mapper.Map<RoleListOutputDto>);
        }
    }
}
