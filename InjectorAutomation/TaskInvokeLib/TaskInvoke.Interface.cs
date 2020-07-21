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
    }
}
