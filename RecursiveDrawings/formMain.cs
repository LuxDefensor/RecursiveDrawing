using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecursiveDrawings
{
    public partial class formMain : Form
    {
        private Color drawColor = Color.White;
        private Color canvasColor = Color.Black;
        private Size CanvasSize = new Size(1920, 1080);
        private int lineWeight = 1;

        public Color DrawColor
        {
            get
            {
                return drawColor;
            }
        }

        public Color CanvasColor
        {
            get
            {
                return canvasColor;
            }
        }

        public int LineWeight
        {
        get
            {
                return lineWeight;
            }
        }

        public formMain()
        {
            InitializeComponent();
            #region Event handlers
            this.Load += FormMain_Load;
            menuExit.Click += MenuExit_Click;
            menuForeColor.Click += MenuForeColor_Click;
            menuBackColor.Click += MenuBackColor_Click;
            menuLineWeight.Click += MenuLineWeight_Click;
            menuSize.Click += MenuSize_Click;
            menuCircles.Click += MenuCircles_Click;
            menuKoch.Click += MenuKoch_Click;

            #endregion
        }

        private void MenuLineWeight_Click(object sender, EventArgs e)
        {
            formInput dlg = new formInput("Enter line weight", "Settings", 1);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (!int.TryParse(dlg.Result, out lineWeight))                
                {
                    MessageBox.Show("The line weight value was restored to default: 1",
                        "Wrong value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lineWeight = 1;
                }
                menuLineWeight.Text = string.Format("Line weight = {0}", lineWeight);
            }
        }

        private void MenuKoch_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child is formKoch)
                {
                    child.Activate();
                    return;
                }
            }
            formKoch frm = new formKoch(CanvasSize);
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void MenuCircles_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child is formCircles)
                {
                    child.Activate();
                    return;
                }
            }
            formCircles frm = new formCircles(CanvasSize);                
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void MenuSize_Click(object sender, EventArgs e)
        {
            formSize dlg = new formSize();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CanvasSize.Width = dlg.Width;
                CanvasSize.Height = dlg.Height;
                menuSize.Text = string.Format("Canvas size ({0} x {1})",
                    CanvasSize.Width, CanvasSize.Height);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            SetColor(menuForeColor, drawColor);
            SetColor(menuBackColor, canvasColor);
        }


        #region Color management
        private void SetColor(ToolStripMenuItem forWhat,Color which)
        {
            Bitmap b = new Bitmap(16, 16);
            Graphics g = Graphics.FromImage(b);
            Pen p = new Pen(which);
            p.Width = 16;
            g.DrawLine(p, 0, 8, 16, 8);
            forWhat.Image = b;
        }

        private void MenuBackColor_Click(object sender, EventArgs e)
        {
            canvasColor = GetColor(CanvasColor);
            SetColor(menuBackColor, CanvasColor);
        }
        private void MenuForeColor_Click(object sender, EventArgs e)
        {
            drawColor = GetColor(drawColor);
            SetColor(menuForeColor, drawColor);
        }

        private Color GetColor(Color defaultColor)
        {
            Color result = defaultColor;
            ColorDialog cdlg = new ColorDialog();
            cdlg.AllowFullOpen = true;
            cdlg.AnyColor = true;
            cdlg.FullOpen = true;
            if (cdlg.ShowDialog() == DialogResult.OK)
                result = cdlg.Color;
            return result;
        }
        #endregion

        private void MenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
