namespace AuthorityManagement.Applications
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 相等比较辅助类，用于快速创建<see cref="IEqualityComparer&lt;T&gt;"/>的实例
    /// </summary>
    /// <example>
    /// var equalityComparer1 = EqualityHelper[Person].CreateComparer(p => p.ID);
    /// var equalityComparer2 = EqualityHelper[Person].CreateComparer(p => p.Name);
    /// var equalityComparer3 = EqualityHelper[Person].CreateComparer(p => p.Birthday.Year);
    /// </example>
    /// <typeparam name="T"> </typeparam>
    public static class EqualityHelper<T>
    {
        #region 公共方法

        /// <summary>
        /// 创建指定对比委托<paramref name="keySelector"/>的实例
        /// </summary>
        public static IEqualityComparer<T> CreateComparer<TV>(Func<T, TV> keySelector)
        {
            return new CommonEqualityComparer<TV>(keySelector);
        }

        /// <summary>
        /// 创建指定对比委托<paramref name="keySelector"/>与结果二次比较器<paramref name="comparer"/>的实例
        /// </summary>
        public static IEqualityComparer<T> CreateComparer<TV>(Func<T, TV> keySelector, IEqualityComparer<TV> comparer)
        {
            return new CommonEqualityComparer<TV>(keySelector, comparer);
        }

        #endregion

        #region Nested type: CommonEqualityComparer

        private class CommonEqualityComparer<TV> : IEqualityComparer<T>
        {
            private readonly IEqualityComparer<TV> _comparer;
            private readonly Func<T, TV> _keySelector;

            public CommonEqualityComparer(Func<T, TV> keySelector, IEqualityComparer<TV> comparer)
            {
                this._keySelector = keySelector;
                this._comparer = comparer;
            }

            public CommonEqualityComparer(Func<T, TV> keySelector)
                : this(keySelector, EqualityComparer<TV>.Default)
            { }

            #region IEqualityComparer<T> Members

            public bool Equals(T x, T y)
            {
                return this._comparer.Equals(this._keySelector(x), this._keySelector(y));
            }

            public int GetHashCode(T obj)
            {
                return this._comparer.GetHashCode(this._keySelector(obj));
            }

            #endregion
        }

        #endregion
    }
}