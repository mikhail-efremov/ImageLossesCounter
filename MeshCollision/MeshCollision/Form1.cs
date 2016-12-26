using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MeshCollision
{
    public partial class Form1 : Form
    {
        private Bitmap _gBitmap;
        private int _weightRange = 20;
        private int _heightRange = 20;
        private int _linesCount = 1;
        private byte _sens = 1;
   //     private int hits = 0;

        public Form1()
        {
            InitializeComponent();
            LoadImage();
            InitializeImage();
            FillColorPickRegion(new ColorDialog {Color = Color.Black});
        }

        private void LoadImage()
        {
            pictureBox1.Image = UploadImage();
       //     pictureBox1.SizeMode =PictureBoxSizeMode.Zoom;
            _gBitmap = new Bitmap(pictureBox1.Image);
        }

        private void InitializeImage()
        {
            _weightRange = _gBitmap.Width/_linesCount;
            _heightRange = _gBitmap.Height/_linesCount;
        }

        public Bitmap UploadImage()
        {
            var open = new OpenFileDialog
            {
                Filter = @"Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp"
            };

            return open.ShowDialog() == DialogResult.OK ? new Bitmap(open.FileName) : null;
        }
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var lineXList = new List<Point>();
            var lineYList = new List<Point>();
            var lines = new List<Point>();

            var g = e.Graphics;

            for (var y = 0; y < _linesCount; ++y)
            {
                var xpt = new Point(0, y * _heightRange);
                lineXList.Add(xpt);
                var ypt = new Point(_gBitmap.Width, _heightRange * y);
                lineYList.Add(ypt);

                var spl = SplitLine(new Tuple<double, double>(xpt.X, xpt.Y),
                    new Tuple<double, double>(ypt.X, ypt.Y), 99);
                lines.AddRange(spl);

                if(checkBoxDrawMesh.Checked)
                    g.DrawLine(new Pen(Color.Aqua), xpt, ypt);
            }

            for (var x = 0; x < _linesCount; ++x)
            {
                var xpt = new Point(x* _weightRange, 0);
                lineXList.Add(xpt);
                var ypt = new Point(x* _weightRange, _gBitmap.Width);
                lineYList.Add(ypt);
                var spl = SplitLine(new Tuple<double, double>(xpt.X, xpt.Y),
                    new Tuple<double, double>(ypt.X, ypt.Y), 99);
                lines.AddRange(spl);

                if (checkBoxDrawMesh.Checked)
                    g.DrawLine(new Pen(Color.Aqua), xpt, ypt);
            }
            
            var customColor = pictureColorBox.BackColor;
            var hits = 0;
            try
            {
                foreach (var lin in lines)
                {
                    if (lin.X >= _gBitmap.Width)
                        continue;
                    if (lin.Y >= _gBitmap.Height)
                        continue;

                    if (StaticMethods.ColorSimilar(customColor, _gBitmap.GetPixel(lin.X, lin.Y), _sens))
                    {
                        hits++;
                        _gBitmap.SetPixel(lin.X, lin.Y, Color.White);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            pictureBox1.Image = _gBitmap;
            pictureBox1.Invalidate();

            if(hits != 0)
            labelHitsCount.Text = @"Hits: " + hits;
        }

        public static List<Point> SplitLine(
            Tuple<double, double> a, Tuple<double, double> b, int count)
        {
            count = count + 1;

            var d = Math.Sqrt((a.Item1 - b.Item1) * (a.Item1 - b.Item1) + (a.Item2 - b.Item2) * (a.Item2 - b.Item2)) / count;
            var fi = Math.Atan2(b.Item2 - a.Item2, b.Item1 - a.Item1);

            var points = new List<Point>(count + 1);

            for (var i = 0; i <= count; ++i)
                points.Add(new Point((int) (a.Item1 + i * d * Math.Cos(fi)), (int) (a.Item2 + i * d * Math.Sin(fi))));

            return points;
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            int linesCount;
            if(int.TryParse(textBoxLinesCount.Text, out linesCount))
                _linesCount = linesCount;
            InitializeImage();
            pictureBox1.Invalidate();
        }

        private void pictureColorBox_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            var colorDiag = colorDialog1;
            FillColorPickRegion(colorDiag);
            pictureBox1.Invalidate();
        }

        private void FillColorPickRegion(ColorDialog colorDiag)
        {
            var flag = new Bitmap(30, 30);
            var flagGraphics = Graphics.FromImage(flag);
            var iterator = 0;
            while (iterator <= 30)
            {
                var myBrush = new SolidBrush(colorDialog1.Color);
                flagGraphics.FillRectangle(myBrush, 0, iterator, 30, 30);
                iterator++;
            }
            pictureColorBox.Image = flag;
            if (colorDiag != null)
                pictureColorBox.BackColor = colorDiag.Color;
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            LoadImage();
            InitializeImage();
            pictureBox1.Invalidate();
        }

        private void trackBarSens_ValueChanged(object sender, EventArgs e)
        {
         //   hits = 0;
            labelSens.Text = trackBarSens.Value.ToString();
            _sens = (byte)trackBarSens.Value;
            InitializeImage();
            pictureBox1.Invalidate();
        }
    }
}