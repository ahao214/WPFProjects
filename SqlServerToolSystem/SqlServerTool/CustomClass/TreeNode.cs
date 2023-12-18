using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SqlServerTool.CustomClass
{
    /// <summary>
    /// 节点类
    /// </summary>
    public class TreeNode:TreeViewItem
    {
        /// <summary>
        /// 节点类型(表 视图 存储过程 自定义函数)
        /// </summary>
        public TreeNodeType NodeType { get; set; }
        /// <summary>
        /// 节点深度
        /// </summary>
        public int Depth { get; set; }
        /// <summary>
        /// 带参数构造函数
        /// </summary>
        /// <param name="header"></param>
        /// <param name="name"></param>
        /// <param name="nodeType"></param>
        /// <param name="depth"></param>
        public TreeNode(string header,string name, TreeNodeType nodeType,int depth)
        {
            Header = header;
            Name = name;
            NodeType = nodeType;
            Depth = depth;
        }
        /// <summary>
        /// 不带参数构造函数
        /// </summary>
        public TreeNode()
        {
                
        }
    }

    #region 节点类型枚举

    /// <summary>
    /// 节点类型枚举
    /// </summary>
    public enum TreeNodeType
    {
        /// <summary>
        /// 表
        /// </summary>
        Table=1,
        /// <summary>
        /// 视图
        /// </summary>
        View=2,
        /// <summary>
        /// 存储过程
        /// </summary>
        Procedure=3,
        /// <summary>
        /// 自定义函数
        /// </summary>
        Function=4
    }

    #endregion

}
