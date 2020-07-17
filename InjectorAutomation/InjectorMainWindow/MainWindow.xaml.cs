using System;
using System.Collections.Generic;
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
    public partial class MainWindow : UserControl
    {
        public MainWindow()
        {
            InitializeComponent();
        }
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

        private void pages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
