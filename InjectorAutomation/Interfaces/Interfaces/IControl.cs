using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interfaces
{
    /// <summary>
    /// 串口控制
    /// </summary>
    public interface IControl
    {
        /// <summary>
        /// 打开
        /// </summary>
        void Open();
        /// <summary>
        /// 关闭
        /// </summary>
        void Close();
  
        void Init(string portName, int bandRoate, Parity parity, int dataP, StopBits stopBits);
        bool MoveHorizontalA(int distance);
        bool MoveHorizontalB(int distance);
        bool MoveVertical(int distance);
        bool MoveElectricClampA(int distance);
        bool MoveElectricClampB(int distance);
        int GetHorizontalA();
        int GetHorizontalB();
        int GetVertical();
        int GetElectricClampA();
        int GetElectricClampB();
        bool RefreshElectricA();
        bool RefreshElectricB();
        bool RefreshElectricVertical();
        bool RefreshElectricClampB();
        bool RefreshElectricClampA();
        bool ControlSystemLED(string colo);
        bool LeftLamp(bool status);
        bool RightLamp(bool status);
        bool ControlSpeed(string sta);

    }
}
