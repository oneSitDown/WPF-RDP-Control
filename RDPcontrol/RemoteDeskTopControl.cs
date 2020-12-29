using System;
using System.Windows.Forms;
using System.IO;

namespace RemoteDesktop
{
    public partial class RemoteDesktopControl : UserControl
    {
        public string myDoucumentConfigPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/inv.xml";

        public RemoteDesktopControl()
        {
            InitializeComponent();
        }

        public void SetScreen(int height,int width)
        {
            pRdpViewer.Height = height;
            pRdpViewer.Width = width;
            this.Width = width;
            this.Height = height;
        }

        public void Connect(string UserName)
        {
            string ConnectionString = File.ReadAllText(myDoucumentConfigPath) ;
            File.Delete(myDoucumentConfigPath);
            if (ConnectionString != null)
            {
                pRdpViewer.Connect(ConnectionString, UserName, "");
            }
        }

        public void DisConnect()
        {
            pRdpViewer.Disconnect();
        }

        public void Control()
        {
            pRdpViewer.RequestControl(RDPCOMAPILib.CTRL_LEVEL.CTRL_LEVEL_INTERACTIVE);
        }

        private void pRdpViewer_Enter(object sender, EventArgs e)
        {

        }
    }
}
