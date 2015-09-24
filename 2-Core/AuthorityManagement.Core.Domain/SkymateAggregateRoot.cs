// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkymateAggregateRoot.cs" company="Skymate">
//   copyright @ skymate
// </copyright>
// <summary>
//   The skymate aggregate root.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AuthorityManagement.Core
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Apworks;

    using Skymate.Entities.Auditing;

    /// <summary>
    /// 聚合跟.
    /// </summary>
    public abstract class SkymateAggregateRoot : IAggregateRoot, IFullAudited
    {
        /// <summary>
        /// 主键.
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        /// <summary>
        /// 创建者的ID.
        /// </summary>
        public Guid? CreatorUserId { get; set; }

        /// <summary>
        /// 最后一次修改时间.
        /// </summary>
        public DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// 最后一次修改者的ID
        /// </summary>
        public Guid? LastModifierUserId { get; set; }

        /// <summary>
        /// 是否已删除.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 删除者的ID.
        /// </summary>
        public Guid? DeleterUserId { get; set; }

        /// <summary>
        /// 删除时间.
        /// </summary>
        public DateTime? DeletionTime { get; set; }

        /// <summary>
        /// 创建日期.
        /// </summary>
        public DateTime CreationTime { get; set; }


    }
}
