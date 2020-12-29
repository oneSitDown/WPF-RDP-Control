using System.Drawing;

namespace RemoteDesktop
{
    partial class RemoteDesktopControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        public Size WindowSize { get; set; }


        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteDesktopControl));
            this.pRdpViewer = new AxRDPCOMAPILib.AxRDPViewer();
            ((System.ComponentModel.ISupportInitialize)(this.pRdpViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // pRdpViewer
            // 
            this.pRdpViewer.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pRdpViewer.Enabled = true;
            this.pRdpViewer.Location = new System.Drawing.Point(0, 0);
            this.pRdpViewer.Name = "pRdpViewer";
            this.pRdpViewer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pRdpViewer.OcxState")));
            this.pRdpViewer.Size = new System.Drawing.Size(1920, 1080);
            this.pRdpViewer.TabIndex = 0;
            this.pRdpViewer.Enter += new System.EventHandler(this.pRdpViewer_Enter);
            // 
            // RemoteDesktopControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.Controls.Add(this.pRdpViewer);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "RemoteDesktopControl";
            this.Size = new System.Drawing.Size(1920, 1080);
            ((System.ComponentModel.ISupportInitialize)(this.pRdpViewer)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private AxRDPCOMAPILib.AxRDPViewer pRdpViewer;
    }
}
