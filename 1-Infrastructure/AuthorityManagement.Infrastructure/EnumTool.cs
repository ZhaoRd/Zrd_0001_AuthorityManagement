// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumTool.cs" company="Skymate">
//   copyright @ 2015 skymate.
// </copyright>
// <summary>
//   枚举工具.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AuthorityManagement
{
    using System;
    using System.Collections.Generic;

    using Skymate.Extensions;

    /// <summary>
    /// 枚举工具.
    /// </summary>
    public static class EnumTool
    {
        /// <summary>
        /// 将枚举转化为value的列表.
        /// </summary>
        /// <param name="type">
        /// 枚举类型.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>IList</cref>
        ///     </see>
        ///     .
        /// </returns>
        public static IList<Enum> ToValueList(this Type type)
        {
            IList<Enum> results = new List<Enum>();

            if (!type.IsEnum)
            {
                return results;
            }

            var enumValues = Enum.GetValues(type);
            foreach (Enum enumValue in enumValues)
            {
                results.Add(enumValue);
            }


            return results;
        }

        /// <summary>
        /// 将枚举转化为带有描述的列表.
        /// </summary>
        /// <param name="type">
        /// 枚举类型.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>IList</cref>
        ///     </see>
        ///     .
        /// </returns>
        public static IList<EnumModel<Enum>> ToList(
            this Type type)
        {
            IList<EnumModel<Enum>> results = new List<EnumModel<Enum>>();

            if (!type.IsEnum)
            {
                return results;
            }

            var enumValues = Enum.GetValues(type);
            foreach (Enum enumValue in enumValues)
            {
                results.Add(new EnumModel<Enum>
                                {
                                    Description = enumValue.GetDescription(),
                                    Enum = enumValue
                                }); 
            }

            return results;
        }
    }
}
