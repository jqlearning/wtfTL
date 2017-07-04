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
using Arthas.Controls.Metro;
using Arthas.Utility.Media;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using System.Drawing;


namespace test2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            #region 保持一个treeItem关闭其他的
            foreach (FrameworkElement fe in lists.Children)
            {
                if (fe is MetroExpander)
                {
                    (fe as MetroExpander).Click += delegate (object sender, EventArgs e)
                    {
                        if ((fe as MetroExpander).CanHide)
                        {
                            foreach (FrameworkElement fe1 in lists.Children)
                            {
                                if (fe1 is MetroExpander && fe1 != sender)
                                {
                                    (fe1 as MetroExpander).IsExpanded = false;
                                }
                            }
                        }
                    };
                }
            }
        }
           #endregion
         #region 添加一个tabItem
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UCTabItemWithClose item = new UCTabItemWithClose();
            item.Header = string.Format("Header{0}", tabControl.Items.Count);
            item.ToolTip = string.Format("Header{0}", tabControl.Items.Count);
            item.Margin = new Thickness(0, 0, 1, 0);
            item.Height = 28;
            Label lbl = new Label() { Content = string.Format("Label{0}", tabControl.Items.Count) };
            Button btn = new Button() { Width = 132, Height = 32, Content = string.Format("Button{0}", tabControl.Items.Count) };
            StackPanel sPanel = new StackPanel();
            sPanel.Children.Add(lbl);
            sPanel.Children.Add(btn);
            item.Content = sPanel;
            tabControl.Items.Add(item);
        }
        #endregion 
    }
}
