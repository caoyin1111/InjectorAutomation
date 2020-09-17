using Interfaces.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interfaces
{
    public interface ITaskInoke
    {
        /// <summary>
        /// 执行接口
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameterItem"></param>
        /// <returns></returns>
        object DoInterface(string url, DoTaskParameterItem parameterItem);
        /// <summary>
        /// 获取接口列表
        /// </summary>
        /// <returns></returns>
        Dictionary<string, DoTaskParameterItem> GetInterfaces();
        /// <summary>
        /// 关闭
        /// </summary>
        void Close();
        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        void Link(string ip, int port);
        /// <summary>
        /// 串口组
        /// </summary>
        List<KeyValueItem<string, string>> Coms { get; }
        int GetMoveA();
        int GetMoveB();
        int GetVertical();
        int GetMoClampA();
        int GetMoClampB();
        bool ControlSp(string sta);
    }
}
