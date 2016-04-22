using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Popup
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private int startPosX;
        private int startPosY;

        public Form1()
        {
            InitializeComponent();
            // We want our window to be the top most
            TopMost = true;
            // Pop doesn't need to be shown in task bar
            ShowInTaskbar = false;
            // Create and run timer for animation
            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += timer_Tick;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            //Lift window by 5 pixels
            startPosX -= 5;
            //If window is fully visible stop the timer
            if (startPosX < Screen.PrimaryScreen.WorkingArea.Width - Width)
                timer.Stop();
            else
                SetDesktopLocation(startPosX, startPosY);
        }
        protected override void OnLoad(EventArgs e)
        {
            Label l = new Label();
            l.Text = "Hola Erick";
            this.Controls.Add(l);
            
            // Move window out of screen
            startPosX = Screen.PrimaryScreen.WorkingArea.Width + Width;
            startPosY = 0;
            SetDesktopLocation(startPosX, startPosY);
            base.OnLoad(e);
            // Begin animation
            timer.Start();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
