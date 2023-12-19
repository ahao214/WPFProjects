using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerTool.SqlItem
{
    /// <summary>
    /// SQL语句（常量）
    /// </summary>
    public class SqlConst
    {
        #region 查询数据库表

        /// <summary>
        /// 查询数据库表
        /// </summary>
        public const string GetTables = "SELECT id,name FROM sysobjects WHERE xtype='{0}' AND id > 0 AND name <> 'dtproperties' ORDER BY name";

        #endregion
    }
}
