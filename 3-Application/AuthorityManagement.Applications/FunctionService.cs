namespace AuthorityManagement.Applications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AuthorityManagement.Core.Domains;
    using AuthorityManagement.Core.Repositories;
    using AuthorityManagement.Presentation;
    using AuthorityManagement.Presentation.Dtos;

    using AutoMapper;

    using Skymate.Logging;

    /// <summary>
    /// The function service.
    /// </summary>
    public class FunctionService : IFunctionService
    {
        /// <summary>
        /// The function repository.
        /// </summary>
        private readonly IFunctionRepository functionRepository;

        /// <summary>
        /// The user repository.
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// The user in role repository.
        /// </summary>
        private readonly IUserInRoleRepository userInRoleRepository;

        /// <summary>
        /// The function in role repository.
        /// </summary>
        private readonly IFunctionInRoleRepository functionInRoleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionService"/> class.
        /// </summary>
        /// <param name="functionRepository">
        /// The function repository.
        /// </param>
        /// <param name="userRepository">
        /// The user repository.
        /// </param>
        /// <param name="functionInRoleRepository">
        /// The function in role repository.
        /// </param>
        /// <param name="userInRoleRepository">
        /// The user in role repository.
        /// </param>
        public FunctionService(IFunctionRepository functionRepository, IUserRepository userRepository, IFunctionInRoleRepository functionInRoleRepository, IUserInRoleRepository userInRoleRepository)
        {
            this.functionRepository = functionRepository;
            this.userRepository = userRepository;
            this.functionInRoleRepository = functionInRoleRepository;
            this.userInRoleRepository = userInRoleRepository;
        }

        /// <summary>
        /// 初始化系统功能.
        /// </summary>
        /// <param name="functionDtos">
        /// The function dtos.
        /// </param>
        public void InitModel(IEnumerable<FunctionDto> functionDtos)
        {
            var functions = this.functionRepository.FindAll().ToList();

            var addFunctions = functionDtos.Select(Mapper.Map<FunctionDto, Function>)
                .AsEnumerable();

            // 创建如何判断两个function是否相等的条件
            var functionComparer = EqualityHelper<Function>.CreateComparer(m => m.ModelName + "#" + m.FunctionName);

            var enumerable = addFunctions as Function[] ?? addFunctions.ToArray();

            // 包含在将要处理的集合(addFunctions)
            // 但不包含在已经存在的集合(functions)
            // 表示需要添加到系统里的模块
            // 差集运算
            var toAddFunctions = enumerable.Except(functions, functionComparer);

            // 包含在已经存在的集合(functions)
            // 但不包含在将要处理的集合(addFunctions)
            // 表示需要从系统中删除的模块
            // 差集运算
            var toDeleteFunctions = functions.Except(enumerable, functionComparer);

            // 即包含在将要处理的集合(addFunctions)
            // 又包含在已经存在的集合(functions)
            // 表示需要更新内容
            // 交集运算
            var toUpdateFunctions = functions.Intersect(enumerable, functionComparer);

            LogHelper.Logger.Info(
                string.Format(
                    "新增功能:{0}条;更新功能:{1}条;删除功能:{2};",
                    toAddFunctions.Count(),
                    toUpdateFunctions.Count(),
                    toDeleteFunctions.Count()));

            foreach (var addFunction in toAddFunctions)
            {
                addFunction.ID = Guid.NewGuid();
                this.functionRepository.Add(addFunction);
            }

            foreach (var deleteFunction in toDeleteFunctions)
            {
                this.functionRepository.Remove(deleteFunction);
            }

            foreach (var updateFunction in toUpdateFunctions)
            {
                var function = updateFunction;
                var query = enumerable.Where(m => m.FunctionName == function.FunctionName);

                var newValue = string.IsNullOrEmpty(updateFunction.ModelName) ? query.SingleOrDefault(u => u.ModelName == null) : query.SingleOrDefault(u => u.ModelName == function.ModelName);

                if (newValue == null)
                {
                    continue;
                }

                updateFunction.FunctionName = newValue.FunctionName;
                updateFunction.ActionName = newValue.ActionName;
                updateFunction.AreasName = newValue.AreasName;
                updateFunction.ControllerName = newValue.ControllerName;
                updateFunction.Description = newValue.Description;
                updateFunction.ModelName = newValue.ModelName;

                updateFunction.PermissionValue = newValue.PermissionValue;

                this.functionRepository.Update(updateFunction);
            }

            this.functionInRoleRepository.Context.Commit();
        }

        public FunctionDto SearFunction(SearchFunctionInputDto inputDto)
        {
            throw new NotImplementedException();
        }

        public bool VerifyPermission(Guid userId, Guid functionId)
        {
            throw new NotImplementedException();
        }
    }
}
