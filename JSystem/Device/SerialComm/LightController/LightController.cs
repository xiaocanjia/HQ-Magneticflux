using System;

namespace JSystem.Device
{
    public class LightController : SerialComm
    {
        public LightController()
        {
            View = new LightControllerView(this);
            StatusPanel = new DevStatusPanel(this);
        }

        public LightController(string name) : this()
        {
            Name = name;
        }

        public void SetLightness(int channel, int lightness)
        {
            byte[] bLightness = BitConverter.GetBytes((ushort)lightness);
            WriteCommand(new byte[] { 0x48, 0x59, 0x01, (byte)channel, bLightness[1], bLightness[0], 0x00, 0x00, 0x0d, 0x0a });
        }
    }
}

