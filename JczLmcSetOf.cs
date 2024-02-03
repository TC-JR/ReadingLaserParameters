using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Runtime.InteropServices;
using System.Configuration;

namespace BJJCZ_BaseDevelop
{

    public class JczLmc
    {
        /// <summary>
        /// �жϺ�������ֵ������˵��
        /// </summary>
        /// <param name="nErr">����ֵ</param>
        /// <returns>����ֵ˵��</returns>
        public static string GetErrorText(int nErr)
        {
            switch (nErr)
            {
                case 0: return "�ɹ�";
                case 1: return "����EZCAD�Ѿ�������";
                case 2: return "�Ҳ���EZCAD.CFG";
                case 3: return "��LMCʧ��";
                case 4: return "û��LMC�豸";
                case 5: return "lmc�豸�汾����";
                case 6: return "�Ҳ����豸�����ļ�MarkCfg";
                case 7: return "�б����ź�";
                case 8: return "�û��ж�";
                case 9: return "��������";
                case 10: return "��ʱ";
                case 11: return "δ��ʼ��";
                case 12: return "���ļ�ʧ��";
                case 13: return "����Ϊ��";
                case 14: return "�Ҳ�������";
                case 15: return "�ʺŴ���";
                case 16: return "ָ���������ı�����";
                case 17: return "�����ļ�ʧ��";
                case 18: return "�����ļ�ʧ���Ҳ���ָ������";
                case 19: return "��ǰ״̬����ִ�д˲���";
                case 20: return "�����������";
                case 21: return "�����Ӳ������";
                default:
                    break;
            }
            return "�����������";
        }
        /// <summary>
        /// �жϺ�������ֵ������˵��
        /// </summary>
        /// <param name="nErr">����ֵ</param>
        /// <param name="English">�Ƿ�Ӣ��</param>
        /// <returns>����ֵ˵��</returns>
        public static string GetErrorText(int nErr, bool English)
        {
            if (English)
            {
                switch (nErr)
                {
                    case 0: return "Success";
                    case 1: return " Now have a working EACAD";
                    case 2: return "No found EZCAD.CFG";
                    case 3: return "Open LMC faild";
                    case 4: return "No LMC Board";
                    case 5: return "Lmc vision Error";
                    case 6: return " No found MarkCfg in Plug ";
                    case 7: return "Error Signal";
                    case 8: return "User Stop";
                    case 9: return "unknown error";
                    case 10: return "out time";
                    case 11: return "No Initialization";
                    case 12: return "Read File Error";
                    case 13: return "full Windows";
                    case 14: return "No found font";
                    case 15: return "Pen error";
                    case 16: return "object is not text";
                    case 17: return "save file fail";
                    case 18: return "save file fail becouse same object is no found";
                    case 19: return "Now state can not work as command";
                    case 20: return "error Parameter";
                    case 21: return "error hardware parameters";
                    default:
                        break;
                }
                return "error Parameter";
            }
            else
            {
                switch (nErr)
                {
                    case 0: return "�ɹ�";
                    case 1: return "����EZCAD�Ѿ�������";
                    case 2: return "�Ҳ���EZCAD.CFG";
                    case 3: return "��LMCʧ��";
                    case 4: return "û��LMC�豸";
                    case 5: return "lmc�豸�汾����";
                    case 6: return "�Ҳ����豸�����ļ�MarkCfg";
                    case 7: return "�б����ź�";
                    case 8: return "�û��ж�";
                    case 9: return "��������";
                    case 10: return "��ʱ";
                    case 11: return "δ��ʼ��";
                    case 12: return "���ļ�ʧ��";
                    case 13: return "����Ϊ��";
                    case 14: return "�Ҳ�������";
                    case 15: return "�ʺŴ���";
                    case 16: return "ָ���������ı�����";
                    case 17: return "�����ļ�ʧ��";
                    case 18: return "�����ļ�ʧ���Ҳ���ָ������";
                    case 19: return "��ǰ״̬����ִ�д˲���";
                    case 20: return "�����������";
                    case 21: return "�����Ӳ������";
                    default:
                        break;
                }
                return "�����������";
            }
        }

        #region �豸

        /// <summary>
        /// ��ʼ��������
        /// </summary>
        /// <param name="PathName">Ezcad2.exe������Ŀ¼��ȫ·��</param>
        /// <param name="bTestMode">ָ�Ƿ��ǲ���ģʽ,����ģʽ���ƿ���غ����޷�����</param>
        /// <param name="MailForm">ָӵ���û����뽹��Ĵ��ڣ����ڼ���û���ͣ��Ϣ</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_Initial", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int InitializeTotal(string PathName, bool bTestMode, IntPtr MailForm);

        /// <summary>
        /// ��ʼ��������
        /// </summary>
        /// <param name="PathName">Ezcad2.exe������Ŀ¼��ȫ·��</param>
        /// <param name="bTestMode">ָ�Ƿ��ǲ���ģʽ,����ģʽ���ƿ���غ����޷�����</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_Initial2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Initialize(string PathName, bool bTestMode);

        /// <summary>
        /// �ͷź�����
        /// </summary>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_Close", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Close();

        /// <summary>
        /// �õ��豸�������öԻ���  
        /// </summary> 
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_SetDevCfg", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetDevCfg();

        /// <summary>
        /// ���Բ
        /// </summary>
        /// <param name="cenX">Բ��X����</param>
        /// <param name="cenY">Բ��Y����</param>
        /// <param name="radius">Բ�뾶</param>
        /// <param name="EntName">��������</param>
        /// <param name="nPen">ʹ�ñʺ�</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_AddCircleToLib", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int AddCircleToLib(double cenX, double cenY, double radius, string EntName, int nPen);

        /// <summary>
        /// �õ��豸�������öԻ���+��չ��
        /// </summary>
        /// <param name="bAxisShow0">��չ��0�Ľ����Ƿ���ʾ</param>
        /// <param name="bAxisShow1">��չ��1�Ľ����Ƿ���ʾ</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_SetDevCfg2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetDevCfg2(bool bAxisShow0, bool bAxisShow1);

        /// <summary>
        /// �������ݿ�����ж������ת����,��Ӱ�����ݵ���ʾ,ֻ�Ǽӹ�ʱ�ŶԶ��������ת
        /// </summary>
        /// <param name="dMoveX">x�����ƶ�����</param>
        /// <param name="dMoveY">y�����ƶ�����</param>
        /// <param name="dCenterX">��ת���ĵ�x����</param>
        /// <param name="dCenterY">��ת���ĵ�y����</param>
        /// <param name="dRotateAng">Ϊ��ת�Ƕ�,��λΪ����ֵ</param>
        /// <returns></returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_SetRotateMoveParam", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetRotateMoveParam(double dMoveX, double dMoveY, double dCenterX, double dCenterY, double dRotateAng);

        #endregion

        #region �ӹ�

        /// <summary>
        /// ��̵�ǰ���ݿ�������������һ��
        /// </summary>
        /// <param name="Fly">��ʾ���зɶ����</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_Mark", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mark(bool Fly);

        /// <summary>
        /// ���ָ������һ��
        /// </summary>
        /// <param name="EntName">ָ�����������</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_MarkEntity", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MarkEntity(string EntName);

