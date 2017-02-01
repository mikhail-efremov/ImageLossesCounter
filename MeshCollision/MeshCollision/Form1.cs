using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MeshCollision
{
    public partial class Form1 : Form
    {
        private Bitmap bitmap;

		private List<MeshCollideObject> meshCollideObjects = new List<MeshCollideObject>();

        public Form1()
        {
            InitializeComponent();
            LoadImage();
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

			foreach (var meshCollideObject in meshCollideObjects) {
				var brush = new SolidBrush(meshCollideObject.MeshColor);

				List<Line> lines = meshCollideObject.GetRawMesh(bitmap);
				List<Line> similarLines = meshCollideObject.GetSimilarMesh(lines, bitmap, meshCollideObjects);

				List<Line> coincidence = CoincidenceAnalyth.GetCoincidence(similarLines);

				meshCollideObject.CoincidencesWithoutInterrupt = coincidence.Count;

				int average = 0;
				coincidence.ForEach(line => average = average + line.Points.Count);
				if (average != 0)
					average = average / coincidence.Count;
				meshCollideObject.AverageCoincidences = average;
				
				DrawLines(similarLines, e.Graphics, brush);

				int hits = 0;
				similarLines.ForEach(line => hits = hits + line.Points.Count);

				meshCollideObject.Hits = hits;
			}
			
            pictureBox1.Image = bitmap;
            InvalidateImage();
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

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            LoadImage();
            InvalidateImage();
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
        }
		
		private static int _nextLocation = 0;
		private void button1_Click(object sender, EventArgs e) {
			var meshObj = new MeshCollideObject();
			meshCollideObjects.Add(meshObj);

			var controlls = meshObj.GetControlls();
			for (int i = 0; i < controlls.Length; i++) {
				var label = new Label();
				label.Text = controlls[i].Description;
				label.Location = new Point(12, _nextLocation);
				controlls[i].Control.Location = new Point(label.Size.Width + 10, _nextLocation);

				panel1.Controls.Add(label);
				panel1.Controls.Add(controlls[i].Control);
				_nextLocation += 24;
			}
			_nextLocation += 24;
		}
	}
}