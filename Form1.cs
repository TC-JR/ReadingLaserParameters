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

        #region ȫ�ֱ���
        //�ϴμ����ļ��б������
        public static int FileListBoxCount;
        //���ƿ�����״̬
        public static bool LaserLoadState = false;
        //�����豸ID
        public static STU_DEVIP[] vDevIP = new STU_DEVIP[8];
        //�����豸����
        public static int iDevCount;
        //���ƿ�״̬�����ߡ�����
        public static bool ControlState;
        //������֤״̬
        public static bool PasswordOk = false;
        //��¼״̬
        public static bool LoginStatus = false;
        //�����źŽ��յļ���
        public Dictionary<string, string> IO = new Dictionary<string, string>();//����io��ֹͣio
        public Dictionary<string, string> Path = new Dictionary<string, string>();//����io���ļ�·��
        //ֹͣ���������źŵı�־λ
        public static bool StopMonitor = false;
        #endregion
        //�����ļ����ض�����
        public class FileObj
        {
            public string FilePath { get; set; }
            public string StartIo { get; set; }
            public string EndIo { get; set; }
        }
        //�ļ������ʼ��
        public static FileObj fileObj = new FileObj();


        /// <summary>
        /// ����������
        /// </summary>
        public void LoadJsonConfig()
        {
            //��IP��ַ
            TextIp_box.Text = JsonConfigHelper.ReadConfig("ip");
            //���˿ں�
            TextPort_box.Text = JsonConfigHelper.ReadConfig("port");
            //���ָ�������
            uiLine1.Text = JsonConfigHelper.ReadConfig("l1");
            uiLine2.Text = JsonConfigHelper.ReadConfig("l2");
            uiLine3.Text = JsonConfigHelper.ReadConfig("l3");
            uiLine4.Text = JsonConfigHelper.ReadConfig("l4");
            uiLine5.Text = JsonConfigHelper.ReadConfig("l5");
            uiLine6.Text = JsonConfigHelper.ReadConfig("l6");
            //����ѡ��״̬
            Pen1.Checked = Convert.ToBoolean(JsonConfigHelper.ReadConfig("pen1")) ? true : false;
            Pen2.Checked = Convert.ToBoolean(JsonConfigHelper.ReadConfig("pen2")) ? true : false;
            Pen3.Checked = Convert.ToBoolean(JsonConfigHelper.ReadConfig("pen3")) ? true : false;
            Pen4.Checked = Convert.ToBoolean(JsonConfigHelper.ReadConfig("pen4")) ? true : false;
            Pen5.Checked = Convert.ToBoolean(JsonConfigHelper.ReadConfig("pen5")) ? true : false;
            Pen6.Checked = Convert.ToBoolean(JsonConfigHelper.ReadConfig("pen6")) ? true : false;
            Pen7.Checked = Convert.ToBoolean(JsonConfigHelper.ReadConfig("pen7")) ? true : false;
            Pen8.Checked = Convert.ToBoolean(JsonConfigHelper.ReadConfig("pen8")) ? true : false;
            //���ļ��б�����
            FileListBoxCount = Convert.ToInt32(JsonConfigHelper.ReadConfig("filecount"));
            //���ļ��б���IO�ź�
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
            //���ĵ���ȡ�ʺ�

        }

        /// <summary>
        /// �������ļ�
        /// </summary>
        public void SaveJsonConfig()
        {
            //��IP��ַ
            JsonConfigHelper.WriteConfig("ip", TextIp_box.Text);
            //��˿ں�
            JsonConfigHelper.WriteConfig("port", TextPort_box.Text);
            //��ָ�������
            JsonConfigHelper.WriteConfig("l1", uiLine1.Text);
            JsonConfigHelper.WriteConfig("l2", uiLine2.Text);
            JsonConfigHelper.WriteConfig("l3", uiLine3.Text);
            JsonConfigHelper.WriteConfig("l4", uiLine4.Text);
            JsonConfigHelper.WriteConfig("l5", uiLine5.Text);
            JsonConfigHelper.WriteConfig("l6", uiLine6.Text);
            //�渴ѡ��״̬
            JsonConfigHelper.WriteConfig("pen1", Pen1.Checked ? "true" : "false");
            JsonConfigHelper.WriteConfig("pen2", Pen2.Checked ? "true" : "false");
            JsonConfigHelper.WriteConfig("pen3", Pen3.Checked ? "true" : "false");
            JsonConfigHelper.WriteConfig("pen4", Pen4.Checked ? "true" : "false");
            JsonConfigHelper.WriteConfig("pen5", Pen5.Checked ? "true" : "false");
            JsonConfigHelper.WriteConfig("pen6", Pen6.Checked ? "true" : "false");
            JsonConfigHelper.WriteConfig("pen7", Pen7.Checked ? "true" : "false");
            JsonConfigHelper.WriteConfig("pen8", Pen8.Checked ? "true" : "false");
            //���б�����
            JsonConfigHelper.WriteConfig("filecount", uiListBox1.Count.ToString());
            //���趨IO
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
            //���ļ��б�
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


        #region ������
        //������
        private void uiButton1_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine(a[0]);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "D://";
            //openFileDialog.Filter = "������ļ�|*.ezd|�ı��ļ�|*.txt|�����ļ�|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Log("�����ص��ĵ�");
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
            LogOut("�������������");
            //Debug.WriteLine(uiListBox1.Count);
            //Random random = new Random();
            //var number = random.Next(0, 2);
            //Debug.WriteLine(number);



        }

        //������
        private void uiButton2_Click(object sender, EventArgs e)
        {
            PENPAR pen = new PENPAR();
            BslSDK.GetPenPar(ref pen, uiTextBox1.Text, Convert.ToUInt32(uiTextBox2.Text));
            Debug.WriteLine(pen.dMarkSpeed);
            uiTextBox2.Text = pen.dMarkSpeed.ToString();
        }
        #endregion

        /// <summary>
        /// �������
        /// </summary>
        static Mutex mutex = new Mutex(true, "{YourAppGuid}"); // {YourAppGuid}ΪӦ�ó����ȫ��Ψһ��ʶ��
        [STAThread]
        private void Form1_Load(object sender, EventArgs e)
        {
            //�жϳ����Ƿ�ע��
            //��ע�����ֵ
            var a = ReadRegistryValue("Software\\TianCiCompany\\DataUpLoad\\RegistrationInformation");
            // ���ע���ֵ�Ƿ����  
            if (a != "True")
            {
                // ע���ֵ�����ڻ��Ҳ���ע������������ʾ���˳�����  
                MessageBox.Show("���δע�ᣬ�����˳���", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            //��ֹ�����ظ�����
            //�жϻ�������Ƿ����
            if (!mutex.WaitOne(TimeSpan.Zero)) //��ֹ�����ظ�����
            {
                MessageBox.Show("�ó����Ѿ��������ˣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }

            //��������ҳ��
            SplashScreenBackground SSB = new SplashScreenBackground();
            //SSB.ShowDialog();
            //SSB.Dispose();
            if (ControlState)
            {
                this.Close();
            }
            //��ʼ�����ƿ�
            //STU_DEVIP[] a = new STU_DEVIP[0];
            //var numbrs = 0;
            //BslSDK.InitDevices();
            //BslSDK.GetAllDevices(a, ref numbrs);

            //�����û��б�
            UserComboBox.Items.Add("����Ա");
            UserComboBox.Items.Add("����ʦ");
            UserComboBox.Items.Add("����Ա");
            UserComboBox.SelectedIndex = 0;
            //���������ļ�
            LoadJsonConfig();
        }

        /// <summary>
        /// ��ע���
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
            //�������ڽ��������˿ڵı���
            int a = 0;

            while (true)
            {
                //50ms���һ��
                Thread.Sleep(50);
                //�����ƿ���ǰIO�ź�
                //BslSDK.ReadInPort(id,a)
                //�ж�ֹͣ������ť����
                if (StopMonitor)
                {
                    //�ָ���־λ
                    StopMonitor = false;
                    //ֹͣ����
                    //BslSDK.StopMark(id);
                    break;
                }
                //�������ϣ��жϵ�ǰ�����ź��Ƿ񴥷�
                foreach (var item in IO)
                {
                    //�ж������ź�
                    if (a.ToString() == item.Key)
                    {
                        //���غ����ĵ����к���
                        foreach (var item1 in Path)
                        {
                            if (a.ToString() == item1.Key)
                            {
                                //���غ����ĵ�
                                //BslSDK.LoadDataFile(item1.Value);
                                //����
                                //BslSDK.MarkByDeviceId(id);
                                Debug.WriteLine(item1.Value);//�����ĵ�·��
                            }
                        }
                        //�������ź�
                        //BslSDK.WriteOutPort(id, item.Value,1,1,500);
                        Debug.WriteLine(item.Value);

                    }
                }

            }
            Log_box.AppendText("�Ѿ�ֹͣ����");
        }


        /// <summary>
        /// listbox����ص��ļ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ����ļ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile loadFile = new LoadFile();
            loadFile.ShowDialog();
            try
            {
                // ���Ҫ��ӵ���Ŀ�Ƿ��Ѵ�����ListBox��  
                if (!uiListBox1.Items.Contains(fileObj.FilePath)) // textBox1������Ҫ�����Ŀ���ı���  
                {
                    //�Ѽ��غŵ�����IO�����IO��ӵ��ֵ�
                    foreach (var item in IO)
                    {
                        if (fileObj.StartIo == item.Key)
                        {
                            Log_box.AppendText("����������ͬ������IO" + "\r\n");
                            return;
                        }
                    }
                    IO.Add(fileObj.StartIo, fileObj.EndIo);

                    //��������IO��·���ֵ�
                    Path.Add(fileObj.StartIo, fileObj.FilePath);
                    // ��������ڣ��������Ŀ��ListBox��  
                    uiListBox1.Items.Add(fileObj.FilePath);

                }
                else
                {
                    // ������ڣ���ִ���κβ���  
                    Log_box.AppendText("���������ͬ���ļ�" + "\r\n");
                }

            }
            catch (Exception ex)
            {
                Log_box.AppendText(ex.ToString() + "\r\n");
            }

            #region ����
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); ;
            ////openFileDialog.Filter = "�����ļ�|*.orzx|�����ļ�|*.*";
            //openFileDialog.RestoreDirectory = true;
            //openFileDialog.FilterIndex = 1;
            ////�ж��Ƿ����˴���ȷ����
            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    // ���Ҫ��ӵ���Ŀ�Ƿ��Ѵ�����ListBox��  
            //    if (!uiListBox1.Items.Contains(openFileDialog.FileName)) // textBox1������Ҫ�����Ŀ���ı���  
            //    {
            //        // ��������ڣ��������Ŀ��ListBox��  
            //        uiListBox1.Items.Add(openFileDialog.FileName);
            //        //textBox1.Clear(); // ����ı����Ա���һ������  
            //    }
            //    else
            //    {
            //        // ������ڣ���ִ���κβ���  
            //        Log_box.AppendText("���������ͬ���ļ�" + "\r\n");
            //    }

            //    //Log("�����ص��ĵ�");
            //    //uiListBox1.Items.Add(openFileDialog.FileName);
            //    //BslSDK.LoadDataFile(uiTextBox1.Text);
            //}
            #endregion
        }

        /// <summary>
        /// ɾ��listboxѡ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ɾ���ļ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ���ListBox�Ƿ���ѡ����  
            if (uiListBox1.SelectedIndex != -1)
            {
                //���Ƴ��ֵ��е�����
                foreach (var item in Path)
                {
                    if (uiListBox1.SelectedItem.ToString() == item.Value)
                    {
                        Path.Remove(item.Key);
                    }
                }

                // �����ѡ������Ƴ�����  
                uiListBox1.Items.RemoveAt(uiListBox1.SelectedIndex);

                //�����ֵ����Ƿ���ֵ
                foreach (var item in Path)
                {
                    Debug.WriteLine(item.Key + "   " + item.Value);
                }
            }
            else
            {
                // ���û��ѡ�����ִ���κβ���  
                Log_box.AppendText("��ѡ��Ҫɾ������Ŀ�ٽ��в���" + "\r\n");
            }
        }

        private void ���ö˿�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ���ListBox�Ƿ���ѡ����  
            if (uiListBox1.SelectedIndex != -1)
            {
                // �����ѡ��������ö˿�  
                //���ö˿ڽ���
            }
            else
            {
                // ���û��ѡ�����ִ���κβ���  
                Log_box.AppendText("��ѡ��Ҫ���õ���Ŀ�ٽ��в���" + "\r\n");
            }

        }

        /// <summary>
        /// �༭ѡ�еĺ����ļ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void �༭�����ļ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PENPAR pen = new PENPAR();

            // ���ListBox�Ƿ���ѡ����  
            if (uiListBox1.SelectedIndex != -1)
            {
                // �����ѡ�����򿪺����ļ�  
                //ʹ��ָ������򿪵�ǰ�����ĵ�


                //������ʾ
                MessageBox.Show("���ں����ļ��༭��ɺ󣬹ر�BSL������ٵ��ȷ�����ؼ�����ƿ�");
                //�ж�BSL�����Ƿ���ڣ�������ڣ���������ʾ������ر�����ؿ��ƿ�
                while (true)
                {
                    //�жϽ��̹ر�
                    if (true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            BslSDK.GetPenPar(ref pen, uiListBox1.SelectedItem.ToString(), Convert.ToUInt32(i));
                            Debug.WriteLine(pen.dMarkSpeed);
                            Debug.WriteLine(pen.dPowerRatio);
                        }
                        //��ȡ���Ӳ���

                        break;
                    }
                    else
                    {
                        MessageBox.Show("��⵽BSL�������û�йرգ����ȹرգ��ٵ��ȷ�����ؼ�����ƿ�");

                    }

                }
            }
            else
            {
                // ���û��ѡ�����ִ���κβ���  
                Log_box.AppendText("��ѡ��Ҫ���õ���Ŀ�ٽ��в���" + "\r\n");
            }

        }

        /// <summary>
        /// �����̣߳����������ź�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartIo_btn_Click(object sender, EventArgs e)
        {
            Thread Monitor = new Thread(WeldingProcess);
            Monitor.Start();
        }

        /// <summary>
        /// ֹͣ������־λ����������ѭ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopIo_btn_Click(object sender, EventArgs e)
        {
            StopMonitor = true;
        }

        //����״̬
        public static bool listenIn = false;
        //�ر�
        public bool col = true;
        //����ͨ�ŵ�Socket
        Socket socketSend;
        //���ڼ�����SOCKET
        Socket socketWatch;
        //����ص�:������̷߳�������
        private delegate void SetTextValueCallBack(string strValue);
        //������տͻ��˷�����Ϣ�Ļص�
        private delegate void ReceiveMsgCallBack(string strReceive);
        //�����ص�
        private SetTextValueCallBack setCallBack;
        //����
        private ReceiveMsgCallBack receiveCallBack;
        //����
        private SetCmbCallBack setCmbCallBack;
        //���巢���ļ��Ļص�
        private delegate void SendFileCallBack(byte[] bf);
        //����ص�����ComboBox�ؼ����Ԫ��
        private delegate void SetCmbCallBack(string strItem);
        //�����������ӵ��߳�
        Thread AcceptSocketThread;
        //���տͻ��˷�����Ϣ���߳�
        Thread threadReceive;
        //��Զ�����ӵĿͻ��˵�IP��ַ��Socket���뼯����
        Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();

        /// <summary>
        /// �ص�ί����Ҫִ�еķ���
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
            //����״̬����
            listenIn = true;
            //���ùر�
            col = true;
            //�������ʼ������ʱ�� �ڷ������˴���һ���������IP��ַ�Ͷ˿ںŵ�Socket
            socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //��ȡip��ַ
            IPAddress ip = IPAddress.Parse(this.TextIp_box.Text.Trim());
            //�����˿ں�
            IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(this.TextPort_box.Text.Trim()));
            try
            {
                //��IP��ַ�Ͷ˿ں�
                socketWatch.Bind(point);
                this.Log_box.AppendText(DateTime.Now.ToString("G") + "�����ɹ�" + " \r");
                //��ʼ����:����������ͬʱ���Ӷ��ٸ�����
                socketWatch.Listen(10);
                //ʵ�����ص�
                setCallBack = new SetTextValueCallBack(SetTextValue);
                receiveCallBack = new ReceiveMsgCallBack(ReceiveMsg);
                setCmbCallBack = new SetCmbCallBack(AddCmbItem);
                //sendCallBack = new SendFileCallBack(SendFile);

                //�����߳�
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
        /// Զ��IP
        /// </summary>
        public string strIp;
        /// <summary>
        /// ��Ϣ����
        /// </summary>
        public static string strMsg;

        /// <summary>
        /// �ȴ��ͻ��˵����ӣ����Ҵ�����֮ͨ���õ�Socket
        /// </summary>
        /// <param name="obj"></param>
        private void StartListen(object obj)
        {
            try
            {
                Socket socketWatch = obj as Socket;
                while (col)
                {
                    //�ȴ��ͻ��˵����ӣ����Ҵ���һ������ͨ�ŵ�Socket
                    socketSend = socketWatch.Accept();
                    //��ȡԶ��������ip��ַ�Ͷ˿ں�
                    strIp = socketSend.RemoteEndPoint.ToString();
                    dicSocket.Add(strIp, socketSend);
                    this.cmb_Socket.Invoke(setCmbCallBack, strIp);
                    strMsg = DateTime.Now.ToString("G") + "Զ��������" + socketSend.RemoteEndPoint + "���ӳɹ�";
                    //ʹ�ûص�
                    Log_box.Invoke(setCallBack, strMsg);
                    if (cmb_Socket.Items.Count != -1)
                    {
                        cmb_Socket.SelectedIndex = cmb_Socket.Items.Count - 1;
                    }

                    //������տͻ�����Ϣ���߳�
                    Thread threadReceive = new Thread(new ParameterizedThreadStart(Receive));
                    threadReceive.IsBackground = true;
                    threadReceive.Start(socketSend);
                    //Debug.WriteLine(1);
                }
            }
            catch { }
        }

        /// <summary>
        /// �������˲�ͣ�Ľ��տͻ��˷��͵���Ϣ
        /// </summary>
        /// <param name="obj"></param>
        private void Receive(object obj)
        {
            try
            {
                Socket socketSend = obj as Socket;
                //�ͻ������ӳɹ��󣬷��������տͻ��˷��͵���Ϣ
                byte[] buffer = new byte[2048];
                int count;
                string str;
                string strReceiveMsg;
                while (col)
                {
                    //ʵ�ʽ��յ�����Ч�ֽ���
                    count = socketSend.Receive(buffer);
                    if (count == 0)//count ��ʾ�ͻ��˹رգ�Ҫ�˳�ѭ��
                    {
                        break;
                    }
                    else
                    {
                        str = Encoding.Default.GetString(buffer, 0, count);
                        strReceiveMsg = DateTime.Now.ToString("G") + "���գ�" + socketSend.RemoteEndPoint + "���͵���Ϣ:" + str;
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
        /// �Զ�Ӧ��
        /// </summary>
        private void Auto()
        {
            try
            {
                if (!LoginStatus)
                {
                    strMsg = "100;200;300;400;500;";//alls();//��������
                }
                else
                {
                    Log_box.Invoke(receiveCallBack, DateTime.Now.ToString("G") + "\t" + "���ȵ�¼����Ա");
                    return;
                }
                Log_box.Invoke(receiveCallBack, DateTime.Now.ToString("G") + "\t" + strMsg);
                Log_box.ScrollToCaret();
                byte[] buffer = Encoding.Default.GetBytes(strMsg);
                List<byte> list = new List<byte>();
                list.Add(0);
                list.AddRange(buffer);
                //�����ͼ���ת��Ϊ����
                byte[] newBuffer = list.ToArray();
                //����û�ѡ���IP��ַ
                ip = this.cmb_Socket.SelectedItem.ToString();
                dicSocket[ip].Send(newBuffer);
                //�ڴ����
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(DateTime.Now.ToString("G") + "���ͻ��˷�����Ϣ����:" + ex.Message);
            }

        }
        /// <summary>
        /// ����ر��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveJsonConfig();
        }

        #region �ָ��߸�������
        private void uiLine1_DoubleClick(object sender, EventArgs e)
        {
            uiLine1.Text = Interaction.InputBox("����ָ�����", "����ָ�����");
        }
        private void uiLine2_DoubleClick(object sender, EventArgs e)
        {
            uiLine2.Text = Interaction.InputBox("����ָ�����", "����ָ�����");
        }
        private void uiLine3_DoubleClick(object sender, EventArgs e)
        {
            uiLine3.Text = Interaction.InputBox("����ָ�����", "����ָ�����");
        }
        private void uiLine4_DoubleClick(object sender, EventArgs e)
        {
            uiLine4.Text = Interaction.InputBox("����ָ�����", "����ָ�����");
        }
        private void uiLine5_DoubleClick(object sender, EventArgs e)
        {
            uiLine5.Text = Interaction.InputBox("����ָ�����", "����ָ�����");
        }
        private void uiLine6_DoubleClick(object sender, EventArgs e)
        {
            uiLine6.Text = Interaction.InputBox("����ָ�����", "����ָ�����");
        }
        #endregion
    }
}