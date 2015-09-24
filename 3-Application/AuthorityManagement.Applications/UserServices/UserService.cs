namespace AuthorityManagement.Applications.UserServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AuthorityManagement.Core.Domains;
    using AuthorityManagement.Core.Repositories;
    using AuthorityManagement.Presentations.UserServices;
    using AuthorityManagement.Presentations.UserServices.Dtos;

    using AutoMapper;

    using Skymate;
    using Skymate.Engines;
    using Skymate.Entities;

    /// <summary>
    /// 用户服务实现
    /// </summary>
    public class UserService:IUserService
    {
        /// <summary>
        /// 用户仓储
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">
        /// The user repository.
        /// </param>
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="userInput">
        /// The user input.
        /// </param>
        public void Add(EditUserInputDto userInput)
        {
            Guard.ArgumentNotNull(() => userInput);
            var toAdd = Mapper.Map<User>(userInput);

            using (var uof = EngineContext.Current.Resolve<ISkymateUnitOfWork>())
            {
                if (toAdd.ID == Guid.Empty)
                {
                    toAdd.ID = Guid.NewGuid();
                }

                this.userRepository.Add(toAdd);
                uof.Commit();
            }
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="userInput">
        /// The user input.
        /// </param>
        public void Update(EditUserInputDto userInput)
        {
            Guard.ArgumentNotNull(() => userInput);
            Guard.ArgumentNotEmpty(() => userInput.Id);

            var toUpdate = this.userRepository.GetByKey(userInput.Id);

            toUpdate = Mapper.Map<EditUserInputDto, User>(userInput, toUpdate);
            this.userRepository.Update(toUpdate);
            this.userRepository.Context.Commit();
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="userid">
        /// The userid.
        /// </param>
        public void Delete(Guid userid)
        {
            Guard.ArgumentNotEmpty(() => userid);

            var toRemove = this.userRepository.GetByKey(userid);
            this.userRepository.Remove(toRemove);
            this.userRepository.Context.Commit();
        }

        /// <summary>
        /// The get user by id.
        /// </summary>
        /// <param name="userid">
        /// The userid.
        /// </param>
        /// <returns>
        /// The <see cref="EditUserInputDto"/>.
        /// </returns>
        public EditUserInputDto GetUserById(Guid userid)
        {
            Guard.ArgumentNotEmpty(() => userid);

            var user = this.userRepository.GetByKey(userid);
            return Mapper.Map<EditUserInputDto>(user);
        }

        /// <summary>
        /// The get all user.
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
        /// <exception cref="Exception">
        /// </exception>
        public IEnumerable<UserListOutputDto> GetAllUser(int pageIndex, int pageSize, out int total)
        {
            if (pageIndex < 0)
            {
                throw new Exception("页面不能小于0");
            }

            var query = this.userRepository.FindAll();

            total = query.Count();
            query = query.OrderBy(u => u.UserName).Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return query.ToList().Select(Mapper.Map<UserListOutputDto>);
        }
    }
}
