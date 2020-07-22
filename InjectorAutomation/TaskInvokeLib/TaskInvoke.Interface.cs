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
        [Route("movehorizontalA",explanation:"移动水平轴A")]
        public bool MoveHorizontalA(int distance)
        {
            return false;
        }
        [Route("movehorizontalB",explanation:"移动水平轴B")]
        public bool MoveHorizontalB(int distance)
        {
            return false;
        }
        [Route("movevectrial", explanation: "移动垂直轴")]
        public bool MoveVectrial(double distance)
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

    }
}
