namespace ReadingLaserParameters
{
    partial class LoadFile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            uiLabel1 = new Sunny.UI.UILabel();
            FilePart_box = new Sunny.UI.UITextBox();
            AddFile_btn = new Sunny.UI.UIButton();
            StartIo_box = new Sunny.UI.UITextBox();
            EndIo_box = new Sunny.UI.UITextBox();
            Save_btn = new Sunny.UI.UIButton();
            uiLabel2 = new Sunny.UI.UILabel();
            uiLabel3 = new Sunny.UI.UILabel();
            SuspendLayout();
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(12, 19);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(100, 23);
            uiLabel1.TabIndex = 0;
            uiLabel1.Text = "文件路径";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FilePart_box
            // 
            FilePart_box.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FilePart_box.Location = new Point(130, 16);
            FilePart_box.Margin = new Padding(4, 5, 4, 5);
            FilePart_box.MinimumSize = new Size(1, 16);
            FilePart_box.Name = "FilePart_box";
            FilePart_box.Padding = new Padding(5);
            FilePart_box.ReadOnly = true;
            FilePart_box.ShowText = false;
            FilePart_box.Size = new Size(367, 29);
            FilePart_box.TabIndex = 1;
            FilePart_box.TagString = "";
            FilePart_box.TextAlignment = ContentAlignment.MiddleLeft;
            FilePart_box.Watermark = "";
            // 
            // AddFile_btn
            // 
            AddFile_btn.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddFile_btn.Location = new Point(515, 13);
            AddFile_btn.MinimumSize = new Size(1, 1);
            AddFile_btn.Name = "AddFile_btn";
            AddFile_btn.Size = new Size(100, 35);
            AddFile_btn.TabIndex = 2;
            AddFile_btn.Text = "添加文件";
            AddFile_btn.Click += AddFile_btn_Click;
            // 
            // StartIo_box
            // 
            StartIo_box.DoubleValue = -1D;
            StartIo_box.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            StartIo_box.IntValue = -1;
            StartIo_box.Location = new Point(130, 67);
            StartIo_box.Margin = new Padding(4, 5, 4, 5);
            StartIo_box.MinimumSize = new Size(1, 16);
            StartIo_box.Name = "StartIo_box";
            StartIo_box.Padding = new Padding(5);
            StartIo_box.ShowText = false;
            StartIo_box.Size = new Size(150, 29);
            StartIo_box.TabIndex = 3;
            StartIo_box.Text = "-1";
            StartIo_box.TextAlignment = ContentAlignment.MiddleLeft;
            StartIo_box.Watermark = "";
            // 
            // EndIo_box
            // 
            EndIo_box.DoubleValue = -1D;
            EndIo_box.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            EndIo_box.IntValue = -1;
            EndIo_box.Location = new Point(130, 118);
            EndIo_box.Margin = new Padding(4, 5, 4, 5);
            EndIo_box.MinimumSize = new Size(1, 16);
            EndIo_box.Name = "EndIo_box";
            EndIo_box.Padding = new Padding(5);
            EndIo_box.ShowText = false;
            EndIo_box.Size = new Size(150, 29);
            EndIo_box.TabIndex = 4;
            EndIo_box.Text = "-1";
            EndIo_box.TextAlignment = ContentAlignment.MiddleLeft;
            EndIo_box.Watermark = "";
            // 
            // Save_btn
            // 
            Save_btn.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Save_btn.Location = new Point(515, 116);
            Save_btn.MinimumSize = new Size(1, 1);
            Save_btn.Name = "Save_btn";
            Save_btn.Size = new Size(100, 35);
            Save_btn.TabIndex = 5;
            Save_btn.Text = "保存";
            Save_btn.Click += Save_btn_Click;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(12, 70);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(100, 23);
            uiLabel2.TabIndex = 0;
            uiLabel2.Text = "启动端口";
            uiLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new Point(12, 121);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(100, 23);
            uiLabel3.TabIndex = 0;
            uiLabel3.Text = "完成端口";
            uiLabel3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LoadFile
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 175);
            Controls.Add(Save_btn);
            Controls.Add(EndIo_box);
            Controls.Add(StartIo_box);
            Controls.Add(AddFile_btn);
            Controls.Add(FilePart_box);
            Controls.Add(uiLabel3);
            Controls.Add(uiLabel2);
            Controls.Add(uiLabel1);
            Name = "LoadFile";
            StartPosition = FormStartPosition.CenterParent;
            Text = "LoadFile";
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox FilePart_box;
        private Sunny.UI.UIButton AddFile_btn;
        private Sunny.UI.UITextBox StartIo_box;
        private Sunny.UI.UITextBox EndIo_box;
        private Sunny.UI.UIButton Save_btn;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
    }
}