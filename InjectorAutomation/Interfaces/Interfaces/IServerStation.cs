using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interfaces
{
    public interface IServerStation
    {
        /// <summary>
        /// 启动服务站点
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        bool Start(string ip, int port);
        /// <summary>
        /// 添加站点路由信息
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        bool AddStationObjectClass(object target);
        /// <summary>
        /// 添加参数转化器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="converter"></param>
        /// <returns></returns>
        bool AddParameterConverter<T>(Func<string, object> converter);
        /// <summary>
        /// 关闭
        /// </summary>
        void Close();
    }
}
