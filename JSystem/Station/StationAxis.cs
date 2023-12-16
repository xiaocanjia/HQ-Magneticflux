using System;
using JSystem.Device;
using Newtonsoft.Json;

namespace JSystem.Station
{
    /// <summary>
    /// 由于该类是通过板卡ID和轴名称来确定的，所以放到工站里面
    /// </summary>
    public class StationAxis
    {
        public string Name;

        public string BoardName;

        public int AxisIndex;

        public int Index = 0;

        public double MoveVelH = 20.0;

        [JsonIgnore]
        public Board Board
        {
            get
            {
                return (Board)OnGetDevice?.Invoke(BoardName);
            }
        }

        [JsonIgnore]
        public double MoveVelHPluse
        {
            get { return MoveVelH * PlusePerUnit; }
        }

        public double MoveVelL = 2.0;

        [JsonIgnore]
        public double MoveVelLPluse
        {
            get { return MoveVelL * PlusePerUnit; }
        }

        public double ManulVel = 20.0;

        public double MoveAcc = 50.0;

        [JsonIgnore]
        public double MoveAccPluse
        {
            get { return MoveAcc * PlusePerUnit; }
        }

        public double MoveDcc = 50.0;

        [JsonIgnore]
        public double MoveDccPluse
        {
            get { return MoveDcc * PlusePerUnit; }
        }

        public string Unit = "mm";

        public uint HomeMode = 0;

        public uint HomeDir = 0;

        public double HomeOffset = 1.0;

        public double HomeVelH = 20.0;

        [JsonIgnore]
        public double HomeVelHPluse
        {
            get { return HomeVelH * PlusePerUnit; }
        }

        public double HomeVelL = 20.0;

        [JsonIgnore]
        public double HomeVelLPluse
        {
            get { return HomeVelL * PlusePerUnit; }
        }

        public double HomeAcc = 50.0;

        [JsonIgnore]
        public double HomeAccPluse
        {
            get { return HomeAcc * PlusePerUnit; }
        }

        public double HomeDcc = 50.0;

        [JsonIgnore]
        public double HomeDccPluse
        {
            get { return HomeDcc * PlusePerUnit; }
        }

        public uint PlusePerUnit = 1000;

        public double Accuracy = 0.01;

        [JsonIgnore]
        public bool IsAlarm;

        [JsonIgnore]
        public bool IsEnabled;

        [JsonIgnore]
        public bool IsEmergencyStop;

        [JsonIgnore]
        public AxisPanel View;

        [JsonIgnore]
        public Action<double, double, byte> OnUpdateView;

        [JsonIgnore]
        public Func<string, DeviceBase> OnGetDevice;

        [JsonIgnore]
        public Action OnSaveParam;

        public StationAxis()
        {
            View = new AxisPanel(this);
        }

        public void UpdateState()
        {
            if (Board == null) return;
            double cmdPos = GetCmdPos();
            double actPos = GetActPos();
            byte state = GetAxisState();
            IsAlarm = (state & (0x01 << 0)) > 0 ? true : false;
            IsEmergencyStop = (state & (0x01 << 4)) > 0 ? true : false;
            IsEnabled = (state & (0x01 << 5)) > 0 ? true : false;
            OnUpdateView?.Invoke(cmdPos, actPos, state);
        }

        public bool GoHome()
        {
            return Board.GoHome(AxisIndex, HomeVelLPluse, HomeVelHPluse, HomeAccPluse, HomeDccPluse, HomeMode, HomeDir);
        }

        public bool AbsMove(double pos, double speed = -1)
        {
            return Board.AbsMove(AxisIndex, MoveVelLPluse, speed == -1 ? MoveVelHPluse : speed * PlusePerUnit, MoveAccPluse, MoveDccPluse, pos * PlusePerUnit);
        }

        public bool JogMove(bool isPositive, double speed = -1)
        {
            return Board.JogMove(AxisIndex, isPositive, MoveVelLPluse, speed == -1 ? MoveVelHPluse : speed * PlusePerUnit, MoveAccPluse, MoveDccPluse);
        }

        public void RelMove(double dist, double speed = -1)
        {
            Board.RelMove(AxisIndex, MoveVelLPluse, speed == -1 ? MoveVelHPluse : speed * PlusePerUnit, MoveAccPluse, MoveDccPluse, dist * PlusePerUnit);
        }

        public void EndMove()
        {
            Board.Stop(AxisIndex);
        }

        public bool CheckIsStop()
        {
            return Board.CheckIsStop(AxisIndex);
        }

        public bool CheckIsInPos(double pos)
        {
            return Math.Abs(pos - GetCmdPos()) < Accuracy;
        }

        public byte GetAxisState()
        {
            return Board.GetAxisState(AxisIndex);
        }

        public double GetActPos()
        {
            return Board.GetActPos(AxisIndex) / PlusePerUnit;
        }

        public double GetCmdPos()
        {
            return Board.GetCmdPos(AxisIndex) / PlusePerUnit;
        }

        public void SetAxisServoEnabled(bool isOn)
        {
            Board.SetAxisServoEnabled(AxisIndex, isOn);
        }
    }
}
