




/*****************************************************************************
*   该文件由T4模版生成
*   如需添加其他功能，请在相同空间命下建立部分类
*
*
*
*****************************************************************************/

using AuthorityManagement.Core.Domains;
using System.Data.Entity;

/*SkymateBase*/
public partial class AuthorityManagementContext : DbContext 
{
 #region Ctor
    /// <summary>
    /// 构造函数，初始化一个新的<c>ByteartRetailDbContext</c>实例。
    /// </summary>
    public AuthorityManagementContext()
        : base("AuthorityManagement_Demo")
    {
        this.Configuration.AutoDetectChangesEnabled = true;
        this.Configuration.LazyLoadingEnabled = true;
    }
    #endregion
 #region Public Properties
   public DbSet<User> Users
        {
            get { return Set<User>(); }
        }
     public DbSet<Group> Groups
        {
            get { return Set<Group>(); }
        }
     public DbSet<UserInGroup> UserInGroups
        {
            get { return Set<UserInGroup>(); }
        }
     public DbSet<Role> Roles
        {
            get { return Set<Role>(); }
        }
     public DbSet<UserInRole> UserInRoles
        {
            get { return Set<UserInRole>(); }
        }
     public DbSet<GroupInRole> GroupInRoles
        {
            get { return Set<GroupInRole>(); }
        }
     public DbSet<Function> Functions
        {
            get { return Set<Function>(); }
        }
     public DbSet<FunctionInRole> FunctionInRoles
        {
            get { return Set<FunctionInRole>(); }
        }
    #endregion
}
