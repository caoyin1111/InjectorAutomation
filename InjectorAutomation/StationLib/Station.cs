using Interfaces.Attributes;
using Interfaces.Expends;
using Interfaces.Interfaces;
using ServerStationLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StationLib
{
    public class Station : IServerStation
    {
        /// <summary>
        /// 服务器站点
        /// </summary>
        private ServerStation ServerStation { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        public ILog Log { get; set; }
        public Station()
        {
            this.ServerStation = new ServerStation();
            ServerStation.ErrorMsg += new Action<object[]>(do_Error);
        }
        /// <summary>
        /// 转化器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="converter"></param>
        /// <returns></returns>
        public bool AddParameterConverter<T>(Func<string, object> converter)
              => this.ServerStation.AddTypeConverter<T>(converter);
        /// <summary>
        /// 添加站点路由信息
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool AddStationObjectClass(object target)
        {
            RouteAttribute classRoute = target.GetAttributeByClass<RouteAttribute>();
            if (classRoute == null) return false;

            string rootPath = classRoute.Url;

            var methods = target.GetType().GetMethods();
            methods.Foreach(m => {
                var attributes = m.GetCustomAttributes().Where(a => a is RouteAttribute);
                if (attributes.Count() > 0)
                {
                    RouteAttribute route = attributes.First() as RouteAttribute;
                    this.ServerStation.AddRoute(rootPath + route.Url,
                        target, m.Name);
                }
            });
            return true;
        }
        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            this.ServerStation.Close();
        }
        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public bool Start(string ip, int port)
        {
            return this.ServerStation.Start(ip, port);
        }
        public void do_Error(object[] obj)
        {
            Log.error(obj);
        }

    }
}
