﻿using System;
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
            Graphics graphics = e.Graphics;
            Brush brush = Brushes.Red;
        
			List<Line> lines = GetRawMesh();
			List<Line> similarLines = GetSimilarMesh(lines);

			List<Line> coincidence = CoincidenceAnalyth.GetCoincidence(similarLines);
			coincidenceLabel.Text = "coincidence: " + coincidence.Count;

			int average = 0;
			coincidence.ForEach(line => average = average + line.Points.Count);
			if(average != 0)
				average = average / coincidence.Count;
			averageLabel.Text = "average coincidence: " + average;

			if (checkBoxDrawMesh.Checked) {
				DrawLines(lines, e.Graphics, brush);
			}

			DrawLines(similarLines, e.Graphics, brush);

            pictureBox1.Image = bitmap;
            InvalidateImage();

			int hits = 0;
			similarLines.ForEach(line => hits = hits + line.Points.Count);

			labelHitsCount.Text = @"Hits: " + hits;
        }

		private List<Line> GetRawMesh() 
		{
			float weightIndent = 0;
			float heightIndent = 0;

			if (linesCount >= bitmap.Width) {
				linesCount = bitmap.Width;
			}
			weightIndent = bitmap.Width / (float)linesCount;

			if (linesCount >= bitmap.Height) {
				linesCount = bitmap.Height;
			}
			heightIndent = bitmap.Height / (float)linesCount;

			List<Line> lines = new List<Line>();

			//horizontal
			for (int index = 0; index < linesCount; index++) {
				Point xpt = new Point(0, (int)Math.Round(index * heightIndent));
				Point ypt = new Point(bitmap.Width, (int)Math.Round(heightIndent * index));

				Line line = new Line(xpt, ypt, bitmap.Width);
				lines.Add(line);
			}

			//vertical
			for (var index = 0; index < linesCount; index++) {
				Point xpt = new Point((int)Math.Round(index * weightIndent), 0);
				Point ypt = new Point((int)Math.Round(index * weightIndent), bitmap.Height);

				Line line = new Line(xpt, ypt, bitmap.Height);
				lines.Add(line);
			}

			return lines;
		}

		private List<Line> GetSimilarMesh(List<Line> lines) 
		{
			Color customColor = pictureColorBox.BackColor;

			List<Line> result = new List<Line>();

			foreach (Line line in lines) {
				Line searchLine = new Line();

				foreach (Point point in line.Points) {
					if (StaticMethods.ColorSimilar(customColor, bitmap.GetPixel(point.X, point.Y), trackBarSecivity)) {
						if (!result.Contains(searchLine)) {
							result.Add(searchLine);
						}
						result[result.IndexOf(searchLine)].Points.Add(point);
					}
				}
			}

			return result;
		}

        private void DrawLines(List<Line> lines, Graphics graphics, Brush brush)
        {
            foreach (Line line in lines)
            {
                foreach (Point point in line.Points)
                {
                    graphics.FillRectangle(brush, point.X, point.Y, 1, 1);
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