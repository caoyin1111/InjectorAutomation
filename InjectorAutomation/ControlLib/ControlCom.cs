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
            SerialRequest serialRequest = SerialControl.CreateRequest();
            serialRequest.SetData((byte)command, datas);
            SerialResponse response = SerialControl.Send(serialRequest);
            if (response.SourceDatas == null || response.SourceDatas.Count() == 0)
            {
                throw new Exception("异常，为接收到任何数据!");
            }
            if (response.UserDatas[0] != 0x00)
            {
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
        public bool MoveHorizontalRightA(int distance)
        {
            SerialResponse re = Send(Commands.Init, new List<byte>() { (byte)distance });
            if(re == null)
            {
                return false;
            }
            return re.UserDatas[1] == 1;
        }

    }
}
