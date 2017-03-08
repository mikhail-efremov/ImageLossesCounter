using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MeshCollision
{
  public partial class Form1 : Form
  {
    public static Bitmap Bitmap;
    private List<MeshCollideObject> meshCollideObjects = new List<MeshCollideObject>();

    public Form1()
    {
      InitializeComponent();
      LoadImage();

      panel1.AutoScroll = false;
      panel1.HorizontalScroll.Enabled = false;
      panel1.HorizontalScroll.Visible = false;
      panel1.HorizontalScroll.Maximum = 0;
      panel1.AutoScroll = true;
    }

    private void LoadImage()
    {
      Image image = UploadImage();
			
			if (image == null)
        return;

      pictureBox1.Image = image;
      Bitmap = new Bitmap(image);
    }

    private void InvalidateImage()
    {
      if (Bitmap == null)
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
      var graphics = e.Graphics;

      foreach (var meshCollideObject in meshCollideObjects) {
        var brush = new SolidBrush(meshCollideObject.MeshColor);

				var lines = meshCollideObject.GetRawMesh(Bitmap);
				var similarLines = meshCollideObject.GetSimilarMesh(lines, Bitmap, meshCollideObjects);

				var coincidence = CoincidenceAnalyth.GetCoincidence(similarLines);

				meshCollideObject.CoincidencesWithoutInterrupt = coincidence.Count;

				int average = 0;
				coincidence.ForEach(line => average = average + line.Points.Count);
				if (average != 0)
					average = average / coincidence.Count;
				meshCollideObject.AverageCoincidences = average;
				
				DrawLines(similarLines, graphics, brush);

				int hits = 0;
				similarLines.ForEach(line => hits = hits + line.Points.Count);

				meshCollideObject.Hits = hits;
			}

      pictureBox1.Image = Bitmap;
      InvalidateImage();
    }

    private void DrawLines(List<Line> lines, Graphics graphics, Brush brush)
    {
      foreach (var line in lines)
      {
        foreach (var point in line.Points)
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
		
		private static int _nextLocation = 0;
		private void button1_Click(object sender, EventArgs e) {
			var meshObj = new MeshCollideObject();
			meshCollideObjects.Add(meshObj);

			var controlls = meshObj.GetControlls();
			foreach (CustomControl control in controlls)
			{
			  if (!string.IsNullOrEmpty(control.Description))
			  {
			    var label = new Label
			    {
			      Text = control.Description,
			      Location = new Point(12, _nextLocation)
			    };
			    control.Control.Location = new Point(label.Size.Width + 10, _nextLocation);

			    panel1.Controls.Add(label);
			    panel1.Controls.Add(control.Control);
			  }
			  else
			  {
          control.Control.Location = new Point(10, _nextLocation);
          panel1.Controls.Add(control.Control);
        }

			  _nextLocation += 24;
			}
      
      _nextLocation += 24;
		}
	}
}