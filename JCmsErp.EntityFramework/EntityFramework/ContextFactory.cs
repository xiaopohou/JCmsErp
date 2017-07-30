using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace JCmsErp.EntityFramework
{
    public class ContextFactory
    {
        /// <summary>
        /// 获取当前数据上下文
        /// </summary>
        /// <returns></returns>
        public static JCmsErpDbContext GetCurrentContext()
        {
            JCmsErpDbContext db = CallContext.GetData("Default") as JCmsErpDbContext;
            if (db == null)
            {
                db = new JCmsErpDbContext();
                CallContext.SetData("Default", db);
            }
            return db;
        }

        public static void GetCurrentContextSetDatabaseExecuteSqlCommand(string FullName)
        {
            JCmsErpDbContext db = CallContext.GetData("Default") as JCmsErpDbContext;
            db.Database.ExecuteSqlCommand(System.IO.File.ReadAllText(FullName, Encoding.Default));
        }
    }
}
