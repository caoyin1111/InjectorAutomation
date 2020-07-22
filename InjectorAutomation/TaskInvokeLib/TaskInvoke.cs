using Interfaces.Attributes;
using Interfaces.Expends;
using Interfaces.Interfaces;
using Interfaces.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Newtonsoft.Json;

namespace TaskInvokeLib
{
    [Route("taskinvoke/")]
    public partial class TaskInvoke : ITaskInoke
    {
        /// <summary>
        /// 服务器站点
        /// </summary>
        public IServerStation ServerStation { get; set; }
        /// <summary>
        /// 控制板
        /// </summary>
        public IControl ControlCom { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        public ILog Log { get; set; }
        /// <summary>
        /// 静态参数
        /// </summary>
        public IStaticParameter StaticParameter { get; set; }
        /// <summary>
        /// 任务函数核参数列表
        /// </summary>
        private Dictionary<string, DoTaskParameterItem> TaskParameterItems = new Dictionary<string, DoTaskParameterItem>();
        /// <summary>
        /// 串口组
        /// </summary>
        public List<KeyValueItem<string, string>> Coms { get; set; }
        = new List<KeyValueItem<string, string>>() {
            new KeyValueItem<string, string>("控制板", "COM3"),
        };
        public void Close()
        {
            try
            {
                Log.log("关闭服务器");
                ServerStation.Close();
                Log.log("关闭控制板");
                ControlCom.Close();
            }
            catch(Exception ex)
            {
                Log.log("关闭异常");
                Log.error(ex);
            }
        }
        /// <summary>
        /// 执行接口
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameterItem"></param>
        /// <returns></returns>
        public object DoInterface(string url, DoTaskParameterItem parameterItem)
        {
            var method = parameterItem.Method;
            ParameterInfo[] parameterInfos = method.GetParameters();
            object[] paras = new object[parameterInfos.Length];
            foreach(ParameterInfo info in parameterInfos)
            {
                string valueMsg = parameterItem.GetValue(info.Name);
                if (info.ParameterType.IsValueType || info.ParameterType.FullName.Equals(typeof(string).FullName))
                {
                    paras[info.Position] = Convert.ChangeType(valueMsg, info.ParameterType);
                }
                else
                {
                    paras[info.Position] = JsonConvert.DeserializeObject(valueMsg, info.ParameterType);

                }
            }
            return method.Invoke(this, paras);
        }
        /// <summary>
        /// 获取接口数据
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, DoTaskParameterItem> GetInterfaces()
        {
            if(TaskParameterItems.Count()!=0)
            {
                return TaskParameterItems;
            }
            else
            {
                RouteAttribute classRoute = this.GetAttributeByClass<RouteAttribute>();
                string rootPath = classRoute.Url;
                var methods = this.GetType().GetMethods();
                methods.Foreach(m =>
                {
                    var attributes = m.GetCustomAttributes().Where(a => a is RouteAttribute);
                    if (attributes.Count() > 0)
                    {
                        RouteAttribute route = attributes.First() as RouteAttribute;
                        List<ParameterItem> paramters = new List<ParameterItem>();
                        m.GetParameters().Foreach(p =>
                        {
                            var it = new ParameterItem()
                            {
                                ParameterName = p.Name,
                            };
                            if (p.HasDefaultValue)
                            {
                                it.Value = p.DefaultValue.ToString();
                            }
                            paramters.Add(it);

                        });
                        this.TaskParameterItems.Add(rootPath + route.Url + string.Format("{0}", route.Explanation),
                            new DoTaskParameterItem()
                            {
                                Paramters = paramters,
                                Url = rootPath + route.Url,
                                Method = m
                            });
                    }
                });
                return TaskParameterItems;
            }
           
        }
        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public void Link(string ip, int port)
        {
            try
            {
                ServerStation.AddStationObjectClass(this);
                Log.log("添加路由!");
                ServerStation.Start(ip, port);
                Log.log("服务器启动成功");
                ControlCom.Init(Coms[0].Value, Convert.ToInt32(StaticParameter.GetValue("Control.BandRote")),

                    System.IO.Ports.Parity.None, Convert.ToInt32(StaticParameter.GetValue("Control.DataBits")), System.IO.Ports.StopBits.One);
                ControlCom.Open();
                Log.log("连接控制成功");
            }
            catch(Exception ex)
            {
                Log.log("连接设备失败");
                Log.error(ex);

            }
        }
    }
}
