using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Items
{
    public class DoTaskParameterItem
    {
        /// <summary>
        /// 路由地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 方法信息
        /// </summary>
        public MethodInfo Method { get; set; }
        /// <summary>
        /// 参数
        /// </summary>
        public List<ParameterItem> Paramters { get; set; } = new List<ParameterItem>();
        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddParamter(string key,string value)
        {
            Paramters.Add(new ParameterItem() { ParameterName = key, Value = value });
        } /// <summary>
          /// 获取值
          /// </summary>
          /// <typeparam name="T"></typeparam>
          /// <param name="key"></param>
          /// <returns></returns>
        public string GetValue(string key)
        {
            return Paramters.Where(p => p.ParameterName.Equals(key)).FirstOrDefault().Value;
        }
    }
}
