using System.Threading;
using System.Threading.Tasks;

namespace JSystem.Device
{
    public class HeightSensor : SerialComm
    {
        private float _height = 0.0f;
        
        public HeightSensor()
        {
            View = new HeightSensorView(this);
            StatusPanel = new DevStatusPanel(this);
            new Task(CalcHeight).Start();
        }

        public HeightSensor(string name) : this()
        {
            Name = name;
        }

        private void CalcHeight()
        {
            while (true)
            {
                Thread.Sleep(10);
                byte[] buffer = _bufferList.ToArray();
                _bufferList.Clear();
                for (int i = 0; i < _bufferList.Count; i++)
                {
                    if (i >= _bufferList.Count - 9)
                        break;
                    if (_bufferList[i] == 0x80 && _bufferList[i + 8] == 0x16)
                    {
                        _height = ((buffer[i + 5] << 8) | buffer[i + 4]) / 10.0f;
                        i += 9;
                        ((HeightSensorView)View).UpdateHeight();
                    }
                }
            }
        }

        public float ReadHeight(int readCount = 1)
        {
            float height = 0.0f;
            if (!CheckConnection()) return height;
            int count = 0;
            while (count < readCount)
            {
                Thread.Sleep(30);
                height += _height;
            }
            height /= readCount;
            return height;
        }
    }
}

