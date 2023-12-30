using SqlServerTool.CustomClass;
using SqlServerTool.DatabaseHelper;
using SqlServerTool.FileRwHelper;
using SqlServerTool.SqlItem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SqlServerTool
{
    /// <summary>
    /// WinMain.xaml 的交互逻辑
    /// </summary>
    public partial class WinMain : Window
    {
        #region 对话框标题信息
        /// <summary>
        /// 对话框标题信息
        /// </summary>
        private const string Caption = "信息提示";
        #endregion

        #region 数据库帮助
        /// <summary>
        /// 数据库帮助
        /// </summary>
        private readonly DBHelper db = new DBHelper(App.DbConnectionInfo.ToString());
        #endregion

        #region 定义数据库表右键菜单
        /// <summary>
        /// 定义数据库表右键菜单
        /// </summary>
        private readonly ContextMenu tbMenu = new ContextMenu();

        #endregion

        #region 定义视图右键菜单
        /// <summary>
        /// 定义视图右键菜单
        /// </summary>
        private readonly ContextMenu vmMenu = new ContextMenu();

        #endregion

        #region 定义存储过程右键菜单
        /// <summary>
        /// 定义存储过程右键菜单
        /// </summary>
        private readonly ContextMenu prMenu = new ContextMenu();

        #endregion

        #region 定义自定义函数右键菜单
        /// <summary>
        /// 定义自定义函数右键菜单
        /// </summary>
        private readonly ContextMenu fcMenu = new ContextMenu();

        #endregion

        #region 装载右键菜单集合
        /// <summary>
        /// 装载右键菜单集合
        /// </summary>
        private List<ContextMenu> listCm = new List<ContextMenu>();

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public WinMain()
        {
            InitializeComponent();
        }
        #endregion

        #region 窗体加载
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadListCm();
            LoadWinCaption();
            LoadTreeView();
            LoadContextMenu();
        }

        #endregion

        #region 装载四个右键菜单
        /// <summary>
        /// 装载四个右键菜单
        /// </summary>
        private void LoadListCm()
        {
            listCm.Add(tbMenu);
            listCm.Add(vmMenu);
            listCm.Add(prMenu);
            listCm.Add(fcMenu);
        }

        #endregion

        #region 加载四个模块的右键菜单内容
        /// <summary>
        /// 加载四个模块的右键菜单内容
        /// </summary>
        private void LoadContextMenu()
        {
            //1.表
            MenuItem tbMiOne = new MenuItem
            {
                Header = "查看表结构"
            };
            tbMiOne.Click += new RoutedEventHandler(TbMiOne_Click);
            tbMenu.Items.Add(tbMiOne);

            MenuItem tbMiTwo = new MenuItem
            {
                Header = "生成Create脚本"
            };
            tbMiTwo.Click += new RoutedEventHandler(TbMiTwo_Click);
            tbMenu.Items.Add(tbMiTwo);

            MenuItem tbMiThree = new MenuItem
            {
                Header = "生成Insert脚本"
            };
            tbMiThree.Click += new RoutedEventHandler(TbMiThree_Click);
            tbMenu.Items.Add(tbMiThree);

            //2.视图
            MenuItem vmMi = new MenuItem
            {
                Header = "查看视图结构"
            };
            vmMi.Click += new RoutedEventHandler(VmMi_Click);
            tbMenu.Items.Add(vmMi);

            //3.存储过程
            MenuItem prMi = new MenuItem
            {
                Header = "查看存储过程脚本"
            };
            prMi.Click += new RoutedEventHandler(PrMi_Click);
            tbMenu.Items.Add(prMi);

            //4.自定义函数
            MenuItem fcMi = new MenuItem
            {
                Header = "查看自定义函数脚本"
            };
            fcMi.Click += new RoutedEventHandler(FcMi_Click);
            tbMenu.Items.Add(fcMi);
        }

        #endregion

        #region 查看函数脚本
        private void FcMi_Click(object sender, RoutedEventArgs e)
        {
            TreeNode tn = GetSelectTreeNode(TreeNodeType.Function);
            if (tn == null)
                return;
            string sql = string.Format(SqlConst.GetFunction, tn.Name);
            StringBuilder sb = new StringBuilder();
            try
            {
                DataTable dt = db.GetDataTable(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    sb.AppendFormat("{0}", dr[0]);
                }
                TxtSql.Text = sb.ToString();
            }
            catch (Exception err)
            {

                throw;
            }
        }

        #endregion

        #region 存储过程
        private void PrMi_Click(object sender, RoutedEventArgs e)
        {
            TreeNode tn = GetSelectTreeNode(TreeNodeType.Procedure);
            if (tn == null)
                return;

            string sql = string.Format(SqlConst.GetProcedure, tn.Name);
            StringBuilder sb = new StringBuilder();
            DataTable dt = db.GetDataTable(tn.Name);
            foreach (DataRow dr in dt.Rows)
            {
                sb.AppendFormat("{0}", dr[0]);

            }
            TxtSql.Text = sb.ToString();

        }
        #endregion

        #region 查看视图
        /// <summary>
        /// 查看视图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void VmMi_Click(object sender, RoutedEventArgs e)
        {
            TreeNode tn = GetSelectTreeNode(TreeNodeType.View);
            if (tn == null)
                return;
            string sql = string.Format(SqlConst.GetColumns, tn.Name);
            Execute(sql);
        }

        #endregion

        #region 生成INSERT语句

        /// <summary>
        /// 生成INSERT语句
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void TbMiThree_Click(object sender, RoutedEventArgs e)
        {
            TreeNode tn = GetSelectTreeNode(TreeNodeType.Table);
            if (tn == null)
                return;
            try
            {
                StringBuilder sb = new StringBuilder();
                FileReadWrite fileRead = new FileReadWrite(AppDomain.CurrentDomain.BaseDirectory + "\\Sql.txt");
                //通过读取文件的方式进行获取SQL脚本
                string sql = string.Format(fileRead.ReadFile(), tn.Name);
                DataSet ds = db.GetDataSet(sql);
                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            sb.Append(dr[i].ToString());
                        }
                        sb.Append(";\r\n");
                    }
                }
                TxtSql.Text = sb.ToString();
                DocContent.Children.Clear();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, Caption, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }

        #endregion

        #region 生成创建表语句Create脚本
        /// <summary>
        /// 生成创建表语句Create脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void TbMiTwo_Click(object sender, RoutedEventArgs e)
        {
            TreeNode tn = GetSelectTreeNode(TreeNodeType.Table);
            if (tn == null)
            {
                return;
            }
            string tbName = tn.Name;
            string sql = string.Format(SqlConst.GetColumns, tbName);
            DataTable dt = db.GetDataTable(sql);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CREATE TABLE [{0}]", tbName);
            sb.AppendLine("\r\n(");
            // 自动增长列
            sql = string.Format(SqlConst.GetIdentity, tbName);
            DataTable dy = db.GetDataTable(sql);
            string identity = string.Empty;
            int seed = 1;
            int increment = 1;
            foreach (DataRow dr in dy.Rows)
            {
                identity = dr["Identity"].ToString();
                seed = Convert.ToInt32(dr["Seed"]);
                increment = Convert.ToInt32(dr["Increment"]);
            }
            int total = dt.Rows.Count, k = 1;
            // 字段
            foreach (DataRow dr in dt.Rows)
            {
                string dataType = dr["DataType"].ToString().ToUpper();
                string fieldName = dr["Name"].ToString().ToUpper();
                string maxLength = dr["MaxLength"].ToString();
                string notVal = string.Empty;
                int isNullable = Convert.ToInt32(dr["IsNullable"]);
                if (dataType.Equals("INT"))
                {
                    sb.AppendFormat("\t[{0}] {1}", fieldName, dataType);
                }
                else
                {
                    sb.AppendFormat("\t[{0}] {1}({2})", fieldName, dataType, maxLength);
                }
                if (identity == fieldName)
                {
                    sb.AppendFormat("IDENTITY({0},{1})", seed, increment);
                }
                notVal = isNullable == 0 ? "NOT " : string.Empty;
                if (total == k)
                {
                    sb.AppendFormat(" {0}NULL", notVal);
                }
                else
                {
                    sb.AppendFormat(" {0}NULL,", notVal);
                }
                sb.AppendLine("");
                k++;
            }
            sb.AppendLine(");\r\n");
            // 约束
            sql = string.Format(SqlConst.GetConstraint, tbName);
            DataSet ds = db.GetDataSet(sql);
            if (ds.Tables.Count == 0)
            {
                return;
            }
            sb.AppendFormat("ALTER TABLE [{0}] WITH NOCHECK ADD ", tbName);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string type = dr["constraint_type"].ToString();
                string keys = dr["constraint_keys"].ToString();
                string name = dr["constraint_name"].ToString();
                sb.AppendFormat(" CONSTRAINT [{0}]", name);

                if (keys.StartsWith("("))
                {
                    string[] typeArr = type.Split(' ');
                    if (typeArr.Length > 3)
                    {
                        sb.AppendFormat("DEFAULT {0} FOR [{1}],", keys, typeArr[3]);

                    }
                    else
                    {

                    }
                }
                else
                {
                    sb.AppendFormat("{0} ([{1}]),", type.Replace("(", "").Replace(")", "").ToUpper(), keys);
                }
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(";\r\n");
            // 索引
            sql = string.Format(SqlConst.GetIndex, tbName);
            if (ds.Tables.Count == 0) { return; }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                sb.AppendFormat("CREATE INDEX [{0}] ON [{1}] ({2})", dr["index_name"], tbName, dr["index_keys"]);
            }

            TxtSql.Text = sb.ToString();

            DocContent.Children.Clear();


        }

        #endregion



        #region 查看表结构
        /// <summary>
        /// 查看表结构
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbMiOne_Click(object sender, RoutedEventArgs e)
        {
            // 前提是我们需要知道选了哪个节点
            TreeNode tn = GetSelectTreeNode(TreeNodeType.Table);
            if (tn == null)
            {
                return;
            }
            string sql = TxtSql.Text = string.Format(SqlConst.GetColumns, tn.Name);
            Execute(sql);
        }

        #endregion



        #region 执行SQL语句
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        private void Execute(string sql)
        {
            if (sql.ToLower().StartsWith("select") || sql.ToLower().StartsWith("sp_help"))
            {
                DataSet ds = default;
                try
                {
                    ds = db.GetDataSet(sql);
                }
                catch (Exception err)
                {
                    OutPutString(err.Message);
                    return;
                }
                ReturnResult(ds);
            }
            else
            {
                int i = 0;
                try
                {
                    i = db.Execute(sql);
                }
                catch (Exception err)
                {
                    OutPutString(err.Message);
                    return;
                }
                OutPutString($"执行成功,影响行数：{i}");
            }
        }

        #endregion

        #region 返回结果集
        /// <summary>
        /// 返回结果集
        /// </summary>
        /// <param name="ds"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void ReturnResult(DataSet ds)
        {
            DocContent.Children.Clear();
            TabControl tabCtl = new TabControl();
            foreach (DataTable dt in ds.Tables)
            {
                TabItem item = new TabItem();
                item.Header = dt.TableName;
                item.Content = BindGrid(dt);
                tabCtl.Items.Add(item);
            }
            DocContent.Children.Add(tabCtl);
        }

        #endregion

        #region 绑定网格数据
        /// <summary>
        /// 绑定网格数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private object BindGrid(DataTable dt)
        {
            DataGrid dg = new DataGrid();
            dg.IsReadOnly = true;
            dg.ItemsSource = dt.DefaultView;
            return dg;
        }

        #endregion

        #region 输出各种查看类型的结果
        /// <summary>
        /// 输出各种查看类型的结果
        /// </summary>
        /// <param name="msg"></param>
        private void OutPutString(string msg)
        {
            TxtSql.Text = msg;
        }

        #endregion

        #region 返回选中的节点
        /// <summary>
        /// 返回选中的节点
        /// </summary>
        /// <param name="nType"></param>
        /// <returns></returns>
        private TreeNode GetSelectTreeNode(TreeNodeType nType)
        {
            TreeNode tn = TvMenu.SelectedItem as TreeNode;
            if (tn == null || tn.NodeType != nType)
            {
                MessageBox.Show("请选择节点对象!", Caption, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return null;
            }
            return tn;
        }

        #endregion

        #region 加载树形菜单(表 视图 存储过程 自定义函数)
        /// <summary>
        /// 加载树形菜单(表 视图 存储过程 自定义函数)
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void LoadTreeView()
        {
            List<TreeNode> nodes = new List<TreeNode>
            {
                new TreeNode("数据库表","DataTable",0,0),
                new TreeNode("视图","DataView",0,0),
                new TreeNode("存储过程","DataTable",0,0),
                new TreeNode("自定义函数","DataTable",0,0),
            };

            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].IsExpanded = true;
                AddChildNode(nodes[i], (TreeNodeType)(i + 1));

                nodes[i].ContextMenu = listCm[i];
            }
            TvMenu.ItemsSource = nodes;
        }

        #endregion

        #region 填充树节点的子节点  
        /// <summary>
        /// 填充树节点的子节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="type"></param>
        private void AddChildNode(TreeNode node, TreeNodeType type)
        {
            string sType = "U";
            switch (type)
            {
                case TreeNodeType.Table:
                    sType = "U";
                    break;
                case TreeNodeType.View:
                    sType = "V";
                    break;
                case TreeNodeType.Procedure:
                    sType = "P";
                    break;
                case TreeNodeType.Function:
                    sType = "TF";
                    break;
            }

            string sql = string.Format(SqlConst.GetTables, sType);
            DataTable dt = db.GetDataTable(sql);

            foreach (DataRow dr in dt.Rows)
            {
                node.Items.Add(new TreeNode(dr["name"].ToString(), dr["name"].ToString(), type, 1));
            }

            TbContent.Text += string.Format("{0}:{1}个  ", node.Header, dt.Rows.Count);

        }

        #endregion

        #region 构造WinMain窗体标题
        /// <summary>
        /// 构造WinMain窗体标题
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void LoadWinCaption()
        {
            Title += string.Format($"-服务器:{App.DbConnectionInfo.Server} 数据库: {App.DbConnectionInfo.DataBase}");
        }

        #endregion
    }
}
