using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Items
{
    public class KeyValueItem<T,V>:BaseNotify
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="t"></param>
        /// <param name="v"></param>
        public KeyValueItem(T t, V v)
        {
            this.Key = t;
            this.Value = v;
        }

        private T key;

        public T Key
        {
            get => key;
            set
            {
                key = value;
                Changed("Key");
            }
        }

        private V value;

        public V Value
        {
            get => value;
            set
            {
                this.value = value;
                Changed("Value");
            }
        }
    }
}