        [DllImport("MES", EntryPoint = "MES_Login", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MES_Login(char[] EntName);

        [DllImport("MES", EntryPoint = "MES_Init", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MES_Init(char[] EntName);

        [DllImport("MES", EntryPoint = "MES_LogReset", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MES_LogReset();

        [DllImport("MES", EntryPoint = " MES_Free", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MES_Free(char[] EntName);

        [DllImport("MES", EntryPoint = "MES_CheckSerialNum", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MES_CheckSerialNum(string ent, char[] name);

        /// <summary>
        /// ���б�̵�ǰ���ݿ������������
        /// </summary>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_MarkFlyByStartSignal", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MarkFlyByStartSignal();

        /// <summary>
        /// ���б��ָ������һ��
        /// </summary>
        /// <param name="EntName">ָ�����������</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_MarkEntityFly", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MarkEntityFly(string EntName);

        /// <summary>
        /// ���ָ���߶�
        /// </summary>
        /// <param name="X1">���X����</param>
        /// <param name="Y1">���Y����</param>
        /// <param name="X2">�յ�X����</param>
        /// <param name="Y2">�յ�Y����</param>
        /// <param name="Pen">ʹ�õıʺ�</param>
        /// <returns></returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_MarkLine", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MarkLine(double X1, double Y1, double X2, double Y2, int Pen);

        /// <summary>
        /// ��̵�
        /// </summary>
        /// <param name="X">X����</param>
        /// <param name="Y">Y����</param>
        /// <param name="Delay">���ʱ��</param>
        /// <param name="Pen">ʹ�õıʺ�</param>
        /// <returns></returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_MarkPoint", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MarkPoint(double X, double Y, double Delay, int Pen);

        /// <summary>
        /// �ӹ������
        /// </summary>
        /// <param name="nPointNum">�����</param>
        /// <param name="ptbuf">ptBuf[][2]Ϊÿ�������ת�ٶ���ʱʱ�䵥λΪus</param>
        /// <param name="dJumpSpeed">��ת�ٶ�</param>
        /// <param name="dLaserOnTimeMs">����ʱ�䵥λ������С0.01MS</param>
        /// <returns></returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_MarkPointBuf2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MarkPointBuf2(int nPointNum, [MarshalAs(UnmanagedType.LPArray)] double[,] ptbuf, double dJumpSpeed, double dLaserOnTimeMs);

        /// <summary>
        /// �жϿ����ڴ��ڹ���״̬
        /// </summary>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_IsMarking", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsMarking();

        /// <summary>
        /// ǿ��ֹͣ���
        /// </summary>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_StopMark", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int StopMark();

        /// <summary>
        /// ���Ԥ����ǰ���ݿ�������������һ��
        /// </summary> 
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_RedLightMark", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RedMark();

        /// <summary>
        /// ���Ԥ����ǰ���ݿ�����������������һ��
        /// </summary>   
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_RedLightMarkContour", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RedMarkContour();

        /// <summary>
        /// ���Ԥ����ǰ���ݿ�����ָ������
        /// </summary>   
        /// <param name="EntName">��������</param>
        /// <param name="bContour">��ʾ���Ƿ�������</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_RedLightMarkByEnt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RedLightMarkByEnt(string EntName, bool bContour);

        /// <summary>
        /// ��ȡ��ˮ���ٶ�
        /// </summary>
        /// <param name="FlySpeed">��ˮ�ߵ�ǰ�ٶ�</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetFlySpeed", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetFlySpeed(ref double FlySpeed);

        /// <summary>
        /// ������ֱ���˶���ָ������
        /// </summary>
        /// <param name="x">ָ��X����</param>
        /// <param name="y">ָ��Y����</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GotoPos", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GotoPos(double x, double y);

        /// <summary>
        /// ��ȡ��ǰ�񾵵���������
        /// </summary>
        /// <param name="x">��ȡX����</param>
        /// <param name="y">��ȡY����</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetCurCoor", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetCurCoor(ref double x, ref double y);

        #endregion

        #region �ļ�

        /// <summary>
        /// ����ezd�ļ�����ǰ���ݿ�����,������ɵ����ݿ�
        /// </summary>
        /// <param name="FileName">�ļ�ȫ·��������</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_LoadEzdFile", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int LoadEzdFile(string FileName);

        /// <summary>
        /// ���浱ǰ���ݵ�ָ���ļ�
        /// </summary>
        /// <param name="strFileName">�ļ�ȫ·��������</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_SaveEntLibToFile", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SaveEntLibToFile(string strFileName);

        /// <summary>
        /// ɾ��ָ�������ͷ���Դ
        /// </summary>
        /// <param name="hObject">ָ��ɾ���Ķ���</param>
        /// <returns>����ֵ</returns>
        [DllImport("gdi32.dll")]
        internal static extern bool DeleteObject(IntPtr hObject);

        /// <summary>
        /// �õ���ǰ���ݿ��������ݵ�Ԥ��ͼƬ
        /// </summary>
        /// <param name="bmpwidth">ͼƬ���</param>
        /// <param name="bmpheight">ͼƬ�߶�</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetPrevBitmap2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr GetCurPrevBitmap(int bmpwidth, int bmpheight);

        /// <summary>
        /// �õ���ǰ���ݿ��������ݵ�Ԥ��ͼƬ
        /// </summary>
        /// <param name="bmpwidth">ͼƬ���</param>
        /// <param name="bmpheight">ͼƬ�߶�</param>
        /// <returns>����ֵ</returns>
        public static Image GetCurPreviewImage(int bmpwidth, int bmpheight)
        {
            IntPtr pBmp = GetCurPrevBitmap(bmpwidth, bmpheight);
            Image img = Image.FromHbitmap(pBmp);
            DeleteObject(pBmp);
            return img;
        }

        /// <summary>
        /// �õ�ָ�������Ԥ��ͼƬ
        /// </summary>
        /// <param name="EntName">��������</param>
        /// <param name="bmpwidth">ͼƬ���</param>
        /// <param name="bmpheight">ͼƬ�߶�</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetPrevBitmapByName2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr GetPrevBitmapByName(string EntName, int bmpwidth, int bmpheight);

        /// <summary>
        /// �õ�ָ�������Ԥ��ͼƬ,������Դ�����ת��
        /// </summary>
        /// <param name="Entname">��������</param>
        /// <param name="bmpwidth">ͼƬ���</param>
        /// <param name="bmpheight">ͼƬ�߶�</param>
        /// <returns>����Image����</returns>
        public static Image GetCurPreviewImageByName(string Entname, int bmpwidth, int bmpheight)
        {
            IntPtr pBmp = GetPrevBitmapByName(Entname, bmpwidth, bmpheight);
            Image img = Image.FromHbitmap(pBmp);
            DeleteObject(pBmp);
            return img;
        }

        #endregion

        #region ����
        /// <summary>
        /// �õ�ָ������ĳߴ���Ϣ
        /// </summary>
        /// <param name="strEntName">��������</param>
        /// <param name="dMinx">��Сx����</param>
        /// <param name="dMiny">��Сy����</param>
        /// <param name="dMaxx">���x����</param>
        /// <param name="dMaxy">���y����</param>
        /// <param name="dz">z����</param>
        /// <returns></returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetEntSize", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetEntSize(string strEntName, ref double dMinx, ref double dMiny, ref double dMaxx, ref double dMaxy, ref double dz);

        /// <summary>
        /// �ƶ����ݿ���ָ�����ƵĶ���
        /// </summary>
        /// <param name="strEntName">��������</param>
        /// <param name="dMovex">x�����ƶ�����</param>
        /// <param name="dMovey">y�����ƶ�����</param>
        /// <returns></returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_MoveEnt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MoveEnt(string strEntName, double dMovex, double dMovey);

        /// <summary>
        /// �����ݿ���ָ�����ƵĶ�����б����任,�任ǰ���й��ɶ���ĵ㵽�任���ľ��밴�任�����任����ӦΪ�任���ͼ������
        /// </summary>
        /// <param name="strEntName">��������</param>
        /// <param name="dCenx">�任���ĵ�X����</param>
        /// <param name="dCeny">�任���ĵ�Y����</param>
        /// <param name="dScaleX">X����任����</param>
        /// <param name="dScaleY">Y����任����</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_ScaleEnt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ScaleEnt(string strEntName, double dCenx, double dCeny, double dScaleX, double dScaleY);
        /// <summary>
        /// 
        /// dCenx,dCeny�������ĵ�����
        /// bMirrorX= true X���� 
        /// bMirrorY= true Y����
        /// </summary> 

        /// <summary>
        /// �����ݿ���ָ�����ƵĶ�����о���任
        /// </summary>
        /// <param name="strEntName">��������</param>
        /// <param name="dCenx">X������������</param>
        /// <param name="dCeny">Y������������</param>
        /// <param name="bMirrorX">X����</param>
        /// <param name="bMirrorY">Y����</param>
        /// <returns></returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_MirrorEnt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MirrorEnt(string strEntName, double dCenx, double dCeny, bool bMirrorX, bool bMirrorY);

        /// <summary>
        /// �����ݿ���ָ�����ƵĶ��������ת�任
        /// </summary>
        /// <param name="strEntName">��������</param>
        /// <param name="dCenx">��ת���ĵ�x����</param>
        /// <param name="dCeny">��ת���ĵ�y����</param>
        /// <param name="dAngle">Ϊ��ת�Ƕ�,��λΪ����ֵ</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_RotateEnt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RotateEnt(string strEntName, double dCenx, double dCeny, double dAngle);

        /// <summary>
        /// ����ָ�����ƶ��󣬲�����
        /// </summary>
        /// <param name="strEntName">��������</param>
        /// <param name="strNewEntName">������</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_CopyEnt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CopyEnt(string strEntName, string strNewEntName);

        /// <summary>
        /// �õ���������
        /// </summary>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetEntityCount", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort GetEntityCount();

        /// <summary>
        /// ���ָ����ŵĶ�������
        /// </summary>
        /// <param name="nEntityIndex">���</param>
        /// <param name="entname">�õ�����</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetEntityName", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lmc1_GetEntityNameByIndex(int nEntityIndex, StringBuilder entname);

        /// <summary>
        /// ���ָ����ŵĶ�������
        /// </summary>
        /// <param name="nEntityIndex">���</param>
        /// <returns>��Ӧ��ŵ�����</returns>
        public static string GetEntityNameByIndex(int nEntityIndex)
        {
            StringBuilder str = new StringBuilder("", 255);
            lmc1_GetEntityNameByIndex(nEntityIndex, str);
            return str.ToString();
        }

        /// <summary>
        /// �趨ָ�������ŵĶ��������
        /// </summary>
        /// <param name="nEntityIndex">���</param>
        /// <param name="entname">ָ������</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_SetEntityName", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetEntityNameByIndex(int nEntityIndex, string entname);

        /// <summary>
        /// ������ָ�����ƶ���
        /// </summary>
        /// <param name="strEntName">��������</param>
        /// <param name="strNewEntName">������</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_ChangeEntName", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ChangeEntName(string strEntName, string strNewEntName);

        /// <summary>
        /// �����ݿ���ָ�����ƵĶ���Ⱥ��
        /// </summary>
        /// <param name="strEntName1">��Ⱥ��Ķ���1</param>
        /// <param name="strEntName2">��Ⱥ��Ķ���2</param>
        /// <param name="strGroupName">Ⱥ������</param>
        /// <param name="nGroupPen">Ⱥ������ʺ�</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GroupEnt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GroupEnt(string strEntName1, string strEntName2, string strGroupName, int nGroupPen);

        /// <summary>
        /// �����ݿ���ָ�����ƵĶ����ɢȺ��
        /// </summary>
        /// <param name="strGroupName">����ɢȺ��Ķ���</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_UnGroupEnt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int UnGroupEnt(string strGroupName);

        /// <summary>
        /// �����ݿ���ָ���Ķ���Ⱥ��
        /// </summary>
        /// <param name="strEntName">���������б�</param>
        /// <param name="nEntCount">Ⱥ���������</param>
        /// <param name="strGroupName">Ⱥ�������</param>
        /// <param name="nGroupPen">Ⱥ������ʺ�</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GroupEnt2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lmc1_GroupEnt2(string[] strEntName, int nEntCount, string strGroupName, int nGroupPen);

        /// <summary>
        /// ���׽�ɢȺ�����Ϊ����
        /// </summary>
        /// <param name="GroupName">Ⱥ������</param>
        /// <param name="nFlag">Ĭ��0</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_UnGroupEnt2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int UnGroupEnt2(string GroupName, int nFlag);

        /// <summary>
        /// ��ȡ��ǰͼƬ�������
        /// </summary> 
        /// <param name="strEntName">λͼ��������</param>
        /// <param name="strImageFileName">λͼ����·��</param>
        /// <param name="nBmpAttrib">λͼ����</param>
        /// <param name="nScanAttrib">ɨ�����</param>
        /// <param name="dBrightness">��������[-1,1]</param>
        /// <param name="dContrast">�Աȶ�����[-1,1]</param>
        /// <param name="dPointTime">���ʱ������</param>
        /// <param name="nImportDpi">DPI</param>
        /// <returns></returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetBitmapEntParam2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetBitmapEntParam2(string strEntName,
                                                        StringBuilder strImageFileName,
                                                        ref int nBmpAttrib,
                                                        ref int nScanAttrib,
                                                        ref double dBrightness,
                                                        ref double dContrast,
                                                        ref double dPointTime,
                                                        ref int nImportDpi,
                                                        ref int bDisableMarkLowGrayPt,
                                                        ref int nMinLowGrayPt
                                                        );

        /// <summary>
        /// ���õ�ǰͼƬ�������
        /// </summary>
        /// <param name="strEntName">��������</param>
        /// <param name="strImageFileName">λͼ����·��</param>
        /// <param name="nBmpAttrib">λͼ����</param>
        /// <param name="nScanAttrib">ɨ�����</param>
        /// <param name="dBrightness">��������</param>
        /// <param name="dContrast">�Աȶ�����</param>
        /// <param name="dPointTime">���ʱ������</param>
        /// <param name="nImportDpi">DPI</param>
        /// <param name="bDisableMarkLowGrayPt">�Ƿ��̵ͻҶ�ֵ</param>
        /// <param name="nMinLowGrayPt">��ͻҶ�ֵ</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_SetBitmapEntParam2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetBitmapEntParam(string strEntName,
                                                         string strImageFileName,
                                                         int nBmpAttrib,
                                                         int nScanAttrib,
                                                         double dBrightness,
                                                         double dContrast,
                                                         double dPointTime,
                                                         int nImportDpi,
                                                         bool bDisableMarkLowGrayPt,
                                                         int nMinLowGrayPt
                                                          );

        /// <summary>
        /// ��ָ�������ƶ����ضԶ���ǰ��
        /// </summary>
        /// <param name="nMoveEnt"></param>
        /// <param name="GoalEnt"></param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_MoveEntityBefore", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MoveEntityBefore(int nMoveEnt, int GoalEnt);

        [DllImport("MarkEzd", EntryPoint = "lmc1_SetBitmapEntParam3", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetBitmapEntParam3(string strEntName,
                                                        double dDpiX,
                                                        double dDpiY,
                                                        [MarshalAs(UnmanagedType.LPArray)] byte[] bGrayScaleBuf);
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetBitmapEntParam3", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetBitmapEntParam3(string strEntName,
                                                          ref double dDpiX,
                                                          ref double dDpiY,
                                                          byte[] bGrayScaleBuf);

        /// <summary>
        /// ��ָ�������ƶ����ض��������
        /// </summary>
        /// <param name="nMoveEnt"></param>
        /// <param name="GoalEnt"></param>
        /// <returns></returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_MoveEntityAfter", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MoveEntityAfter(int nMoveEnt, int GoalEnt);


        /// <summary>
        /// 20140228 �����ж���˳��ߵ�
        /// </summary>
        /// <param name="nMoveEnt"></param>
        /// <param name="GoalEnt"></param>
        /// <returns></returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_ReverseAllEntOrder", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReverseAllEntOrder();


        #endregion

        #region �˿�

        /// ����ǰ����˿�
        /// data Ϊ��ǰ����˿ڵ�ֵ,
        /// Bit0��In0��״̬,Bit0=1��ʾIn0Ϊ�ߵ�ƽ,Bit0=0��ʾIn0Ϊ�͵�ƽ
        /// Bit1��In1��״̬,Bit1=1��ʾIn1Ϊ�ߵ�ƽ,Bit1=0��ʾIn1Ϊ�͵�ƽ
        /// ........
        /// Bit15��In15��״̬,Bit15=1��ʾIn15Ϊ�ߵ�ƽ,Bit15=0��ʾIn15Ϊ�͵�ƽ
        /// <summary>
        /// ����ǰ����˿�
        /// </summary>
        /// <param name="data">��ǰ״̬</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_ReadPort", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadPort(ref ushort data);

        /// data Ϊ��ǰ��ڶ˿�Ҫ���õ�ֵ,
        /// Bit0��Out0��״̬,Bit0=1��ʾOut0Ϊ�ߵ�ƽ,Bit0=0��ʾOut0Ϊ�͵�ƽ
        /// Bit1��Out1��״̬,Bit1=1��ʾOut1Ϊ�ߵ�ƽ,Bit1=0��ʾOut1Ϊ�͵�ƽ
        /// ........
        /// Bit15��Out15��״̬,Bit15=1��ʾOut15Ϊ�ߵ�ƽ,Bit15=0��ʾOut15Ϊ�͵�ƽ
        /// <summary>
        /// ���õ�ǰ����˿����
        /// </summary>
        /// <param name="data">��ǰ״̬</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_WritePort", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WritePort(ushort data);

        /// <summary>
        /// ��ȡ��ǰ�豸�����״ֵ̬
        /// </summary>
        /// <param name="data">״̬</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetOutPort", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetOutPort(ref ushort data);

        /// <summary>
        /// ֱ�Ӵ򿪼���
        /// </summary>
        /// <param name="bOpen">�Ƿ񿪹�</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_LaserOn", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int LaserOn(bool bOpen);

        #endregion

        #region �ı�

        /// <summary>
        /// �������ݿ���ָ�����Ƶ��ı����������Ϊָ���ı�
        /// </summary>
        /// <param name="EntName">��������</param>
        /// <param name="NewText">��ָ��������</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_ChangeTextByName", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ChangeTextByName(string EntName, string NewText);

        /// <summary>
        /// �õ�ָ��������ı�
        /// </summary>
        /// <param name="strEntName">�ı���������</param>
        /// <param name="Text">��ȡ������</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetTextByName", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTextByName(string strEntName, StringBuilder Text);

        /// <summary>
        /// �������кŶ���
        /// </summary>
        /// <param name="TextName">�ı���������</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_TextResetSn", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextResetSn(string TextName);

        #region ����

        public const uint LMC1_FONT_JSF = 1; //JczSingleLine����
        public const uint LMC1_FONT_TTF = 2; //TrueType����
        public const uint LMC1_FONT_DMF = 4; //DotMatrix����
        public const uint LMC1_FONT_BCF = 8; //Barcode����

        public struct FontRecord
        {
            public string fontname;//��������
            public uint fontattrib;//��������
        }

        /// <summary>
        /// �õ����ݿ��������¼������
        /// </summary>
        /// <param name="fontCount">��������</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetFontRecordCount", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetFontRecordCount(ref int fontCount);

        /// <summary>
        /// �õ�ϵͳ��ָ����ŵ������¼�����ƺ�����
        /// </summary>
        /// <param name="fontIndex">�������</param>
        /// <param name="fontName">��������</param>
        /// <param name="fontAttrib">�������Ͳ���</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetFontRecord", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetFontRecordByIndex(int fontIndex, StringBuilder fontName, ref uint fontAttrib);

        /// <summary>
        /// �õ�ϵͳ�����п���ʹ�õ��������ƺ�����
        /// </summary>
        /// <param name="fonts"></param>
        /// <returns></returns>
        public static bool GetAllFontRecord(ref FontRecord[] fonts)
        {
            int fontnum = 0;
            if (GetFontRecordCount(ref fontnum) != 0)
            {
                return false;
            }
            if (fontnum == 0)
            {
                return true;
            }
            fonts = new FontRecord[fontnum];
            StringBuilder str = new StringBuilder("", 255);
            uint fontAttrib = 0;
            for (int i = 0; i < fontnum; i++)
            {
                GetFontRecordByIndex(i, str, ref fontAttrib);
                fonts[i].fontname = str.ToString(); ;
                fonts[i].fontattrib = fontAttrib;
            }
            return true;
        }

        #endregion

        /// <summary>
        /// ��ȡ����Ĳ�����������Զ���ģ������������
        /// </summary>
        /// <param name="strFontName">��������</param>
        /// <param name="CharHeight">�ַ��߶�</param>
        /// <param name="CharWidthRatio">�ַ����</param>
        /// <param name="CharAngle">����Ƕ�</param>
        /// <param name="CharSpace">������</param>
        /// <param name="LineSpace">�м��</param>
        /// <param name="EqualCharWidth">�Ƿ�ȿ�</param>
        /// <param name="nTextAlign">�ı����뷽ʽ</param>
        /// <param name="bBold">����</param>
        /// <param name="bItalic">б��</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetFontParam3", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetFontParam3(string strFontName,
                                                     ref double CharHeight,
                                                     ref double CharWidthRatio,
                                                     ref double CharAngle,
                                                     ref double CharSpace,
                                                     ref double LineSpace,
                                                     ref bool EqualCharWidth,
                                                     ref int nTextAlign,
                                                     ref bool bBold,
                                                     ref bool bItalic);

        /// <summary>
        /// ��������Ĳ��������´�����ı���ʱ����Ч
        /// </summary>
        /// <param name="fontname">��������</param>
        /// <param name="CharHeight">�ַ��߶�</param>
        /// <param name="CharWidthRatio">�ַ����</param>
        /// <param name="CharAngle">����Ƕ�</param>
        /// <param name="CharSpace">������</param>
        /// <param name="LineSpace">�м��</param>
        /// <param name="spaceWidthRatio">�ռ��ȱ�</param>
        /// <param name="EqualCharWidth">�Ƿ�ȿ�</param>
        /// <param name="nTextAlign">�ı����뷽ʽ</param>
        /// <param name="bBold">����</param>
        /// <param name="bItalic">б��</param>
        /// <returns></returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_SetFontParam3", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetFontParam3(string fontname,
                                                    double CharHeight,
                                                    double CharWidthRatio,
                                                    double CharAngle,
                                                    double CharSpace,
                                                    double LineSpace,
                                                    double spaceWidthRatio,
                                                    bool EqualCharWidth,
                                                    int nTextAlign,
                                                    bool bBold,
                                                    bool bItalic);

        /// <summary>
        /// �õ�ָ���ı��������
        /// </summary>
        /// <param name="EntName"></param>��������
        /// <param name="FontName"></param>��������
        /// <param name="CharHeight"></param>�ַ��߶�
        /// <param name="CharWidthRatio"></param>�ַ����
        /// <param name="CharAngle"></param>�ַ����
        /// <param name="CharSpace"></param>�ַ����
        /// <param name="LineSpace"></param>�м��lmc1_GetEzdFilePrevBitmap
        /// <param name="EqualCharWidth"></param>���ַ����
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetTextEntParam", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTextEntParam(string EntName,
                                                         StringBuilder FontName,
                                                      ref double CharHeight,
                                                      ref double CharWidthRatio,
                                                      ref double CharAngle,
                                                      ref double CharSpace,
                                                      ref double LineSpace,
                                                      ref bool EqualCharWidth);

        /// <summary>
        /// ����ָ���ı����������
        /// </summary>
        /// <param name="EntName">��������</param>
        /// <param name="CharHeight">�ַ��߶�</param>
        /// <param name="CharWidthRatio">�ַ����</param>
        /// <param name="CharAngle">�ַ����</param>
        /// <param name="CharSpace">�ַ����</param>
        /// <param name="LineSpace">�м��</param>
        /// <param name="EqualCharWidth">���ַ����ģʽ</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_SetTextEntParam", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetTextEntParam(string EntName,
                                                        double CharHeight,
                                                        double CharWidthRatio,
                                                        double CharAngle,
                                                        double CharSpace,
                                                        double LineSpace,
                                                        bool EqualCharWidth);

        /// <summary>
        /// ��ȡָ���ı����������
        /// </summary>
        /// <param name="EntName">�ı�����</param>
        /// <param name="FontName">��������</param>
        /// <param name="CharHeight">�ַ��߶�</param>
        /// <param name="CharWidthRatio">�ַ����</param>
        /// <param name="CharAngle">�ַ����</param>
        /// <param name="CharSpace">�ַ����</param>
        /// <param name="LineSpace">�м��</param>
        /// <param name="spaceWidthRatio">���ַ����</param>
        /// <param name="EqualCharWidth">���ַ����ģʽ</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetTextEntParam2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTextEntParam2(string EntName,
                                                        StringBuilder FontName,
                                                     ref double CharHeight,
                                                     ref double CharWidthRatio,
                                                     ref double CharAngle,
                                                     ref double CharSpace,
                                                     ref double LineSpace,
                                                     ref double spaceWidthRatio,
                                                     ref bool EqualCharWidth);


        /// <summary>
        /// ����ָ���ı����������
        /// </summary>
        /// <param name="EntName">�ı�����</param>
        /// <param name="FontName">��������</param>
        /// <param name="CharHeight">�ַ��߶�</param>
        /// <param name="CharWidthRatio">�ַ����</param>
        /// <param name="CharAngle">�ַ����</param>
        /// <param name="CharSpace">�ַ����</param>
        /// <param name="LineSpace">�м��</param>
        /// <param name="spaceWidthRatio">���ַ����</param>
        /// <param name="EqualCharWidth">���ַ����ģʽ</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_SetTextEntParam2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetTextEntParam2(string EntName,
                                                         string FontName,
                                                        double CharHeight,
                                                        double CharWidthRatio,
                                                        double CharAngle,
                                                        double CharSpace,
                                                        double LineSpace,
                                                        double spaceWidthRatio,
                                                        bool EqualCharWidth);

        /// <summary>
        /// ��ȡָ���ı����������
        /// </summary>
        /// <param name="EntName">�ı�����</param>
        /// <param name="FontName">��������</param>
        /// <param name="nTextSpaceMode">�ı����ģʽ</param>
        /// <param name="dTextSpace">�ı�������</param>
        /// <param name="CharHeight">�ַ��߶�</param>
        /// <param name="CharWidthRatio">�ַ����</param>
        /// <param name="CharAngle">�ַ���ǣ�����ֵ��</param>
        /// <param name="CharSpace">�ַ����</param>
        /// <param name="LineSpace">�м��</param>
        /// <param name="dNullCharWidthRatio">���ַ����</param>
        /// <param name="nTextAlign">�ı����뷽ʽ</param>
        /// <param name="bBold">����</param>
        /// <param name="bItalic">б��</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetTextEntParam4", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTextEntParam4(string EntName,
                                                       StringBuilder FontName,
                                                       ref int nTextSpaceMode,
                                                       ref double dTextSpace,
                                                ref double CharHeight,
                                                ref double CharWidthRatio,
                                                ref double CharAngle,
                                                ref double CharSpace,
                                                ref double LineSpace,
                                                ref double dNullCharWidthRatio,
                                                ref int nTextAlign,
                                                ref bool bBold,
                                                ref bool bItalic);

        /// <summary>
        /// ����ָ���ı����������
        /// </summary>
        /// <param name="EntName">�ı�����</param>
        /// <param name="fontname">��������</param>
        /// <param name="nTextSpaceMode">�ı����ģʽ</param>
        /// <param name="dTextSpace">�ı�������</param>
        /// <param name="CharHeight">�ַ��߶�</param>
        /// <param name="CharWidthRatio">�ַ����</param>
        /// <param name="CharAngle">�ַ���ǣ�����ֵ��</param>
        /// <param name="CharSpace">�ַ����</param>
        /// <param name="LineSpace">�м��</param>
        /// <param name="spaceWidthRatio">���ַ����</param>
        /// <param name="nTextAlign">�ı����뷽ʽ</param>
        /// <param name="bBold">����</param>
        /// <param name="bItalic">б��</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_SetTextEntParam4", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetTextEntParam4(string EntName,
                                                   string fontname,
                                                   int nTextSpaceMode,
                                                  double dTextSpace,
                                                  double CharHeight,
                                                  double CharWidthRatio,
                                                  double CharAngle,
                                                  double CharSpace,
                                                  double LineSpace,
                                                  double spaceWidthRatio,
                                                    int nTextAlign,
                                                    bool bBold,
                                                    bool bItalic);

        /// <summary>
        /// ���ָ��Բ���ı�����Ĳ���
        /// </summary>
        /// <param name="pEntName">��������</param>
        /// <param name="dCenX">�ı����ڻ�׼Բ��x����</param>
        /// <param name="dCenY">�ı����ڻ�׼Բ��y����</param>
        /// <param name="dCenZ">�ַ�z����</param>
        /// <param name="dCirDiameter">��׼Բֱ��</param>
        /// <param name="dCirBaseAngle">���ֻ�׼�Ƕ�</param>
        /// <param name="bCirEnableAngleLimit">�Ƿ�ʹ�ܽǶ�����</param>
        /// <param name="dCirAngleLimit">���ƵĽǶ�</param>
        /// <param name="nCirTextFlag">�ı���Բ�ϵķ���</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetCircleTextParam", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetCircleTextParam(string pEntName,
                                                  ref double dCenX,
                                                  ref double dCenY,
                                                  ref double dCenZ,
                                                  ref double dCirDiameter,
                                                  ref double dCirBaseAngle,
                                                  ref bool bCirEnableAngleLimit,
                                                  ref double dCirAngleLimit,
                                                  ref int nCirTextFlag);

