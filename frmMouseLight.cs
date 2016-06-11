//*************************************************************************
// Name: frmMouseLight.cs
// Programmer: Curtis N Frank
// Date: 4/6/2016
// Purpose: Create a yellow highlighter circle to follow the mouse
//          cursor without disrupting its click ability.
//*************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseLight
{
    public partial class frmMouseLight : Form
    {
        // private class member variables
        private HaloForm _halo;
        private Timer _timer;

        // default constructor
        public frmMouseLight()
        {
            // initialize form
            InitializeComponent();

            // insantiate halo and timer,            
            _halo = new HaloForm();
            _timer = new Timer() { Interval = 20, Enabled = true };

            // delegate timer event handler
            _timer.Tick += new EventHandler(Timer_Tick);
        }

        // timer event handler method
        void Timer_Tick(object sender, EventArgs e)
        {
            // update cursor position
            Point pt = Cursor.Position;

            // update halo center position
            pt.Offset(-(_halo.Width / 2), -(_halo.Height) / 2);
            _halo.Location = pt;

            // show halo
            if(!_halo.Visible)
            {
                _halo.Show();
            }
        }

        // exit button click event handler method
        private void btnExit_Click(object sender, EventArgs e)
        {
            // exit program
            this.Close();
        }
    }

    // HaloForm class
    public class HaloForm : Form
    {
        // default constructor
        public HaloForm()
        {
            // HaloForm properties
            TopMost = true;
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.LightGreen;
            TransparencyKey = Color.LightGreen;
            Width = 200;
            Height = 200;

            // delegate Paint event handler
            Paint += new PaintEventHandler(HaloForm_Paint);
        }

        // Paint event handler method
        void HaloForm_Paint(object sender, PaintEventArgs e)
        {
            // instantiate a yellow brush object
            SolidBrush myBrush = new SolidBrush(
                Color.Yellow);

            // call the FillEllipse class method
            e.Graphics.FillEllipse(myBrush, (Width) / 2,
                (Height) / 2, 50, 50);
        }
    }
}
