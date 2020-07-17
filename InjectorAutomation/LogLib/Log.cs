using Interfaces.Enums;
using Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xyxandwxx.LobLib;

namespace LogLib
{
    public class Log:ILog
    {
        public LogInfo LogInfo { get; set; }
        /// <summary>
        /// 日志回调
        /// </summary>
        public Action<string,LogType> LogCallBack { get; set; }
        public Log(string name)
        {
            LogInfo = new LogInfo() { FileName = name };
            LogInfo.ErroStringEvent += LogInfo_ErroStringEvent;
        }

        private void LogInfo_ErroStringEvent(LogMessage obj)
        {
            LogType logType = LogType.Normal;
            switch (obj.Type)
            {
                case LogErroType.Normal:
                    break;
                case LogErroType.Waring:
                    logType = LogType.Waring;
                    break;
                case LogErroType.Erro:
                    logType = LogType.Error;
                    break;
                case LogErroType.Debug:
                    logType = LogType.Waring;
                    break;
                default:
                    break;
            }
            LogCallBack?.Invoke(obj.NormalMessage + obj.DetailMessage, logType);
        }
        public void error(params object[] msg)
        {
            LogInfo.erro(msg);
        }

        public void log(params object[] msg)
        {
            LogInfo.log(msg);
        }

        public void waring(params object[] msg)
        {
            LogInfo.debug(msg);
        }
    }
}
