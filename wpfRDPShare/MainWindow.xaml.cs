using RDPCOMAPILib;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;

namespace wpfRDPShare
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        protected RDPSession m_pRdpSession = null;

        public void WriteToFile(string InviteString)
        {
            using (StreamWriter sw = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/inv.xml"))
            {
                sw.WriteLine(InviteString);
            }
        }

        private void OnAttendeeConnected(object pObjAttendee)
        {
            IRDPSRAPIAttendee pAttendee = pObjAttendee as IRDPSRAPIAttendee;
            pAttendee.ControlLevel = CTRL_LEVEL.CTRL_LEVEL_VIEW;
        }
        void OnAttendeeDisconnected(object pDisconnectInfo)
        {
            IRDPSRAPIAttendeeDisconnectInfo pDiscInfo = pDisconnectInfo as IRDPSRAPIAttendeeDisconnectInfo;
        }

        void OnControlLevelChangeRequest(object pObjAttendee, CTRL_LEVEL RequestedLevel)
        {
            IRDPSRAPIAttendee pAttendee = pObjAttendee as IRDPSRAPIAttendee;
            pAttendee.ControlLevel = RequestedLevel;
        }

        private void ShareButton_Click(object sender, RoutedEventArgs e)
        {
            m_pRdpSession = new RDPSession();

            m_pRdpSession.OnAttendeeConnected += new _IRDPSessionEvents_OnAttendeeConnectedEventHandler(OnAttendeeConnected);
            m_pRdpSession.OnAttendeeDisconnected += new _IRDPSessionEvents_OnAttendeeDisconnectedEventHandler(OnAttendeeDisconnected);
            m_pRdpSession.OnControlLevelChangeRequest += new _IRDPSessionEvents_OnControlLevelChangeRequestEventHandler(OnControlLevelChangeRequest);

            m_pRdpSession.Open();
            IRDPSRAPIInvitation pInvitation = m_pRdpSession.Invitations.CreateInvitation("WinPresenter", "PresentationGroup", "", 5);
            string invitationString = pInvitation.ConnectionString;
            WriteToFile(invitationString);
        }

        private void DisShareButton_Click(object sender, RoutedEventArgs e)
        {
            m_pRdpSession.Close();
            //LogTextBox.Text += "Presentation Stopped." + Environment.NewLine;
            Marshal.ReleaseComObject(m_pRdpSession);
            m_pRdpSession = null;
        }
    }
}
