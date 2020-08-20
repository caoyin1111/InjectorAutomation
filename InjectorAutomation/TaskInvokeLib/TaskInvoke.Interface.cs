using Interfaces.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskInvokeLib
{
    public partial class TaskInvoke
    {
        [Route("movehorizontalrightA",explanation:"移动水平轴A向右")]
        public bool MoveHorizontalRightA(int distance)
        {
            return false;
        }
        [Route("movehorizontalleftA", explanation: "移动水平轴A向左")]
        public int MoveHorizontalLeftA(int distance)
        {
            return 20;
        }
        [Route("movehorizontalrightB",explanation:"移动水平轴B向右")]
        public bool MoveHorizontalRightB(int distance)
        {
            return false;
        }
        [Route("movehorizontalleftB", explanation: "移动水平轴B向左")]
        public bool MoveHorizontalLeftB(int distance)
        {
            return false;
        }
        [Route("movevectrialup", explanation: "移动垂直轴向上")]
        public bool MoveVectrialUp(int distance)
        {
            return false;
        }
        [Route("movevectrialdown", explanation: "移动垂直轴向下")]
        public bool MoveVectrialDown(int distance)
        {
            return false;
        }
        [Route("horizontalAtozero",explanation:"水平轴A归零")]
        public bool HorizontalAToZero()
        {
            return false;
        }
        [Route("horizontalBtozero", explanation: "水平轴B归零")]
        public bool HorizontalBToZero()
        {
            return false;
        }
        [Route("vectrialtozero", explanation: "垂直轴归零")]
        public bool VectrialToZero()
        {
            return false;
        }
        [Route("expendB", explanation: "电动夹爪B放大")]
        public bool ExpendB(int distance)
        {
            return false;
        }
        [Route("expendA", explanation: "电动夹爪A放大")]
        public bool ExpendA(int distance)
        {
            return false;
        }
        [Route("shrinkB", explanation: "电动夹爪B缩小")]
        public bool ShrinkB(int distance)
        {
            return false;
        }
        [Route("shrinkA", explanation: "电动夹爪A缩小")]
        public bool ShrinkA(int distance)
        {
            return false;
        }




    }
}
