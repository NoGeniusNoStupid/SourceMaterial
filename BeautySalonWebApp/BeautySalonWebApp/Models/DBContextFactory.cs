using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace BeautySalonWebApp.Models
{   
    /// <summary>
    /// 负责创建EF数据操作上下文实例，必须保证线程内唯一.
    /// </summary>
    public class DBContextFactory
    {
        /// <summary>
        /// 创建EF数据操作上下文实例
        /// </summary>
        /// <returns></returns>
        public static DbContext CreateDbContext()
        {
            //线程槽
            DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
            if (dbContext == null)
            {
                dbContext = new BeautySalonEntities();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;
        }
    }
}
