using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interfaces
{
    public interface IWindow : IDisposable
    {
        /// <summary>
        /// 显示窗口
        /// </summary>
        void ShowWindow();
    }
}
