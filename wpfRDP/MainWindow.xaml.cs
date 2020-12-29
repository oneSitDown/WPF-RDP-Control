using RemoteDesktop;
using System;
using System.IO;
using System.Threading;
using System.Windows;

namespace wpfRDP
{
   
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private RemoteDesktopControl rdpControl;

        public MainWindow()
        {
            InitializeComponent();
            DeskTopControlWindow deskTopControlWindow = new DeskTopControlWindow();
            deskTopControlWindow.ConnectButton.Click += Button_Click;
            deskTopControlWindow.DisConnectButton.Click += Button_Click_1;
            deskTopControlWindow.ControlButton.Click += Button_Click_2;
            deskTopControlWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            rdpControl = new RemoteDesktopControl();
            RemoteDesktopControlHost.Child = rdpControl;
            rdpControl.Connect("Viewer1");
            rdpControl.Top = 0;
            rdpControl.Left = 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            rdpControl.DisConnect();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            rdpControl.Control();
        }
    }
}
