using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform;
using Winform.Models;

namespace WinForm
{
    public partial class frmGenerate : Form
    {
        /// <summary>
        /// 节点类型
        /// </summary>
        public enum NodeType
        {
            /// <summary>
            /// 文件夹
            /// </summary>
            Directory=0,
            /// <summary>
            /// 文件
            /// </summary>
            File=1
        }

        public frmGenerate()
        {
            InitializeComponent();
        }
        /// <summary>
        /// IconIndexs类 对应ImageList中5张图片的序列
        /// </summary>
        private class IconIndexes
        {
            public const int MyComputer = 0;      //我的电脑
            public const int ClosedFolder = 1;    //文件夹关闭
            public const int OpenFolder = 2;      //文件夹打开
            public const int FixedDrive = 3;      //磁盘盘符
            public const int MyDocuments = 4;     //我的文档
        }
        private void frmGenerate_Load(object sender, EventArgs e)
        {
            tvDir.CheckBoxes = true;
            //实例化TreeNode类 TreeNode(string text,int imageIndex,int selectImageIndex)            
            TreeNode rootNode = new TreeNode("我的电脑",
                IconIndexes.MyComputer, IconIndexes.MyComputer);  //载入显示 选择显示
            rootNode.Tag = "我的电脑";                            //树节点数据
            rootNode.Text = "我的电脑";                           //树节点标签内容
            this.tvDir.Nodes.Add(rootNode);               //树中添加根目录

            //显示MyDocuments(我的文档)结点
            var myDocuments = Environment.GetFolderPath           //获取计算机我的文档文件夹
                (Environment.SpecialFolder.MyDocuments);
            TreeNode DocNode = new TreeNode(myDocuments);
            DocNode.Tag = "我的文档";                            //设置结点名称
            DocNode.Text = "我的文档";
            DocNode.ImageIndex = IconIndexes.MyDocuments;         //设置获取结点显示图片
            DocNode.SelectedImageIndex = IconIndexes.MyDocuments; //设置选择显示图片
            rootNode.Nodes.Add(DocNode);                          //rootNode目录下加载节点
            DocNode.Nodes.Add("");

            //循环遍历计算机所有逻辑驱动器名称(盘符)
            foreach (string drive in Environment.GetLogicalDrives())
            {
                //实例化DriveInfo对象 命名空间System.IO
                var dir = new DriveInfo(drive);
                switch (dir.DriveType)           //判断驱动器类型
                {
                    case DriveType.Fixed:        //仅取固定磁盘盘符 Removable-U盘 
                        {
                            //Split仅获取盘符字母
                            TreeNode tNode = new TreeNode(dir.Name.Split(':')[0]);
                            tNode.Name = dir.Name;
                            tNode.Tag = tNode.Name;
                            tNode.ImageIndex = IconIndexes.FixedDrive;         //获取结点显示图片
                            tNode.SelectedImageIndex = IconIndexes.FixedDrive; //选择显示图片
                            tvDir.Nodes.Add(tNode);                    //加载驱动节点
                            tNode.Nodes.Add("");
                        }
                        break;
                }
            }
            rootNode.Expand();                  //展开树状视图
        }

        private void tvDir_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.Expand();
        }

