using System;
using System.Drawing;
using System.Threading.Tasks;
using Sunny.UI;
using JSystem.Device;
using JSystem.Station;
using JSystem.Param;
using System.IO;
using FileHelper;

namespace JSystem.Perform
{
    public partial class PerformPage : UIPage
    {
        private SysController _controller;

        private int _totalCount = 0;

        private int _passCount = 0;

        private int _failCount = 0;

        public PerformPage()
        {
            InitializeComponent();
        }

        public void Init(SysController controller)
        {
            try
            {
                _controller = controller;
                _controller.OnUpdateState = UpdateState;
                TestStation station = (TestStation)_controller.StationMgr.StationList.Find((s) => s.Name == "测试工站");
                station.OnInitDisp = InitDisp;
                station.OnSendRets = UpdateView;
                station.OnSetCT = DispCT;
                runningMsgPanel.Init(LogManager.Instance);
                InitDisp();
            }
            catch (Exception ex)
            {
                throw new Exception("主页初始化失败：" + ex.Message);
            }
        }

        private void UpdateState(EDeviceState state)
        {
            if (InvokeRequired)
                BeginInvoke(new Action(() => { UpdateState(state); }));
            else
            {
                _controller.CurrState = state;
                switch (state)
                {
                    case EDeviceState.UNINIT:
                        StatusPanel.UpdateState(state, 0, 0, 0, 0);
                        Btn_Reset.Enabled = true;
                        Btn_Start.BringToFront();
                        break;
                    case EDeviceState.INITING:
                        StatusPanel.UpdateState(state, 0, 0, 2, 0);
                        Btn_Reset.Enabled = false;
                        DGV_Result.Rows.Clear();
                        InitDisp();
                        break;
                    case EDeviceState.INITED:
                        StatusPanel.UpdateState(state, 0, 1, 0, 0);
                        Btn_Reset.Enabled = true;
                        break;
                    case EDeviceState.RUN:
                        StatusPanel.UpdateState(state, 0, 0, 1, 0);
                        Btn_Reset.Enabled = false;
                        Btn_Pause.BringToFront();
                        break;
                    case EDeviceState.PAUSE:
                        StatusPanel.UpdateState(state, 0, 0, 2, 0);
                        Btn_Start.BringToFront();
                        break;
                    case EDeviceState.PAUSEALARM:
                        StatusPanel.UpdateState(state, 0, 2, 0, 1);
                        Btn_Reset.Enabled = false;
                        break;
                    case EDeviceState.EMERGENCY:
                        StatusPanel.UpdateState(state, 2, 0, 0, 1);
                        Btn_Reset.Enabled = true;
                        Btn_Start.BringToFront();
                        break;
                }
            }
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            new Task(() =>
            {
                _controller.Init();
            }).Start();
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            if (_controller.CurrState == EDeviceState.PAUSEALARM)
                return;
            if (!_controller.Start())
                UIMessageTip.ShowError("启动失败");
        }

        private void Btn_Pause_Click(object sender, EventArgs e)
        {
            if (_controller.CurrState == EDeviceState.PAUSEALARM)
                return;
            if (!_controller.Pause(true))
                UIMessageTip.ShowError("暂停失败");
        }

        private void Btn_End_Click(object sender, EventArgs e)
        {
            if (_controller.CurrState == EDeviceState.PAUSEALARM)
                return;
            _controller.Stop(true);
        }

        private void Btn_ClearAlarm_Click(object sender, EventArgs e)
        {
            _controller.DeviceMgr.OnSetOut("蜂鸣器", false);
        }

