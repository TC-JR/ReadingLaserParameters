using SDKDemoCS;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic;

namespace ReadingLaserParameters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //定义信号接收的集合
        public Dictionary<string, string> IO = new Dictionary<string, string>();
        public Dictionary<string, string> Path = new Dictionary<string, string>();

        //创建公共文件加载对象
        public class FileObj
        {
            public string FilePath { get; set; }
            public string StartIo { get; set; }
            public string EndIo { get; set; }
        }

        public static FileObj fileObj = new FileObj();

        private void uiButton1_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine(a[0]);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "D://";
            //openFileDialog.Filter = "金橙子文件|*.ezd|文本文件|*.txt|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Log("加载镭雕文档");
                uiTextBox1.Text = openFileDialog.FileName;
                BslSDK.LoadDataFile(uiTextBox1.Text);
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            PENPAR pen = new PENPAR();
            BslSDK.GetPenPar(ref pen, uiTextBox1.Text, Convert.ToUInt32(uiTextBox2.Text));
            Debug.WriteLine(pen.dMarkSpeed);
            uiTextBox2.Text = pen.dMarkSpeed.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //STU_DEVIP[] a = new STU_DEVIP[0];
            //var numbrs = 0;
            //BslSDK.InitDevices();
            //BslSDK.GetAllDevices(a, ref numbrs);
            //加载用户列表
            UserComboBox.Items.Add("操作员");
            UserComboBox.Items.Add("工程师");
            UserComboBox.Items.Add("管理员");
            UserComboBox.SelectedIndex = 0;
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {

            Debug.WriteLine(uiListBox1.SelectedItem.ToString());

            //Random random = new Random();
            //var number = random.Next(0, 2);
            //Debug.WriteLine(number);

            //foreach (var item in IO)
            //{
            //    //判断启动信号
            //    if (number.ToString() == item.Key)
            //    {
            //        //加载焊接文档进行焊接
            //        foreach (var item1 in Path)
            //        {
            //            if (number.ToString() == item1.Key)
            //            {
            //                Debug.WriteLine(item1.Value);
            //            }
            //        }
            //        //输出完成信号
            //        Debug.WriteLine(item.Value);
            //    }
            //}


        }

        /// <summary>
        /// listbox添加镭雕文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile loadFile = new LoadFile();
            loadFile.ShowDialog();
            try
            {
                // 检查要添加的项目是否已存在于ListBox中  
                if (!uiListBox1.Items.Contains(fileObj.FilePath)) // textBox1是输入要添加项目的文本框  
                {
                    //把加载号的启动IO和完成IO添加到字典
                    foreach (var item in IO)
                    {
                        if (fileObj.StartIo == item.Key)
                        {
                            Log_box.AppendText("请勿设置相同的启动IO" + "\r\n");
                            return;
                        }
                    }
                    IO.Add(fileObj.StartIo, fileObj.EndIo);

                    //对照启动IO的路径字典
                    Path.Add(fileObj.StartIo, fileObj.FilePath);
                    // 如果不存在，则添加项目到ListBox中  
                    uiListBox1.Items.Add(fileObj.FilePath);

                }
                else
                {
                    // 如果存在，则不执行任何操作  
                    Log_box.AppendText("请勿添加相同的文件" + "\r\n");
                }

            }
            catch (Exception ex)
            {
                Log_box.AppendText(ex.ToString() + "\r\n");
            }

            #region 弃用
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); ;
            ////openFileDialog.Filter = "焊接文件|*.orzx|所有文件|*.*";
            //openFileDialog.RestoreDirectory = true;
            //openFileDialog.FilterIndex = 1;
            ////判断是否点击了窗口确定键
            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    // 检查要添加的项目是否已存在于ListBox中  
            //    if (!uiListBox1.Items.Contains(openFileDialog.FileName)) // textBox1是输入要添加项目的文本框  
            //    {
            //        // 如果不存在，则添加项目到ListBox中  
            //        uiListBox1.Items.Add(openFileDialog.FileName);
            //        //textBox1.Clear(); // 清空文本框，以便下一次输入  
            //    }
            //    else
            //    {
            //        // 如果存在，则不执行任何操作  
            //        Log_box.AppendText("请勿添加相同的文件" + "\r\n");
            //    }

            //    //Log("加载镭雕文档");
            //    //uiListBox1.Items.Add(openFileDialog.FileName);
            //    //BslSDK.LoadDataFile(uiTextBox1.Text);
            //}
            #endregion
        }

        /// <summary>
        /// 删除listbox选择的项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 检查ListBox是否有选中项  
            if (uiListBox1.SelectedIndex != -1)
            {
                //先移除字典中的内容
                foreach (var item in Path)
                {
                    if (uiListBox1.SelectedItem.ToString() == item.Value)
                    {
                        Path.Remove(item.Key);
                    }
                }


                // 如果有选中项，则移除该项  
                uiListBox1.Items.RemoveAt(uiListBox1.SelectedIndex);

                //测试字典中是否还有值
                foreach (var item in Path)
                {
                    Debug.WriteLine(item.Key + "   " + item.Value);
                }

            }
            else
            {
                // 如果没有选中项，则不执行任何操作  
                Log_box.AppendText("先选中要删除的项目再进行操作" + "\r\n");
            }
        }

        private void 设置端口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 检查ListBox是否有选中项  
            if (uiListBox1.SelectedIndex != -1)
            {
                // 如果有选中项，则配置端口  
                //配置端口界面
            }
            else
            {
                // 如果没有选中项，则不执行任何操作  
                Log_box.AppendText("先选中要设置的项目再进行操作" + "\r\n");
            }

        }

        /// <summary>
        /// 编辑选中的焊接文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 编辑焊接文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 检查ListBox是否有选中项  
            if (uiListBox1.SelectedIndex != -1)
            {
                // 如果有选中项，则打开焊接文件  
                //配置端口界面
                MessageBox.Show("请在焊接文件编辑完成后，关闭BSL软件，再点击确定加载激光控制卡");
                //判断BSL进程是否存在，如果存在，则重新提示，如果关闭则加载控制卡
                while (true)
                {
                    //判断进程关闭
                    if (true)
                    {
                        break;
                    }
                    else
                    {
                        MessageBox.Show("检测到BSL软件进程没有关闭，请先关闭，再点击确定加载激光控制卡");

                    }

                }
            }
            else
            {
                // 如果没有选中项，则不执行任何操作  
                Log_box.AppendText("先选中要设置的项目再进行操作" + "\r\n");
            }

        }

        private void uiLine1_Click(object sender, EventArgs e)
        {
            uiLine1.Text = Interaction.InputBox("输入分割名称", "输入分割名称");
        }
    }
}