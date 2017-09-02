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
    public partial class formCircles : Form
    {
        private Bitmap b;
        private Graphics canvas;
        private int N;
        private int Levels;
        private int Coef;
        private new int Size;
        private bool Inwards;
        private float angle;
        private float turn;

        private Pen _foreColor;
        private Color _backColor;
        private Size _canvasSize;

        private PointF startDrag;
        private bool drag = false;

        public formCircles(Size canvasSize)
        {
            InitializeComponent();
            _canvasSize = canvasSize;
            #region Event handlers
            this.Load += FormCircles_Load;
            picture.MouseDown += Picture_MouseDown;
            picture.MouseUp += Picture_MouseUp;
            picture.MouseMove += Picture_MouseMove;
            picture.DoubleClick += Picture_DoubleClick;
            btnDraw.Click += BtnDraw_Click;
            btnClear.Click += BtnClear_Click;
            btnSave.Click += BtnSave_Click;
            cboZoom.TextChanged += CboZoom_TextChanged;
            #endregion
        }

        private void CboZoom_TextChanged(object sender, EventArgs e)
        {
            switch (cboZoom.Text)
            {
                case "Actual size":
                    {
                        picture.Width = _canvasSize.Width;
                        picture.Height = _canvasSize.Height;
                        picture.Left = (panel.Width - picture.Width) / 2;
                        picture.Top = (panel.Height - picture.Height) / 2;
                        picture.SizeMode = PictureBoxSizeMode.AutoSize;
                        break;
                    }
                case "Fit width":
                    {
                        float currentRatio = (float)_canvasSize.Width / _canvasSize.Height;
                        picture.Width = panel.Width;
                        picture.Height = (int)(picture.Width / currentRatio);
                        picture.Left = 0;
                        picture.Top = (panel.Height - picture.Height) / 2;
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        break;
                    }
                case "Fit height":
                    {
                        float currentRatio = (float)_canvasSize.Width / _canvasSize.Height;
                        picture.Height = panel.Height;
                        picture.Width = (int)(picture.Height * currentRatio);
                        picture.Left = (panel.Width - picture.Width) / 2;
                        picture.Top = 0;
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        break;
                    }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.InitialDirectory = folderName;
            dlg.Title = "Save result as an image file";
            dlg.Filter = "Image files|*.jpg;*.bmp;*.png";
            if (dlg.ShowDialog() == DialogResult.OK)
                b.Save(dlg.FileName);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            formMain main = (formMain)this.MdiParent;
            _backColor = main.CanvasColor;
            _foreColor = new Pen(main.DrawColor, main.LineWeight);
            canvas.Clear(_backColor);
            picture.Refresh();
        }

        private void BtnDraw_Click(object sender, EventArgs e)
        {
            DrawCircles();
        }

        #region Picture control

        private void Picture_DoubleClick(object sender, EventArgs e)
        {
            picture.Width = _canvasSize.Width;
            picture.Height = _canvasSize.Height;
            picture.Left = (panel.Width - picture.Width) / 2;
            picture.Top = (panel.Height - picture.Height) / 2;
            picture.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                picture.Left += (int)(e.X - startDrag.X);
                picture.Top += (int)(e.Y - startDrag.Y);
                picture.Refresh();
            }
        }

        private void Picture_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            startDrag = e.Location;
            drag = true;
        }
        #endregion

        private void FormCircles_Load(object sender, EventArgs e)
        {
            formMain main = (formMain)this.MdiParent;
            _backColor = main.CanvasColor;
            _foreColor = new Pen(main.DrawColor, main.LineWeight);
            b = new Bitmap(_canvasSize.Width, _canvasSize.Height);
            canvas = Graphics.FromImage(b);
            canvas.Clear(_backColor);
            picture.Width = _canvasSize.Width;
            picture.Height = _canvasSize.Height;
            picture.Left = (panel.Width - picture.Width) / 2;
            picture.Top = (panel.Height - picture.Height) / 2;
            picture.Image = b;
        }

        private void DrawCircles()
        {
            #region Collect draw parameters
            if (!int.TryParse(txtN.Text, out N))
            {
                MessageBox.Show("N must be an integer", "Wrong parameter: N",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtN.Focus();
                return;
            }
            N = N < 1 ? 1 : N;
            N = N > 100 ? 100 : N;
            txtN.Text = N.ToString();

            if (!int.TryParse(txtLevels.Text, out Levels))
            {
                MessageBox.Show("Number of levels must be an integer", "Wrong parameter: Levels",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLevels.Focus();
                return;
            }
            Levels = Levels < 1 ? 1 : Levels;
            Levels = Levels > 10 ? 10 : Levels;
            txtLevels.Text = Levels.ToString();

            if (!int.TryParse(txtCoef.Text, out Coef))
            {
                MessageBox.Show("Coef. must be an integer", "Wrong parameter: Coef.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCoef.Focus();
                return;
            }
            Coef = Coef < 1 ? 1 : Coef;
            Coef = Coef > 100 ? 100 : Coef;
            txtCoef.Text = Coef.ToString();

            if (!int.TryParse(txtSize.Text, out Size))
            {
                MessageBox.Show("Size must be an integer", "Wrong parameter: Size",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSize.Focus();
                return;
            }
            Size = Size< 1 ? 1 : Size;
            Size = Size > 40000 ? 40000 : Size;
            txtSize.Text = Size.ToString();

            int numerator, denominator;
            if (!int.TryParse(txtTurnNumer.Text, out numerator))
            {
                MessageBox.Show("The numerator must be an integer", "Wrong parameter: Turn numerator",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTurnNumer.Focus();
                return;
            }
            numerator = numerator < 1 ? 1 : numerator;
            numerator = numerator > 360 ? 360 : numerator;

            if (!int.TryParse(txtTurnDenom.Text, out denominator))
            {
                MessageBox.Show("The denominator must be an integer", "Wrong parameter: Turn denominator",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTurnDenom.Focus();
                return;
            }
            denominator = denominator < 1 ? 1 : denominator;
            denominator = denominator > 360 ? 360 : denominator;

            turn = (float)numerator / denominator;
            turn = turn == 1 ? 0 : (float)Math.PI * 2 * turn;

            Inwards = cboOffset.Text == "Inwards";
            angle = (float)Math.PI * 2 / N;

            formMain main = (formMain)this.MdiParent;
            _backColor = main.CanvasColor;
            _foreColor = new Pen(main.DrawColor, main.LineWeight);
            #endregion

            DrawRecursive(new PointF(_canvasSize.Width / 2, _canvasSize.Height / 2), Size, Levels);
            picture.Image = b;
        }

        private void DrawRecursive(PointF oldCenter, float oldRadius, int depth)
        {
            if (depth == 0)
                return;
            float newRadius = oldRadius * Coef / 10;
            float newOffset = Inwards ? oldRadius - newRadius : newRadius;
            PointF newCenter = new PointF();
            for (int i = 0; i < N; i++)
            {
                newCenter.X = oldCenter.X + newOffset * (float)Math.Cos(angle * i - turn);
                newCenter.Y = oldCenter.Y + newOffset * (float)Math.Sin(angle * i - turn);
                DrawRecursive(newCenter, newRadius, depth - 1);
            }
            canvas.DrawEllipse(_foreColor, oldCenter.X - oldRadius, oldCenter.Y - oldRadius,
                2 * oldRadius, 2 * oldRadius);
        }
    }
}
