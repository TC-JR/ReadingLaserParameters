using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDKDemoCS;


namespace ReadingLaserParameters
{
    public partial class SplashScreenBackground : Form
    {
        public SplashScreenBackground()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void SplashScreenBackground_Load(object sender, EventArgs e)
        {
            uiLabel1.BackColor = Color.Transparent;
            uiLabel1.Parent = pictureBox1;
            uiLabel1.Location = new Point(650, 400);
            Thread start = new Thread(LoadingBsl);
            start.Start();
        }


        public void LoadingBsl()
        {
            //初始化控制卡
            var ret = BslSDK.InitDevices();
            if (ret != BslErrCode.SUCCESS)
            {
                MessageBox.Show($"初始化失败，错误码：{ret}({(int)ret})", "提示");

                this.Close();
            }
            uiLabel1.Text = "设备初始化成功";
            Thread.Sleep(300);
            //获取所有设备
            if (BslErrCode.SUCCESS == BslSDK.GetAllDevices(Form1.vDevIP, ref Form1.iDevCount))
            {
                if (Form1.iDevCount == 0)
                {
                    MessageBox.Show("查找设备失败，未连接到板卡", "提示");
                    this.Close();
                }
                else
                {
                    uiLabel1.Text = "设备查找成功";
                    Thread.Sleep(300);

                    //把设备IP转换成字符串
                    string strIP = Encoding.Default.GetString(Form1.vDevIP[0].wszDevName).TrimEnd('\0');
                    //获取控制卡状态
                    BslSDK.GetDevOffilineState(strIP, out Form1.ControlState);
                    if (Form1.ControlState)
                    {
                        MessageBox.Show("控制卡为离线状态，请切换成在线", "提示");
                        this.Close();
                    }
                    uiLabel1.Text = "设备状态验证成功";
                    Thread.Sleep(300);
                    this.Close();
                }
            }

        }


    }
}