        private void InitDisp()
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new Action(() => InitDisp()));
                }
                else
                {
                    DGV_Result.Rows.Clear();
                    DGV_Result.Columns[2].HeaderText = $"磁通量({ParamManager.GetDoubleParam("磁通量下限")}-{ParamManager.GetDoubleParam("磁通量上限")})";
                    DGV_Result.Columns[3].HeaderText = $"测高高度({ParamManager.GetDoubleParam("测高下限")}-{ParamManager.GetDoubleParam("测高上限")})";
                    for (int i = 0; i < 4; i++)
                    {
                        DGV_Result.Rows.Add(new object[] { i + 1, "", "", "", "" });
                        _controller.DeviceMgr.OnSetOut($"OK指示灯{i + 1}", true);
                        _controller.DeviceMgr.OnSetOut($"NG指示灯{i + 1}", false);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.AddLog($"主页初始化异常：{ex.Message}");
            }
        }
        
        private void UpdateView(int idx, string sn, double magneticflux, double height, bool mesRet)
        {
            try
            {
                if (sn == "")
                {
                    _controller.DeviceMgr.OnSetOut($"OK指示灯{idx + 1}", false);
                    _controller.DeviceMgr.OnSetOut($"NG指示灯{idx + 1}", true);
                    return;//加入判断二维码是否为空，空不显示结果
                }
                string math = magneticflux.ToString("f2");
                magneticflux = double.Parse(math);//取小数点后两位
                string ftpmesstart = "";
                if (((MesSys)_controller.StationMgr.OnGetDevice("Mes系统")).IsEnable)
                {
                    DGV_Result.Rows[idx].Cells[4].Value = mesRet ? "OK" : "NG";
                    ftpmesstart = "Online";
                }
                else
                {
                    DGV_Result.Rows[idx].Cells[4].Value = "";
                    ftpmesstart = "Offline";
                }
                string filePath = ParamManager.GetStringParam("数据保存路径") + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv";
                string ftpfilePath = ParamManager.GetStringParam("服务器数据保存路径")+"\\"+ ftpmesstart + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv";
                if (!File.Exists(filePath))
                {
                    string header = $"序号,时间,SN,磁通量({ParamManager.GetDoubleParam("磁通量下限")}-{ParamManager.GetDoubleParam("磁通量上限")})," +
                        $"测高高度({ParamManager.GetDoubleParam("测高下限")}-{ParamManager.GetDoubleParam("测高上限")}),Mes上传结果,测试总结果";
                    TxtHelper.FileWrite(filePath, header);
                }
                if (!File.Exists(ftpfilePath))
                {
                    string header = $"序号,时间,SN,磁通量({ParamManager.GetDoubleParam("磁通量下限")}-{ParamManager.GetDoubleParam("磁通量上限")})," +
                        $"测高高度({ParamManager.GetDoubleParam("测高下限")}-{ParamManager.GetDoubleParam("测高上限")}),Mes上传结果,测试总结果";
                    TxtHelper.FileWrite(ftpfilePath, header);
                }
                DGV_Result.Rows[idx].Cells[1].Value = sn;
                DGV_Result.Rows[idx].Cells[2].Value = magneticflux;
                DGV_Result.Rows[idx].Cells[3].Value = height;
                string dec = "OK";
                
                if (ParamManager.GetBoolParam("禁用测高"))
                {
                    if (magneticflux < ParamManager.GetDoubleParam("磁通量下限") || magneticflux > ParamManager.GetDoubleParam("磁通量上限") || !mesRet)
                        dec = "NG";
                }
                else
                {
                    if (magneticflux < ParamManager.GetDoubleParam("磁通量下限") || magneticflux > ParamManager.GetDoubleParam("磁通量上限") ||
                        height < ParamManager.GetDoubleParam("高度下限") || height > ParamManager.GetDoubleParam("高度上限") || !mesRet)
                        dec = "NG";
                }
                TxtHelper.FileWrite(filePath,$"{idx+1}"+","+DateTime.Now.ToString("HH-mm-ss-ffff") + $",{sn},{magneticflux},{height},{DGV_Result.Rows[idx].Cells[4].Value},{dec}");
                TxtHelper.FileWrite(ftpfilePath,$"{idx+1}"+","+ DateTime.Now.ToString("HH-mm-ss-ffff") + $",{sn},{magneticflux},{height},{DGV_Result.Rows[idx].Cells[4].Value},{dec}");
                DGV_Result.Rows[idx].DefaultCellStyle.ForeColor = dec == "NG" ? Color.Red : Color.Green;
                DGV_Result.Rows[idx].Cells[5].Value = dec;
                _totalCount++;
                if (dec == "OK")
                {
                    _controller.DeviceMgr.OnSetOut($"OK指示灯{idx + 1}", true);
                    _controller.DeviceMgr.OnSetOut($"NG指示灯{idx + 1}", false);
                    _passCount++;
                }
                else
                {
                    _controller.DeviceMgr.OnSetOut($"OK指示灯{idx + 1}", false);
                    _controller.DeviceMgr.OnSetOut($"NG指示灯{idx + 1}", true);
                    _failCount++;
                }
                Lb_OK_Pct.Text = ((_passCount / Convert.ToDouble(_totalCount)) * 100).ToString("F1") + "%";
                Lb_Total.Text = _totalCount.ToString();
                Lb_Pass.Text = _passCount.ToString();
                Lb_Fail.Text = _failCount.ToString();
            }
            catch (Exception ex)
            {
                LogManager.Instance.AddLog($"结果显示异常{ex.Message}");
            }
        }

        private void DispCT(double ct)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => DispCT(ct)));
            }
            else
            {
                Lb_CT.Text = ct.ToString();
                Lb_UPH.Text = (3600 / ct).ToString("F1");
            }
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            _totalCount = 0;
            _passCount = 0;
            _failCount = 0;
            Lb_Total.Text = _totalCount.ToString();
            Lb_Pass.Text = _passCount.ToString();
            Lb_Fail.Text = _failCount.ToString();
            if (_totalCount == 0)
                Lb_OK_Pct.Text = "100%";
            else
                Lb_OK_Pct.Text = ((_passCount / Convert.ToDouble(_totalCount)) * 100).ToString("F1") + "%";
        }
    }
}
