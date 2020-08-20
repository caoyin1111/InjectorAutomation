using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Expends
{
    public static class Expends
    {
       
        /// <summary>
        /// 把from中的所有元素添加到to的集合中并且返回to
        /// </summary>
        /// <typeparam name="T">集合中的元素类型</typeparam>
        /// <param name="to">集合</param>
        /// <param name="from">集合</param>
        /// <returns>to集合</returns>
        public static ICollection<T> AddRange<T>(this ICollection<T> to, ICollection<T> from)
        {
            from.Foreach(t => to.Add(t));
            return to;
        }
        /// <summary>
        /// 通过反射设置对象的具有访问器的值
        /// </summary>
        /// <param name="obj">属性所属的对象</param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="value">属性需要被赋值的值</param>
        public static void SetObjectPropertyValue(this object obj, string propertyName, object value)
        {
            obj.GetType().GetProperty(propertyName).SetValue(obj, value);
        }
        /// <summary>
        /// 获取属性的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static T GetObjectPropertyValue<T>(this object obj, string propertyName)
        {
            return (T)obj.GetType().GetProperty(propertyName).GetValue(obj);
        }
       
        /// <summary>
        /// 清空队列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queues"></param>
        /// <param name="action"></param>
        public static void ClearAll<T>(this ConcurrentQueue<T> queues, Action<T> action)
        {
            T t;
            while (queues.TryDequeue(out t)) { action?.Invoke(t); }
        }
        /// <summary>
        /// 路径组合
        /// </summary>
        /// <param name="path1">第一个路径</param>
        /// <param name="paths">其他路径</param>
        /// <returns>返回整合的路径</returns>
        public static string Combine(this string path1, params string[] paths)
        {
            List<string> path = new List<string>();
            path.Add(path1);
            path.AddRange(paths);
            return System.IO.Path.Combine(path.ToArray());
        }
        /// <summary>
        /// 格式化字符串 {0}{1}
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="objs">填充的对象</param>
        /// <returns></returns>
        public static string Format(this string msg, params object[] objs)
        {
            return string.Format(msg, objs);
        }
        /// <summary>
        /// 集合转换到字符串
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="center">间隔符</param>
        /// <returns></returns>
        public static string JoinToString(this IEnumerable enumerable, string center)
        {
            string msg = "";
            foreach (var item in enumerable)
            {
                msg += item.ToString() + center;
            }
            return msg;
        }
        /// <summary>
        /// 集合转换到字符串
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="enumerable">集合</param>
        /// <param name="center">间隔符</param>
        /// <param name="func">转换到字符串的处理函数</param>
        /// <returns></returns>
        public static string JoinToString<T>(this IEnumerable<T> enumerable, string center, Func<T, string> func)
        {
            string msg = "";
            foreach (var item in enumerable)
            {
                msg += func?.Invoke(item) + center;
            }
            return msg;
        }


        public static List<int> GetRange(this int start, int end)
        {
            List<int> values = new List<int>();
            start.Range(end + 1, p => { values.Add(p); return true; });
            return values;
        }
        /// <summary>
        /// for循环[from, to)
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="action">返回false跳出循环</param>
        public static void Range(this int from, int to, Func<int, bool> action)
        {
            if (from < to)
            {
                for (int i = from; i < to; i++)
                {
                    if (!action(i))
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int i = from; i > to; i--)
                {
                    if (!action(i))
                    {
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// 匹配value与后续所有的参数，如果正确匹配到条件则回调equalevent
        /// </summary>
        /// <param name="value"></param>
        /// <param name="equalevent">返回false则终止循环</param>
        /// <param name="args"></param>
        public static bool EqualLists(this string value, Func<string, bool> equalevent, params string[] args)
        {
            return args.Foreach(t => {
                string tv = t as string;
                if (value.Equals(tv))
                {
                    return equalevent(tv);
                }
                return true;
            });
        }
        /// <summary>
        /// 枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerator"></param>
        /// <param name="func"></param>
        /// <returns>返回enumerator可让表达式继续</returns>
        public static IEnumerable<T> Foreach<T>(this IEnumerable<T> enumerator, Action<T> func)
        {
            foreach (var item in enumerator)
            {
                func?.Invoke(item);
            }
            return enumerator;
        }
        /// <summary>
        /// 枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerator"></param>
        /// <param name="func"></param>
        /// <returns>返回是否全部遍历</returns>
        public static bool Foreach<T>(this IEnumerable<T> enumerator, Func<T, bool> func)
        {
            foreach (var item in enumerator)
            {
                if (!func(item))
                {
                    return false;
                }
            }
            return true;
        }

    
        /// <summary>
        /// 转换集合类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="enumerator"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<V> ChangedList<T, V>(this IEnumerable<T> enumerator, Func<T, V> func)
        {
            List<V> vs = new List<V>();

            enumerator.Foreach(t => {
                vs.Add(func(t));
            });
            return vs;
        }
        /// <summary>
        /// 列举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerator"></param>
        public static void Foreach<T, V>(this IDictionary<T, V> enumerator, Action<T, V> func)
        {
            foreach (var item in enumerator)
            {
                func?.Invoke(item.Key, item.Value);
            }
        }
        /// <summary>
        /// 列举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerator"></param>
        public static void Foreach(this IEnumerable enumerator, Action<object> func)
        {
            foreach (var item in enumerator)
            {
                func?.Invoke(item);
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerator"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<T> Where<T, V>(this IDictionary<T, V> enumerator,
            Func<T, V, bool> func)
        {
            List<T> ts = new List<T>();
            enumerator.Foreach((c, v) => {
                if (func?.Invoke(c, v) == true)
                {
                    ts.Add(c);
                }
            });
            return ts;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerator"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<T> Where<T>(this IEnumerable enumerator, Func<object, bool> func)
        {
            List<T> ts = new List<T>();
            enumerator.Foreach(_ => {
                if (func?.Invoke(_) == true)
                {
                    ts.Add((T)_);
                }
            });
            return ts;
        }
        /// <summary>
        /// 转到到对应的枚举类型的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetEnumType<T>(this string name)
        {
            return Enum.GetValues(typeof(T)).Where<T>(c => c.ToString().Equals(name)).First();
        }
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="path"></param>
        public static void ToFile(this object obj, string path)
        {
            System.IO.File.WriteAllBytes(path, Newtonsoft.Json.JsonConvert.SerializeObject(obj).ToBytes());
        }
        /// <summary>
        /// 从文件读取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T ReadFromFile<T>(this string path)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(
                System.Text.Encoding.UTF8.GetString(
                    System.IO.File.ReadAllBytes(path)));
        }


        /// <summary>
        /// 字符串转换到字节
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static byte[] ToBytes(this string msg)
        {
            return System.Text.Encoding.UTF8.GetBytes(msg);
        }
        /// <summary>
        /// 获取枚举类型T中的attribute属性V
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns></returns>
        public static IEnumerable<V> GetEnumModeType<T, V>()
        {
            List<V> vs = new List<V>();
            Type t = typeof(T);
            Array arrays = Enum.GetValues(t);
            for (int i = 0; i < arrays.LongLength; i++)
            {
                T test = (T)arrays.GetValue(i);
                FieldInfo fieldInfo = test.GetType().GetField(test.ToString());
                object[] attribArray = fieldInfo.GetCustomAttributes(false);
                foreach (var item in attribArray)
                {
                    if (item is V)
                    {
                        vs.Add((V)item);
                        break;
                    }
                }
            }
            return vs;
        }
      
        /// <summary>
        /// 获取value的枚举类型的注释名称,value必须是枚举类型，并且有Attribute的注释才能获取
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T GetEnumTypeModeName<T>(this object value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            object[] attribArray = fieldInfo.GetCustomAttributes(false);
            foreach (var item in attribArray)
            {
                if (item is T)
                {
                    return (T)item;
                }
            }
            return default(T);
        }
        /// <summary>
        /// 获取类上的指定特性
        /// </summary>
        /// <typeparam name="T">特性类型</typeparam>
        /// <param name="value">类对象</param>
        /// <returns></returns>
        public static T GetAttributeByClass<T>(this object value)
        {
            //引用类型为null，值类型为0
            T t = default(T);
            var attributes = value.GetType().GetCustomAttributes(false);
            attributes.Foreach(a => {
                if (a is T)
                {
                    t = (T)a;
                    return false;
                }
                return true;
            });
            return t;
        }



       
        /// <summary>
        /// 转换到基础类型
        /// </summary>
        /// <typeparam name="T">具体的基础类型</typeparam>
        /// <param name="baseobj">待转换的对象</param>
        /// <returns></returns>
        public static T ToBaseType<T>(this object baseobj)
        {
            return (T)Convert.ChangeType(baseobj, typeof(T));
        }
        /// <summary>
        /// double类型保留小数
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="format">保留小数的形式</param>
        /// <returns></returns>
        public static double ToSavePoint(this double value, string format)
        {
            return value.ToString(format).ToBaseType<double>();
        }

       
       
    }
}