        private void tvDir_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes != null)
            {
                foreach (TreeNode n in e.Node.Nodes)
                {
                    n.Checked = e.Node.Checked;
                }
            }
        }

        /// <summary>
        /// 自定义类TreeViewItems 调用其Add(TreeNode e)方法加载子目录
        /// </summary>
        public static class TreeViewItems
        {
            public static void Add(TreeNode e)
            {
                //try..catch异常处理
                try
                {
                    //判断"我的电脑"Tag 上面加载的该结点没指定其路径
                    if (e.Tag.ToString() != "我的电脑")
                    {
                        e.Nodes.Clear();                               //清除空节点再加载子节点
                        TreeNode tNode = e;                            //获取选中\展开\折叠结点
                        string path = tNode.Name;                      //路径  

                        //获取"我的文档"路径
                        if (e.Tag.ToString() == "我的文档")
                        {
                            path = Environment.GetFolderPath           //获取计算机我的文档文件夹
                                (Environment.SpecialFolder.MyDocuments);
                        }

                        //获取指定目录中的子目录名称并加载结点
                        string[] dics = Directory.GetDirectories(path);
                        foreach (string dic in dics)
                        {
                            TreeNode subNode = new TreeNode(new DirectoryInfo(dic).Name); //实例化
                            subNode.Name = new DirectoryInfo(dic).FullName;               //完整目录
                            subNode.Tag = NodeType.Directory;
                            subNode.ImageIndex = IconIndexes.ClosedFolder;       //获取节点显示图片
                            subNode.SelectedImageIndex = IconIndexes.OpenFolder; //选择节点显示图片
                            tNode.Nodes.Add(subNode);
                            subNode.Nodes.Add("");                               //加载空节点 实现+号
                        }

                        //获取指定目录中的文件名称并加载结点
                        string[] files = Directory.GetFiles(path);
                        foreach (string f in files)
                        {
                            TreeNode subNode = new TreeNode(new DirectoryInfo(f).Name); //实例化
                            subNode.Name = new DirectoryInfo(f).FullName;               //完整目录
                            subNode.Tag = NodeType.File;
                            subNode.ImageIndex = IconIndexes.ClosedFolder;       //获取节点显示图片
                            subNode.SelectedImageIndex = IconIndexes.OpenFolder; //选择节点显示图片
                            tNode.Nodes.Add(subNode);
                        }
                    }
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.Message);                   //异常处理
                }
            }
        }

        private void tvDir_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeViewItems.Add(e.Node);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var generateSettings=new List<GenerateSettings>();
            foreach (var control in pnlTempSettings.Controls)
            {
                var tsControl = control as TempSettingControl;
                if (tsControl != null)
                {
                    var settings = tsControl.GetSettings();
                    if(string.IsNullOrWhiteSpace(settings.TemplateFileName))
                        throw new Exception("模板文件名为空！");

                    if(string.IsNullOrWhiteSpace(settings.Extention))
                        throw new Exception("文件扩展名不能为空！");

                    if(string.IsNullOrWhiteSpace(settings.DestPath))
                        throw new Exception("目标文件夹不能为空！");

                    generateSettings.Add(settings);
                }
            }
            var modelFileNames = new List<string>();

            foreach (TreeNode node  in tvDir.Nodes)
            {
                GetCheckedFiles(node,modelFileNames);
            }
        }

        private void GetCheckedFiles(TreeNode node, List<string> checkedFileNames)
        {
            if (node.Checked && node.Tag!=null)
            {
                var type = (NodeType)node.Tag;
                //是文件节点，把文件添加到集合，并退出当次循环
                if (type == NodeType.File)
                {
                    checkedFileNames.Add(node.Name);
                    return;
                }
            }

            if (node.GetNodeCount(false) > 0)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    GetCheckedFiles(child,checkedFileNames);
                }
            }
        }

        private void frmGenerate_Activated(object sender, EventArgs e)
        {
            var root = AppDomain.CurrentDomain.BaseDirectory + @"\Temps";
            var rootDir = new DirectoryInfo(root);
            if (!rootDir.Exists)
                rootDir.Create();

            var files = rootDir.GetFiles("*.temp");
            pnlTempSettings.Controls.Clear();
            var index = 0;
            foreach (FileInfo fInfo in files)
            {
                var lc = new TempSettingControl(fInfo.Name);
                lc.Width = pnlTempSettings.Width - 10;
                lc.Location = new Point(5, index * lc.Height + 5 * (index + 1));
                pnlTempSettings.Controls.Add(lc);
                index++;
            }
        }
    }
}
