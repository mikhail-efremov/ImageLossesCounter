using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MeshCollision
{
    public partial class Form1 : Form
    {
        private Bitmap bitmap;
        private int linesCount = 1;
        private byte trackBarSecivity = 1;

        public Form1()
        {
            InitializeComponent();
            LoadImage();
            FillColorPickRegion(Color.Black);
        }

        private void LoadImage()
        {
            Image image = UploadImage();

            if (image == null)
                return;

            pictureBox1.Image = image;
            bitmap = new Bitmap(image);
        }

        private void InvalidateImage()
        {
            if (bitmap == null)
                return;

            int count;
            if (int.TryParse(textBoxLinesCount.Text, out count))
            {
                linesCount = count;
            }
            
            pictureBox1.Invalidate();
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
            float weightIndent = 0;
            float heightIndent = 0;

            if (linesCount >= bitmap.Width)
            {
                linesCount = bitmap.Width;
            }
            weightIndent = bitmap.Width / (float)linesCount;

            if (linesCount >= bitmap.Height)
            {
                linesCount = bitmap.Height;
            }
            heightIndent = bitmap.Height / (float)linesCount;

            List<Line> lines = new List<Line>();
            Graphics graphics = e.Graphics;
            Brush brush = Brushes.Red;

//horizontal
            for (int index = 0; index < linesCount; index++)
            {
                Point xpt = new Point(0, (int)Math.Round(index * heightIndent));
                Point ypt = new Point(bitmap.Width, (int)Math.Round(heightIndent * index));
                
                Line line = new Line(xpt, ypt, bitmap.Width);
                lines.Add(line);
            }

//vertical
            for (var index = 0; index < linesCount; index++)
            {
                Point xpt = new Point((int)Math.Round(index* weightIndent), 0);
                Point ypt = new Point((int)Math.Round(index* weightIndent), bitmap.Height);

                Line line = new Line(xpt, ypt, bitmap.Height);
                lines.Add(line);
            }
          
            Color customColor = pictureColorBox.BackColor;
            int hits = 0;

            foreach (Line line in lines)
            {
                foreach (Point point in line.Points)
                {
                    if (StaticMethods.ColorSimilar(customColor, bitmap.GetPixel(point.X, point.Y), trackBarSecivity))
                    {
                        hits++;
                        e.Graphics.FillRectangle(Brushes.Red, point.X, point.Y, 1, 1);
                    }
                }
            }

            DrawLines(lines, e.Graphics, brush);

            pictureBox1.Image = bitmap;
            InvalidateImage();

            labelHitsCount.Text = @"Hits: " + hits;
        }

        private void DrawLines(List<Line> lines, Graphics graphics, Brush brush)
        {
            if (checkBoxDrawMesh.Checked)
            {
                foreach (Line line in lines)
                {
                    foreach (Point point in line.Points)
                    {
                        graphics.FillRectangle(brush, point.X, point.Y, 1, 1);
                    }
                }
            }
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            InvalidateImage();
        }

        private void FillColorPickRegion(Color color)
        {
            pictureColorBox.BackColor = color;
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            LoadImage();
            InvalidateImage();
        }

        private void trackBarSens_ValueChanged(object sender, EventArgs e)
        {
            labelSens.Text = trackBarSens.Value.ToString();
            trackBarSecivity = (byte)trackBarSens.Value;
            InvalidateImage();
        }

        private void pictureColorBox_Click(object sender, EventArgs e)
        {
            this.Hide();
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                FillColorPickRegion(colorDialog1.Color);
                InvalidateImage();
            }
            this.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ImageClick(e);
        }

        private void ImageClick(EventArgs e)
        {
            if (pictureBox1.Image == null)
                return;
            
            MouseEventArgs mouseEvent = (MouseEventArgs)e;
            Point coordinates = mouseEvent.Location;
            
            FillColorPickRegion(new Bitmap(pictureBox1.Image).GetPixel(coordinates.X, coordinates.Y));
        }
    }
}