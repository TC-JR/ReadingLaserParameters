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

        //�����źŽ��յļ���
        public Dictionary<string, string> IO = new Dictionary<string, string>();
        public Dictionary<string, string> Path = new Dictionary<string, string>();

        //���������ļ����ض���
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
            //�����û��б�
            UserComboBox.Items.Add("����Ա");
            UserComboBox.Items.Add("����ʦ");
            UserComboBox.Items.Add("����Ա");
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
            //    //�ж������ź�
            //    if (number.ToString() == item.Key)
            //    {
            //        //���غ����ĵ����к���
            //        foreach (var item1 in Path)
            //        {
            //            if (number.ToString() == item1.Key)
            //            {
            //                Debug.WriteLine(item1.Value);
            //            }
            //        }
            //        //�������ź�
            //        Debug.WriteLine(item.Value);
            //    }
            //}


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
            // ���ListBox�Ƿ���ѡ����  
            if (uiListBox1.SelectedIndex != -1)
            {
                // �����ѡ�����򿪺����ļ�  
                //���ö˿ڽ���
                MessageBox.Show("���ں����ļ��༭��ɺ󣬹ر�BSL������ٵ��ȷ�����ؼ�����ƿ�");
                //�ж�BSL�����Ƿ���ڣ�������ڣ���������ʾ������ر�����ؿ��ƿ�
                while (true)
                {
                    //�жϽ��̹ر�
                    if (true)
                    {
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

        private void uiLine1_Click(object sender, EventArgs e)
        {
            uiLine1.Text = Interaction.InputBox("����ָ�����", "����ָ�����");
        }
    }
}