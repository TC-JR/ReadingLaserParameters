using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SDKDemoCS
{
    /// <summary>
    /// 八思量SDK定义
    /// </summary>
    public class BslSDK
    {
        #region 设备
        /// <summary>
        /// 初始化全部lmc控制卡
        /// </summary>
        /// <param name="dwWndHanle">指拥有用户输入焦点的窗口，用于检测用户暂停消息</param>
        /// <returns></returns>
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode InitDevices(/*Int32 dwWndHanle*/);

        //获取所有的设备ID
        [DllImport("MarkSDK.dll", EntryPoint = "GetAllDevices2", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode GetAllDevices([Out] STU_DEVIP[] vDevID, ref int nDevCount);

        //获取焊接卡状态
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode GetDevOffilineState([MarshalAs(UnmanagedType.LPWStr)]string strDevId, out bool bOffLine);

        //切换选中焊接卡的状态
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode SwitchDevOffilineMode([MarshalAs(UnmanagedType.LPWStr)]string strDevId);

        //关闭所有控制卡
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode CloseAllDevice();

        #endregion 设备

        #region 焊接

        //焊接一个焊接卡的关联文件
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode MarkByDeviceId([MarshalAs(UnmanagedType.LPWStr)]string strDevId);

        //焊接一个焊接卡的关联文件扩展
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode MarkByDeviceIdEx([MarshalAs(UnmanagedType.LPWStr)]string strDevId, int nMarkCount, bool bContinue);

        //焊接一个焊接卡的关联文件扩展
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode StopMark([MarshalAs(UnmanagedType.LPWStr)]string strDevId);

        //所有图元范围框红光一次
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode RedLightMark([MarshalAs(UnmanagedType.LPWStr)]string strDevId, bool bContinue);

        //使用一个设备显示红光
        //szDevId-设备ID
        //输入参数: strEntName 要加工的指定对象的名称
        //int[] vShpIndex 要红光的图元序号
        //int iShpCount 要红光的图元个数
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode RedLightMarkByEnt2([MarshalAs(UnmanagedType.LPWStr)] string strDevID,
            [MarshalAs(UnmanagedType.LPWStr)] string szFileName, int[] vShpIndex, int iShpCount, bool bCountinue);

        //设置旋转角度、偏移、旋转中心
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode SetOffsetValues(double r, double dx, double dy, double cx, double cy,   
            [MarshalAs(UnmanagedType.LPWStr)]string strDevId); 

        //焊接点
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode MarkPoint([MarshalAs(UnmanagedType.LPWStr)]string strDevId,
            double x, double y, double delay, int pen);      

        //焊接一组点
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode MarkPoints2([MarshalAs(UnmanagedType.LPWStr)] string strDevID,
            POINTF[] vPoints, int iPtCount, int nPenNum);

        //焊接一组线段 统一笔号
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode MarkLines2([MarshalAs(UnmanagedType.LPWStr)] string strDevID, 
            POINTF[] lines, int iLineCount, int[] iPtCount, int penNum);

        //焊接当前数据库里的指定对象
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode MarkEntity([MarshalAs(UnmanagedType.LPWStr)] string strDevID, 
            [MarshalAs(UnmanagedType.LPWStr)] string szFileName, [MarshalAs(UnmanagedType.LPWStr)] string strEntName);

        //获取标刻路径数据
        /**
          * 获取文件中所有打标路径数据 for C#
          * szDevId：设备ID
          * szDocName: 文件名
          * bRotOffset: 是否做偏移旋转
          * r   旋转角度
          * dx  X偏移
          * dy  Y偏移
          * cx  旋转中心X坐标
          * cy  旋转中心Y坐标
          * nCount 输出数目
          * pMarkPaths：输出标刻数据
        */
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode GetMarkDataPaths2([MarshalAs(UnmanagedType.LPWStr)] string szDevId, 
            [MarshalAs(UnmanagedType.LPWStr)] string szDocName, bool bRotOffset, double r, double dx, double dy, 
            double cx, double cy, ref int nCount, IntPtr pMarkPaths, ref PENPAR penpar);

        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode GetMarkDataPaths2([MarshalAs(UnmanagedType.LPWStr)] string szDevId,
           [MarshalAs(UnmanagedType.LPWStr)] string szDocName, bool bRotOffset, double r, double dx, double dy,
           double cx, double cy, ref int nCount, [Out] PathDataShape[] MarkPaths, ref PENPAR penpar);

        //标刻路径
        /**
          * 标刻路径点 for C#
          * szDevId：设备ID
          * nCount 数目
          * pMarkPaths：标刻数据
        */
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode MarkDocDataPaths2([MarshalAs(UnmanagedType.LPWStr)] string szDevId, 
            int nCount, PathDataShape[] pMarkPaths, PENPAR penpar, [MarshalAs(UnmanagedType.LPWStr)] string szParName);
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode MarkDocDataPaths2([MarshalAs(UnmanagedType.LPWStr)] string szDevId,
           int nCount, IntPtr pMarkPaths, PENPAR penpar, [MarshalAs(UnmanagedType.LPWStr)] string szParName);

        #endregion 焊接

        #region 文档

        //加载图形文件
        //输入参数: strFileName  图形文件名称
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode LoadDataFile([MarshalAs(UnmanagedType.LPWStr)] string strFileName);

        //卸载图形文件
        //输入参数: strFileName  图形文件名称
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode UnloadDataFile([MarshalAs(UnmanagedType.LPWStr)] string strFileName);

        //新建文件
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode NewFile([MarshalAs(UnmanagedType.LPWStr)] string szFileName); //图形文件名     

        //保存文件
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode SaveEntLibToFile([MarshalAs(UnmanagedType.LPWStr)] string szFileName);

        //将指定的图形数据文件关联到设备
        //输入参数: strFileName  图形文件名称
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode AppendFileToDevice([MarshalAs(UnmanagedType.LPWStr)] string strFileName,
                                                      [MarshalAs(UnmanagedType.LPWStr)] string strDevId);

        //得到指定文档的所有图形的中点
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode GetCenterValues([MarshalAs(UnmanagedType.LPWStr)] string strFileName,
                                                         out double cx, out double cy);

        //显示文档的图元内容 width是显示的宽，height是显示的高。
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern IntPtr DrawFileInImg([MarshalAs(UnmanagedType.LPWStr)] string strFileName, int dwWidth, int dwHeight, bool bDrawAxis);

        //预览图形文件-----bDrawGlvArea为：true最大显示振镜区域，false为最大图形显示。并支持缩放
        //输入参数: strFileName  图形文件名称
        //			nWidth nHeight 图形显示的范围大小
        //          fDelta 放缩比，调节放缩的尺寸
        //          bDrawGlvArea  是否显示振镜区域线
        //			bDrawAxis   是否绘制轴线 
        //			nBlankSize  两边留白像素点
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern IntPtr DrawFileInImgEx([MarshalAs(UnmanagedType.LPWStr)] string strFileName, Int32 dwWidth,
            Int32 dwHeight, float fDelta, bool bDrawGlvArea, bool bDrawAxis, UInt32 nBlankSize, bool bDrawSelectRect);

        //得到对象总数
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode GetEntityCount([MarshalAs(UnmanagedType.LPWStr)] string szFileName); //图形文件名     

        //获取某个打开的文件中的图形列表
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode GetShapesInFile2([MarshalAs(UnmanagedType.LPWStr)] string szFileName,
            [Out] ShapeInfo2[] vShapes, int iListCount);

        //移动图元位置
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode MoveEntityOrderByIndex([MarshalAs(UnmanagedType.LPWStr)] string szFileName,
            int iIndex, int iOrderOffset);

        //取反图元位置
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode ReverseAllEntOrder([MarshalAs(UnmanagedType.LPWStr)] string szFileName);

        #endregion 文档

        #region 参数

        //设置对应笔号参数
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode SetPenPar(ref PENPAR penpar,
            [MarshalAs(UnmanagedType.LPWStr)] string strFileName,  int nPenNo);

        //获取笔号参数
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode GetPenPar(ref PENPAR penpar,
             [MarshalAs(UnmanagedType.LPWStr)] string strFileName, uint nPenNo);

        //设置打点时间
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode SetPointTime([MarshalAs(UnmanagedType.LPWStr)] string strFileName,
            float pointTime);

        //获取打点时间
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode GetPointTime([MarshalAs(UnmanagedType.LPWStr)] string strFileName,
            out float pointTime);

        //关联设备和参数，如果不调用此函数，则会使用默认的default参数
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode AssocDevPara(
            [MarshalAs(UnmanagedType.LPWStr)] string strDevId,
            [MarshalAs(UnmanagedType.LPWStr)] string strParName);

        //通过图元名称获取图元笔号
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode GetShapePenNoByEntName([MarshalAs(UnmanagedType.LPWStr)] string strFileName,
            [MarshalAs(UnmanagedType.LPWStr)] string szEntName, ref UInt32 nPenNo);

        //获取所有参数
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode GetAllPara2([Out] STU_PARAM[] vDevID, ref int nParCount);

        //显示参数对话框
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode DisplayDevCfgDlg([MarshalAs(UnmanagedType.LPWStr)] string strDevID);

        #endregion 参数

        #region 端口
        /// <summary>
        /// 读取焊接卡的输入端口状态
        /// </summary>
        /// <param name="strDevID"></param>
        /// <param name="data">输入端口数据</param>
        /// <returns></returns>
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode ReadInPort([MarshalAs(UnmanagedType.LPWStr)] string strDevID, out UInt16 data);

        //写焊接卡的输出端口
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode WriteOutPort([MarshalAs(UnmanagedType.LPWStr)] string strDevID,
                            UInt16 portNum,   //输出端口, 目前有效端口为0-7
                            UInt16 nMode,     //输出模式, 0-电平，1-脉冲，2-跳变
                            UInt16 nLevel,    //输出电平, 0-低电平，1-高电平
                            UInt32 nPulse);   //脉冲周期 ,us， 0-65535us,当 nMode=1脉冲模式时有效

        /// <summary>
        /// 在程序中调用 GetOutPort来读入当前输出端口的数据。Bit0是In0
        /// </summary>
        /// <param name="strDevID"></param>
        /// <param name="data">当前输出端口的数据</param>
        /// <returns></returns>
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode ReadOutPort([MarshalAs(UnmanagedType.LPWStr)] string strDevID, 
            out UInt16 data);

        #endregion

        #region 图元绘制

        //增加点
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode AddPointToFile([MarshalAs(UnmanagedType.LPWStr)] string szFileName,
            IntPtr ptBuf, int ptNum, [MarshalAs(UnmanagedType.LPWStr)] string pEntName, int nPenNo);

        //增加直线
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode AddLinesToFile([MarshalAs(UnmanagedType.LPWStr)] string szFileName,
            IntPtr ptBuf, int ptNum, [MarshalAs(UnmanagedType.LPWStr)] string pEntName, int nPenNo);

        //增加贝塞尔曲线
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode AddBezierCurveToFile([MarshalAs(UnmanagedType.LPWStr)] string szFileName,
            IntPtr ptBuf, int ptNum, [MarshalAs(UnmanagedType.LPWStr)] string pEntName, int nPenNo);

        //增加圆
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode AddCircleToFile([MarshalAs(UnmanagedType.LPWStr)] string szFileName,
            [MarshalAs(UnmanagedType.LPWStr)] string pEntName, double dPosX, double dPosY, double dPosZ,
             double dRadius, double dRotateAngle, int nPenNo, bool bFill);

        //增加椭圆
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode AddEllipseToFile([MarshalAs(UnmanagedType.LPWStr)] string szFileName,
            [MarshalAs(UnmanagedType.LPWStr)] string pEntName, double dPosX, double dPosY, double dPosZ,
             double dLongAxis, double dMinorAxis, double dRotateAngle, int nPenNo, bool bFill);

        //增加矩形
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode AddRectToFile([MarshalAs(UnmanagedType.LPWStr)] string szFileName,
            [MarshalAs(UnmanagedType.LPWStr)] string pEntName, IntPtr ptBuf, int[] nRound,
            double dRotateAngle, int nPenNo, bool bFill);

        //增加多边形
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode AddPolygonToFile([MarshalAs(UnmanagedType.LPWStr)] string szFileName,
            [MarshalAs(UnmanagedType.LPWStr)] string pEntName, IntPtr ptBuf,
            int nBorder, int nPenNo, bool bFill);

        //增加螺旋线
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode AddScrewToFile(ref SCREW_PAR vScrewPar,
            [MarshalAs(UnmanagedType.LPWStr)] string szFileName,
            [MarshalAs(UnmanagedType.LPWStr)] string pEntName,
            IntPtr ptBuf, int nPenNo);

        //增加延时器
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode AddDelayToFile([MarshalAs(UnmanagedType.LPWStr)] string szFileName,
            [MarshalAs(UnmanagedType.LPWStr)] string pEntName, POINTF point, int time);

        //增加输入口
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode AddInportToFile([MarshalAs(UnmanagedType.LPWStr)] string szFileName,
            [MarshalAs(UnmanagedType.LPWStr)] string pEntName, POINTF point, int[] iPortState);

        //增加输出口
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode AddOutportToFile([MarshalAs(UnmanagedType.LPWStr)] string szFileName,
            [MarshalAs(UnmanagedType.LPWStr)] string pEntName, POINTF point, int iOutPortNo, int iSignal,
            int iPulse, int iPulseWidth);

        #endregion 图元绘制

        #region 图形编辑

        //移动指定对象相对坐标
        //iIndex 对象索引号
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode MoveEntityRelByIndex([MarshalAs(UnmanagedType.LPWStr)] string strFileName, 
            int iIndex, double dMovex, double dMovey);

        //移动指定对象相对坐标
        //strEntName 对象名称
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode MoveEntityRelByName([MarshalAs(UnmanagedType.LPWStr)] string strFileName, 
            [MarshalAs(UnmanagedType.LPWStr)] string strEntName, double dMovex, double dMovey);

        //移动指定对象绝对坐标
        //iIndex 对象索引号
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode MoveEntityAbsByIndex([MarshalAs(UnmanagedType.LPWStr)] string strFileName, 
            int iIndex, double dPtx, double dPty);

        //移动指定对象绝对坐标
        //strEntName 对象名称
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode MoveEntityAbsByName([MarshalAs(UnmanagedType.LPWStr)] string strFileName,
            [MarshalAs(UnmanagedType.LPWStr)] string strEntName, double dPtx, double dPty);

        //缩放指定对象，缩放中心坐标(dCenx，dCeny)  dScaleX=X方向缩放比例  dScaleY=Y方向缩放比例
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode ScaleEntityByIndex([MarshalAs(UnmanagedType.LPWStr)] string strFileName,
            int iIndex, double dCenx, double dCeny, double dScaleX, double dScaleY);

        //缩放指定对象，缩放中心坐标(dCenx，dCeny)  dScaleX=X方向缩放比例  dScaleY=Y方向缩放比例
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode ScaleEntityByName([MarshalAs(UnmanagedType.LPWStr)] string strFileName,
            [MarshalAs(UnmanagedType.LPWStr)] string strEntName, double dCenx, double dCeny, double dScaleX, double dScaleY);

        //旋转指定对象  
        //iIndex对象索引号
        //(dCenx，dCeny) 旋转中心坐标
        //dAngle=旋转角度(逆时针为正，单位为度) 
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode RotateEntityByIndex([MarshalAs(UnmanagedType.LPWStr)] string strFileName,
            int iIndex, double dCenx, double dCeny, double dAngle);

        //旋转指定对象  
        //pEntName 对象名称
        //(dCenx，dCeny) 旋转中心坐标
        //dAngle = 旋转角度(逆时针为正，单位为度)  
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode RotateEntityByName([MarshalAs(UnmanagedType.LPWStr)] string strFileName,
            [MarshalAs(UnmanagedType.LPWStr)] string strEntName, double dCenx, double dCeny, double dAngle);

        //倾斜指定对象  
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode SlopeEntityByIndex([MarshalAs(UnmanagedType.LPWStr)] string strFileName, 
            int iIndex, double dCenx, double dCeny, double dx, double dy);

        //倾斜指定对象  
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode SlopeEntityByName([MarshalAs(UnmanagedType.LPWStr)] string strFileName,
            [MarshalAs(UnmanagedType.LPWStr)] string strEntName, double dCenx, double dCeny, double dx, double dy);

        //镜像指定对象，镜像中心坐标(dCenx，dCeny)  bMirrorX=TRUE X方向镜像  bMirrorY=TRUE Y方向镜像
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode MirrorEntityByIndex([MarshalAs(UnmanagedType.LPWStr)] string strFileName,
            int iIndex, double dCenx, double dCeny, bool bMirrorX, bool bMirrorY);

        //镜像指定对象，镜像中心坐标(dCenx，dCeny)  bMirrorX=TRUE X方向镜像  bMirrorY=TRUE Y方向镜像
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode MirrorEntityByName([MarshalAs(UnmanagedType.LPWStr)] string strFileName,
            [MarshalAs(UnmanagedType.LPWStr)] string strEntName, double dCenx, double dCeny, bool bMirrorX, bool bMirrorY);

        //复制选定图元
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode CopyEntByIndex([MarshalAs(UnmanagedType.LPWStr)] string strFileName, 
            int iIndex, [MarshalAs(UnmanagedType.LPWStr)] string pNewEntName);

        //复制选定图元
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode CopyEntByName([MarshalAs(UnmanagedType.LPWStr)] string strFileName, 
            [MarshalAs(UnmanagedType.LPWStr)] string strEntName, [MarshalAs(UnmanagedType.LPWStr)] string pNewEntName);

        //删除当前数据库里的指定文本对象
        //输入参数: strFileName		图形文件名称
        //			strEntName      要删除对象的名称
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode DeleteEntityByName([MarshalAs(UnmanagedType.LPWStr)] string strFileName, 
            [MarshalAs(UnmanagedType.LPWStr)] string strEntName);

        //删除当前数据库里的全部对象
        //输入参数: strFileName		图形文件名称
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode DeleteAllEntityByName([MarshalAs(UnmanagedType.LPWStr)] string strFileName);

        //清除对象库里所有数据
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode ClearEntityLib([MarshalAs(UnmanagedType.LPWStr)] String strFileName);

        //设置填充参数
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode SetFillParam(ref FillPara fillPar);

        //获取图元填充参数
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode GetEntFillParam([MarshalAs(UnmanagedType.LPWStr)] string strFileName, 
            [MarshalAs(UnmanagedType.LPWStr)] string strEntName, ref FillPara fillPar);

        //生成填充线
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode GetFillData(POINTF[] outline, int[] outlinepnts, int outlinecount,
            FillPara fillPar, [Out] POINTF[] fillLines, ref int filllinecount, [Out] int[] filllinepnts);

        //填充对象
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode FillEntity([MarshalAs(UnmanagedType.LPWStr)] string strFileName,
            [MarshalAs(UnmanagedType.LPWStr)] string strEntName, [MarshalAs(UnmanagedType.LPWStr)] string strEntNameNew);

        //删除填充
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode UnFillEnt([MarshalAs(UnmanagedType.LPWStr)] string strFileName,
            [MarshalAs(UnmanagedType.LPWStr)] string strEntName, bool bUnGroup);

        //填充单个对象
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode FillSingleEntity([MarshalAs(UnmanagedType.LPWStr)] string strFileName, 
            int nShapeIndex, [MarshalAs(UnmanagedType.LPWStr)] string pEntNameNew);

        //删除单个填充
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode UnFillSingleEnt([MarshalAs(UnmanagedType.LPWStr)] string strFileName, 
            int nShapeIndex, bool bUnGroup);

        #endregion 图形编辑

        #region 图元属性

        //得到指定对象的最大最小坐标。
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode GetEntSizeByIndex([MarshalAs(UnmanagedType.LPWStr)] string strFileName, //图形文件名
                            int iIndex, //对象在文件图元列表中的索引号
                            ref double dMinx,   //最小x坐标
                            ref double dMiny,   //最小y坐标
                            ref double dMaxx,   //最大x坐标
                            ref double dMaxy,   //最大y坐标
                            ref double dZ);     //对象的Z 坐标

        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode GetEntSizeByName([MarshalAs(UnmanagedType.LPWStr)] string strFileName,  //图形文件名
                            [MarshalAs(UnmanagedType.LPWStr)] string strEntName,     //对象名称
                            ref double dMinx,   //最小x坐标
                            ref double dMiny,   //最小y坐标
                            ref double dMaxx,   //最大x坐标
                            ref double dMaxy,   //最大y坐标
                            ref double dZ);     //对象的Z 坐标

        //得到指定序号的对象名称
        //输入参数: nEntityIndex 指定对象的序号(围: 0 － (lmc1_GetEntityCount()-1))
        //输出参数: szEntName 对象的名称
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode GetEntityNameByIndex2([MarshalAs(UnmanagedType.LPWStr)] string strFileName,
            Int32 nEntityIndex, ref ShapeName strEntName);

        //设置指定序号的实体名
        //输入参数: nEntityIndex 指定对象的序号(围: 0 － (lmc1_GetEntityCount()-1))
        //输出参数: szEntName 对象的名称
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode SetEntityNameByIndex([MarshalAs(UnmanagedType.LPWStr)] string strFileName,
            Int32 nEntityIndex, [MarshalAs(UnmanagedType.LPWStr)] string strEntName);

        //设置指定对象的名称
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode ChangeEntName([MarshalAs(UnmanagedType.LPWStr)] string strFileName,
           [MarshalAs(UnmanagedType.LPWStr, SizeConst = DEFINE.BUFFER_SIZE)] StringBuilder szOldEntName, 
           [MarshalAs(UnmanagedType.LPWStr, SizeConst = DEFINE.BUFFER_SIZE)] StringBuilder szNewEntName);

        #endregion 图元属性

        #region 校正

        //修改当前数据库中的手工校正参数
        //输入参数：szParName  将要设置的参数名称
        //输入参数: dScaleX  X轴方向的放缩比例
        //输入参数: dScaleY  Y轴方向的放缩比例
        //输入参数: dDistorX  X轴方向的桶形失真系数
        //输入参数: dDistorY  Y轴方向的桶形失真系数
        //输入参数: dHorverX  X轴方向的平行四边形失真系数
        //输入参数: dHorverY  Y轴方向的平行四边形失真系数
        //输入参数: dTrapedistorX  X轴方向的梯形失真系数
        //输入参数: dTrapedistorY  Y轴方向的梯形失真系数
        //输入参数: bSaveToFile  是否保存到标准配置文件(BslCAD.cfg)
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode ModifyManualCorPara([MarshalAs(UnmanagedType.LPWStr)] string szParName,
            double dScaleX, double dScaleY, double dDistorX, double dDistorY, double dHorverX, double dHorverY,
            double dTrapedistorX, double dTrapedistorY, bool bSaveToFile);

        //获取当前数据库中的手工校正参数
        //输入参数：szParName  将要设置的参数名称
        //输出参数: dScaleX  X轴方向的放缩比例
        //输出参数: dScaleY  Y轴方向的放缩比例
        //输出参数: dDistorX  X轴方向的桶形失真系数
        //输出参数: dDistorY  Y轴方向的桶形失真系数
        //输出参数: dHorverX  X轴方向的平行四边形失真系数
        //输出参数: dHorverY  Y轴方向的平行四边形失真系数
        //输出参数: dTrapedistorX  X轴方向的梯形失真系数
        //输出参数: dTrapedistorY  Y轴方向的梯形失真系数
        [DllImport("MarkSDK.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern BslErrCode GetManualCorPara([MarshalAs(UnmanagedType.LPWStr)] string szParName,
            ref double dScaleX, ref double dScaleY, ref double dDistorX, ref double dDistorY, ref double dHorverX,
            ref double dHorverY, ref double dTrapedistorX, ref double dTrapedistorY);

        #endregion 校正

    }

    #region 错误码
    public enum BslErrCode
    {
        WRONGPARAM = -1, //传入的参数错误
        SUCCESS = 0,            //成功
        BSLCADRUN = 1,          //发现BslCAD在运行
        NOFINDCFGFILE = 2,      //找不到BslCAD.CFG
        FAILEDOPEN = 3,         //打开LMC1失败
        NODEVICE = 4,           //没有有效的lmc1设备
        HARDVER = 5,            //lmc1版本错误
        DEVCFG = 6,             //找不到设备配置文件
        STOPSIGNAL = 7,         //报警信号
        USERSTOP = 8,           //用户停止
        UNKNOW = 9,             //不明错误
        OUTTIME = 10,           //超时
        NOINITIAL = 11,         //未初始化
        READFILE = 12,          //读文件错误
        OWRWNDNULL = 13,        //窗口为空
        NOFINDFONT = 14,        //找不到指定名称的字体
        PENNO = 15,             //错误的笔号
        NOTTEXT = 16,           //指定名称的对象不是文本对象
        SAVEFILE = 17,          //保存文件失败
        NOFINDENT = 18,         //找不到指定对象
        STATUE = 19,            //当前状态下不能执行此操作
        LOADNEWFILE = 20, //加载振镜校正文件失败
        INCORRECTCALPOINT = 21,  //检定点数不正确，必须超过3x3点
        INCORRECTFILELINE = 22,  //文件行数不对

        OPENVEC_FAIL = 100, //打开向量文件失败
    }

    #endregion 错误码

    #region 结构体

    //设备ID
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct STU_DEVIP
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        public byte[] wszDevName;
    }

    //图形的信息结构体
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ShapeInfo2
    {
        public uint nShapeIndex;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] wszShapeName;
        public int iShapeType;
    }

    //线焊波形参数
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct LINEWAVE_PAR
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public int[] vIntLineWaveStartTime;      //线焊波形起始段时间

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public float[] vIntLineWaveStartPower;   //线焊波形起始段功率

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public int[] vIntLineWaveEndTime;        //线焊波形结束段时间

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public float[] vIntLineWaveEndPower;     //线焊波形结束段功率

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public int[] vIntLineWaveStartTimeDA2;   //DA2线焊波形起始段时间

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public float[] vIntLineWaveStartPowerDA2;    //DA2线焊波形起始段功率

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public int[] vIntLineWaveEndTimeDA2; //DA2线焊波形结束段时间

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public float[] vIntLineWaveEndPowerDA2;  //DA2线焊波形结束段功率
        public int iLineWaveStartNum;              //线焊波形起始段节点数
        public int iLineWaveEndNum;                //线焊波形结束段节点数
        public int iLineWaveStartNumDA2;           //DA2线焊波形起始段节点数
        public int iLineWaveEndNumDA2;         //DA2线焊波形结束段节点数
        public bool bEnableLineWave;               //使能线焊波形

        public void init()
        {
            iLineWaveStartNum = 0;
            iLineWaveEndNum = 0;
            iLineWaveStartNumDA2 = 0;
            iLineWaveEndNumDA2 = 0;
            bEnableLineWave = false;
        }
    };

    //摆动参数
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct WOBBLE_PAR
    {
        public bool WOBBLE;                    //是否摆动
        public bool WOBBLESHOWROUTE;       //显示抖动路线
        public float WOBBLEDIAMETER;           //抖动直径
        public float WOBBLEDISTANCE;           //抖动间距
        public int WOBBLE_TYPE;            //抖动类型：0-圆形抖动；1-椭圆形抖动；2-正弦形抖动；3-立8螺旋；4-横8螺旋
        public float WOBBLE_Ellipse_A;     //椭圆长轴长度
        public float WOBBLE_Ellipse_B;     //椭圆短轴长度
        public float WOBBLE_Sin_Amplitude; //正弦振幅长度
        public float WOBBLE_Sin_Cycle;     //正弦周期长度
        public float WOBBLE_SmoothPar;     //椭圆及正弦抖动时的曲线平滑系数，取值范围[0,1]
        public float WOBBLE_Space;         //8字间距
        public float WOBBLE_Height;            //8字高
        public float WOBBLE_Width;         //8字宽

        public void init()
        {
            WOBBLE = false;
            WOBBLESHOWROUTE = false;
            WOBBLEDIAMETER = 1;
            WOBBLEDISTANCE = 1;
            WOBBLE_TYPE = 0;
            WOBBLE_Ellipse_A = 1;
            WOBBLE_Ellipse_B = 1;
            WOBBLE_Sin_Amplitude = 1;
            WOBBLE_Sin_Cycle = 1;
            WOBBLE_SmoothPar = 0.2f;
            WOBBLE_Space = 1;
            WOBBLE_Height = 1;
            WOBBLE_Width = 1;
        }
    };

    //引线参数
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct LEAD_PAR
    {
        public bool bLeadEnable;               //使能引线
        public float fLeadStartDistance;       //引入线长度
        public float fLeadEndDistance;     //引出线长度
        public float fLeadStartAngle;          //引入线角度
        public float fLeadEndAngle;            //引出线角度

        public void init()
        {
            bLeadEnable = false;
            fLeadStartDistance = 0;
            fLeadEndDistance = 0;
            fLeadStartAngle = 0;
            fLeadEndAngle = 0;
        }
    };

    //笔号参数
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct PENPAR
    {				 
        public int nMarkLoop;//加工次数
        public float dMarkSpeed;//焊接速度mm/s
        public float dPowerRatio;//功率百分比(0-100%)
        public float dDA2;//功率DA2百分比(0-100%)	
        public int nFreq;//频率HZ
        public int nQPulseWidth;//Q脉冲宽度us	
        public int nStartTC;//开始延时us
        public int nLaserOffTC;//激光关闭延时us 
        public int nEndTC;//结束延时us
        public int nPolyTC;//拐角延时us   

        public LINEWAVE_PAR lineWavePar;//线焊波形参数
        public WOBBLE_PAR wobblePar;//摆动参数
        public LEAD_PAR leadPar;//引线参数

        public void init()
        {
            nMarkLoop = 1;
            dMarkSpeed = 2000;
            dPowerRatio = 20;
            dDA2 = 20;
            nFreq = 300;
            nQPulseWidth = 50;
            nStartTC = 100;
            nLaserOffTC = 100;
            nEndTC = 100;
            nPolyTC = 100;        
        }
    };

    //螺旋线属性
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct SCREW_PAR
    {
        public UInt32 nType;//控制螺距是逐渐增大，还是逐渐减小
        public UInt32 nDir;//方向：0-逆时针/由内向外； 1-顺时针/由外向内
        public float fMinRadius;//内部最小半径
        public float fMinGap;
        public float fMaxGap;
        public float fGapStep;
        public UInt32 nOutCount;
        public UInt32 nInCount;
        public int nPenNum;
        public bool bEnable;//使能标志
        public int nLoopCount;//使能循环次数

        public void init()
        {
            nType = 1;
            nDir = 1;
            fMinRadius = 1;
            fMinGap = 0.5f;
            fMaxGap = 1;
            fGapStep = 0.5f;
            nOutCount = 0;
            nInCount = 0;
            nPenNum = 0;
            bEnable = false;
            nLoopCount = 1;
        }
    }

    //点
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct POINTF
    {
        public float x;
        public float y;
    };

    //宏定义
    class DEFINE
    {
        public const int MAX_SHAPE_COUNT = 256; //最大图元数量
        public const int BUFFER_SIZE = 256;//缓冲区大小
        public const double PI = 3.1415926;     //圆周率
        public const int MAX_SHAPE_FILL_COUNT = 4; //最大支持四层填充
        public const int MAX_SHAPE_LINE_COUNT = 500; //最大支持路径行数
        public const int MAX_SHAPE_POINT_COUNT = 500; //每行最大支持点数
    }

    //填充类型
    public enum FILLTYPE
    {
        FT_CIRCULAR = 0,        /* 环形填充 */
        FT_SINGLE_LINE,         /* 弓形, 在单个连通区是不断开 */
        FT_SINGLE_LINE_BREAK,   /* 弓形，跨越两个不相连的图块时，中间会断开*/
        FT_MULTI_LINE,          /* 多线，单向填充，各线段在两端不相连*/
        FT_MULTI_LINE_TWO_DIR	/* 多线，双向填充，各线段在两端不相连，可减少空跳时间*/
    };

    //图元填充参数
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ShapeFillPara
    {
        public FILLTYPE m_nFillType;	//填充类型, 
        public int m_nExecuteType;		//多个图形的运算方式，0=异或 1=交  2=并 3=差，
        public int m_nIndex;			//第几个填充
        public bool m_bEnable;			//使能当前填充
        public bool m_bRoundInvert;
        public double m_fLineSpacing;	//线间距
        public double m_fMargin;        // 边距

        // 以下属性对环形填充无效的
        public bool m_bWholeConsider;  /* 整体计算，当环形填充时无效*/
        public bool m_bAlongBorder; /* 绕边走一次，当环形填充时无效*/
        public double m_fAngle;  // 线条的角度，对环形无效
        public int m_nPenNum;      //笔号
        public UInt64 m_cPenColor; //颜色
        public UInt32 m_nCircularCount; // 边界环数，是除绕边走一圈以外的的环,对环形填充无效
        public double m_fCircularGap;  // 环间距，
        public double m_fInnerSpacing;   //直线缩进，是环与绕边走一圈里面的
        // 注意：环与绕边走一圈的区别：绕边走一圈与填充线条是没有间距的。	
        public bool m_bArrangeEqually; //平均分布各条，如果为false,则以下属性有效
        public double m_fStartPreserve;    // 开始保留
        public double m_fEndPreserve;		//结束保留
        public bool m_fill_rotate;		//自动旋转角度标刻
        public double m_fRotateAngle;	//旋转角度

        public void init()
        {
            m_bEnable = false;
            m_bWholeConsider = true;
            m_bAlongBorder = false;
            m_fAngle = 0;
            m_nPenNum = 0;
            m_fLineSpacing = 0.06;
            m_bArrangeEqually = false;
            m_fMargin = 0;
            m_fStartPreserve = 0;
            m_fEndPreserve = 0;
            m_fInnerSpacing = 0;
            m_nCircularCount = 0;
            m_fCircularGap = 0.5;
            m_bRoundInvert = false;
            m_nFillType = 0;
            m_nExecuteType = 0;
            m_cPenColor = 0; // RGB(0, 0, 0);
        }
    };

    //填充参数
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct FillPara
    {
        /*使能轮廓和/或绕边走一次：
	     * 0:无轮廓，无绕边走一次；1:有轮廓无绕边；2：无轮廓，有绕边；3:有轮廓有绕边
	     * 当有轮廓且优先轮廓时，轮廓在填充线前，若不优先轮廓，则轮廓在填充线后；
	     * 绕边一次的标刻，总是在填充之后。
	     */
        public int m_bOutLine;
        public bool m_bOutLineFirst;	//是否先标刻轮廓
        public bool m_bKeepSeperate;   //保持填充对象的独立
        public bool m_bDelUngroup;		//删除填充时是否解散群组
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DEFINE.MAX_SHAPE_FILL_COUNT)]
        public ShapeFillPara[] m_arrPar;   //多组参数
        public void init()
        {
            m_bOutLine = 1;
            m_bOutLineFirst = true;
            m_bKeepSeperate = false;
            m_bDelUngroup = true;
            bool bFirstParEnabled = true;

            m_arrPar = new ShapeFillPara[DEFINE.MAX_SHAPE_FILL_COUNT];
            for (int i = 0; i < DEFINE.MAX_SHAPE_FILL_COUNT; i++)
            {
                m_arrPar[i].init();
                m_arrPar[i].m_bEnable = bFirstParEnabled;
                m_arrPar[i].m_nPenNum = 0;
                m_arrPar[i].m_nIndex = i;
                bFirstParEnabled = false;
            }
        }
    };

    //图元对象名称
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ShapeName
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DEFINE.BUFFER_SIZE)]
        public byte[] wszShapeName;
    };

    //参数名
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct STU_PARAM
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        public byte[] wszParaName;
    };

    //路径点数据
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct LineDataShape
    {
        public int nPtCount;    //行数   点数

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DEFINE.MAX_SHAPE_POINT_COUNT)]
        public POINTF[] pPoint;   //点

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            this.nPtCount = 0;

            for (int i = 0; i < DEFINE.MAX_SHAPE_POINT_COUNT; i++)
            {
                pPoint[i].x = 0.0F;
                pPoint[i].y = 0.0F;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="nCnt">点阵数</param>
        public LineDataShape(int nCnt)
        {
            this.nPtCount = nCnt;

            pPoint = new POINTF[DEFINE.MAX_SHAPE_POINT_COUNT];

            Init();
        }
    };

    //路径数据
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct PathDataShape
    {
        public int nPenIdx;

        public int nMarkCount;

        public int nLineCount;    //行数   路径数

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DEFINE.MAX_SHAPE_LINE_COUNT)]
        public LineDataShape[] pLine;

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            nLineCount = 0;

            for (int i = 0; i < DEFINE.MAX_SHAPE_LINE_COUNT; i++)
            {
                pLine[i].Init();
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="nCnt">行数</param>
        public PathDataShape(int nCnt)
        {
            nLineCount = nCnt;
            this.nPenIdx = 0;
            this.nMarkCount = 0;

            pLine = new LineDataShape[DEFINE.MAX_SHAPE_LINE_COUNT];
            for (int i = 0; i < DEFINE.MAX_SHAPE_LINE_COUNT; i++)
            {
                pLine[i] = new LineDataShape(0);
            }
            Init();
        }
    };

    #endregion 结构体
    public class JsonConfigHelper
    {

        private static Dictionary<string, string> configDic = new Dictionary<string, string>();

        /// <summary>
        /// 读取配置信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ReadConfig(string key)
        {
            if (File.Exists("config.json") == false)//如果不存在就创建file文件夹
            {
                FileStream f = File.Create("config.json");
                f.Close();
            }
            string s = File.ReadAllText("config.json");
            try
            {
                configDic = JsonConvert.DeserializeObject<Dictionary<string, string>>(s);
            }
            catch
            {
                configDic = new Dictionary<string, string>();
            }

            if (configDic != null && configDic.ContainsKey(key))
            {
                return configDic[key];
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 添加配置信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void WriteConfig(string key, string value)
        {
            if (configDic == null)
            {
                configDic = new Dictionary<string, string>();
            }
            configDic[key] = value;
            string s = JsonConvert.SerializeObject(configDic);
            File.WriteAllText("config.json", s);
        }

        /// <summary>
        /// 删除配置信息
        /// </summary>
        /// <param name="key"></param>
        public static void DeleteConfig(string key)
        {
            if (configDic != null && configDic.ContainsKey(key))
            {
                configDic.Remove(key);
                string s = JsonConvert.SerializeObject(configDic);
                File.WriteAllText("config.json", s);
            }
        }
    }

};


