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
    }
}
