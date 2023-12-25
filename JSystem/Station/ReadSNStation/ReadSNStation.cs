using System;
using System.Threading;
using System.Threading.Tasks;
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
                            if (OnGetIn("进料启动按钮") && OnGetIn("皮带1感应有料1") && !OnGetIn("皮带1感应有料2"))
                            {
                                SetOut("阻挡缸1", false);
                                SetOut("皮带1", true);
                                if (!GetIn("皮带1感应有料2", true, 5000))
                                    break;
                                SetOut("皮带1", false);
                                SetOut("阻挡缸1", true);
                                gun = (ScanningGun)OnGetDevice("扫码枪");
                                JumpStep((int)EStationStep.扫码);
                            }
                            break;
                        case (int)EStationStep.扫码:
                            {
                                Task[] taskPool = new Task[4];
                                string[] snArr = new string[4];
                                for (int i = 0; i < 4; i++)
                                {
                                    taskPool[i] = new Task((idx) =>
                                    {
                                        snArr[(int)idx] = ((ScanningGun)OnGetDevice($"扫码枪{(int)idx + 1}")).ReadSN();
                                        AddLog($"产品{(int)idx + 1} SN为{snArr[(int)idx]}");
                                    }, i);
                                    taskPool[i].Start();
                                }
                                Task.WaitAll(taskPool);
                                for (int i = 0; i < 4; i++)
                                    OnAddSN("测试工站", snArr[i]);
                                AddLog($"等待移动产品到皮带2");
                                JumpStep((int)EStationStep.出站);
                                break;
                            }
                        case (int)EStationStep.出站:
                            if (!OnGetIn("皮带2感应有料") && OnGetStep("测试工站") == (int)TestStation.EStationStep.进站)
                            {
                                SetOut("阻挡缸2", false);
                                SetOut("皮带1", true);
                                SetOut("皮带2", true);
                                if (!GetIn("皮带2感应有料", true, 5000))
                                    break;
                                SetOut("皮带1", false);
                                SetOut("皮带2", false);
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
            if (OnGetIn("皮带1感应有料2"))
            {
                AddLog("请先将扫码位的产品取出");
                return false;
            }
            SetOut("阻挡缸1", true);
            SetOut("阻挡缸2", true);
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
