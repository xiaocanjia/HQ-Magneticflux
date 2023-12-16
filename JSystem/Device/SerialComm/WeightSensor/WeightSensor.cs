using System;
using System.Threading;
using System.Threading.Tasks;

namespace JSystem.Device
{
    public class WeightSensor : SerialComm
    {
        private float[] _weightList = new float[2];

        public WeightSensor()
        {
            View = new WeightSensorView(this);
            StatusPanel = new DevStatusPanel(this);
            new Task(CalcWeight).Start();
        }

        public WeightSensor(string name) : this()
        {
            Name = name;
        }

        private void CalcWeight()
        {
            while (true)
            {
                Thread.Sleep(10);
                byte[] buffer = _bufferList.ToArray();
                _bufferList.Clear();
                for (int i = 0; i < buffer.Length; i++)
                {
                    if (i >= buffer.Length - 12)
                        break;
                    if (buffer[i] == 0x48 && buffer[i + 12] == 0x0A)
                    {
                        _weightList[0] = BitConverter.ToSingle(new byte[] { buffer[i + 6],  buffer[i + 5], buffer[i + 4], buffer[i + 3] }, 0);
                        _weightList[1] = BitConverter.ToSingle(new byte[] { buffer[i + 10], buffer[i + 9], buffer[i + 8], buffer[i + 7] }, 0);
                        i += 12;
                        ((WeightSensorView)View).UpdateWeight();
                    }
                }
            }
        }

        public float[] ReadWeight(int readCount = 1)
        {
            float[] weightList = new float[2];
            if (!CheckConnection()) return weightList;
            int count = 0;
            while (count < readCount)
            {
                Thread.Sleep(30);
                weightList[0] += _weightList[0];
                weightList[1] += _weightList[1];
            }
            weightList[0] /= readCount;
            weightList[1] /= readCount;
            return weightList;
        }
    }
}

