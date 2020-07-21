using InjectorMainWindow.Items;
using Interfaces.Enums;
using Interfaces.Interfaces;
using Interfaces.Items;
using MahApps.Metro.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InjectorMainWindow
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow,IWindow
    {
        #region 接口
        public ITaskInoke TaskInoke { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        public ILog Log { get; set; }
        /// <summary>
        /// 参数
        /// </summary>
        public IStaticParameter StaticParameters { get; set; }
        /// <summary>
        /// 串口
        /// </summary>
        public ObservableCollection<string> ExitComs { get; set; } = new ObservableCollection<string>();
        #endregion
        /// <summary>
        /// 菜单项
        /// </summary>
        private ObservableCollection<MItem> MenuItems = new ObservableCollection<MItem>()
        {
            new MItem(){ Icon = @"F:\ctest\InjectorAutomation\InjectorAutomation\InjectorMainWindow\Resources\home.png", MenuName="首页"},
            new MItem(){ Icon = @"F:\ctest\InjectorAutomation\InjectorAutomation\InjectorMainWindow\Resources\log.png", MenuName="日志"},
      //      new MItem(){ Icon = @"Resources\deviceconfig.png", MenuName="设备配置"},
            new MItem(){ Icon = @"F:\ctest\InjectorAutomation\InjectorAutomation\InjectorMainWindow\Resources\api.png", MenuName="接口测试"},
        };
        /// <summary>
        /// 普通日志
        /// </summary>
        public bool IsNormalLog { get; set; } = true;
        /// <summary>
        /// 警告日志
        /// </summary>
        public bool IsWaringLog { get; set; } = true;
        /// <summary>
        /// 错误日志
        /// </summary>
        public bool IsErrorLog { get; set; } = false;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            leftMenus.ItemsSource = MenuItems;
            interfaceList.ItemsSource = TaskInoke.GetInterfaces();
            Log.LogCallBack += LogMsg;
            pages.SelectedIndex = 0;
            leftMenus.SelectedIndex = 0;


 
        }

        /// <summary>
        /// 日志回调
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="msg"></param>
        private void LogMsg(string msg,LogType obj)
        {
            switch(obj)
            {
                case LogType.Normal:
                    if (!IsNormalLog)
                        return;
                    break;
                case LogType.Waring:
                    if (!IsWaringLog)
                        return;
                    break;
                case LogType.Error:
                    if (!IsErrorLog)
                        return;
                    break;
                default:
                    break;

            }
            this.Dispatcher.BeginInvoke(new Action<LogType, string>((a, b) =>
            {
                b += "\r\n";
                if (logBox.Inlines.Count > 100)
                {
                    logBox.Inlines.Clear();
                }
                if (a == LogType.Error)
                {
                    logBox.Inlines.Add(new Run()
                    {
                        Foreground = new SolidColorBrush(Colors.Red),
                        Text = b
                    });

                }
                else if (a == LogType.Waring)
                {
                    logBox.Inlines.Add(new Run()
                    {
                        Foreground = new SolidColorBrush(Color.FromArgb(255, 0xeb, 0x8e, 0x55)),
                        Text = b
                    });
                }
                else if (a == LogType.Normal)
                {
                    logBox.Inlines.Add(new Run()
                    {
                        Foreground = new SolidColorBrush(Colors.Black),
                        Text = b,
                    });
                }

            }), obj, msg);
        }

        /// <summary>
        /// 显示窗口
        /// </summary>
        public void ShowWindow()
        {
            this.ShowDialog();
        }
  
        private void pages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        /// <summary>
        /// 连接设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Link(object sender, MouseButtonEventArgs e)
        {
            try
            {
                TaskInoke.Coms[0].Value = com.SelectedItem.ToString();
                TaskInoke.Link(ipbox.Text, Convert.ToInt32(portbox.Text));
               
                
            }
            catch(Exception ex)
            {
                Log.error("连接失败", ex);
            }
        }
        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisLink(object sender, MouseButtonEventArgs e)
        {
            try
            {
                TaskInoke.Close();
            }
            catch(Exception ex)
            {
                Log.error("连接失败", ex);
            }
        }
        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            this.Close();
        }
        /// <summary>
        /// 左侧菜单点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftMenuClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                pages.SelectedIndex = leftMenus.SelectedIndex;
            }
            catch(Exception ex)
            {
                Log.error(ex);
            }
        }
        /// <summary>
        /// 刷新com口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshComs(object sender, RoutedEventArgs e)
        {
            ExitComs.Clear();
            for(int i=0;i < System.IO.Ports.SerialPort.GetPortNames().Length;i++)
            {
                ExitComs.Add(System.IO.Ports.SerialPort.GetPortNames()[i]);
            }
       
        }
        /// <summary>
        /// 执行接口按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoInterfaceClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (interfaceList.SelectedItem == null) return;
                DoTaskParameterItem taskinfo = ((KeyValuePair<string,DoTaskParameterItem>)interfaceList.SelectedItem).Value;
                Task task = new Task(obj =>{
                    try
                    {
                        DoTaskParameterItem info = obj as DoTaskParameterItem;
                        var result = TaskInoke.DoInterface(info.Url, info);
                        this.Dispatcher.BeginInvoke(new Action<string>(s =>
                        {
                            resultBox.Text = s;
                        }), JsonConvert.SerializeObject(result).ToString());
                    }
                    catch(Exception ex)
                    {
                        Log.error(ex);
                    }
                },taskinfo);
            }
            catch(Exception ex)
            {
                Log.error(ex);
            }
        
        }
    }
}
