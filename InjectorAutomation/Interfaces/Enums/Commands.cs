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
        /// 电机A
        /// </summary>
        ElectricMachineryA = 0x05,
        /// <summary>
        /// 电机B
        /// </summary>
        ElectricMachineryB = 0x04,
        /// <summary>
        /// 垂直电机
        /// </summary>
        ElectricVertical = 0x03,
        /// <summary>
        /// 电动夹爪A
        /// </summary>
        ElectricClampA = 0x02,
        /// <summary>
        /// 电动夹爪B
        /// </summary>
        ElectricClampB = 0x01,
        /// <summary>
        /// 速度控制
        /// </summary>
        Speed = 0x10,
        /// <summary>
        /// 右灯
        /// </summary>
        RightLamp = 0x20,
        /// <summary>
        /// 左灯
        /// </summary>
        LeftLamp = 0x21,
        /// <summary>
        /// 系统指示灯
        /// </summary>
        SystemLED = 0x30,
        /// <summary>
        /// 电动夹B位置
        /// </summary>
        ElectricClampBLocation = 0x41,
        /// <summary>
        /// 电动夹A位置
        /// </summary>
        ElectricClampALocation = 0x42,
        /// <summary>
        /// 垂直电机位置
        /// </summary>
        ElectricVerticalLocation = 0x43,
        /// <summary>
        /// 电机B位置
        /// </summary>
        ElectricMachineryBLocation = 0x44,
        /// <summary>
        /// 电机A位置
        /// </summary>
        ElectricMachineryALocation = 0x45,
        /// <summary>
        /// 电动夹爪B复位
        /// </summary>
        ElectricClampBReset = 0x51,
        /// <summary>
        /// 电动夹爪A复位
        /// </summary>
        ElectricClampAReset = 0x52,
        /// <summary>
        /// 垂直电机复位
        /// </summary>
        ElectricVerticalReset = 0x53,
        /// <summary>
        /// 电机B复位
        /// </summary>
        ElectricMachineryBReset =0x54,
        /// <summary>
        /// 电机A复位
        /// </summary>
        ElectricMachineryAReset = 0x55


    }
}
