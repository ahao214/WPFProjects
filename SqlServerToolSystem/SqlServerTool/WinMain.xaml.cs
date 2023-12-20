using SqlServerTool.CustomClass;
using SqlServerTool.DatabaseHelper;
using SqlServerTool.SqlItem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        #region 自定义函数
        private void FcMi_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 存储过程
        private void PrMi_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 视图
        private void VmMi_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region 表
        private void TbMiThree_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TbMiTwo_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TbMiOne_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("");
        } 
        #endregion

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
