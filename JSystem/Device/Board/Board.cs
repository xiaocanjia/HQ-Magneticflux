using System;
using Newtonsoft.Json;
using BoardSDK;

namespace JSystem.Device
{
    public class Board : DeviceBase
    {
        public int BoardType = 0;

        [JsonIgnore]
        private IBoard _board;

        private bool _isConnected = false;

        public Board()
        {
            View = new BoardView(this);
            StatusPanel = new DevStatusPanel(this);
        }

        public Board(string name) : this()
        {
            Name = name;
        }

        public override bool Connect()
        {
            _board = BoardFactory.CreateBoard((EBoardType)BoardType);
            return _board.Connect(AppDomain.CurrentDomain.BaseDirectory + $"Config\\{Name}.cfg");
        }

        public override void DisConnect()
        {
            _board?.Disconnect();
        }

        public override bool CheckConnection()
        {
            _isConnected = _board == null ? false : _board.CheckConnect();
            OnUpdateStatus?.Invoke(_isConnected);
            return _isConnected;
        }
        
        public bool SetOut(int axisIdx, int IOIdx, bool Value)
        {
            if (!_isConnected) return false;
            return _board.SetOut(axisIdx, IOIdx, Value);
        }
        
        public bool GetOut(int axisIdx, int IOIdx)
        {
            if (!_isConnected) return false;
            return _board.GetOut(axisIdx, IOIdx);
        }
        
        public bool GetIn(int axisIdx, int IOIdx)
        {
            if (!_isConnected) return false;
            return _board.GetIn(axisIdx, IOIdx);
        }
        
        public bool ClearAlarm(int axis)
        {
            if (!_isConnected) return false;
            return _board.ClearAlarm(axis);
        }

        public bool SetAxisServoEnabled(int axis, bool isOn)
        {
            if (!_isConnected) return false;
            return _board.SetAxisServoEnabled(axis, isOn);
        }

        public bool GoHome(int axis, double homeVelL, double homeVelH, double homeAcc, double homeDcc, uint homeMode, uint homeDir)
        {
            if (!_isConnected) return false;
            return _board.GoHome(axis, homeVelL, homeVelH, homeAcc, homeDcc, homeMode, homeDir);
        }

        public bool CheckIsStop(int axis)
        {
            if (!_isConnected) return false;
            return _board.CheckIsStop(axis);
        }

        public byte GetAxisState(int axis)
        {
            if (!_isConnected) return 0;
            return _board.GetAxisState(axis);
        }

        public double GetActPos(int axis)
        {
            if (!_isConnected) return 0.0;
            return _board.GetActPos(axis);
        }

        public double GetCmdPos(int axis)
        {
            if (!_isConnected) return 0.0;
            return _board.GetCmdPos(axis);
        }

        public bool AbsMove(int axis, double moveVelL, double moveVelH, double moveAcc, double moveDcc, double pos)
        {
            if (!_isConnected) return false;
            return _board.AbsMove(axis, moveVelL, moveVelH, moveAcc, moveDcc, pos);
        }

        public bool RelMove(int axis, double moveVelL, double moveVelH, double moveAcc, double moveDcc, double dist)
        {
            if (!_isConnected) return false;
            return _board.RelMove(axis, moveVelL, moveVelH, moveAcc, moveDcc, dist);
        }

        public bool JogMove(int axis, bool isPositive, double moveVelL, double moveVelH, double moveAcc, double moveDcc)
        {
            if (!_isConnected) return false;
            return _board.JogMove(axis, isPositive, moveVelL, moveVelH, moveAcc, moveDcc);
        }

        public bool Stop(int axis)
        {
            if (!_isConnected) return false;
            return _board.Stop(axis);
        }

        public bool InstancyStop(int axis)
        {
            if (!_isConnected) return false;
            return _board.InstancyStop(axis);
        }
    }
}
