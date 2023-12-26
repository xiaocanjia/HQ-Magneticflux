using JSystem.Device;
using JSystem.Param;
using System;
using System.Threading;

namespace JSystem.Station
{
    public class TestStation : StationBase
    {
        public enum EStationStep
        {
            进站,
            顶升气缸上升, 
            测试,
            出站
        }
        
        public Action<double> OnSetCT;

        public Action OnInitDisp;

        public Action<int, string, double, double> OnSendRets;

        public TestStation()
        {
            try
            {
                Name = "测试工站";
                Model = new DataModel();
                View = new StationView(this);
                Step = (int)EStationStep.进站;
            }
            catch (Exception ex)
            {
                throw new Exception($"{Name}初始化异常，请检查配置文件是否存在：{ex.Message}");
            }
        }
        
        public override void Run()
        {
            try
            {
                DateTime start = DateTime.Now;
                while (true)
                {
                    Thread.Sleep(10);
                    if (State == EStationState.END) return;
                    else if (State != EStationState.RUNNING) continue;
                    switch (Step)
                    {
                        case (int)EStationStep.进站:
                            if (OnGetStep("扫码工站") == (int)ReadSNStation.EStationStep.出站完成)
                            {
                                start = DateTime.Now;
                                AddLog($"产品进站");
                                Thread.Sleep(1000);
                                JumpStep((int)EStationStep.顶升气缸上升);
                            }
                            break;
                        case (int)EStationStep.顶升气缸上升:
                            {
                                SetOut("顶升缸", true);
                                if (!GetIn("顶升缸到位", true, 3000))
                                    break;
                                JumpStep((int)EStationStep.测试);
                            }
                            break;
                        case (int)EStationStep.测试:
                            {
                                OnInitDisp();
                                if (!Test()) break;
                                OnSetCT(DateTime.Now.Subtract(start).TotalSeconds / 4);
                                AddLog("等待移动到皮带3");
                                JumpStep((int)EStationStep.出站);
                            }
                            break;
                        case (int)EStationStep.出站:
                            if (!OnGetIn("皮带3感应有料"))
                            {
                                SetOut("顶升缸", false);
                                SetOut("阻挡缸3", false);
                                SetOut("皮带2", true);
                                SetOut("皮带3", true);
                                Delay(4500);
                                if (!GetIn("皮带3感应有料", true, 5000))
                                    break;
                                SetOut("阻挡缸3", true);
                                AddLog("产品移动到皮带3");
                                SetOut("皮带2", false);
                                SetOut("皮带3", false);
                                Delay(1000); //加上延迟，减速停止没那么快
                                JumpStep((int)EStationStep.进站);
                            }
                            break;
                        default:
                            return;
                    }
                }
            }
            catch (Exception ex)
            {
                AddLog($"{Name}发生异常：{ex.Message}", true);
                OnStop(false);
            }
        }

        public bool Test()
        {
            double[] magneticflux = new double[4];
            double[] height = new double[4];
            if (!ParamManager.GetBoolParam("禁用测高"))
            {
                if (!MoveToPos(GetPos("高度基准位1")))
                    return false;
                double refHeight1 = 0;
                double refHeight2 = 0;
                if (!MoveToPos(GetPos("高度检测位1")))
                    return false;
                double mesHeight1 = 0;
                double mesHeight2 = 0;
                height[0] = mesHeight1 - refHeight1;
                height[2] = mesHeight2 - refHeight2;
            }
            {
                if (!((MagneticFlux)OnGetDevice("磁通计1")).ClearZero() || !((MagneticFlux)OnGetDevice("磁通计2")).ClearZero())//磁通量清零
                {
                    ((MagneticFlux)OnGetDevice("磁通计1")).ClearZero();
                    ((MagneticFlux)OnGetDevice("磁通计2")).ClearZero();
                }
                double[] pos = GetPos("磁通量检测位1");
                if (!MoveToPos(new double[] { pos[0], pos[1], double.NaN, pos[3], pos[4], double.NaN }))
                    return false;
                if (!MoveToPos(new double[] { double.NaN, double.NaN, pos[2], double.NaN, double.NaN, pos[5] }, "磁通量检测位1"))
                    return false;
                Delay(1000);
                magneticflux[0] = ((MagneticFlux)OnGetDevice("磁通计1")).GetCurrValue();
                magneticflux[2] = ((MagneticFlux)OnGetDevice("磁通计2")).GetCurrValue();
                if (!MoveToPos(new double[] { double.NaN, double.NaN, 0, double.NaN, double.NaN, 0 }, "安全高度"))
                    return false;
            }
            
            if (!ParamManager.GetBoolParam("禁用测高"))
            {
                if (!MoveToPos(GetPos("高度基准位2")))
                    return false;
                double refHeight1 = 0;
                double refHeight2 = 0;
                if (!MoveToPos(GetPos("高度检测位2")))
                    return false;
                double mesHeight1 = 0;
                double mesHeight2 = 0;
                height[1] = mesHeight1 - refHeight1;
                height[3] = mesHeight2 - refHeight2;
            }
            {
                if (!((MagneticFlux)OnGetDevice("磁通计1")).ClearZero() || !((MagneticFlux)OnGetDevice("磁通计2")).ClearZero())//磁通量清零
                {
                    ((MagneticFlux)OnGetDevice("磁通计1")).ClearZero();
                    ((MagneticFlux)OnGetDevice("磁通计2")).ClearZero();
                }
                double[] pos = GetPos("磁通量检测位2");
                if (!MoveToPos(new double[] { pos[0], pos[1], double.NaN, pos[3], pos[4], double.NaN }))
                    return false;
                if (!MoveToPos(new double[] { double.NaN, double.NaN, pos[2], double.NaN, double.NaN, pos[5] }, "磁通量检测位2"))
                    return false;
                Delay(1000);
                magneticflux[1] = ((MagneticFlux)OnGetDevice("磁通计1")).GetCurrValue();
                magneticflux[3] = ((MagneticFlux)OnGetDevice("磁通计2")).GetCurrValue();
                if (!MoveToPos(new double[] { double.NaN, double.NaN, 0, double.NaN, double.NaN, 0 }, "安全高度"))
                    return false;
            }
            for (int i = 0; i < 4; i++)
                OnSendRets(i, SNQueue.Dequeue(), magneticflux[i], height[i]);
            return true;
        }

        public override bool Reset()
        {
            State = EStationState.RESETING;
            SetOut("阻挡缸4", true);
            SetOut("顶升缸", false);
            if (!GoHome(new bool[] { false, false, true, false, false, true }))
                return false;
            if (!GoHome(new bool[] { true, true, false, true, true, false }))
                return false;
            if (OnGetIn("皮带2感应有料"))
            {
                SetOut("阻挡缸3", false);
                AddLog("请先将检测位的产品取出");
                return false;
            }
            SetOut("阻挡缸3", true);
            JumpStep((int)EStationStep.进站);
            State = EStationState.RESETED;
            return base.Reset();
        }

        public override void JumpStep(int step)
        {
            AddLog($"跳转到步骤：{(EStationStep)step}");
            base.JumpStep(step);
        }
    }
}
