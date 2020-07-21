using Interfaces.Interfaces;
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
        public ILog Log { get; set; }
        /// <summary>
        /// 串口
        /// </summary>
        private SerialPort port = new SerialPort();
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
        /// 是否成功接收数据
        /// </summary>
        private bool isReceiveOk = false;

        public void Close()
        {
            if(port!=null &&port.IsOpen)
            {
                port.Close();
                Log.log("控制板关闭");
            }
        }
        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            Close();
            port.Dispose();
            port = null;
        }
        /// <summary>
        /// 发送命令
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected bool Send(byte[] msg)
        {
            recData.Clear();
            byte[] sendMsg = new byte[msg.Length + 1];
            byte all = 0;
            string sends = "";
            for(int i=0;i<msg.Length;i++)
            {
                all += msg[i];
                sends += msg[i].ToString() + "_";
                sendMsg[i] = msg[i];
            }
            sendMsg[msg.Length] = all;
            sends += all.ToString();
            Log.log("发送数据:", sends);
            sends = null;
            isReceiveOk = false;
            port.Write(sendMsg, 0, sendMsg.Length);
            DateTime now = DateTime.Now;
            while(!isReceiveOk&&(DateTime.Now-now).TotalSeconds<10)
            {
                Thread.Sleep(100);
            }
            if(isReceiveOk == false)
            {
                Log.log("接受数据超时");
                throw new Exception("接收数据超时");

            }
            string receive = "";
            foreach(var data in recData)
            {
                receive += data.ToString() + "_";

            }
            Log.log("接收数据：", receive);
            return isReceiveOk;

        }
        /// <summary>
        /// 打开
        /// </summary>
        public void Open()
        {
            if (!port.IsOpen)
            {
                port.PortName = this.PortName;
                port.BaudRate = this.BandRoate;
                port.Parity = this.Parity;
                port.DataBits = this.DataP;
                port.StopBits = this.StopBit;
                port.Open();
                this.port.DataReceived += SeriPortReceiveData;
                Log.log("绑定设备数据接收!");
            }
            else
            {
                port.Close();
                port.PortName = this.PortName;
                port.BaudRate = this.BandRoate;
                port.Parity = this.Parity;
                port.DataBits = this.DataP;
                port.StopBits = this.StopBit;
                port.Open();
            }
        }
        /// <summary>
        /// 串口数据回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeriPortReceiveData(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] buffer = new byte[port.BytesToRead];
            port.Read(buffer, 0, buffer.Length);
            foreach(var item in buffer)
            {
                recData.Add(item);
            }
            isReceiveOk = true;
        }
        public void Init(string portName,int bandRoate,Parity parity,int dataP,StopBits stopBits)
        {
            this.PortName = portName;
            this.BandRoate = bandRoate;
            this.Parity = parity;
            this.DataP = dataP;
            this.StopBit = stopBits;
        }
    }
}
