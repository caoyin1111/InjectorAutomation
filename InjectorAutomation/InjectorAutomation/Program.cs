using ControlLib;
using InjectionServerLib;
using InjectorMainWindow;
using Interfaces.Expends;
using Interfaces.Interfaces;
using LogLib;
using StaticParameterLib;
using StationLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskInvokeLib;

namespace InjectorAutomation
{
    class Program
    {
        /// <summary>
        /// 自动注入
        /// </summary>
        public static IService Service = new InjectionService();
        /// <summary>
        /// 日志
        /// </summary>
        public static ILog Log = new Log("启动层级日志");
        /// <summary>
        /// 窗口
        /// </summary>
        public static IWindow Window { get; set; }
        /// <summary>
        /// 参数
        /// </summary>
        public static IStaticParameter StaticParameters { get; set; } = new StaticParameter(Properties.Resources.Config);
        /// <summary>
        /// 启动容器
        /// </summary>
        public static void Start()
        {
            Service.InjectionSingleInstance<ILog>(new Log("日志内容"));
            Service.InjectionSingleInstance<IStaticParameter>(StaticParameters);
            Service.InjectionSingleInstance<IService>(Service);
            Service.InjectionSingleInstance<IWindow, MainWindow>();
            Service.InjectionSingleInstance<ITaskInoke, TaskInvoke>();
            Service.InjectionSingleInstance<IServerStation, Station>();
            Service.InjectionSingleInstance<IControl, ControlCom>();

            Service.Start();

        }
        /// <summary>
        /// 修改静态参数
        /// </summary>
        /// <param name="argvs"></param>
        public static void ModifyStaticParamters(string[] argvs)
        {
            if (argvs.Length < 1)
            {
                return;
            }
            List<string> modifys = argvs.ToList();
            foreach (var item in modifys)
            {
                var key = item.Split(':')[0];
                var value = item.Split(':')[1];
                StaticParameters.SetValue(key, value);
            }
        }
        [STAThread]
        public static void Main(string[] args)
        {
    
            Start();
            try
            {
                Log.log(args.JoinToString(","));
                ModifyStaticParamters(args);
                using (Window = Service.Resolve<IWindow>())
                {
                    Window.ShowWindow();
                }
            }
            catch(Exception ex)
            {
                Log.error("程序运行错误:", ex);
            }
        }

    
    }
}
