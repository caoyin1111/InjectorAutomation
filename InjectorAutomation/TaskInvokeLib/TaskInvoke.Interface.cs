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
            int locationA =  ControlCom.GetHorizontalA();
            int location = locationA + distance;
            if (location <= 1350)
            {
                return ControlCom.MoveHorizontalA(location);
            }
            else
            {
                return ControlCom.MoveHorizontalA(1350);
            }


        }
        [Route("movehorizontalleftA", explanation: "移动水平轴A向左")]
        public bool MoveHorizontalLeftA(int distance)
        {
            int locationA = ControlCom.GetHorizontalA();
            int location = locationA - distance;
            if (location >= 0)
            {
                return ControlCom.MoveHorizontalA(location);
            }
            else
            {
                return ControlCom.RefreshElectricA();
            }
        }
        [Route("movehorizontalrightB",explanation:"移动水平轴B向右")]
        public bool MoveHorizontalRightB(int distance)
        {
            int locationB = ControlCom.GetHorizontalB();
            int location = locationB + distance;
            if(location<=1350)
            {
                return ControlCom.MoveHorizontalB(location);

            }
            else
            {
                return ControlCom.MoveHorizontalB(1350);
            }
           
        }
        [Route("movehorizontalleftB", explanation: "移动水平轴B向左")]
        public bool MoveHorizontalLeftB(int distance)
        {
            int locationB = ControlCom.GetHorizontalB();
            int location = locationB - distance;
            if(location>=0)
            {
                return ControlCom.MoveHorizontalB(location);
            }
            else
            {
                return ControlCom.MoveHorizontalB(0);
            }
            
        }
        [Route("movevectrialup", explanation: "移动垂直轴向上")]
        public bool MoveVectrialUp(int distance)
        {
            int locationV = ControlCom.GetVertical();
            int location = locationV - distance;
            if(location>=0)
            {
                return ControlCom.MoveVertical(location);
            }
            else
            {
                return ControlCom.MoveVertical(0);
            }
            
        }
        [Route("movevectrialdown", explanation: "移动垂直轴向下")]
        public bool MoveVectrialDown(int distance)
        {
            int locationV = ControlCom.GetVertical();
            int location = locationV + distance;
            if(location<=1000)
            {
                return ControlCom.MoveVertical(location);
            }
            else
            {
                return ControlCom.MoveVertical(1000);
            }
           
        }
        [Route("horizontalClampAtozero", explanation: "电动夹A归零")]
        public bool HorizontalClampAToZero()
        {
            return ControlCom.RefreshElectricClampA();

        }
        [Route("horizontalClampBtozero", explanation: "电动夹B归零")]
        public bool HorizontalClampBToZero()
        {
            return ControlCom.RefreshElectricClampB();

        }
        [Route("vectrialtozero", explanation: "垂直轴归零")]
        public bool VectrialToZero()
        {
            return ControlCom.RefreshElectricVertical();
        }
        [Route("horizontalAtozero",explanation:"水平轴A归零")]
        public bool HorizontalAToZero()
        {
            return ControlCom.RefreshElectricA();
            
        }
        [Route("horizontalBtozero", explanation: "水平轴B归零")]
        public bool HorizontalBToZero()
        {
            return ControlCom.RefreshElectricB();
        }
     
        [Route("expendB", explanation: "电动夹爪B放大")]
        public bool ExpendB(int distance)
        {
            int locaB = ControlCom.GetElectricClampB();
            int location = locaB - distance;
            if(location>=0)
            {
                return ControlCom.MoveElectricClampB(location);
            }
            else
            {
                return ControlCom.MoveElectricClampB(0);
            }
          
        }
        [Route("expendA", explanation: "电动夹爪A放大")]
        public bool ExpendA(int distance)
        {
            int locaA = ControlCom.GetElectricClampA();
            int location = locaA - distance;
            if (location >= 0)
            {
                return ControlCom.MoveElectricClampA(location);
            }
            else
            {
                return ControlCom.MoveElectricClampA(0);
            }
        }
        [Route("shrinkB", explanation: "电动夹爪B缩小")]
        public bool ShrinkB(int distance)
        {
            int locaB = ControlCom.GetElectricClampB();
            int location = locaB + distance;
            if(location<=360)
            {
                return ControlCom.MoveElectricClampB(location);
            }
            else
            {
                return ControlCom.MoveElectricClampB(360);
            }
            
        }
        [Route("shrinkA", explanation: "电动夹爪A缩小")]
        public bool ShrinkA(int distance)
        {
            int locaA = ControlCom.GetElectricClampA();
            int location = locaA + distance;
            if (location <=360)
            {
                return ControlCom.MoveElectricClampA(location);
            }
            else
            {
                return ControlCom.MoveElectricClampA(360);
            }
        }
     
        [Route("moveabsohorizontalA",explanation:"绝对移动水平轴A")]
        public bool MoveAbsoHorizontalA(int distance)
        {
            if (distance <= 1350)
            {
                return ControlCom.MoveHorizontalA(distance);
            }
            else
            {
                return ControlCom.MoveHorizontalA(1350);

            }
        }
        [Route("moveabsohorizontalB", explanation: "绝对移动水平轴B")]
        public bool MoveAbsoHorizontalB(int distance)
        {
            if (distance <= 1350)
            {
                return ControlCom.MoveHorizontalB(distance);
            }
            else
            {
                return ControlCom.MoveHorizontalB(1350);

            }
        }
        [Route("moveabsovertical", explanation: "绝对移动垂直轴")]
        public bool MoveAbsoVertical(int distance)
        {
            if (distance <= 1000)
            {
                return ControlCom.MoveVertical(distance);
            }
            else
            {
                return ControlCom.MoveVertical(1000);

            }
        }
        [Route("moveabsoClampA", explanation: "绝对移动电动夹A")]
        public bool MoveAbsoClampA(int distance)
        {
            if (distance <= 360)
            {
                return ControlCom.MoveElectricClampA(distance);
            }
            else
            {
                return ControlCom.MoveHorizontalA(360);

            }
        }
        [Route("moveabsoClampB", explanation: "绝对移动电动夹B")]
        public bool MoveAbsoClampB(int distance)
        {
            if (distance <= 360)
            {
                return ControlCom.MoveElectricClampB(distance);
            }
            else
            {
                return ControlCom.MoveHorizontalB(360);

            }
        }
        [Route("controlleftled", explanation: "控制左灯")]
        public bool ControlLeftLed(bool status)
        {
            return ControlCom.LeftLamp(status);
        }
        [Route("controlrightled", explanation: "控制右灯")]
        public bool ControlRightLed(bool status)
        {
            return ControlCom.RightLamp(status);
        }
        

        [Route("controlspeed",explanation:"控制速度")]
        public bool ControlSpeed(string status)
        {
            return ControlCom.ControlSpeed(status);
        }





    }
}
