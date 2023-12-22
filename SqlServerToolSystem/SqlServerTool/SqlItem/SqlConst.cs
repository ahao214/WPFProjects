﻿using System;
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

        #region 查看表结构SQL语句
        /// <summary>
        /// 查看表结构SQL语句
        /// </summary>
        public const string GetColumns = @"SELECT c.name as Name,t.name as DataType,c.max_length as MaxLength,c.is_nullable as IsNullable FROM SYSOBJECTS AS o inner join sys.columns AS c ON c.object_id=o.id inner join sys.types AS t ON t.system_type_id=c.system_type_id WHERE o.name='{0}' ORDER BY c.name";

        #endregion

        #region 获取自动增长列、表示量、标识种子
        /// <summary>
        /// 获取自动增长列、表示量、标识种子
        /// </summary>
        public const string GetIdentity = @"SELECT COL_NAME(OBJECT_ID('autoadmin_managed_databases'),column_id) AS [Identity],IDENT_SEED('autoadmin_managed_databases') AS Seed,IDENT_INCR('autoadmin_managed_databases') AS Increment FROM sys.identity_columns WHERE OBJECT_ID=OBJECT_ID('autoadmin_managed_databases')";

        #endregion


    }
}
