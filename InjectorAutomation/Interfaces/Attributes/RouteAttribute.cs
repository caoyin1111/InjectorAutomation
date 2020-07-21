using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Attributes
{
    public class RouteAttribute : Attribute
    {
        public string Url { get; set; }
        /// <summary>
        /// 解释
        /// </summary>
        public string Explanation { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url">路由地址</param>
        /// <param name="explanation">解释</param>
        public RouteAttribute(string url, string explanation = "")
        {
            this.Url = url;
            this.Explanation = explanation;
        }
    }
}