        /// <summary>
        /// ����ָ��Բ���ı�����Ĳ���
        /// </summary>
        /// <param name="pEntName">�ַ�����������</param>
        /// <param name="dCenX">�ı����ڻ�׼Բ��x����</param>
        /// <param name="dCenY">�ı����ڻ�׼Բ��y����</param>
        /// <param name="dCenZ">�ַ�z����</param>
        /// <param name="dCirDiameter">��׼Բֱ��</param>
        /// <param name="dCirBaseAngle">���ֻ�׼�Ƕ�</param>
        /// <param name="bCirEnableAngleLimit">�Ƿ�ʹ�ܽǶ�����</param>
        /// <param name="dCirAngleLimit">���ƵĽǶ�</param>
        /// <param name="nCirTextFlag">�ı���Բ�ϵķ���</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_SetCircleTextParam", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetCircleTextParam(string pEntName,
                                                    double dCenX,
                                                    double dCenY,
                                                    double dCenZ,
                                                    double dCirDiameter,
                                                    double dCirBaseAngle,
                                                    bool bCirEnableAngleLimit,
                                                    double dCirAngleLimit,
                                                    int nCirTextFlag);
        #endregion

        #region �ʺ�

        /// <summary>
        /// �õ�ָ���ʺŵĲ���
        /// </summary>
        /// <param name="nPenNo">Ҫ���õıʺ�0-255</param>
        /// <param name="nMarkLoop">��̴���</param>
        /// <param name="dMarkSpeed">�ӹ��ٶ� mm/s����inch/mm,ȡ����markdll.dll�ĵ�ǰ��λ</param>
        /// <param name="dPowerRatio">���ʰٷֱ� 0-100%</param>
        /// <param name="dCurrent">����A</param>
        /// <param name="nFreq">Ƶ��Hz</param>
        /// <param name="dQPulseWidth">Q������ us</param>
        /// <param name="nStartTC">������ʱ us</param>
        /// <param name="nLaserOffTC">�ع���ʱ us</param>
        /// <param name="nEndTC">������ʱ us</param>
        /// <param name="nPolyTC">����ιս���ʱus</param>
        /// <param name="dJumpSpeed">��ת�ٶ� mm/s����inch/mm,ȡ����markdll.dll�ĵ�ǰ��λ</param>
        /// <param name="nJumpPosTC">��תλ����ʱ us</param>
        /// <param name="nJumpDistTC">��ת������ʱ us</param>
        /// <param name="dEndComp">ĩ�㲹������ mm����inch,ȡ����markdll.dll�ĵ�ǰ��λ</param>
        /// <param name="dAccDist">���پ��� mm����inch</param>
        /// <param name="dPointTime">���ʱ��ms</param>
        /// <param name="bPulsePointMode">���ģʽ trueʹ��</param>
        /// <param name="nPulseNum">������</param>
        /// <param name="dFlySpeed">��ˮ���ٶ� mm/s����inch/mm</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetPenParam", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPenParam(int nPenNo,
                     ref int nMarkLoop,
                     ref double dMarkSpeed,
                     ref double dPowerRatio,
                     ref double dCurrent,
                     ref int nFreq,
                     ref double dQPulseWidth,
                     ref int nStartTC,
                     ref int nLaserOffTC,
                     ref int nEndTC,
                     ref int nPolyTC,
                     ref double dJumpSpeed,
                     ref int nJumpPosTC,
                     ref int nJumpDistTC,
                     ref double dEndComp,
                     ref double dAccDist,
                     ref double dPointTime,
                     ref bool bPulsePointMode,
                     ref int nPulseNum,
                     ref double dFlySpeed);

        /// <summary>
        /// 20111201 ��� �õ�ָ���ʺŵĲ���
        /// </summary>
        /// <param name="nPenNo">Ҫ���õıʺ�0-255</param>
        /// <param name="nMarkLoop">��̴���</param>
        /// <param name="dMarkSpeed">�ӹ��ٶ� mm/s����inch/mm,ȡ����markdll.dll�ĵ�ǰ��λ</param>
        /// <param name="dPowerRatio">���ʰٷֱ� 0-100%</param>
        /// <param name="dCurrent">����A</param>
        /// <param name="nFreq">Ƶ��Hz</param>
        /// <param name="dQPulseWidth">Q������ us</param>
        /// <param name="nStartTC">������ʱ us</param>
        /// <param name="nLaserOffTC">�ع���ʱ us</param>
        /// <param name="nEndTC">������ʱ us</param>
        /// <param name="nPolyTC">����ιս���ʱus</param>
        /// <param name="dJumpSpeed">��ת�ٶ� mm/s����inch/mm,ȡ����markdll.dll�ĵ�ǰ��λ</param>
        /// <param name="nJumpPosTC">��תλ����ʱ us</param>
        /// <param name="nJumpDistTC">��ת������ʱ us</param>
        /// <param name="dPointTime">���ʱ��ms</param>
        /// <param name="nSpiWave">SPI����ѡ��</param>
        /// <param name="bWobbleMode">����ģʽ</param>
        /// <param name="bWobbleDiameter">����ֱ��</param>
        /// <param name="bWobbleDist">�������</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetPenParam2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPenParam2(int nPenNo,
                     ref int nMarkLoop,
                     ref double dMarkSpeed,
                     ref double dPowerRatio,
                     ref double dCurrent,
                     ref int nFreq,
                     ref double dQPulseWidth,
                     ref int nStartTC,
                     ref int nLaserOffTC,
                     ref int nEndTC,
                     ref int nPolyTC,
                     ref double dJumpSpeed,
                     ref int nJumpPosTC,
                     ref int nJumpDistTC,
                     ref double dPointTime,
                     ref int nSpiWave,
                     ref bool bWobbleMode,
                     ref double bWobbleDiameter,
                     ref double bWobbleDist);

        /// <summary>
        /// �õ���Ӧ�ʺŵĲ���
        /// </summary>
        /// <param name="nPenNo">Ҫ���õıʺ�(0-255)</param>
        /// <param name="pStrName">�����֣�Ĭ��default</param>
        /// <param name="clr">����ɫ</param>
        /// <param name="bDisableMark">�Ƿ�ʹ�ܱʺţ�true�رձʺŲ����</param>
        /// <param name="bUseDefParam">�Ƿ�ʹ��Ĭ��ֵ</param>
        /// <param name="nMarkLoop">�ӹ�����</param>
        /// <param name="dMarkSpeed">����ٶ�mm/s</param>
        /// <param name="dPowerRatio">���ʰٷֱ�(0-100%)</param>
        /// <param name="dCurrent">����A</param>
        /// <param name="nFreq">Ƶ��HZ</param>
        /// <param name="dQPulseWidth">Q������us</param>
        /// <param name="nStartTC">��ʼ��ʱus</param>
        /// <param name="nLaserOffTC">����ر���ʱus</param>
        /// <param name="nEndTC">������ʱus</param>
        /// <param name="nPolyTC">�ս���ʱus</param>
        /// <param name="dJumpSpeed">��ת�ٶ�mm/s</param>
        /// <param name="nMinJumpDelayTCUs">��С��ת��ʱus</param>
        /// <param name="nMaxJumpDelayTCUs">�����ת��ʱus</param>
        /// <param name="dJumpLengthLimit">��ת���ļ���</param>
        /// <param name="dPointTimeMs">���ʱ�� ms</param>
        /// <param name="nSpiSpiContinueMode">SPI����ģʽ</param>
        /// <param name="nSpiWave">SPI����ѡ��</param>
        /// <param name="nYagMarkMode">YAG�Ż����ģʽ</param>
        /// <param name="bPulsePointMode">�����ģʽ</param>
        /// <param name="nPulseNum">�������</param>
        /// <param name="bEnableACCMode">ʹ�ܼ���ģʽ</param>
        /// <param name="dEndComp">ĩ�㲹��</param>
        /// <param name="dAccDist">���پ���</param>
        /// <param name="dBreakAngle">�жϽǶ�</param>
        /// <param name="bWobbleMode">����ģʽ</param>
        /// <param name="bWobbleDiameter">����ֱ��</param>
        /// <param name="bWobbleDist">�������</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetPenParam4", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPenParam4(int nPenNo,
                                                        StringBuilder pStrName,
                                                        ref int clr,
                                                        ref bool bDisableMark,
                                                        ref bool bUseDefParam,
                                                        ref int nMarkLoop,
                                                        ref double dMarkSpeed,
                                                        ref double dPowerRatio,
                                                        ref double dCurrent,
                                                        ref int nFreq,
                                                        ref double dQPulseWidth,
                                                        ref int nStartTC,
                                                        ref int nLaserOffTC,
                                                        ref int nEndTC,
                                                        ref int nPolyTC,
                                                        ref double dJumpSpeed,
                                                        ref int nMinJumpDelayTCUs,
                                                        ref int nMaxJumpDelayTCUs,
                                                        ref double dJumpLengthLimit,
                                                        ref double dPointTimeMs,
                                                        ref bool nSpiSpiContinueMode,
                                                        ref int nSpiWave,
                                                        ref int nYagMarkMode,
                                                        ref bool bPulsePointMode,
                                                        ref int nPulseNum,
                                                        ref bool bEnableACCMode,
                                                        ref double dEndComp,
                                                        ref double dAccDist,
                                                        ref double dBreakAngle,
                                                        ref bool bWobbleMode,
                                                        ref double bWobbleDiameter,
                                                        ref double bWobbleDist);

        /// <summary>
        /// ����ָ���ʺŵĲ���
        /// </summary>
        /// <param name="nPenNo">Ҫ���õıʺ�0-255</param>
        /// <param name="nMarkLoop">��̴���</param>
        /// <param name="dMarkSpeed">�ӹ��ٶ� mm/s����inch/mm,ȡ����markdll.dll�ĵ�ǰ��λ</param>
        /// <param name="dPowerRatio">���ʰٷֱ� 0-100%</param>
        /// <param name="dCurrent">����A</param>
        /// <param name="nFreq">Ƶ��Hz</param>
        /// <param name="dQPulseWidth">Q������ us</param>
        /// <param name="nStartTC">������ʱ us</param>
        /// <param name="nLaserOffTC">�ع���ʱ us</param>
        /// <param name="nEndTC">������ʱ us</param>
        /// <param name="nPolyTC">����ιս���ʱus</param>
        /// <param name="dJumpSpeed">��ת�ٶ� mm/s����inch/mm,ȡ����markdll.dll�ĵ�ǰ��λ</param>
        /// <param name="nJumpPosTC">��תλ����ʱ us</param>
        /// <param name="nJumpDistTC">��ת������ʱ us</param>
        /// <param name="dEndComp">ĩ�㲹������ mm����inch,ȡ����markdll.dll�ĵ�ǰ��λ</param>
        /// <param name="dAccDist">���پ��� mm����inch</param>
        /// <param name="dPointTime">���ʱ��ms</param>
        /// <param name="bPulsePointMode">���ģʽ trueʹ��</param>
        /// <param name="nPulseNum">������</param>
        /// <param name="dFlySpeed">��ˮ���ٶ� mm/s����inch/mm</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_SetPenParam", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetPenParam(int nPenNo,
                             int nMarkLoop,
                             double dMarkSpeed,
                             double dPowerRatio,
                             double dCurrent,
                             int nFreq,
                             double dQPulseWidth,
                             int nStartTC,
                             int nLaserOffTC,
                             int nEndTC,
                             int nPolyTC,
                             double dJumpSpeed,
                             int nJumpPosTC,
                             int nJumpDistTC,
                             double dEndComp,
                             double dAccDist,
                             double dPointTime,
                             bool bPulsePointMode,
                             int nPulseNum,
                             double dFlySpeed);





        //////////////////////////////////////
        ///20110329��Ӹ������ñʺŲ���
        /////////////////////////////////////////
        /// <summary>
        /// ����ָ���ʺŵĲ���
        /// nPenNoҪ���õıʺ�0-255
        /// nMarkLoop��̴���
        /// dMarkSpeed �ӹ��ٶ� mm/s����inch/mm,ȡ����markdll.dll�ĵ�ǰ��λ
        /// dPowerRatio���ʰٷֱ� 0-100%
        /// dCurrent����A
        /// nFreqƵ��Hz
        /// nQPulseWidth Q������ us
        /// nStartTC ������ʱ us
        /// nLaserOffTC �ع���ʱ us
        /// nEndTC  ������ʱ us
        /// nPolyTC ����ιս���ʱus
        /// dJumpSpeed ��ת�ٶ� mm/s����inch/mm,ȡ����markdll.dll�ĵ�ǰ��λ 
        /// nJumpPosTC ��תλ����ʱ us
        /// nJumpDistTC ��ת������ʱ us
        /// nSpiWave SPI����ѡ��
        /// bWobbleMode ����ģʽ
        /// bWobbleDiameter ����ֱ��
        /// bWobbleDist �������
        /// </summary> 
        [DllImport("MarkEzd", EntryPoint = "lmc1_SetPenParam2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetPenParam2(int nPenNo,
                                                        int nMarkLoop,
                                                        double dMarkSpeed,
                                                        double dPowerRatio,
                                                        double dCurrent,
                                                        int nFreq,
                                                        double dQPulseWidth,
                                                        int nStartTC,
                                                        int nLaserOffTC,
                                                        int nEndTC,
                                                        int nPolyTC,
                                                        double dJumpSpeed,
                                                        int nJumpPosTC,
                                                        int nJumpDistTC,
                                                        double dPointTime,
                                                        int nSpiWave,
                                                        bool bWobbleMode,
                                                        double bWobbleDiameter,
                                                        double bWobbleDist);


        public static int ColorToCOLORREF(Color color)
        {
            return ((color.R | (color.G << 8)) | (color.B << 0x10));
        }

        public static Color COLORREFToColor(int colorRef)
        {
            byte[] _IntByte = BitConverter.GetBytes(colorRef);
            return Color.FromArgb(_IntByte[0], _IntByte[1], _IntByte[2]);
        }

        [DllImport("MarkEzd", EntryPoint = "lmc1_SetPenParam4", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetPenParam4(int nPenNo,//�ʺ�
                                                            string pStrName,    // ����
                                                            int clr,//��ɫ
                                                            bool bDisableMark,//ʹ�ܼӹ�
                                                            bool bUseDefParam,//ʹ��Ĭ�ϲ���
                                                            int nMarkLoop,//�ӹ�����
                                                            double dMarkSpeed,//�ӹ��ٶ�
                                                            double dPowerRatio,//���� %
                                                            double dCurrent,//����,A
                                                            int nFreq,//Ƶ�� HZ
                                                            double dQPulseWidth,//����yag us    ylpm ns
                                                            int nStartTC,//������ʱ
                                                            int nLaserOffTC,//�ع���ʱ
                                                            int nEndTC,//������ʱ
                                                            int nPolyTC,//�ս���ʱ
                                                            double dJumpSpeed,//��ת�ٶ�
                                                            int nMinJumpDelayTCUs,//��С��ת��ʱ
                                                            int nMaxJumpDelayTCUs,//�����ת��ʱ
                                                            double dJumpLengthLimit,//��ת������ֵ
                                                            double dPointTimeMs,//���ʱ��
                                                            bool nSpiSpiContinueMode,//SPI����ģʽ
                                                            int nSpiWave,//SPI���α��
                                                            int nYagMarkMode,//YAG�Ż�ģʽ
                                                            bool bPulsePointMode,//������ģʽ
                                                            int nPulseNum,//��������������
                                                            bool bEnableACCMode,//���üӼ����Ż�
                                                            double dEndComp,//����
                                                            double dAccDist,//����
                                                            double dBreakAngle,//�жϽǶ�
                                                            bool bWobbleMode,//����ģʽ
                                                            double bWobbleDiameter,//����ֱ��
                                                            double bWobbleDist);//�����߼��


        /// <summary>
        ///���ñʺ��Ƿ���
        /// </summary>
        /// <param name="nPenNo">Ҫ���õıʺ�0-255</param>
        /// <param name="bDisableMark">�Ƿ���</param>
        /// <returns>����ֵ</returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_SetPenDisableState", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetPenDisableState(int nPenNo, bool bDisableMark);


        /// <summary>
        /// ��ȡ�ʺ��Ƿ���
        /// </summary>
        /// <param name="nPenNo"></param>
        /// <param name="bDisableMark"></param>
        /// <returns></returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetPenDisableState", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPenDisableState(int nPenNo, ref bool bDisableMark);

        ///<summary>
        ///��ȡָ�����ƶ���ʺ�
        ///<summary>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetPenNumberFromName", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPenNumberFromName(string strEntName);

        /// <summary>
        /// ��ȡ����ʺ�
        /// </summary>
        /// <param name="strEntName"></param>
        /// <returns></returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetPenNumberFromEnt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPenNumberFromEnt(string strEntName);

        ///<summary>
        ///����Ӧ�ñʺ����ã����ʸ��ͼ�ļ���
        ///<summary>
        [DllImport("MarkEzd", EntryPoint = "lmc1_SetEntAllChildPen", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetEntAllChildPen(string strEntName, int nPenNo);

        #endregion

        #region ���
        public const int HATCHATTRIB_ALLCALC = 0x01;//ȫ�������������
        public const int HATCHATTRIB_EDGE = 0x02;//�Ʊ���һ��
        public const int HATCHATTRIB_MINUP = 0x04;//�������
        public const int HATCHATTRIB_BIDIR = 0x08;//˫�����
        public const int HATCHATTRIB_LOOP = 0x10;//�������
        public const int HATCHATTRIB_OUT = 0x20;//������������
        public const int HATCHATTRIB_AUTOROT = 0x40;//�Զ��Ƕ���ת
        public const int HATCHATTRIB_AVERAGELINE = 0x80;//�Զ��ֲ������
        public const int HATCHATTRIB_CROSELINE = 0x400;//�������

        /// <summary>
        /// ���õ�ǰ��������,��������ݿ���Ӷ���ʱʹ�����,ϵͳ���ô˺������õĲ��������
        /// </summary> 
        [DllImport("MarkEzd", EntryPoint = "lmc1_SetHatchParam", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetHatchParam(bool bEnableContour,
                          int bEnableHatch1,
                          int nPenNo1,
                          int nHatchAttrib1,
                          double dHatchEdgeDist1,
                          double dHatchLineDist1,
                          double dHatchStartOffset1,
                          double dHatchEndOffset1,
                          double dHatchAngle1,
                          int bEnableHatch2,
                          int nPenNo2,
                          int nHatchAttrib2,
                          double dHatchEdgeDist2,
                          double dHatchLineDist2,
                          double dHatchStartOffset2,
                          double dHatchEndOffset2,
                          double dHatchAngle2);



        /// <summary>
        /// ���õ�ǰ��������2,��������ݿ���Ӷ���ʱʹ�����,ϵͳ���ô˺������õĲ��������  20120911add  2.7.2
        /// </summary> 
        [DllImport("MarkEzd", EntryPoint = "lmc1_SetHatchParam2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetHatchParam2(bool bEnableContour,//ʹ����������
                                                          int nParamIndex,//���������ֵΪ1,2,3
                                                          int bEnableHatch,//ʹ�����
                                                          int nPenNo,//�������ʺ�
                                                          int nHatchType,//������� 0���� 1˫�� 2���� 3���� 4���β�����
                                                          bool bHatchAllCalc,//�Ƿ�ȫ��������Ϊ����һ�����
                                                          bool bHatchEdge,//�Ʊ�һ��
                                                          bool bHatchAverageLine,//�Զ�ƽ���ֲ���
                                                          double dHatchAngle,//����߽Ƕ� 
                                                          double dHatchLineDist,//����߼��
                                                          double dHatchEdgeDist,//����߱߾�    
                                                          double dHatchStartOffset,//�������ʼƫ�ƾ���
                                                          double dHatchEndOffset,//����߽���ƫ�ƾ���
                                                          double dHatchLineReduction,//ֱ������
                                                          double dHatchLoopDist,//�����
                                                          int nEdgeLoop,//����
                                                          bool nHatchLoopRev,//���η�ת
                                                          bool bHatchAutoRotate,//�Ƿ��Զ���ת�Ƕ�
                                                          double dHatchRotateAngle//�Զ���ת�Ƕ�   
                                                       );

        /// <summary>
        /// ���õ�ǰ��������3,��������ݿ���Ӷ���ʱʹ�����,ϵͳ���ô˺������õĲ��������  20170330add  2.14.9
        /// </summary> 
        [DllImport("MarkEzd", EntryPoint = "lmc1_SetHatchParam3", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetHatchParam3(bool bEnableContour,//ʹ����������
                                                          int nParamIndex,//���������ֵΪ1,2,3
                                                          int bEnableHatch,//ʹ�����
                                                          int nPenNo,//�������ʺ�
                                                          int nHatchType,//������� 0���� 1˫�� 2���� 3���� 4���β�����
                                                          bool bHatchAllCalc,//�Ƿ�ȫ��������Ϊ����һ�����
                                                          bool bHatchEdge,//�Ʊ�һ��
                                                          bool bHatchAverageLine,//�Զ�ƽ���ֲ���
                                                          double dHatchAngle,//����߽Ƕ� 
                                                          double dHatchLineDist,//����߼��
                                                          double dHatchEdgeDist,//����߱߾�    
                                                          double dHatchStartOffset,//�������ʼƫ�ƾ���
                                                          double dHatchEndOffset,//����߽���ƫ�ƾ���
                                                          double dHatchLineReduction,//ֱ������
                                                          double dHatchLoopDist,//�����
                                                          int nEdgeLoop,//����
                                                          bool nHatchLoopRev,//���η�ת
                                                          bool bHatchAutoRotate,//�Ƿ��Զ���ת�Ƕ�
                                                          double dHatchRotateAngle,//�Զ���ת�Ƕ�  
                                                          bool bHatchCross
                                                       );

        [DllImport("MarkEzd", EntryPoint = "lmc1_GetHatchParam3", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetHatchParam3(ref bool bEnableContour,
                                                         int nParamIndex,
                                                         ref int bEnableHatch,
                                                         ref int nPenNo,
                                                         ref int nHatchType,
                                                         ref bool bHatchAllCalc,
                                                         ref bool bHatchEdge,
                                                         ref bool bHatchAverageLine,
                                                         ref double dHatchAngle,
                                                         ref double dHatchLineDist,
                                                         ref double dHatchEdgeDist,
                                                         ref double dHatchStartOffset,
                                                         ref double dHatchEndOffset,
                                                         ref double dHatchLineReduction,//ֱ������
                                                         ref double dHatchLoopDist,//�����
                                                         ref int nEdgeLoop,//����
                                                         ref bool nHatchLoopRev,//���η�ת
                                                         ref bool bHatchAutoRotate,//�Ƿ��Զ���ת�Ƕ�
                                                         ref double dHatchRotateAngle,
                                                         ref bool nHatchCross);



        [DllImport("MarkEzd", EntryPoint = "lmc1_SetHatchEntParam", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int
            SetHatchEntParam(string HatchName,
                                                        bool bEnableContour,
                                                        int nParamIndex,
                                                        int bEnableHatch,
                                                        int nPenNo,
                                                        int nHatchType,
                                                        bool bHatchAllCalc,
                                                        bool bHatchEdge,
                                                        bool bHatchAverageLine,
                                                        double dHatchAngle,
                                                        double dHatchLineDist,
                                                        double dHatchEdgeDist,
                                                        double dHatchStartOffset,
                                                        double dHatchEndOffset,
                                                        double dHatchLineReduction,//ֱ������
                                                        double dHatchLoopDist,//�����
                                                        int nEdgeLoop,//����
                                                        bool nHatchLoopRev,//���η�ת
                                                        bool bHatchAutoRotate,//�Ƿ��Զ���ת�Ƕ�
                                                        double dHatchRotateAngle);

        [DllImport("MarkEzd", EntryPoint = "lmc1_GetHatchEntParam", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetHatchEntParam(string HatchName,
                         ref bool bEnableContour,
                         int nParamIndex,
                         ref int bEnableHatch,
                         ref int nPenNo,
                         ref int nHatchType,
                         ref bool bHatchAllCalc,
                         ref bool bHatchEdge,
                         ref bool bHatchAverageLine,
                         ref double dHatchAngle,
                         ref double dHatchLineDist,
                         ref double dHatchEdgeDist,
                         ref double dHatchStartOffset,
                         ref double dHatchEndOffset,
                         ref double dHatchLineReduction,//ֱ������
                         ref double dHatchLoopDist,//�����
                         ref int nEdgeLoop,//����
                         ref bool nHatchLoopRev,//���η�ת
                         ref bool bHatchAutoRotate,//�Ƿ��Զ���ת�Ƕ�
                         ref double dHatchRotateAngle);

        [DllImport("MarkEzd", EntryPoint = "lmc1_SetHatchEntParam2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int
            SetHatchEntParam2(string HatchName,
                            bool bEnableContour,
                            int nParamIndex,
                            int bEnableHatch,
                            bool bContourFirst,
                            int nPenNo,
                            int nHatchType,
                            bool bHatchAllCalc,
                            bool bHatchEdge,
                            bool bHatchAverageLine,
                            double dHatchAngle,
                            double dHatchLineDist,
                            double dHatchEdgeDist,
                            double dHatchStartOffset,
                            double dHatchEndOffset,
                            double dHatchLineReduction,//ֱ������
                            double dHatchLoopDist,//�����
                            int nEdgeLoop,//����
                            bool nHatchLoopRev,//���η�ת
                            bool bHatchAutoRotate,//�Ƿ��Զ���ת�Ƕ�
                            double dHatchRotateAngle,
                                bool bHatchCrossMode,
                                int dCycCount);

        [DllImport("MarkEzd", EntryPoint = "lmc1_GetHatchEntParam2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetHatchEntParam2(string HatchName,
                         ref bool bEnableContour,
                         int nParamIndex,
                         ref int bEnableHatch,
                         ref bool bContourFirst,
                         ref int nPenNo,
                         ref int nHatchType,
                         ref bool bHatchAllCalc,
                         ref bool bHatchEdge,
                         ref bool bHatchAverageLine,
                         ref double dHatchAngle,
                         ref double dHatchLineDist,
                         ref double dHatchEdgeDist,
                         ref double dHatchStartOffset,
                         ref double dHatchEndOffset,
                         ref double dHatchLineReduction,//ֱ������
                         ref double dHatchLoopDist,//�����
                         ref int nEdgeLoop,//����
                         ref bool nHatchLoopRev,//���η�ת
                         ref bool bHatchAutoRotate,//�Ƿ��Զ���ת�Ƕ�
                         ref double dHatchRotateAngle,
                         ref bool bHatchCrossMode,
                         ref int dCycCount);


        /// <summary>
        /// �����ݿ���ָ�����ƵĶ������
        /// strEntName����������      
        /// strHatchEntName���������
        /// </summary> 
        [DllImport("MarkEzd", EntryPoint = "lmc1_HatchEnt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HatchEnt(string strEntName, string strHatchEntName);

        /// <summary>
        /// �����ݿ���ָ�����ƵĶ���ɾ�����
        /// strHatchEntName��������
        /// </summary> 
        [DllImport("MarkEzd", EntryPoint = "lmc1_UnHatchEnt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int UnHatchEnt(string strHatchEntName);

        #endregion

        #region ���ɾ������

        /// <summary>
        /// ������ݿ������ж���
        /// </summary> 
        [DllImport("MarkEzd", EntryPoint = "lmc1_ClearEntLib", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ClearLibAllEntity();

        ///<summary>
        /// ɾ��ָ�����ƶ���
        ///<summary>
        [DllImport("MarkEzd", EntryPoint = "lmc1_DeleteEnt", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeleteEnt(string strEntName);

        /// <summary>
        /// �����ݿ�������ı�
        /// </summary> 
        [DllImport("MarkEzd", EntryPoint = "lmc1_AddTextToLib", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int AddTextToLib(string text, string EntName, double dPosX, double dPosY, double dPosZ, int nAlign, double dTextRotateAngle, int nPenNo, int bHatchText);

        [DllImport("MarkEzd", EntryPoint = "lmc1_AddCircleTextToLib", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int AddCircleTextToLib(string pStr,
                                                    string pEntName,
                                                    double dCenX,
                                                    double dCenY,
                                                    double dCenZ,
                                                    int nPenNo,
                                                    int bHatchText,
                                                    double dCirDiameter,
                                                    double dCirBaseAngle,
                                                    bool bCirEnableAngleLimit,
                                                    double dCirAngleLimit,
                                                    int nCirTextFlag);



        /// <summary>
        /// �����ݿ����һ�����߶���
        /// ע��PtBuf����Ϊ2ά����,�ҵ�һάΪ2,�� double[5,2],double[n,2],
        /// ptNumΪPtBuf����ĵ�2ά,��PtBufΪdouble[5,2]����,��ptNum=5
        /// </summary> 
        [DllImport("MarkEzd", EntryPoint = "lmc1_AddCurveToLib", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int AddCurveToLib([MarshalAs(UnmanagedType.LPArray)] double[,] PtBuf, int ptNum, string strEntName, int nPenNo);



        /// <summary>
        ///Բ�뾶
        ///���߶�������
        ///���߶���ʹ�õıʺ�
        /// </summary> 
        [DllImport("MarkEzd", EntryPoint = "lmc1_AddCircleToLib", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int lmc1_AddCircleToLib(double ptCenX, double ptCenY, double dRadius, string pEntName, int nPenNo);



        /// <summary>
        /// <summary>
        /// 
        /// �����ݿ����һ������
        /// ע��PtBuf����Ϊ2ά����,�ҵ�һάΪ2,�� double[5,2],double[n,2],
        /// ptNumΪPtBuf����ĵ�2ά,��PtBufΪdouble[5,2]����,��ptNum=5
        /// </summary> 
        [DllImport("MarkEzd", EntryPoint = "lmc1_AddPointToLib", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int AddPointToLib([MarshalAs(UnmanagedType.LPArray)] double[,] PtBuf, int ptNum, string strEntName, int nPenNo);

        /// <summary>
        /// �����ʱ�����ļ���
        /// </summary>
        /// <param name="dDelayMs">��ʱ������ʱ��</param>
        /// <returns></returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_AddDelayToLib", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int AddDelayToLib(double dDelayMs);

        /// <summary>
        /// �������ڵ��ļ���
        /// </summary>
        /// <param name="nOutPutBit">����ڹܽ�</param>
        /// <param name="bHigh">�Ƿ����Ч</param>
        /// <param name="bPulse">�Ƿ�����ģʽ</param>
        /// <param name="dPulseTimeMs">�����������</param>
        /// <returns></returns>
        [DllImport("MarkEzd", EntryPoint = "lmc1_AddWritePortToLib", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int AddWritePortToLib(int nOutPutBit, bool bHigh, bool bPulse, double dPulseTimeMs);

        /// <summary>
        /// ����ָ�������ļ�
        /// </summary> 
        [DllImport("MarkEzd", EntryPoint = "lmc1_AddFileToLib", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int AddFileToLib(string strFileName, string strEntName, double dPosX, double dPosY, double dPosZ, int nAlign, double dRatio, int nPenNo, int bHatchFile);

        #region ����

        public enum BARCODETYPE
        {
            BARCODETYPE_39 = 0,
            BARCODETYPE_93 = 1,
            BARCODETYPE_128A = 2,
            BARCODETYPE_128B = 3,
            BARCODETYPE_128C = 4,
            BARCODETYPE_128OPT = 5,
            BARCODETYPE_EAN128A = 6,
            BARCODETYPE_EAN128B = 7,
            BARCODETYPE_EAN128C = 8,
            BARCODETYPE_EAN13 = 9,
            BARCODETYPE_EAN8 = 10,
            BARCODETYPE_UPCA = 11,
            BARCODETYPE_UPCE = 12,
            BARCODETYPE_25 = 13,
            BARCODETYPE_INTER25 = 14,
            BARCODETYPE_CODABAR = 15,
            BARCODETYPE_PDF417 = 16,
            BARCODETYPE_DATAMTX = 17,
            BARCODETYPE_USERDEF = 18,
            BARCODETYPE_QRCODE = 19,
            BARCODETYPE_MICROQRCODE = 20

        };

        public const ushort BARCODEATTRIB_CHECKNUM = 0x0004;//������
        public const ushort BARCODEATTRIB_REVERSE = 0x0008;//��ת
        public const ushort BARCODEATTRIB_SHORTMODE = 0x0040;//��ά������ģʽ
        public const ushort BARCODEATTRIB_DATAMTX_DOTMODE = 0x0080;//��ά��Ϊ��ģʽ
        public const ushort BARCODEATTRIB_DATAMTX_CIRCLEMODE = 0x0100;//��ά��ΪԲģʽ
        public const ushort BARCODEATTRIB_DATAMTX_ENABLETILDE = 0x0200;//DataMatrixʹ��~
        public const ushort BARCODEATTRIB_RECTMODE = 0x0400;//��ά��Ϊ����ģʽ
        public const ushort BARCODEATTRIB_SHOWCHECKNUM = 0x0800;//��ʾУ��������
        public const ushort BARCODEATTRIB_HUMANREAD = 0x1000;//��ʾ��ʶ���ַ�
        public const ushort BARCODEATTRIB_NOHATCHTEXT = 0x2000;//������ַ�
        public const ushort BARCODEATTRIB_BWREVERSE = 0x4000;//�ڰ׷�ת
        public const ushort BARCODEATTRIB_2DBIDIR = 0x8000;//2ά��˫������

        public enum DATAMTX_SIZEMODE
        {
            DATAMTX_SIZEMODE_SMALLEST = 0,
            DATAMTX_SIZEMODE_10X10 = 1,
            DATAMTX_SIZEMODE_12X12 = 2,
            DATAMTX_SIZEMODE_14X14 = 3,
            DATAMTX_SIZEMODE_16X16 = 4,
            DATAMTX_SIZEMODE_18X18 = 5,
            DATAMTX_SIZEMODE_20X20 = 6,
            DATAMTX_SIZEMODE_22X22 = 7,
            DATAMTX_SIZEMODE_24X24 = 8,
            DATAMTX_SIZEMODE_26X26 = 9,
            DATAMTX_SIZEMODE_32X32 = 10,
            DATAMTX_SIZEMODE_36X36 = 11,
            DATAMTX_SIZEMODE_40X40 = 12,
            DATAMTX_SIZEMODE_44X44 = 13,
            DATAMTX_SIZEMODE_48X48 = 14,
            DATAMTX_SIZEMODE_52X52 = 15,
            DATAMTX_SIZEMODE_64X64 = 16,
            DATAMTX_SIZEMODE_72X72 = 17,
            DATAMTX_SIZEMODE_80X80 = 18,
            DATAMTX_SIZEMODE_88X88 = 19,
            DATAMTX_SIZEMODE_96X96 = 20,
            DATAMTX_SIZEMODE_104X104 = 21,
            DATAMTX_SIZEMODE_120X120 = 22,
            DATAMTX_SIZEMODE_132X132 = 23,
            DATAMTX_SIZEMODE_144X144 = 24,
            DATAMTX_SIZEMODE_8X18 = 25,
            DATAMTX_SIZEMODE_8X32 = 26,
            DATAMTX_SIZEMODE_12X26 = 27,
            DATAMTX_SIZEMODE_12X36 = 28,
            DATAMTX_SIZEMODE_16X36 = 29,
            DATAMTX_SIZEMODE_16X48 = 30,
        }

        /// <summary>
        /// �����ݿ�����������ı�
        /// ע�� double[] dBarWidthScale ��dSpaceWidthScale��С����Ϊ4
        /// </summary> 

        [DllImport("MarkEzd", EntryPoint = "lmc1_AddBarCodeToLib", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int AddBarCodeToLib(string strText,
            string strEntName,
            double dPosX,
            double dPosY,
            double dPosZ,
            int nAlign,
            int nPenNo,
            int bHatchText,
            BARCODETYPE nBarcodeType,
            ushort wBarCodeAttrib,
            double dHeight,
            double dNarrowWidth,
            [MarshalAs(UnmanagedType.LPArray)] double[] dBarWidthScale,
            [MarshalAs(UnmanagedType.LPArray)] double[] dSpaceWidthScale,
              double dMidCharSpaceScale,
            double dQuietLeftScale,
            double dQuietMidScale,
            double dQuietRightScale,
            double dQuietTopScale,
            double dQuietBottomScale,
            int nRow,
            int nCol,
            int nCheckLevel,
           DATAMTX_SIZEMODE nSizeMode,
            double dTextHeight,
            double dTextWidth,
            double dTextOffsetX,
            double dTextOffsetY,
            double dTextSpace,
            double dDiameter,
            string TextFontName);


        [DllImport("MarkEzd", EntryPoint = "lmc1_GetBarcodeParam", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetBarcodeParam(string pEntName,
                                                    ref ushort wBarCodeAttrib,
                                                    ref int nSizeMode,
                                                    ref int nCheckLevel,
                                                    ref int nLangPage,
                                                    ref double dDiameter,
                                                    ref int nPointTimesN,
                                                    ref double dBiDirOffset);

        [DllImport("MarkEzd", EntryPoint = "lmc1_SetBarcodeParam", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetBarcodeParam(string pEntName,
                                                    ushort wBarCodeAttrib,
                                                    int nSizeMode,
                                                    int nCheckLevel,
                                                    int nLangPage,
                                                    double dDiameter,
                                                    int nPointTimesN,
                                                    double dBiDirOffset);


        #endregion

        #endregion

        #region ��չ��

        /// <summary>
        /// ��λ��ʹ����չ��
        /// ***ʹ����չ��֮ǰ����ʹ���ȵ��ô˺�������ʼ����չ��*******
        /// </summary> 
        [DllImport("MarkEzd", EntryPoint = "lmc1_Reset", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ResetAxis(bool bEnAxis1, bool bEnAxis2);

        /// <summary>
        /// ��չ���ƶ���Ŀ��λ��
        /// axis=0��1
        /// GoalPosĿ��λ��,��λmm��inch
        /// </summary> 
        [DllImport("MarkEzd", EntryPoint = "lmc1_AxisMoveTo", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int AxisMoveTo(int axis, double GoalPos);

        /// <summary>
        /// ��չ���ԭ��(У��ԭ��)
        /// axis=0��1
        /// GoalPosĿ��λ��
        /// </summary> 
        [DllImport("MarkEzd", EntryPoint = "lmc1_AxisCorrectOrigin", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int AxisGoHome(int axis);

        /// <summary>
        /// �õ���չ��ĵ�ǰ����
        /// axis=0��1
        /// </summary> 
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetAxisCoor", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern double GetAxisCoor(int axis);

        /// <summary>
        /// ��չ���ƶ�������Ŀ��λ��
        /// axis=0��1
        /// nGoalPosĿ��λ��,��λ:����
        /// </summary> 
        [DllImport("MarkEzd", EntryPoint = "lmc1_AxisMoveToPulse", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int AxisMoveToPulse(int axis, int nGoalPos);

        /// <summary>
        /// �õ���չ��ĵ�ǰ��������
        /// axis=0��1
        /// </summary> 
        [DllImport("MarkEzd", EntryPoint = "lmc1_GetAxisCoorPulse", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetAxisCoorPulse(int axis);

        #endregion

        #region Ӳ������

        [DllImport("MarkEzd", EntryPoint = "lmc1_EnableLockInputPort", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int EnableLockInputPort(bool bLowToHigh);

        [DllImport("MarkEzd", EntryPoint = "lmc1_ClearLockInputPort", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ClearLockInputPort();

        [DllImport("MarkEzd", EntryPoint = "lmc1_ReadLockPort", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadLockPort(ref ushort data);
        #endregion

    }
    class AppSettings
    {
        //ָ��config�ļ���ȡ
        private static readonly string file = System.Windows.Forms.Application.ExecutablePath;
        private static readonly Configuration config = ConfigurationManager.OpenExeConfiguration(file);
        /// <summary>
        /// �������Ӵ�����connectionName�������������ַ���
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string connectionName)
        {
            //ָ��config�ļ���ȡ
            string connectionString = config.ConnectionStrings.ConnectionStrings[connectionName].ConnectionString.ToString();
            return connectionString;
        }
        ///<summary>
        ///���������ַ���
        ///</summary>
        ///<param name="newName">�����ַ�������</param>
        ///<param name="newConString">�����ַ�������</param>
        ///<param name="newProviderName">�����ṩ��������</param>
        public static void SetConnectionString(string name, string conString, string providerName)
        {
            bool exist = false; //��¼�����Ӵ��Ƿ��Ѿ�����
                                //���Ҫ���ĵ����Ӵ��Ѿ�����
            if (config.ConnectionStrings.ConnectionStrings[name] != null)
            {
                exist = true;
            }
            // ������Ӵ��Ѵ��ڣ�����ɾ����
            if (exist)
            {
                config.ConnectionStrings.ConnectionStrings.Remove(name);
            }
            //�½�һ�������ַ���ʵ��
            ConnectionStringSettings mySettings = new ConnectionStringSettings(name, conString, providerName);
            // ���µ����Ӵ���ӵ������ļ���
            config.ConnectionStrings.ConnectionStrings.Add(mySettings);
            // ����������ļ������ĸ���
            config.Save(ConfigurationSaveMode.Modified);
            // ǿ���������������ļ���ConnectionStrings���ý�
            ConfigurationManager.RefreshSection("connectionStrings");
        }
        ///<summary>
        ///��ȡ*.exe.config�ļ���appSettings���ýڵ��valueֵ
        ///</summary>
        ///<param name="strKey"></param>
        ///<returns></returns>
        public static string GetValue(string strKey)
        {
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                if (key == strKey)
                {
                    return config.AppSettings.Settings[strKey].Value.ToString();
                }
            }
            return null;
        }
        ///<summary>
        ///����*.exe.config�ļ���appSettings�ڵ��ֵ
        ///</summary>
        ///<param name="key"></param>
        ///<param name="newValue"></param>
        public static void SetValue(string key, string value)
        {
            //�������ļ�����Ӽ�ֵ�ԣ������޸ģ��������
            if (!ConfigurationManager.AppSettings.AllKeys.Contains(key))
            {
                config.AppSettings.Settings.Add(key, value);
                config.Save();
            }
            else
            {
                config.AppSettings.Settings[key].Value = value;
                config.Save();
            }
            ConfigurationManager.RefreshSection("appSettings");
        }
    }

}
