using Interfaces.Expends;
using Interfaces.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticParameterLib
{
    public class StaticParameter : IStaticParameter
    {
        /// <summary>
        /// 对象
        /// </summary>
        private JObject Object = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="datas"></param>
        public StaticParameter(byte[] datas)
        {
            string msg = System.Text.Encoding.UTF8.GetString(datas);
            Object = JsonConvert.DeserializeObject(msg) as JObject;
            //Object = JObject.Parse(msg);
        }
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {

            string[] keys = key.Split('.');
            JToken jObject = Object;
            foreach (var item in keys)
            {
                jObject = jObject[item];
            }
            return jObject.ToString();

        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetValue<T>(string key)
        {
            string[] keys = key.Split('.');
            JToken jObject = Object;
            foreach (var item in keys)
            {
                jObject = jObject[item];
            }
            try
            {
                try
                {
                    return (T)Convert.ChangeType(jObject.ToString(), typeof(T));
                }
                catch (Exception ex)
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jObject.ToString());
                }
            }
            catch (Exception)
            {
                return default(T);
            }
        }
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="path"></param>
        public void Load(string path)
        {
            if (File.Exists(path))
            {
                Object = (JObject)JsonConvert.DeserializeObject(path.ReadFromFile<string>());
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="path"></param>
        public void Save(string path)
        {
            this.Object.ToString().ToFile(path);
        }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetValue<T>(string key, T value)
        {
            string[] keys = key.Split('.');
            JToken jObject = Object;
            if (keys.Length == 1)
            {
                jObject[key] = JToken.FromObject(value);
            }
            else
            {
                for (int i = 0; i < keys.Length - 1; i++)
                {
                    jObject = jObject[keys[i]];
                }
                jObject[keys.Last()] = JToken.FromObject(value);
            }
        }
    }
}
