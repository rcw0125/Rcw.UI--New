namespace Rcw.CalFramework
{
    using System;

    /// <summary>
    /// 获取标签值的接口，实现该接口的类，需要重写GetTagValue和GetTagValueByCode方法
    /// 实现类是list，遍历每一条记录，如果该条记录的tag等于tagname，则返回该条记录的tag值
    /// </summary>
    public interface IGetTagValue
    {
        /// <summary>
        /// 获取标签值
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        double? GetTagValue(string tagName);
        /// <summary>
        /// 根据code获取标签值
        /// </summary>
        /// <param name="tagCode"></param>
        /// <returns></returns>
        double? GetTagValueByCode(string tagCode);
    }
}

