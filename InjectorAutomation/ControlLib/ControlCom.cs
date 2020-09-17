using Interfaces.Enums;
using Interfaces.Expends;
using Interfaces.Interfaces;
using SerialControlLib;
using SerialControlLib.Items;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlLib
{
    public class ControlCom : IControl
    {
        /// <summary>
        /// 日志
        /// </summary>
        public ILog Log { get; set; }
        /// <summary>
        /// 串口
        /// </summary>
        private SerialControl SerialControl { get; set; } = new SerialControl();
        /// <summary>
        /// 串口名
        /// </summary>
        public string PortName { get; set; }
        /// <summary>
        /// 波特率
        /// </summary>
        public int BandRoate { get; set; }
        /// <summary>
        /// 校验方法
        /// </summary>
        public Parity Parity { get; set; }
        /// <summary>
        /// 数据位
        /// </summary>
        public int DataP { get; set; }
        /// <summary>
        /// 停止位
        /// </summary>
        public StopBits StopBit { get; set; }
        /// <summary>
        /// 接收的数据
        /// </summary>
        private List<byte> recData = new List<byte>();

        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            try
            {
                SerialControl.Close();
                SerialControl.Dispose();
                SerialControl = null;
            }
            catch(Exception ex)
            {
                Log.error("关闭串口失败", ex);
            }
            finally
            {
                SerialControl = new SerialControl();
            }
        
        }
       
        /// <summary>
        /// 打开
        /// </summary>
        public void Open()
        {
            if(SerialControl.IsOpen)
            {
                Close();
            }
            SerialControl.Parity = Parity;
            SerialControl.BaudRate = BandRoate;
            SerialControl.StopBits = StopBit;
            SerialControl.PortName = PortName;
            SerialControl.DataBits = DataP;
            SerialControl.Head = 0xee;
            SerialControl.End = 0xff;
            SerialControl.Open();
        }
       

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="bandRoate"></param>
        /// <param name="parity"></param>
        /// <param name="dataP"></param>
        /// <param name="stopBits"></param>
        public void Init(string portName,int bandRoate,Parity parity,int dataP,StopBits stopBits)
        {
            this.PortName = portName;
            this.BandRoate = bandRoate;
            this.Parity = parity;
            this.DataP = dataP;
            this.StopBit = stopBits;
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="command"></param>
        /// <param name="datas"></param>
        /// <returns></returns>
        private SerialResponse Send(Commands command,List<byte> datas)
        {

            try
            {

                SerialRequest serialRequest = SerialControl.CreateRequest();
                serialRequest.SetData((byte)command, datas);
                SerialResponse response = SerialControl.Send(serialRequest);
           
                if (response.SourceDatas == null || response.SourceDatas.Count() == 0)
                {
                    Log.error("异常，未接收到任何数据");
                    throw new Exception("异常，为接收到任何数据!");

                }
                if (response.UserDatas[0] != 0x00)
                {
                    Log.error(string.Format("操作命令异常 : 命令关键字 - {0}, 错误吗 - {1}, 实际接收的全部数据 - {2}"
                        , serialRequest.KeyWorld.ToString("x2"), response.UserDatas[0].ToString("x2"), response.SourceDatas.JoinToString(",", b =>
                             b.ToString("X2")
                        )));
                    throw new Exception(string.Format("操作命令异常 : 命令关键字 - {0}, 错误吗 - {1}, 实际接收的全部数据 - {2}"
                        , serialRequest.KeyWorld.ToString("x2"), response.UserDatas[0].ToString("x2"), response.SourceDatas.JoinToString(",", b =>
                             b.ToString("X2")
                        )));
                }
                else
                {
                    Log.log("接受数据 : ", response.SourceDatas.JoinToString(",", b =>
                            b.ToString("X2")
                        ));
                    return response;
                }
            }
            catch(Exception ex)
            {
                Log.error("发送数据问题：" + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// 拆分一个整形到2个字节
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private List<byte> splitIntToDoubleByte(int value)
        {
            //前面是高位，后面是低位
            return new List<byte>(){ (byte)(value >> 8), (byte)(((UInt16)value) << 8 >> 8) };
        }
        /// <summary>
        /// 移动水平轴A
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        public bool MoveHorizontalA(int distance)
        {
            try
            {



                SerialResponse re = Send(Commands.ElectricMachineryA, splitIntToDoubleByte(distance));
                if (re == null)
                {
                    return false;
                }
                return re.UserDatas[0] == 0;
            }
            catch (Exception e)
            {
                Log.error(e.Message);
                return false;
            }
        }
        /// <summary>
        /// 移动水平轴B
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        public bool MoveHorizontalB(int distance)
        {
            try
            {


                SerialResponse re = Send(Commands.ElectricMachineryB, splitIntToDoubleByte(distance));
                if (re == null)
                {
                    return false;
                }
                return re.UserDatas[0] == 0;
            }
            catch (Exception e)
            {
                Log.error(e.Message);
                return false;
            }
        }
        /// <summary>
        /// 移动垂直轴
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        public bool MoveVertical(int distance)
        {
            try
            {


                SerialResponse re = Send(Commands.ElectricVertical, splitIntToDoubleByte(distance));
                if (re == null)
                {
                    return false;
                }
                return re.UserDatas[0] == 0;
            }
            catch (Exception e)
            {
                Log.error(e.Message);
                return false;
            }
        }
        /// <summary>
        /// 移动电动夹A
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        public bool MoveElectricClampA(int distance)
        {
            try
            {


                SerialResponse re = Send(Commands.ElectricClampA, splitIntToDoubleByte(distance));
                if (re == null)
                {
                    return false;
                }
                return re.UserDatas[0] == 0;
            }
            catch (Exception e)
            {
                Log.error(e.Message);
                return false;
            }
        }
        /// <summary>
        /// 移动电动夹B
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        public bool MoveElectricClampB(int distance)
        {
            try
            {


                SerialResponse re = Send(Commands.ElectricClampB, splitIntToDoubleByte(distance));
                if (re == null)
                {
                    return false;
                }
                return re.UserDatas[0] == 0;
            }
            catch (Exception e)
            {
                Log.error(e.Message);
                return false;
            }
        }
        /// <summary>
        /// 获得电机A位置
        /// </summary>
        /// <returns></returns>
        public int GetHorizontalA()
        {
            try
            {


                SerialResponse re = Send(Commands.ElectricMachineryALocation, new List<byte>() { });
                int reDis = re.UserDatas[2] + re.UserDatas[1] * 256;
                return reDis;
            }
            catch (Exception e)
            {
                Log.error(e.Message);
                return 0;
            }
        }
        /// <summary>
        /// 获得电机B位置
        /// </summary>
        /// <returns></returns>
        public int GetHorizontalB()
        {
            try
            {


                SerialResponse re = Send(Commands.ElectricMachineryBLocation, new List<byte>() { });
                int reDis = re.UserDatas[2] + re.UserDatas[1] * 256;
                return reDis;
            }
            catch (Exception e)
            {
                Log.error(e.Message);
                return 0;
            }
        }
        /// <summary>
        /// 获得垂直电机位置
        /// </summary>
        /// <returns></returns>
        public int GetVertical()
        {
            try
            {


                SerialResponse re = Send(Commands.ElectricVerticalLocation, new List<byte>() { });
                int reDis = re.UserDatas[2] + re.UserDatas[1] * 256;
                return reDis;
            }
            catch (Exception e)
            {
                Log.error(e.Message);
                return 0;
            }
        }
        /// <summary>
        /// 获得电动爪A的位置
        /// </summary>
        /// <returns></returns>
        public int GetElectricClampA()
        {
            try
            {


                SerialResponse re = Send(Commands.ElectricClampALocation, new List<byte>() { });
                int reDis = re.UserDatas[2] + re.UserDatas[1] * 256;
                return reDis;
            }
            catch (Exception e)
            {
                Log.error(e.Message);
                return 0;
            }
        }
        /// <summary>
        /// 获得电动爪B的位置
        /// </summary>
        /// <returns></returns>
        public int GetElectricClampB()
        {
            try
            {


                SerialResponse re = Send(Commands.ElectricClampBLocation, new List<byte>() { });
                int reDis = re.UserDatas[2] + re.UserDatas[1] * 256;
                return reDis;
            }
            catch (Exception e)
            {
                Log.error(e.Message);
                return 0;
            }
        }
        /// <summary>
        /// 电机A归零
        /// </summary>
        /// <returns></returns>
        public bool RefreshElectricA()
        {
            try
            {
                SerialResponse re = Send(Commands.ElectricMachineryAReset, new List<byte>() { (byte)1 });
                if (re == null)
                {
                    return false;
                }
                return re.UserDatas[0] == 0;
            }
            catch(Exception e)
            {
                Log.error(e.Message);
                return false;
            }
        }
        /// <summary>
        /// 电机B归零
        /// </summary>
        /// <returns></returns>
        public bool RefreshElectricB()
        {
            try
            {


                SerialResponse re = Send(Commands.ElectricMachineryBReset, new List<byte>() { (byte)1 });
                if (re == null)
                {
                    return false;
                }
                return re.UserDatas[0] == 0;
            }
            catch (Exception e)
            {
                Log.error(e.Message);
                return false;
            }
        }
        /// <summary>
        /// 垂直电机归零
        /// </summary>
        /// <returns></returns>
        public bool RefreshElectricVertical()
        {
            try
            {

            
            SerialResponse re = Send(Commands.ElectricVerticalReset, new List<byte>() { (byte)1 });
            if (re == null)
            {
                return false;
            }
            return re.UserDatas[0] == 0;
            }
                catch (Exception e)
            {
                Log.error(e.Message);
                return false;
            }
        }
        /// <summary>
        /// 电动夹爪B归零
        /// </summary>
        /// <returns></returns>
        public bool RefreshElectricClampB()
        {
            try
            {


                SerialResponse re = Send(Commands.ElectricClampBReset, new List<byte>() { (byte)1 });
                if (re == null)
                {
                    return false;
                }
                return re.UserDatas[0] == 0;
            }
            catch (Exception e)
            {
                Log.error(e.Message);
                return false;
            }

        }
        /// <summary>
        /// 电动夹爪A归零
        /// </summary>
        /// <returns></returns>
        public bool RefreshElectricClampA()
        {
            try
            {


                SerialResponse re = Send(Commands.ElectricClampAReset, new List<byte>() { (byte)1 });
                if (re == null)
                {
                    return false;
                }
                return re.UserDatas[0] == 0;
            }
            catch (Exception e)
            {
                Log.error(e.Message);
                return false;
            }

        }
        /// <summary>
        /// 控制系统灯
        /// </summary>
        /// <param name="colo"></param>
        /// <returns></returns>
        public bool ControlSystemLED(string colo)
        {
            SerialResponse re = null;
            if (colo.Equals("黄"))
            {
                re = Send(Commands.SystemLED, new List<byte>() {(byte)0 });
            }
            else if (colo.Equals("绿"))
            {
                re = Send(Commands.SystemLED, new List<byte>() { (byte)1 });
            }
            else if(colo.Equals("红"))
            {
                re = Send(Commands.SystemLED, new List<byte>() { (byte)2 });
            }
         
            return re.UserDatas[0] == 0;
        }
        /// <summary>
        /// 左灯
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool LeftLamp(bool status)
        {
            SerialResponse re = Send(Commands.LeftLamp, new List<byte>() { (byte)(status?1:0)});
            if (re == null)
            {
                return false;
            }
            return re.UserDatas[0] == 0;
        }
        /// <summary>
        /// 右灯
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool RightLamp(bool status)
        {
            SerialResponse re = Send(Commands.RightLamp, new List<byte>() { (byte)(status ? 1 : 0) });
            if (re == null)
            {
                return false;
            }
            return re.UserDatas[0] == 0;
        }
        /// <summary>
        /// 控制速度
        /// </summary>
        /// <param name="sta"></param>
        /// <returns></returns>
        public bool ControlSpeed(string sta)
        {
            try
            {


                SerialResponse re = Send(Commands.Speed, new List<byte>() { (byte)(Convert.ToInt32(sta) - 1) });
                if (re == null)
                {
                    return false;
                }
                return re.UserDatas[0] == 0;
            }
            catch (Exception e)
            {
                Log.error(e.Message);
                return false;
            }
        }
        


    }
}
