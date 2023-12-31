﻿//----------------------------------------------------------------------------- 
// <copyright file="SR7LinkFunc.cs" company="SSZN">
//	 Copyright (c) 2017 SSZN.  All rights reserved.
// </copyright>
//----------------------------------------------------------------------------- 
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Camera3DSDK
{

    #region Structure
    /// <summary>
    /// IP 结构体
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SR7IF_ETHERNET_CONFIG
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] abyIpAddress;
    }

    public struct SR_TARGET_SETTING
    {
        public byte byType;
        public byte byCategory;
        public byte byItem;
        public byte reserve;
        public byte byTarget1;
        public byte byTarget2;
        public byte byTarget3;
        public byte byTarget4;
    };

    public struct SR7IF_STR_CALLBACK_INFO
    {
        public int xPoints;                //x方向数据数量
        public int BatchPoints;            //批处理数量
        public int BatchTimes;             //批处理次数

        public double xPixth;              //x方向点间距
        public int startEncoder;           //批处理开始编码器值
        public int HeadNumber;             //相机头数量
        public int returnStatus;           //0:正常批处理
    }
    #endregion

    #region Method

    /// <summary>
    /// 
    /// </summary>
    /// <param name="info"></param>
    /// <param name="DataObj"></param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SR7IF_BatchOneTimeCallBack(IntPtr info, IntPtr DataObj);
    /// <summary>
    /// Function definitions   接口函数定义
    /// </summary>
    internal class SR7LinkFunc
    {
        internal static UInt32 ProgramSettingSize
        {
            get { return 10932; }
        }

        ///<summary>
        /// 通信连接------与相机连接
        /// </summary>
        /// <param name="lDeviceId"></param>          设备ID号，范围为0-3
        /// <param name="pEthernetConfig"></param>   （网口）通信设定
        /// <returns></returns>                       0：成功; 小于0：失败
        /// <remarks></remarks>
        [DllImport("SR7Link.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_EthernetOpen(int lDeviceId, ref SR7IF_ETHERNET_CONFIG pEthernetConfig);
    
        /// <summary>
        /// 断开与相机的连接
        /// </summary>
        /// <param name="lDeviceId"></param>      设备ID号，范围为0-3
        /// <returns></returns>                   0：成功; 小于0：失败
        /// <remarks></remarks>
        [DllImport("SR7Link.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_CommClose(int lDeviceId);
      
        /// <summary>
        /// 开始批处理,立即执行批处理程序
        /// </summary>
        /// <param name="lDeviceId"></param>       设备ID号，范围为0-3
        /// <param name="Timeout"></param>         非循环获取时，超时时间(单位ms);循环模式该参数可设置为-1
        /// <returns></returns>                    0：成功; 小于0：失败
        /// <remarks></remarks>
        [DllImport("SR7Link.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_StartMeasure(int lDeviceId, int Timeout);  

        /// <summary>
        /// 开始批处理,硬件IO触发开始批处理，具体查看硬件手册
        /// </summary>
        /// <param name="lDeviceId"></param>     设备ID号，范围为0-3
        /// <param name="Timeout"></param>       非循环获取时,超时时间(单位ms);循环模式该参数可设置为-1
        /// <param name="restart"></param>       预留，设为0
        /// <returns></returns>                  0：成功; 小于0：失败
        /// <remarks></remarks>
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_StartIOTriggerMeasure(int lDeviceId, int Timeout, int restart);
    
        /// <summary>
        /// 停止批处理---停止扫描
        /// </summary>
        /// <param name="lDeviceId"></param>     设备ID号，范围为0-3
        /// <returns></returns>                  0：成功; 小于0：失败
        /// <remarks></remarks>
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_StopMeasure(int lDeviceId);
    
        /// <summary>
        /// 阻塞方式获取数据---等待数据接收完成
        /// </summary>
        /// <param name="lDeviceId"></param>     设备ID号，范围为0-3
        /// <param name="DataObj"></param>       返回数据指针
        /// <returns></returns>                  0：成功; 小于0：失败
        /// <remarks></remarks>
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_ReceiveData(int lDeviceId, IntPtr DataObj);


        [DllImport("SR7Link.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_GetCurrentEncoder(int lDeviceId, IntPtr DataObj);

        /// <summary>
        /// 获取当前批处理设定行数
        /// </summary>
        /// <param name="lDeviceId">设备号0-3</param>
        /// <param name="DataObj">预留设置为null</param>
        /// <returns></returns>  返回实际批处理行数
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_ProfilePointSetCount(int lDeviceId, IntPtr DataObj);


        /// <summary>
        /// 获取批处理实际获取行数
        /// </summary>
        /// <param name="lDeviceId"></param>      设备ID号，范围为0-3
        /// <param name="DataObj"></param>        预留，设置为NULL
        /// <returns></returns>                   返回实际批处理行数
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_ProfilePointCount(int lDeviceId, IntPtr DataObj);
    
        /// <summary>
        /// 获取数据宽度
        /// </summary>
        /// <param name="lDeviceId"></param>      设备ID号，范围为0-3
        /// <param name="DataObj"></param>        预留，设置为NULL
        /// <returns></returns>                   返回数据宽度(单位像素)
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_ProfileDataWidth(int lDeviceId, IntPtr DataObj);
    
        /// <summary>
        /// 获取数据x方向间距
        /// </summary>
        /// <param name="lDeviceId"></param>      设备ID号，范围为0-3
        /// <param name="DataObj"></param>        预留，设置为NULL
        /// <returns></returns>                   返回数据x方向间距(mm)
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern double SR7IF_ProfileData_XPitch(int lDeviceId, IntPtr DataObj);
    
        /// <summary>
        /// 获取编码器值
        /// </summary>
        /// <param name="lDeviceId"></param>       设备ID号，范围为0-3
        /// <param name="DataObj"></param>         预留，设置为NULL
        /// <param name="Encoder"></param>         返回数据指针
        /// <returns></returns>                    0：成功; 小于0：失败
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_GetEncoder(int lDeviceId, IntPtr DataObj, IntPtr Encoder);

        /// <summary>
        /// 非阻塞方式获取编码器值
        /// </summary>
        /// <param name="lDeviceId"></param>       设备ID号，范围为0-3
        /// <param name="DataObj"></param>         预留，设置为NULL
        /// <param name="Encoder"></param>         返回数据指针
        /// <param name="GetCnt"></param>          获取数据长度
        /// <returns></returns>                    >=0: 实际返回的数据长度   小于0: 获取失败
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_GetEncoderContiune(int lDeviceId, IntPtr DataObj, IntPtr Encoder, int GetCnt);
    
        /// <summary>
        /// 阻塞方式获取轮廓数据
        /// </summary>
        /// <param name="lDeviceId"></param>       设备ID号，范围为0-3
        /// <param name="DataObj"></param>         预留，设置为NULL
        /// <param name="Profile"></param>         返回数据指针
        /// <returns></returns>                    0：成功; 小于0：失败
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_GetProfileData(int lDeviceId, IntPtr DataObj, IntPtr Profile);

        /// <summary>
        /// 非阻塞方式获取轮廓数据
        /// </summary>
        /// <param name="lDeviceId"></param>        设备ID号，范围为0-3
        /// <param name="DataObj"></param>          预留，设置为NULL
        /// <param name="Profile"></param>          返回数据指针
        /// <param name="GetCnt"></param>           获取数据长度
        /// <returns></returns>                     >=0: 实际返回的数据长度   小于0: 获取失败
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_GetProfileContiuneData(int lDeviceId, IntPtr DataObj, IntPtr Profile, int GetCnt);

        /// <summary>
        /// 无终止循环获取数据
        /// </summary>
        /// <param name="lDeviceId"></param>         设备ID号，范围为0-3
        /// <param name="DataObj"></param>           预留，设置为NULL
        /// <param name="Profile"></param>           返回轮廓数据指针
        /// <param name="Intensity"></param>         返回亮度数据指针
        /// <param name="Encoder"></param>           返回编码器数据指针
        /// <param name="FrameId"></param>           返回帧编号数据指针
        /// <param name="FrameLoss"></param>         返回批处理过快掉帧数量数据指针
        /// <param name="GetCnt"></param>            获取数据长度
        /// <returns></returns>                      >=0: 实际返回的数据长度   小于0: 获取失败
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_GetBatchRollData(int lDeviceId, 
            IntPtr DataObj, 
            IntPtr Profile,
            IntPtr Intensity,
            IntPtr Encoder, 
            IntPtr FrameId,
            IntPtr FrameLoss,
            int GetCnt);
    
        /// <summary>
        /// 阻塞方式获取亮度数据
        /// </summary>
        /// <param name="lDeviceId"></param>        设备ID号，范围为0-3
        /// <param name="DataObj"></param>          预留，设置为NULL
        /// <param name="Intensity"></param>        返回数据指针
        /// <returns></returns>                     0：成功; 小于0：失败
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_GetIntensityData(int lDeviceId, IntPtr DataObj, IntPtr Intensity);

        /// <summary>
        /// 非阻塞获取亮度数据
        /// </summary>
        /// <param name="lDeviceId"></param>        设备ID号，范围为0-3
        /// <param name="DataObj"></param>          预留，设置为NULL
        /// <param name="Intensity"></param>        返回数据指针
        /// <param name="GetCnt"></param>           获取数据长度
        /// <returns></returns>                     >=0: 实际返回的数据长度   小于0: 获取失败
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_GetIntensityContiuneData(int lDeviceId, IntPtr DataObj, IntPtr Intensity, int GetCnt);
       
        /// <summary>
        /// 无终止循环获取数据异常计算值
        /// </summary>
        /// <param name="lDeviceId"></param>        设备ID号，范围为0-3.
        /// <param name="EthErrCnt"></param>        返回网络传输导致错误的数量
        /// <param name="UserErrCnt"></param>       返回用户获取导致错误的数量
        /// <returns></returns>                     0：成功; 小于0：失败
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_GetBatchRollError(int lDeviceId, IntPtr EthErrCnt, IntPtr UserErrCnt);

        /// <summary>
        /// 获取系统错误信息.
        /// </summary>
        /// <param name="lDeviceId"></param>     设备ID号，范围为0-3.
        /// <param name="EthErrCnt"></param>     返回错误码数量.
        /// <param name="UserErrCnt"></param>    返回错误码指针.
        /// <returns></returns>                  0：成功; 小于0：失败
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_GetError(int lDeviceId, IntPtr pbyErrCnt, IntPtr pwErrCode);

        /// <summary>
        /// 初始化以太网高速数据通信.
        /// </summary>
        /// <param name="lDeviceId"></param>              设备ID号，范围为0-3.
        /// <param name="pEthernetConfig"></param>        Ethernet 通信设定.
        /// <param name="wHighSpeedPortNo"></param>       Ethernet 通信端口设定.
        /// <param name="pCallBack"></param>              高速通信中数据接收的回调函数.
        /// <param name="dwProfileCnt"></param>           回调函数被调用的频率. 范围1-256
        /// <param name="dwThreadId"></param>             线程号.
        /// <returns></returns>                           0：成功; 小于0：失败
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_HighSpeedDataEthernetCommunicationInitalize(int lDeviceId,
            ref SR7IF_ETHERNET_CONFIG pEthernetConfig,
            int wHighSpeedPortNo,
            HighSpeedDataCallBack pCallBack,
            uint dwProfileCnt,
            uint dwThreadId);

        /// <summary>
        /// 获取库版本号.
        /// </summary>
        /// <returns></returns>       返回版本信息.
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr SR7IF_GetVersion();

        /// <summary>
        /// 获取相机型号
        /// </summary>
        /// <param name="lDeviceId"></param>   设备ID号，范围为0-3.
        /// <returns></returns>                0：成功; 小于0：失败
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr SR7IF_GetModels(int lDeviceId);

        /// <summary>
        /// 获取相机头序列号
        /// </summary>
        /// <param name="lDeviceId"></param>   设备ID号，范围为0-3.
        /// <param name="Head"></param>        0:相机头A 1:相机头B
        /// <returns></returns>                成功:返回相机头序列号,失败：相机头不存在或参数错误
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr SR7IF_GetHeaderSerial(int lDeviceId ,int Head);

        /// <summary>
        /// 获取传感头B是否在线
        /// </summary>
        /// <param name="lDeviceId"></param>      设备ID号，范围为0-3.
        /// <returns></returns>                   0：在线; 小于0：不在线
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_GetOnlineCameraB(int lDeviceId);

        /// <summary>
        /// 切换相机配置的参数.
        /// </summary>
        /// <param name="lDeviceId"></param>     设备ID号，范围为0-3.
        /// <param name="No"></param>            任务参数列表编号 0 - 63.
        /// <returns></returns>                  0：成功; 小于0：失败
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_SwitchProgram(int lDeviceId, int No);

        /// <summary>
        /// 设置输出端口电平.
        /// </summary>
        /// <param name="lDeviceId"></param>   设备ID号，范围为0-3.
        /// <param name="Port"></param>        输出端口号，范围为0-7.
        /// <param name="Level"></param>       输出电平值.
        /// <returns></returns>                0：成功; 小于0：失败
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_SetOutputPortLevel(uint lDeviceId, uint Port, bool Level);

        /// <summary>
        /// 读取输入端口电平
        /// </summary>
        /// <param name="lDeviceId"></param> 设备ID号，范围为0-3.
        /// <param name="Port"></param>      输入端口号，范围为0-7.
        /// <param name="Level"></param>     读取输入电平.
        /// <returns></returns>              0：成功; 小于0：失败
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_GetInputPortLevel(uint lDeviceId, uint Port, IntPtr Level);

        /// <summary>
        /// 参数设定
        /// </summary> 
        /// <param name="lDeviceId"></param>    设备ID号，范围为0-3.
        /// <param name="Depth"></param>        设置的值的级别.
        /// <param name="Type"></param>         设置类型.
        /// <param name="Category"></param>     设置种类.
        /// <param name="Item"></param>         设置项目.
        /// <param name="Target"></param>       根据发送 / 接收的设定，可能需要进行相应的指定。无需设定时，指定为 0。
        /// <param name="pData"></param>        设置数据.
        /// <param name="DataSize"></param>     设置数据的长度.
        /// <returns></returns>                 0：成功; 小于0：失败
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_SetSetting(uint lDeviceId, int Depth, int Type, int Category, int Item, int[] Target, IntPtr pData, int DataSize);

        /// <summary>
        /// 参数获取
        /// </summary> 
        /// <param name="lDeviceId"></param>    设备ID号，范围为0-3.
        /// <param name="Type"></param>         设置类型.
        /// <param name="Category"></param>     设置种类.
        /// <param name="Item"></param>         设置项目.
        /// <param name="Target"></param>       根据发送 / 接收的设定，可能需要进行相应的指定。无需设定时，指定为 0。
        /// <param name="pData"></param>        设置数据.
        /// <param name="DataSize"></param>     设置数据的长度.
        /// <returns></returns>                 0：成功; 小于0：失败
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_GetSetting(uint lDeviceId,int Type, int Category, int Item, int[] Target, IntPtr pData, int DataSize);
        
        /// <summary>
        /// 获取当前一条轮廓（非批处理下）
        /// </summary>
        /// <param name="lDeviceId"></param>         设备ID号，范围为0-3.
        /// <param name="pProfileData"></param>      返回轮廓的指针.
        /// <param name="pEncoder"></param>          返回编码器的指针.
        /// <returns></returns>                      0：成功; 小于0：失败
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_GetSingleProfile(uint lDeviceId, IntPtr pProfileData, IntPtr pEncoder);

        /// <summary>
        /// 将导出的参数导入到系统中.
        /// </summary>
        /// <param name="lDeviceId"></param>          设备ID号，范围为0-3.
        /// <param name="pSettingdata"></param>       导入参数表指针.
        /// <param name="size"></param>               导入参数表的大小.
        /// <returns></returns>                       0：成功; 小于0：失败
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_LoadParameters(uint lDeviceId, IntPtr pSettingdata, UInt32 size);
        /// <summary>
        /// 返回产品剩余天数
        /// </summary>
        /// <param name="lDeviceId"></param>
        /// <param name="RemainDay"></param>    返回剩余天数
        /// <returns></returns>                  0：成功; 小于0：失败
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_GetLicenseKey(uint lDeviceId, IntPtr RemainDay);
        /// <summary>
        /// 将系统参数导出，注意只导出当前任务的参数.
        /// </summary>
        /// <param name="lDeviceId"></param>          设备ID号，范围为0-3.
        /// <param name="size"></param>               返回参数表的大小.
        /// <returns></returns>                       NULL:失败. 其他:成功
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr SR7IF_ExportParameters(int lDeviceId, IntPtr size);

        /// <summary>
        /// 3D显示
        /// </summary>
        /// <param name="_BatchData"></param>               批处理数据
        /// <param name="x_true_step"></param>              x方向间矩/mm
        /// <param name="y_true_step"></param>              y方向间距/mm
        /// <param name="x_Point_num"></param>              x方向数据个数
        /// <param name="y_batchPoint_num"></param>         批处理行数
        /// <param name="z_scale"></param>                  z方向缩放系数
        /// <param name="Ho"></param>                       z方向最大值
        /// <param name="Lo"></param>                       z方向最小值
        [DllImport("SR3dexe.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SR_3D_EXE_Show(IntPtr _BatchData,
                                double x_true_step,
                                double y_true_step,
                                int x_Point_num,
                                int y_batchPoint_num,
                                double z_scale,
                                double Ho,
                                double Lo
                                );


        /// <summary>
        /// 设置回调函数,建议获取数据后另外开启线程进行处理(批处理一次回调一次）
        /// </summary>
        /// <param name="lDeviceId"></param>   设备ID号，范围为0-3.
        /// <param name="size"></param>        回调函数.
        /// <returns></returns>                 0：成功; 小于0：失败
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern  int SR7IF_SetBatchOneTimeDataHandler(int lDeviceId, SR7IF_BatchOneTimeCallBack CallFunc);

        /// <summary>
        ///  开始批处理 （批处理一次, 回调一次)
        /// </summary>
        /// <param name="lDeviceId"></param>        设备ID号，范围为0-3.
        /// <param name="ImmediateBatch"></param>    0:立即开始批处理  1:等待外部开始批处理.
        /// <returns></returns>                       0：成功; 小于0：失败
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_StartMeasureWithCallback (int lDeviceId, int ImmediateBatch);

        /// <summary>
        /// 批处理软件触发开始（批处理一次回调一次）
        /// </summary>
        /// <param name="lDeviceId"></param>   设备ID号，范围为0-3.
        /// <returns></returns>                 0：成功; 小于0：失败
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SR7IF_TriggerOneBatch(int lDeviceId);


        /// <summary>
        /// 批处理轮廓获取（批处理一次回调一次）
        /// </summary>
        /// <param name="DataObj"></param>     设备ID号，范围为0-3.
        /// <param name="Head"></param>         0：相机头A  1：相机头B
        /// <returns></returns>                 返回数据指针 null:无数据或相应头不存在
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr SR7IF_GetBatchProfilePoint(IntPtr DataObj,int Head);

        /// <summary>
        ///  批处理亮度获取（批处理一次回调一次）
        /// </summary>
        /// <param name="DataObj"></param>   设备ID号，范围为0-3.
        /// <param name="Head"></param>    0：相机头A  1：相机头B
        /// <returns></returns>                返回数据指针 null:无数据或相应头不存在
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr SR7IF_GetBatchIntensityPoint(IntPtr DataObj, int Head);

        /// <summary>
        /// 批处理编码器获取（批处理一次回调一次）
        /// </summary>
        /// <param name="DataObj"></param>  设备ID号，范围为0-3.
        /// <param name="Head"></param>     0：相机头A  1：相机头B
        /// <returns></returns>             返回数据指针 null:无数据或相应头不存在
        [DllImport("SR7Link.dll",CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr SR7IF_GetBatchEncoderPoint(IntPtr DataObj, int Head);


    }

    #endregion


}
