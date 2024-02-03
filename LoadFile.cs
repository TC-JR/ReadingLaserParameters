using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadingLaserParameters
{
    public partial class LoadFile : Form
    {
        public LoadFile()
        {
            InitializeComponent();
        }

        private void AddFile_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); ;
            //openFileDialog.Filter = "焊接文件|*.orzx|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            //判断是否点击了窗口确定键
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilePart_box.Text = openFileDialog.FileName;
            }
        }


        private void Save_btn_Click(object sender, EventArgs e)
        {
            if (FilePart_box.Text != "")
            {
                Form1.fileObj.FilePath = FilePart_box.Text;
                Form1.fileObj.StartIo = StartIo_box.Text;
                Form1.fileObj.EndIo = EndIo_box.Text;
            }
            this.Close();
        }

    }
}
