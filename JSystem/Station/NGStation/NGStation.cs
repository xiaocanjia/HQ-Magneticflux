using System;
using System.Threading;
using JSystem.Param;

namespace JSystem.Station
{
    public class NGStation : StationBase
    {
        public enum EStationStep
        {
            进站,
        }

        public NGStation()
        {
            try
            {
                Name = "NG工站";
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
                while (true)
                {
                    Thread.Sleep(10);
                    if (State == EStationState.END) return;
                    else if (State != EStationState.RUNNING) continue;
                    switch (Step)
                    {
                        case (int)EStationStep.进站:
                            if (OnGetIn("NG皮带启动按钮1") || OnGetIn("NG皮带启动按钮2"))
                            {
                                if (OnGetIn("NG皮带感应满料"))
                                {
                                    AddLog("NG皮带满料，请手动清料");
                                    break;
                                }
                                MoveToPos("皮带", GetAxisByName("皮带").GetCmdPos() + ParamManager.GetDoubleParam("NG皮带移动间距"));
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
            Step = (int)EStationStep.进站;
            State = EStationState.RESETED;
            return base.Reset();
        }
    }
}
