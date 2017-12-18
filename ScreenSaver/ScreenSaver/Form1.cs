using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ScreenSaver
{
    public partial class Form1 : Form
    {
        private int mousePosition;
        private PictureHandling pictureHandling;
        private MusicHanling musicHandling;

        public Form1()
        {
            InitializeComponent();
            timerGeneral.Enabled = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            mousePosition = MousePosition.X;
            WindowState = FormWindowState.Minimized;
            pictureHandling = new PictureHandling();
            musicHandling = new MusicHanling();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { this.Close(); }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MousePosition.X != mousePosition)
            {
                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureHandling.checkPictureExist();
            pictureHandling.loadFirstPicture(this);
            musicHandling.checkMusicExist();
            musicHandling.wmpHandling();
            Cursor.Hide();
            this.WindowState = FormWindowState.Maximized;
            timerGeneral.Start();
        }

        private void timerGeneral_Tick(object sender, EventArgs e)
        {
            pictureHandling.pictureShow();
        }
    }
}
