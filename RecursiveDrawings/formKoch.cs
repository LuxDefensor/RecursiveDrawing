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
    public partial class formKoch : Form
    {
        private Bitmap b;
        private Graphics canvas;
        private int N;
        private int Levels;
        private int Tear;
        private int Thorn;
        private new int Size;
        private float InitialTurn;
        private bool Inwards;
        private bool Alter;
        private float angle;
        private List<Vector> Edges;
        private float correctionAngle = (float)Math.PI;

        private Pen _foreColor;
        private Color _backColor;
        private Size _canvasSize;

        private PointF startDrag;
        private bool drag = false;

        public formKoch(Size canvasSize)
        {
            InitializeComponent();
            _canvasSize = canvasSize;
            #region Event handlers
            this.Load += FormKoch_Load;
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
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        picture.Width = panel.Width;
                        picture.Height = (int)(picture.Width / currentRatio);
                        picture.Left = 0;
                        picture.Top = (panel.Height - picture.Height) / 2;
                        break;
                    }
                case "Fit height":
                    {
                        float currentRatio = (float)_canvasSize.Width / _canvasSize.Height;
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        picture.Height = panel.Height;
                        picture.Width = (int)(picture.Height * currentRatio);
                        picture.Left = (panel.Width - picture.Width) / 2;
                        picture.Top = 0;
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
            DrawSnowflake();
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

        private void FormKoch_Load(object sender, EventArgs e)
        {
            b = new Bitmap(_canvasSize.Width, _canvasSize.Height);
            canvas = Graphics.FromImage(b);
            formMain main = (formMain)this.MdiParent;
            _backColor = main.CanvasColor;
            _foreColor = new Pen(main.DrawColor, main.LineWeight);
            canvas.Clear(_backColor);
            picture.Width = _canvasSize.Width;
            picture.Height = _canvasSize.Height;
            picture.Left = (panel.Width - picture.Width) / 2;
            picture.Top = (panel.Height - picture.Height) / 2;
            picture.Image = b;
        }

        private void DrawSnowflake()
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

            if (!int.TryParse(txtTear.Text, out Tear))
            {
                MessageBox.Show("Tear must be an integer between 1 and 99", "Wrong parameter: Tear",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTear.Focus();
                return;
            }
            Tear = Tear < 1 ? 1 : Tear;
            Tear = Tear > 99 ? 99 : Tear;
            txtTear.Text = Tear.ToString();

            if (!int.TryParse(txtThorn.Text, out Thorn))
            {
                MessageBox.Show("Thorn must be an integer", "Wrong parameter: Thorn",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtThorn.Focus();
                return;
            }
            Thorn= Thorn< 1 ? 1 : Thorn;
            Thorn = Thorn > 4000 ? 4000 : Thorn;
            txtThorn.Text = Thorn.ToString();

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

            int circleParts;
            if (!int.TryParse(txtTurn.Text, out circleParts))
            {
                MessageBox.Show("Number of circle partse must be an integer", 
                    "Wrong parameter: Circle parts",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTurn.Focus();
                return;
            }
            circleParts = circleParts < 1 ? 1 : circleParts;
            circleParts = circleParts > 180 ? 180 : circleParts;
            txtTurn.Text = circleParts.ToString();

            int mult;
            if (!int.TryParse(txtMult.Text, out mult))
            {
                MessageBox.Show("Turn multiplier must be an integer", "Wrong parameter: Multiplier",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMult.Focus();
                return;
            }
            mult = mult < 1 ? 1 : mult;
            mult = mult > 360 ? 360 : mult;
            txtMult.Text = mult.ToString();

            InitialTurn = 2 * mult * (float)Math.PI / circleParts;

            Inwards = cboOffset.Text == "Inwards";
            Alter = btnAlternating.Checked;
            angle = (float)Math.PI * 2 / N;
            #endregion


            formMain main = (formMain)this.MdiParent;
            _backColor = main.CanvasColor;
            _foreColor = new Pen(main.DrawColor, main.LineWeight);
            //canvas.Clear(_backColor);
            Edges = new List<Vector>();
            List<Vector> TempEdges;
            bool isCurrentlyInwards = Inwards;
            PointF center = new PointF(_canvasSize.Width / 2, _canvasSize.Height / 2);
            PointF[] points = new PointF[N];
            points[0] = new PointF(
                center.X + 0.5f * Size * (float)Math.Cos(InitialTurn),
                center.Y + 0.5f * Size * (float)Math.Sin(InitialTurn));
            float currentAngle = angle + InitialTurn;
            for (int i = 1; i < N; i++)
            {
                points[i] = new PointF((float)(center.X + 0.5 * Size * Math.Cos(currentAngle)),
                                  (float)(center.Y + 0.5 * Size * Math.Sin(currentAngle)));
                Edges.Add(new Vector(points[i - 1], points[i]));
                currentAngle += angle;
            }
            Edges.Add(new Vector(points[N - 1], points[0]));            
            for (int i = 1; i <= Levels; i++)
            {
                TempEdges = Edges.ToList();
                foreach (Vector edge in TempEdges)
                {
                    BreakEdge(edge, isCurrentlyInwards);
                }
                if (Alter)
                    isCurrentlyInwards = !isCurrentlyInwards;
            }
            foreach (Vector v in Edges)
            {
                canvas.DrawLine(_foreColor, v.Begin, v.End);
            }
            picture.Image = b;
        }

        private void BreakEdge(Vector edge, bool inwards)
        {
            PointF[] points = new PointF[5];
            points[0] = edge.Begin;
            points[4] = edge.End;
            float edgeLength = edge.Length;
            float tearLength = edgeLength * Tear / 100;
            float shelfLength = (edgeLength - tearLength) / 2;
            float thornLength = shelfLength * Thorn / 100;
            float thornDistance = (float)Math.Sqrt(Math.Pow(edgeLength / 2, 2) + Math.Pow(thornLength, 2));
            float thornAngle = (float)Math.Atan(2 * thornLength / edgeLength);
            if (inwards)
                thornLength = thornLength + (float)Math.PI;
            points[1] = new PointF(
                points[0].X + shelfLength * edge.CosAngle,
                points[0].Y + shelfLength * edge.SinAngle);
            points[2] = new PointF(
                points[1].X + (float)(0.5 * tearLength * edge.CosAngle +
                    thornLength * Math.Cos(edge.Angle + (inwards ? Math.PI / 2 : -Math.PI / 2))),
                points[1].Y + (float)(0.5 * tearLength * edge.SinAngle +
                    thornLength * Math.Sin(edge.Angle + (inwards ? Math.PI / 2 : -Math.PI / 2))));
            points[3]=new PointF(
                points[1].X+tearLength*edge.CosAngle,
                points[1].Y+tearLength*edge.SinAngle);
            Edges.Remove(edge);
            Edges.Add(new Vector(points[0], points[1]));
            Edges.Add(new Vector(points[1], points[2]));
            Edges.Add(new Vector(points[2], points[3]));
            Edges.Add(new Vector(points[3], points[4]));
        }


    }
}
