using SDKDemoCS;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Logging;
using Microsoft.Win32;
using System.Net.Sockets;
using System.Net;
using System;
using System.Text;
using Sunny.UI.Win32;

namespace ReadingLaserParameters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 全局变量
        //上次加载文件列表的数量
        public static int FileListBoxCount;
        //控制卡加载状态
        public static bool LaserLoadState = false;
        //所有设备ID
        public static STU_DEVIP[] vDevIP = new STU_DEVIP[8];
        //所有设备数量
        public static int iDevCount;
        //控制卡状态、在线、离线
        public static bool ControlState;
        //密码验证状态
        public static bool PasswordOk = false;
        //登录状态
        public static bool LoginStatus = false;
        //定义信号接收的集合
        public Dictionary<string, string> IO = new Dictionary<string, string>();//启动io和停止io
        public Dictionary<string, string> Path = new Dictionary<string, string>();//启动io和文件路径
        //停止监听启动信号的标志位
        public static bool StopMonitor = false;
        #endregion
        //创建文件加载对象类
        public class FileObj
        {
            public string FilePath { get; set; }
            public string StartIo { get; set; }
            public string EndIo { get; set; }
        }
        //文件对象初始化
        public static FileObj fileObj = new FileObj();


        /// <summary>
        /// 加载启动配
        /// </summary>
        public void LoadJsonConfig()
        {
            //读IP地址
            TextIp_box.Text = JsonConfigHelper.ReadConfig("ip");
            //读端口号
            TextPort_box.Text = JsonConfigHelper.ReadConfig("port");
            //读分割线名称
            uiLine1.Text = JsonConfigHelper.ReadConfig("l1");
            uiLine2.Text = JsonConfigHelper.ReadConfig("l2");
            uiLine3.Text = JsonConfigHelper.ReadConfig("l3");
            uiLine4.Text = JsonConfigHelper.ReadConfig("l4");
            uiLine5.Text = JsonConfigHelper.ReadConfig("l5");
            uiLine6.Text = JsonConfigHelper.ReadConfig("l6");
            //读复选框状态
            Pen1.Checked = Convert.ToBoolean(JsonConfigHelper.ReadConfig("pen1")) ? true : false;
            Pen2.Checked = Convert.ToBoolean(JsonConfigHelper.ReadConfig("pen2")) ? true : false;
            Pen3.Checked = Convert.ToBoolean(JsonConfigHelper.ReadConfig("pen3")) ? true : false;
            Pen4.Checked = Convert.ToBoolean(JsonConfigHelper.ReadConfig("pen4")) ? true : false;
            Pen5.Checked = Convert.ToBoolean(JsonConfigHelper.ReadConfig("pen5")) ? true : false;
            Pen6.Checked = Convert.ToBoolean(JsonConfigHelper.ReadConfig("pen6")) ? true : false;
            Pen7.Checked = Convert.ToBoolean(JsonConfigHelper.ReadConfig("pen7")) ? true : false;
            Pen8.Checked = Convert.ToBoolean(JsonConfigHelper.ReadConfig("pen8")) ? true : false;
            //读文件列表数量
            FileListBoxCount = Convert.ToInt32(JsonConfigHelper.ReadConfig("filecount"));
            //读文件列表与IO信号
            for (int i = 1; i <= FileListBoxCount; i++)
            {
                uiListBox1.Items.Add(JsonConfigHelper.ReadConfig("filepath" + i.ToString()));
                Debug.WriteLine(JsonConfigHelper.ReadConfig("filepath" + i.ToString()));
                IO.Add(JsonConfigHelper.ReadConfig("strtio" + i.ToString()), JsonConfigHelper.ReadConfig("endio" + i.ToString()));
            }
            //test
            foreach (var item in IO)
            {
                Debug.WriteLine(item.Key);
                Debug.WriteLine(item.Value);
            }
            //从文档获取笔号

        }

        /// <summary>
        /// 存配置文件
        /// </summary>
        public void SaveJsonConfig()
        {
            //存IP地址
            JsonConfigHelper.WriteConfig("ip", TextIp_box.Text);
            //存端口号
            JsonConfigHelper.WriteConfig("port", TextPort_box.Text);
            //存分割线名称
            JsonConfigHelper.WriteConfig("l1", uiLine1.Text);
            JsonConfigHelper.WriteConfig("l2", uiLine2.Text);
            JsonConfigHelper.WriteConfig("l3", uiLine3.Text);
            JsonConfigHelper.WriteConfig("l4", uiLine4.Text);
            JsonConfigHelper.WriteConfig("l5", uiLine5.Text);
            JsonConfigHelper.WriteConfig("l6", uiLine6.Text);
            //存复选框状态
            JsonConfigHelper.WriteConfig("pen1", Pen1.Checked ? "true" : "false");
            JsonConfigHelper.WriteConfig("pen2", Pen2.Checked ? "true" : "false");
            JsonConfigHelper.WriteConfig("pen3", Pen3.Checked ? "true" : "false");
            JsonConfigHelper.WriteConfig("pen4", Pen4.Checked ? "true" : "false");
            JsonConfigHelper.WriteConfig("pen5", Pen5.Checked ? "true" : "false");
            JsonConfigHelper.WriteConfig("pen6", Pen6.Checked ? "true" : "false");
            JsonConfigHelper.WriteConfig("pen7", Pen7.Checked ? "true" : "false");
            JsonConfigHelper.WriteConfig("pen8", Pen8.Checked ? "true" : "false");
            //存列表数量
            JsonConfigHelper.WriteConfig("filecount", uiListBox1.Count.ToString());
            //存设定IO
            int y = 1;
            foreach (var item in IO)
            {
                JsonConfigHelper.WriteConfig("strtio" + y.ToString(), item.Key);
                JsonConfigHelper.WriteConfig("endio" + y.ToString(), item.Value);
                y++;
            }
            y = 1;
            foreach (var item in Path)
            {
                JsonConfigHelper.WriteConfig("filepath" + y.ToString(), item.Value);
                y++;
            }
            y = 1;
            //存文件列表
            foreach (var item in uiListBox1.Items)
            {
                JsonConfigHelper.WriteConfig("filepath" + y.ToString(), item.ToString());
                y++;
            }

        }

        public void LogOut(string str)
        {
            string time = DateTime.Now.ToString("T") + DateTime.Now.ToString(":fff");
            Debug.WriteLine(time);
            Log_box.AppendText(time+"\t"+str+ "\r\n");
        }


        #region 测试用
        //测试用
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
        /// <summary>
        /// test
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiButton3_Click(object sender, EventArgs e)
        {
            LogOut("天地玄黄宇宙洪荒");
            //Debug.WriteLine(uiListBox1.Count);
            //Random random = new Random();
            //var number = random.Next(0, 2);
            //Debug.WriteLine(number);



        }

        //测试用
        private void uiButton2_Click(object sender, EventArgs e)
        {
            PENPAR pen = new PENPAR();
            BslSDK.GetPenPar(ref pen, uiTextBox1.Text, Convert.ToUInt32(uiTextBox2.Text));
            Debug.WriteLine(pen.dMarkSpeed);
            uiTextBox2.Text = pen.dMarkSpeed.ToString();
        }
        #endregion

        /// <summary>
        /// 程序加载
        /// </summary>
        static Mutex mutex = new Mutex(true, "{YourAppGuid}"); // {YourAppGuid}为应用程序的全局唯一标识符
        [STAThread]
        private void Form1_Load(object sender, EventArgs e)
        {
            //判断程序是否注册
            //读注册表返回值
            var a = ReadRegistryValue("Software\\TianCiCompany\\DataUpLoad\\RegistrationInformation");
            // 检查注册表值是否存在  
            if (a != "True")
            {
                // 注册表值不存在或找不到注册表键，给出提示并退出程序  
                MessageBox.Show("软件未注册，程序将退出。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            //防止程序重复运行
            //判断互斥变量是否存在
            if (!mutex.WaitOne(TimeSpan.Zero)) //防止程序重复运行
            {
                MessageBox.Show("该程序已经在运行了！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }

            //加载启动页面
            SplashScreenBackground SSB = new SplashScreenBackground();
            //SSB.ShowDialog();
            //SSB.Dispose();
            if (ControlState)
            {
                this.Close();
            }
            //初始化控制卡
            //STU_DEVIP[] a = new STU_DEVIP[0];
            //var numbrs = 0;
            //BslSDK.InitDevices();
            //BslSDK.GetAllDevices(a, ref numbrs);

            //加载用户列表
            UserComboBox.Items.Add("操作员");
            UserComboBox.Items.Add("工程师");
            UserComboBox.Items.Add("管理员");
            UserComboBox.SelectedIndex = 0;
            //加载配置文件
            LoadJsonConfig();
        }

        /// <summary>
        /// 读注册表
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static string ReadRegistryValue(string keyName)
        {
            string value = "";
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName))
                {
                    if (key != null)
                    {
                        value = key.GetValue(keyName).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur.  
                Console.WriteLine(ex.Message);
                return "false";
            }
            return value;
        }



        public void WeldingProcess()
        {
            //创建用于接受启动端口的变量
            int a = 0;

            while (true)
            {
                //50ms检测一次
                Thread.Sleep(50);
                //读控制卡当前IO信号
                //BslSDK.ReadInPort(id,a)
                //判断停止监听按钮按下
                if (StopMonitor)
                {
                    //恢复标志位
                    StopMonitor = false;
                    //停止出光
                    //BslSDK.StopMark(id);
                    break;
                }
                //遍历集合，判断当前启动信号是否触发
                foreach (var item in IO)
                {
                    //判断启动信号
                    if (a.ToString() == item.Key)
                    {
                        //加载焊接文档进行焊接
                        foreach (var item1 in Path)
                        {
                            if (a.ToString() == item1.Key)
                            {
                                //加载焊接文档
                                //BslSDK.LoadDataFile(item1.Value);
                                //焊接
                                //BslSDK.MarkByDeviceId(id);
                                Debug.WriteLine(item1.Value);//焊接文档路径
                            }
                        }
                        //输出完成信号
                        //BslSDK.WriteOutPort(id, item.Value,1,1,500);
                        Debug.WriteLine(item.Value);

                    }
                }

            }
            Log_box.AppendText("已经停止监听");
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
            PENPAR pen = new PENPAR();

            // 检查ListBox是否有选中项  
            if (uiListBox1.SelectedIndex != -1)
            {
                // 如果有选中项，则打开焊接文件  
                //使用指定程序打开当前焊接文档


                //给出提示
                MessageBox.Show("请在焊接文件编辑完成后，关闭BSL软件，再点击确定加载激光控制卡");
                //判断BSL进程是否存在，如果存在，则重新提示，如果关闭则加载控制卡
                while (true)
                {
                    //判断进程关闭
                    if (true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            BslSDK.GetPenPar(ref pen, uiListBox1.SelectedItem.ToString(), Convert.ToUInt32(i));
                            Debug.WriteLine(pen.dMarkSpeed);
                            Debug.WriteLine(pen.dPowerRatio);
                        }
                        //读取焊接参数

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

        /// <summary>
        /// 创建线程，监听启动信号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartIo_btn_Click(object sender, EventArgs e)
        {
            Thread Monitor = new Thread(WeldingProcess);
            Monitor.Start();
        }

        /// <summary>
        /// 停止监听标志位，跳出监听循环
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopIo_btn_Click(object sender, EventArgs e)
        {
            StopMonitor = true;
        }

        //监听状态
        public static bool listenIn = false;
        //关闭
        public bool col = true;
        //用于通信的Socket
        Socket socketSend;
        //用于监听的SOCKET
        Socket socketWatch;
        //定义回调:解决跨线程访问问题
        private delegate void SetTextValueCallBack(string strValue);
        //定义接收客户端发送消息的回调
        private delegate void ReceiveMsgCallBack(string strReceive);
        //声明回调
        private SetTextValueCallBack setCallBack;
        //声明
        private ReceiveMsgCallBack receiveCallBack;
        //声明
        private SetCmbCallBack setCmbCallBack;
        //定义发送文件的回调
        private delegate void SendFileCallBack(byte[] bf);
        //定义回调：给ComboBox控件添加元素
        private delegate void SetCmbCallBack(string strItem);
        //创建监听连接的线程
        Thread AcceptSocketThread;
        //接收客户端发送消息的线程
        Thread threadReceive;
        //将远程连接的客户端的IP地址和Socket存入集合中
        Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();

        /// <summary>
        /// 回调委托需要执行的方法
        /// </summary>
        /// <param name="strValue"></param>
        private void SetTextValue(string strValue)
        {
            this.Log_box.AppendText(strValue + " \r");
        }

        private void ReceiveMsg(string strMsg)
        {
            this.Log_box.AppendText(strMsg + " \r");
        }

        private void AddCmbItem(string strItem)
        {
            this.cmb_Socket.Items.Add(strItem);
        }
        public string ip;


        private void uiButton4_Click(object sender, EventArgs e)
        {
            //监听状态开启
            listenIn = true;
            //重置关闭
            col = true;
            //当点击开始监听的时候 在服务器端创建一个负责监听IP地址和端口号的Socket
            socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //获取ip地址
            IPAddress ip = IPAddress.Parse(this.TextIp_box.Text.Trim());
            //创建端口号
            IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(this.TextPort_box.Text.Trim()));
            try
            {
                //绑定IP地址和端口号
                socketWatch.Bind(point);
                this.Log_box.AppendText(DateTime.Now.ToString("G") + "监听成功" + " \r");
                //开始监听:设置最大可以同时连接多少个请求
                socketWatch.Listen(10);
                //实例化回调
                setCallBack = new SetTextValueCallBack(SetTextValue);
                receiveCallBack = new ReceiveMsgCallBack(ReceiveMsg);
                setCmbCallBack = new SetCmbCallBack(AddCmbItem);
                //sendCallBack = new SendFileCallBack(SendFile);

                //创建线程
                AcceptSocketThread = new Thread(new ParameterizedThreadStart(StartListen));
                AcceptSocketThread.IsBackground = true;
                AcceptSocketThread.Start(socketWatch);

            }
            catch (Exception str)
            {
                this.Log_box.AppendText(DateTime.Now.ToString("G") + str + " \r");
                return;
            }

        }

        /// <summary>
        /// 远程IP
        /// </summary>
        public string strIp;
        /// <summary>
        /// 消息变量
        /// </summary>
        public static string strMsg;

        /// <summary>
        /// 等待客户端的连接，并且创建与之通信用的Socket
        /// </summary>
        /// <param name="obj"></param>
        private void StartListen(object obj)
        {
            try
            {
                Socket socketWatch = obj as Socket;
                while (col)
                {
                    //等待客户端的连接，并且创建一个用于通信的Socket
                    socketSend = socketWatch.Accept();
                    //获取远程主机的ip地址和端口号
                    strIp = socketSend.RemoteEndPoint.ToString();
                    dicSocket.Add(strIp, socketSend);
                    this.cmb_Socket.Invoke(setCmbCallBack, strIp);
                    strMsg = DateTime.Now.ToString("G") + "远程主机：" + socketSend.RemoteEndPoint + "连接成功";
                    //使用回调
                    Log_box.Invoke(setCallBack, strMsg);
                    if (cmb_Socket.Items.Count != -1)
                    {
                        cmb_Socket.SelectedIndex = cmb_Socket.Items.Count - 1;
                    }

                    //定义接收客户端消息的线程
                    Thread threadReceive = new Thread(new ParameterizedThreadStart(Receive));
                    threadReceive.IsBackground = true;
                    threadReceive.Start(socketSend);
                    //Debug.WriteLine(1);
                }
            }
            catch { }
        }

        /// <summary>
        /// 服务器端不停的接收客户端发送的消息
        /// </summary>
        /// <param name="obj"></param>
        private void Receive(object obj)
        {
            try
            {
                Socket socketSend = obj as Socket;
                //客户端连接成功后，服务器接收客户端发送的消息
                byte[] buffer = new byte[2048];
                int count;
                string str;
                string strReceiveMsg;
                while (col)
                {
                    //实际接收到的有效字节数
                    count = socketSend.Receive(buffer);
                    if (count == 0)//count 表示客户端关闭，要退出循环
                    {
                        break;
                    }
                    else
                    {
                        str = Encoding.Default.GetString(buffer, 0, count);
                        strReceiveMsg = DateTime.Now.ToString("G") + "接收：" + socketSend.RemoteEndPoint + "发送的消息:" + str;
                        Log_box.Invoke(receiveCallBack, strReceiveMsg);
                        if (!LoginStatus)
                        {
                            if (str == "1")
                            {
                                Auto();
                            }
                        }
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// 自动应答
        /// </summary>
        private void Auto()
        {
            try
            {
                if (!LoginStatus)
                {
                    strMsg = "100;200;300;400;500;";//alls();//参数集合
                }
                else
                {
                    Log_box.Invoke(receiveCallBack, DateTime.Now.ToString("G") + "\t" + "请先登录操作员");
                    return;
                }
                Log_box.Invoke(receiveCallBack, DateTime.Now.ToString("G") + "\t" + strMsg);
                Log_box.ScrollToCaret();
                byte[] buffer = Encoding.Default.GetBytes(strMsg);
                List<byte> list = new List<byte>();
                list.Add(0);
                list.AddRange(buffer);
                //将泛型集合转换为数组
                byte[] newBuffer = list.ToArray();
                //获得用户选择的IP地址
                ip = this.cmb_Socket.SelectedItem.ToString();
                dicSocket[ip].Send(newBuffer);
                //内存回收
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(DateTime.Now.ToString("G") + "给客户端发送消息出错:" + ex.Message);
            }

        }
        /// <summary>
        /// 程序关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveJsonConfig();
        }

        #region 分割线更改名称
        private void uiLine1_DoubleClick(object sender, EventArgs e)
        {
            uiLine1.Text = Interaction.InputBox("输入分割名称", "输入分割名称");
        }
        private void uiLine2_DoubleClick(object sender, EventArgs e)
        {
            uiLine2.Text = Interaction.InputBox("输入分割名称", "输入分割名称");
        }
        private void uiLine3_DoubleClick(object sender, EventArgs e)
        {
            uiLine3.Text = Interaction.InputBox("输入分割名称", "输入分割名称");
        }
        private void uiLine4_DoubleClick(object sender, EventArgs e)
        {
            uiLine4.Text = Interaction.InputBox("输入分割名称", "输入分割名称");
        }
        private void uiLine5_DoubleClick(object sender, EventArgs e)
        {
            uiLine5.Text = Interaction.InputBox("输入分割名称", "输入分割名称");
        }
        private void uiLine6_DoubleClick(object sender, EventArgs e)
        {
            uiLine6.Text = Interaction.InputBox("输入分割名称", "输入分割名称");
        }
        #endregion
    }
}