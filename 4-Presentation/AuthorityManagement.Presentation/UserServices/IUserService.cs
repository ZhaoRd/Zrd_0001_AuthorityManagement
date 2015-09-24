using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityManagement.Presentations.UserServices
{
    using AuthorityManagement.Presentations.UserServices.Dtos;

    /// <summary>
    /// 用户服务接口.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 增加新的用户.
        /// </summary>
        /// <param name="userInput">
        /// 新用户信息.
        /// </param>
        void Add(EditUserInputDto userInput);

        /// <summary>
        /// 更新用户.
        /// </summary>
        /// <param name="userInput">
        /// 更新用户信息.
        /// </param>
        void Update(EditUserInputDto userInput);

        /// <summary>
        /// 用户删除.
        /// </summary>
        /// <param name="userid">
        /// 用户ID.
        /// </param>
        void Delete(Guid userid);

        /// <summary>
        /// 根据ID获取用户.
        /// </summary>
        /// <param name="userid">
        /// 用户id.
        /// </param>
        /// <returns>
        /// The <see cref="EditUserInputDto"/>.
        /// </returns>
        EditUserInputDto GetUserById(Guid userid);

        /// <summary>
        /// 获取分页数据的用户.
        /// </summary>
        /// <param name="pageIndex">
        /// 页吗.
        /// </param>
        /// <param name="pageSize">
        /// 每页大小.
        /// </param>
        /// <param name="total">
        /// 用户总数.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        ///     .
        /// </returns>
        IEnumerable<UserListOutputDto> GetAllUser(int pageIndex,int pageSize,out int total);


    }
}
