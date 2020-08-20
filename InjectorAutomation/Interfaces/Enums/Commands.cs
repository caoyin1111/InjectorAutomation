using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Enums
{
    public enum Commands
    {
        /// <summary>
        /// 初始化命令
        /// </summary>
        Init = 0x43,
        /// <summary>
        /// 操作Z轴命令
        /// </summary>
        OptionZAxis = 0x5a,
        /// <summary>
        /// 充电命令
        /// </summary>
        Power = 0x52,
        /// <summary>
        /// 侧键操作
        /// </summary>
        SlidKey = 0x4d,
        /// <summary>
        /// 手机治具复位命令
        /// </summary>
        PhoneJigRest = 0x53,
        /// <summary>
        /// 手机治具失能使能命令
        /// </summary>
        PhoneJigEnable = 0x45,
        /// <summary>
        /// 查询固件版本号
        /// </summary>
        Version = 0x56,
        /// <summary>
        /// 检测有无手机
        /// </summary>
        CheckPhone = 0x50,
    }
}
