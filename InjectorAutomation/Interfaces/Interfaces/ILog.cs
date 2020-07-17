using Interfaces.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interfaces
{
    public interface ILog
    {
        /// <summary>
        /// 打印一般日志
        /// </summary>
        /// <param name="msg">消息</param>
        void log(params object[] msg);
        /// <summary>
        /// 打印警告日志
        /// </summary>
        /// <param name="msg"></param>
        void waring(params object[] msg);
        /// <summary>
        /// 打印错误日志
        /// </summary>
        /// <param name="msg"></param>
        void error(params object[] msg);

        /// <summary>
        /// 日志回调
        /// </summary>
        Action<string, LogType> LogCallBack { get; set; }
    }
}
