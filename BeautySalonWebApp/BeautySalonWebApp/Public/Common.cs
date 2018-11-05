

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautySalonWebApp.Public
{ 
    /// <summary>
    /// 表示通用方法的公共类
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// 获得字符串类型
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetString(object name)
        {
           string result = name == null ? string.Empty : name.ToString();
           return result;
           
        }





       
    }
}
