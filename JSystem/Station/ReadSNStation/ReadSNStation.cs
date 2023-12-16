using System;
using System.Threading;
using JSystem.Device;

namespace JSystem.Station
{
    public class ReadSNStation : StationBase
    {
        public enum EStationStep
        {
            进站,
            扫码,
            出站,
            出站完成
        }

        public ReadSNStation()
        {
            try
            {
                Name = "扫码工站";
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
                ScanningGun gun = null;
                while (true)
                {
                    Thread.Sleep(10);
                    if (State == EStationState.END) return;
                    else if (State != EStationState.RUNNING) continue;
                    switch (Step)
                    {
                        case (int)EStationStep.进站:
                            if (OnGetIn("皮带线1感应有料1") && !OnGetIn("皮带线1感应有料2"))
                            {
                                SetOut("阻挡缸1", false);
                                SetOut("皮带线1", true);
                                if (!GetIn("皮带线1感应有料2", true, 5000))
                                    break;
                                SetOut("皮带线1", false);
                                SetOut("阻挡缸1", true);
                                gun = (ScanningGun)OnGetDevice("扫码枪");
                                JumpStep((int)EStationStep.扫码);
                            }
                            break;
                        case (int)EStationStep.扫码:
                            {
                                string sn1 = ((ScanningGun)OnGetDevice("扫码枪1")).ReadSN();
                                AddLog($"产品1 SN为{sn1}");
                                OnAddSN("测试工站", sn1);
                                string sn2 = ((ScanningGun)OnGetDevice("扫码枪2")).ReadSN();
                                AddLog($"产品2 SN为{sn2}");
                                OnAddSN("测试工站", sn2);
                                string sn3 = ((ScanningGun)OnGetDevice("扫码枪3")).ReadSN();
                                AddLog($"产品3 SN为{sn3}");
                                OnAddSN("测试工站", sn3);
                                string sn4 = ((ScanningGun)OnGetDevice("扫码枪4")).ReadSN();
                                AddLog($"产品4 SN为{sn4}");
                                OnAddSN("测试工站", sn4);
                                AddLog($"等待移动产品到皮带线2");
                                JumpStep((int)EStationStep.出站);
                                break;
                            }
                        case (int)EStationStep.出站:
                            if (!OnGetIn("皮带线2感应有料") && OnGetStep("测试工站") == (int)TestStation.EStationStep.进站)
                            {
                                SetOut("阻挡缸2", false);
                                SetOut("皮带线1", true);
                                SetOut("皮带线2", true);
                                if (!GetIn("皮带线2感应有料", true, 5000))
                                    break;
                                SetOut("皮带线1", false);
                                SetOut("皮带线2", false);
                                SetOut("阻挡缸2", true);
                                JumpStep((int)EStationStep.出站完成);
                            }
                            break;
                        case (int)EStationStep.出站完成:
                            {
                                Thread.Sleep(100);
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
        
        public override bool Reset()
        {
            State = EStationState.RESETING;
            if (OnGetIn("皮带线1感应有料2"))
            {
                AddLog("请先将扫码位的产品取出");
                return false;
            }
            SetOut("阻挡缸1", true);
            Step = (int)EStationStep.进站;
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
