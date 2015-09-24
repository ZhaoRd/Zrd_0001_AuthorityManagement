// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuidHelper.cs" company="skymate">
//   copyright @ 2015 skymate.
// </copyright>
// <summary>
//   Defines the GuidHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AuthorityManagement
{
    using System;

    /// <summary>
    /// Guid帮助类.
    /// </summary>
    public static class GuidHelper
    {
        /// <summary>
        /// 生成有序的Guid.
        /// </summary>
        /// <returns>
        /// The <see cref="Guid"/>.
        /// </returns>
        public static Guid GenerateGuid()
        {
            var guidArray = Guid.NewGuid().ToByteArray();

            var baseDate = new DateTime(1900, 1, 1);
            var now = DateTime.Now;
            var days = new TimeSpan(now.Ticks - baseDate.Ticks);
            var msecs = now.TimeOfDay;

            var daysArray = BitConverter.GetBytes(days.Days);
            var msecsArray = BitConverter.GetBytes((long)(msecs.TotalMilliseconds / 3.333333));

            Array.Reverse(daysArray);
            Array.Reverse(msecsArray);

            Array.Copy(daysArray, daysArray.Length - 2, guidArray, guidArray.Length - 6, 2);
            Array.Copy(msecsArray, msecsArray.Length - 4, guidArray, guidArray.Length - 4, 4);

            return new Guid(guidArray);
        }
    }
}
